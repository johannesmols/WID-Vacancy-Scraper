using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.UserControls;
using File = Google.Apis.Drive.v3.Data.File;

namespace Vacancy_Scraper.Tools
{
    class GoogleDriveManager
    {
        private bool _initialized = false;

        // If modifying these scopes, delete the folder
        // at ~/token.json
        private static readonly string[] Scopes = { DriveService.Scope.Drive };
        private const string ApplicationName = "Vacancy Scraper";

        private UserCredential _credential;
        private DriveService _service;

        private SettingsManager _settingsManager = new SettingsManager();

        // Initialize credentials and Google Drive service
        private async Task Initialize()
        {
            if (!_initialized)
            {
                _credential = await Authenticate();
                _service = await CreateDriveAPIService(_credential);
                _initialized = true;
            }
        }

        // Authenticate with Google Drive
        private async Task<UserCredential> Authenticate()
        {
            UserCredential credential = null;
            await Task.Run(() =>
            {
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    const string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine(@"Credential file saved to: " + credPath);
                }
            });

            return credential;
        }

        // Create the Google Drive API Service
        private async Task<DriveService> CreateDriveAPIService(UserCredential credential)
        {
            DriveService service = null;
            await Task.Run(() =>
            {
                service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName
                });
            });
            
            return service;
        }

        /// <summary>
        /// Checks Google Drive, if a certain file exists
        /// If it doesn't exist, the method will try to find a matching file and update the file ID accordingly
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<bool> DoesFileExistInDriveAndFindFilesIfNot(ResourceType type)
        {
            await Initialize(); // Initialize Google Drive Service

            FilesResource.GetRequest fileListRequest;

            switch (type)
            {
                case ResourceType.Vacancies:
                    fileListRequest = _service.Files.Get(_settingsManager.Settings.GoogleDriveVacanciesFileId);
                    break;
                case ResourceType.Blacklist:
                    fileListRequest = _service.Files.Get(_settingsManager.Settings.GoogleDriveBlacklistFileId);
                    break;
                case ResourceType.Done:
                    fileListRequest = _service.Files.Get(_settingsManager.Settings.GoogleDriveDoneFileId);
                    break;
                case ResourceType.Companies:
                    fileListRequest = _service.Files.Get(_settingsManager.Settings.GoogleDriveCompaniesFileId);
                    break;
                default:
                    fileListRequest = null;
                    break;
            }

            bool fileFound = false;

            try
            {
                var file = fileListRequest?.Execute(); // null propagation
                fileFound = file != null;
            }
            catch (Exception e) // the Google Drive API throws an error if the file can't be found. Catch this here and return false.
            {
                Console.WriteLine(e);
                Console.WriteLine(@"File does not exist in Google Drive");
                fileFound = false;
            }

            // If the file was found, then return true here
            if (fileFound) return true;

            return await FindFilesAndUpdateId(type);
        }

        /// <summary>
        /// Find matching files in the Drive and update the file ID locally
        /// </summary>
        /// <param name="type">the file type to search for</param>
        /// <returns></returns>
        private async Task<bool> FindFilesAndUpdateId(ResourceType type)
        {
            var otherFiles = await GetFilesWithMatchingFileNames();

            // check for matching file and update the file ID accordingly
            switch (type)
            {
                case ResourceType.Vacancies:
                    foreach (var file in otherFiles)
                    {
                        if (!file.Name.Equals("vacancies.json")) continue;
                        _settingsManager.SetGoogleDriveVacanciesFileId(file.Id);
                        Console.WriteLine(@"Found existing file in Drive, updated File ID.");
                        return true;
                    }
                    break;
                case ResourceType.Blacklist:
                    foreach (var file in otherFiles)
                    {
                        if (!file.Name.Equals("blacklist.json")) continue;
                        _settingsManager.SetGoogleDriveBlacklistFileId(file.Id);
                        Console.WriteLine(@"Found existing file in Drive, updated File ID.");
                        return true;
                    }
                    break;
                case ResourceType.Done:
                    foreach (var file in otherFiles)
                    {
                        if (!file.Name.Equals("done.json")) continue;
                        _settingsManager.SetGoogleDriveDoneFileId(file.Id);
                        Console.WriteLine(@"Found existing file in Drive, updated File ID.");
                        return true;
                    }
                    break;
                case ResourceType.Companies:
                    foreach (var file in otherFiles)
                    {
                        if (!file.Name.Equals("companies.json")) continue;
                        _settingsManager.SetGoogleDriveCompaniesFileId(file.Id);
                        Console.WriteLine(@"Found existing file in Drive, updated File ID.");
                        return true;
                    }
                    break;
                default:
                    return false;
            }

            return false;
        }

        // Get all JSON files that are relevant for the application from the Google Drive
        private async Task<IList<File>> GetFilesWithMatchingFileNames()
        {
            await Initialize(); // Initialize Google Drive Service

            // define parameters of request
            var fileListRequest = _service.Files.List();
            fileListRequest.PageSize = 1000;
            fileListRequest.OrderBy = "modifiedTime desc";
            fileListRequest.Q = "mimeType = 'application/json'";
            fileListRequest.Fields = "nextPageToken, files(id, name, size, version, createdTime)";

            // execute request
            var files = fileListRequest.Execute().Files;
            var foundFiles = new List<File>();
            if (files != null && files.Count > 0)
            {
                foundFiles.AddRange(files.Where(file => file.Name.Equals("vacancies.json") ||
                                                        file.Name.Equals("blacklist.json") ||
                                                        file.Name.Equals("done.json") ||
                                                        file.Name.Equals("companies.json")));
            }

            return foundFiles;
        }

        /// <summary>
        /// Upload or update a file to Google Drive
        /// </summary>
        /// <param name="file">the path to the file</param>
        /// <param name="type">the type of the file</param>
        /// <returns></returns>
        public async Task<File> UploadFile(string file, ResourceType type)
        {
            await Initialize(); // Initialize Google Drive Service

            var fileMetaData = new File
            {
                Name = Path.GetFileName(file),
                MimeType = MimeTypeDictionary.GetMimeType(Path.GetExtension(file)),
                Description = @"Uploaded by the Vacancy Scraper application"
            };

            if (await DoesFileExistInDriveAndFindFilesIfNot(type)) // update the already existing file
            {
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    FilesResource.UpdateMediaUpload request = null;
                    switch (type)
                    {
                        case ResourceType.Vacancies:
                            request = _service.Files.Update(fileMetaData, _settingsManager.Settings.GoogleDriveVacanciesFileId, stream, fileMetaData.MimeType);
                            break;
                        case ResourceType.Blacklist:
                            request = _service.Files.Update(fileMetaData, _settingsManager.Settings.GoogleDriveBlacklistFileId, stream, fileMetaData.MimeType);
                            break;
                        case ResourceType.Done:
                            request = _service.Files.Update(fileMetaData, _settingsManager.Settings.GoogleDriveDoneFileId, stream, fileMetaData.MimeType);
                            break;
                        case ResourceType.Companies:
                            request = _service.Files.Update(fileMetaData, _settingsManager.Settings.GoogleDriveCompaniesFileId, stream, fileMetaData.MimeType);
                            break;
                        default:
                            break;
                    }

                    if (request == null) return null;

                    request.Fields = "id";
                    await request.UploadAsync();

                    Console.WriteLine(@"Updated " + fileMetaData.Name);

                    return request.ResponseBody;
                }
            }
            else // create new file
            {
                FilesResource.CreateMediaUpload request;
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    request = _service.Files.Create(fileMetaData, stream, fileMetaData.MimeType);
                    request.Fields = "id";
                    await request.UploadAsync();

                    Console.WriteLine(@"Uploaded " + fileMetaData.Name);
                }

                return request.ResponseBody;
            }
        }

        /// <summary>
        /// Download a file from Google Drive and overwrite any exisiting local files
        /// </summary>
        /// <param name="type">the file type</param>
        /// <returns></returns>
        public async Task DownloadAndReplaceFile(ResourceType type)
        {
            await Initialize(); // Initialize Google Drive Service

            var stream = new MemoryStream();

            // Generate download request
            if (await DoesFileExistInDriveAndFindFilesIfNot(type))
            {
                FilesResource.GetRequest request;
                switch (type)
                {
                    case ResourceType.Vacancies:
                        request = _service.Files.Get(_settingsManager.Settings.GoogleDriveVacanciesFileId);
                        break;
                    case ResourceType.Blacklist:
                        request = _service.Files.Get(_settingsManager.Settings.GoogleDriveBlacklistFileId);
                        break;
                    case ResourceType.Done:
                        request = _service.Files.Get(_settingsManager.Settings.GoogleDriveDoneFileId);
                        break;
                    case ResourceType.Companies:
                        request = _service.Files.Get(_settingsManager.Settings.GoogleDriveCompaniesFileId);
                        break;
                    default:
                        return;
                }

                // Progress listener
                request.MediaDownloader.ProgressChanged += progress =>
                {
                    switch (progress.Status)
                    {
                        case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                        case DownloadStatus.Completed:
                        {
                            Console.WriteLine(@"Download complete.");
                            break;
                        }
                        case DownloadStatus.Failed:
                        {
                            Console.WriteLine(@"Download failed.");
                            break;
                        }
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                };

                // Download
                request.Download(stream);

                // Save stream to file
                using (var fileStream = new FileStream(
                    Path.Combine(_settingsManager.Settings.ResourceFolderPath, type.ToString().ToLower() + ".json"),
                    FileMode.Create,
                    FileAccess.Write))
                {
                    stream.WriteTo(fileStream);
                }
            }
        }
    }
}
