using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
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
        // If modifying these scopes, delete the folder
        // at ~/token.json
        private static readonly string[] Scopes = { DriveService.Scope.Drive };
        private const string ApplicationName = "Vacancy Scraper";

        private UserCredential _credential;
        private DriveService _service;

        private SettingsManager _settingsManager = new SettingsManager();

        // Initialize authentication with the Google Drive API
        public GoogleDriveManager()
        {
            _credential = Authenticate();
            _service = CreateDriveAPIService(_credential);
        }

        // Authenticate with Google Drive
        private UserCredential Authenticate()
        {
            UserCredential credential;

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

            return credential;
        }

        // Create the Google Drive API Service
        private DriveService CreateDriveAPIService(UserCredential credential)
        {
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
            return service;
        }

        // Get all JSON files that are relevant for the application from the Google Drive
        public IList<Google.Apis.Drive.v3.Data.File> GetFilesWithMatchingFileNames()
        {
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
        /// Checks Google Drive, if a certain file exists
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool DoesFileExistInDrive(ResourceType type)
        {
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

            try
            {
                var file = fileListRequest?.Execute(); // null propagation
                return file != null; // return true if the file is not null, therefore exists in the Drive
            }
            catch (Exception e) // the Google Drive API throws an error if the file can't be found. Catch this here and return false.
            {
                Console.WriteLine(e);
                Console.WriteLine(@"File does not exist in Google Drive");
                return false;
            }
        }

        /// <summary>
        /// Upload or update a file to Google Drive
        /// </summary>
        /// <param name="file">the path to the file</param>
        /// <param name="type">the type of the file</param>
        /// <returns></returns>
        public File UploadFile(string file, ResourceType type)
        {
            var fileMetaData = new Google.Apis.Drive.v3.Data.File
            {
                Name = Path.GetFileName(file),
                MimeType = MimeTypeDictionary.GetMimeType(Path.GetExtension(file)),
                Description = @"Uploaded by the Vacancy Scraper application"
            };

            if (DoesFileExistInDrive(type)) // update the already existing file
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
                    request.Upload(); // TODO: make asynchronously

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
                    request.Upload(); // TODO: make asynchronously

                    Console.WriteLine(@"Uploaded " + fileMetaData.Name);
                }

                return request.ResponseBody;
            }
        }
    }
}
