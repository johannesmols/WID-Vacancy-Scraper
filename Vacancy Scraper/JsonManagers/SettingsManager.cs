using System;
using System.IO;
using Newtonsoft.Json;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.JsonManagers
{
    /// <summary>
    /// This class handles reading and writing to and from the settings file
    /// This file is located in the local usser's documents folder
    /// </summary>
    class SettingsManager
    {
        /// <summary>
        /// A public settings object that is readable by every instance, but can't be modified
        /// This is the preferred way of reading the settings
        /// </summary>
        public SettingsObject Settings { get; private set; }

        /// <summary>
        /// The constructor reads the settings into the local copy as an object
        /// </summary>
        public SettingsManager()
        {
            ReadSettings();
        }

        private readonly SettingsObject _defaultSettings = new SettingsObject("", "", GetDefaultLogsDirectory(), "", "Standard Browser", "", "", true, true, 3, "Months", DateTime.MinValue, DateTime.MinValue, "", "", "", "");

        /// <summary>
        /// Read the settings from the JSON file into the local copy as an object
        /// If the file does not exist, a new one will be created
        /// </summary>
        private void ReadSettings()
        {
            if (!File.Exists(GetSettingsFilePath()))
            {
                WriteSettings(_defaultSettings);
            }

            string fileContent = File.ReadAllText(GetSettingsFilePath());
            try
            {
                Settings = JsonConvert.DeserializeObject<SettingsObject>(fileContent);
            }
            catch {
                // In case the read file is invalid JSON. The VerifySettings method will reset the file to the default state in this case.
            }

            VerifySettings();
        }

        /// <summary>
        /// Write new settings to the JSON file
        /// </summary>
        /// <param name="settings"></param>
        private void WriteSettings(SettingsObject settings)
        {
            string path = GetSettingsDirectory();
            string logsPath = GetDefaultLogsDirectory();
            Directory.CreateDirectory(path); // Create directories and subdirectories if they don't already exist
            Directory.CreateDirectory(logsPath);
            File.WriteAllText(GetSettingsFilePath(), JsonConvert.SerializeObject(settings, Formatting.Indented));
        }

        /// <summary>
        /// Get the file path of the settings file, which is located in the local user's documents folder
        /// </summary>
        /// <returns>the file path as a string</returns>
        private static string GetSettingsFilePath()
        {
            return Path.Combine(GetSettingsDirectory(), "settings.json");
        }

        /// <summary>
        /// Get the directory path of the settings file, which is located in the local user's documents folder
        /// </summary>
        /// <returns>the file path as a string</returns>
        private static string GetSettingsDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vacancy Scraper");
        }

        /// <summary>
        /// Get the default directory of the logs folder
        /// </summary>
        /// <returns></returns>
        private static string GetDefaultLogsDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vacancy Scraper", "logs");
        }

        /// <summary>
        /// Verifies if the settings that were read from the file are valid and contain every property
        /// Do not verify last drive synch date since that is hidden from the user and only changeable by the program itself
        /// </summary>
        private void VerifySettings()
        {
            if (Settings == null)
            {
                WriteSettings(_defaultSettings);
            }
            else
            {
                bool changed = false;
                SettingsObject fixedSettings = Settings;

                if (fixedSettings.WebDriversPath == null)
                {
                    fixedSettings.WebDriversPath = "";
                    changed = true;
                }

                if (fixedSettings.ResourceFolderPath == null)
                {
                    fixedSettings.ResourceFolderPath = "";
                    changed = true;
                }

                if (fixedSettings.LogsFolderPath == null)
                {
                    fixedSettings.LogsFolderPath = GetDefaultLogsDirectory();
                    changed = true;
                }

                if (fixedSettings.Browser == null)
                {
                    fixedSettings.Browser = "Standard Browser";
                    changed = true;
                }

                if (fixedSettings.ExportFolderPath == null)
                {
                    fixedSettings.ExportFolderPath = "";
                    changed = true;
                }

                if (fixedSettings.ScraperWebDriver == null)
                {
                    fixedSettings.ScraperWebDriver = "";
                    changed = true;
                }

                if (fixedSettings.ScraperBannedKeywords == null)
                {
                    fixedSettings.ScraperBannedKeywords = "";
                    changed = true;
                }

                if (fixedSettings.ScraperIgnoreDuplicatesTimeMode == null)
                {
                    fixedSettings.ScraperIgnoreDuplicatesTimeMode = "Months";
                    changed = true;
                }

                if (changed)
                {
                    WriteSettings(fixedSettings);
                }
            }
        }

        /* --- SETTERS OF SETTINGS --- */

        /// <summary>
        /// Set the web drivers path setting and write it to the settings file
        /// </summary>
        /// <param name="webDriversPath">the path</param>
        public void SetWebDriversPath(string webDriversPath)
        {
            if (!string.IsNullOrWhiteSpace(webDriversPath))
            {
                Settings.WebDriversPath = webDriversPath;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Set the resource folder path setting and write it to the settings file
        /// </summary>
        /// <param name="resourceFolderPath">the path</param>
        public void SetResourceFolderPath(string resourceFolderPath)
        {
            if (!string.IsNullOrWhiteSpace(resourceFolderPath))
            {
                Settings.ResourceFolderPath = resourceFolderPath;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Set the logs folder path setting and write it to the settings file
        /// </summary>
        /// <param name="logsFolderPath">the path</param>
        public void SetLogsFolderPath(string logsFolderPath)
        {
            if (!string.IsNullOrWhiteSpace(logsFolderPath))
            {
                Settings.LogsFolderPath = logsFolderPath;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Set the export folder path setting and write it to the settings file
        /// </summary>
        /// <param name="exportFolderPath"></param>
        public void SetExportFolderPath(string exportFolderPath)
        {
            if (!string.IsNullOrWhiteSpace(exportFolderPath))
            {
                Settings.ExportFolderPath = exportFolderPath;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Set the browser setting and write it to the settings file
        /// </summary>
        /// <param name="browser"></param>
        public void SetBrowser(string browser)
        {
            if (!string.IsNullOrWhiteSpace(browser))
            {
                Settings.Browser = browser;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Set the web driver that should be used and write it to the settings file
        /// </summary>
        /// <param name="webDriver"></param>
        public void SetScraperWebDriver(string webDriver)
        {
            if (!string.IsNullOrWhiteSpace(webDriver))
            {
                Settings.ScraperWebDriver = webDriver;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Write the banned keywords to the settings file
        /// </summary>
        /// <param name="bannedKeywords"></param>
        public void SetScraperBannedKeywords(string bannedKeywords)
        {
            Settings.ScraperBannedKeywords = bannedKeywords;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write to the settings file if the scraper should check jobnet for duplicates
        /// </summary>
        /// <param name="checkJobnet"></param>
        public void SetScraperCheckJobnet(bool checkJobnet)
        {
            Settings.ScraperCheckJobnet = checkJobnet;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write to the settings file if the scraper should ignore duplicate posts that are older than a certain age
        /// </summary>
        /// <param name="scraperIgnoreDuplicatesOlderThan"></param>
        public void SetScraperIgnoreDuplicatesOlderThan(bool scraperIgnoreDuplicatesOlderThan)
        {
            Settings.ScraperIgnoreDuplicatesOlderThan = scraperIgnoreDuplicatesOlderThan;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the value of the age where duplicates should be ignored to the settings file
        /// </summary>
        /// <param name="scraperIgnoreDuplicatesValue"></param>
        public void SetScraperIgnoreDuplicatesValue(long scraperIgnoreDuplicatesValue)
        {
            Settings.ScraperIgnoreDuplicatesValue = scraperIgnoreDuplicatesValue;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write to the settings file what time mode should be used for ignoring old duplicates (days, weeks, months, years)
        /// </summary>
        /// <param name="scraperIgnoreDuplicatesTimeMode"></param>
        public void SetScraperIgnoreDuplicatesTimeMode(string scraperIgnoreDuplicatesTimeMode)
        {
            Settings.ScraperIgnoreDuplicatesTimeMode = scraperIgnoreDuplicatesTimeMode;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the last upload with Google Drive to the settings file
        /// </summary>
        /// <param name="lastDriveUpload"></param>
        public void SetLastDriveUpload(DateTime lastDriveUpload)
        {
            Settings.LastDriveUpload = lastDriveUpload;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the last download with Google Drive to the settings file
        /// </summary>
        /// <param name="lastDriveDownload"></param>
        public void SetLastDriveDownload(DateTime lastDriveDownload)
        {
            Settings.LastDriveDownload = lastDriveDownload;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the file ID of the vacancies file in the Google Drive to the settings file
        /// </summary>
        /// <param name="id"></param>
        public void SetGoogleDriveVacanciesFileId(string id)
        {
            Settings.GoogleDriveVacanciesFileId = id;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the file ID of the blacklist file in the Google Drive to the settings file
        /// </summary>
        /// <param name="id"></param>
        public void SetGoogleDriveBlacklistFileId(string id)
        {
            Settings.GoogleDriveBlacklistFileId = id;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the file ID of the done file in the Google Drive to the settings file
        /// </summary>
        /// <param name="id"></param>
        public void SetGoogleDriveDoneFileId(string id)
        {
            Settings.GoogleDriveDoneFileId = id;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Write the file ID of the companies file in the Google Drive to the settings file
        /// </summary>
        /// <param name="id"></param>
        public void SetGoogleDriveCompaniesFileId(string id)
        {
            Settings.GoogleDriveCompaniesFileId = id;
            WriteSettings(Settings);
        }

        /// <summary>
        /// Check if the driver executable exists for the currently selected driver
        /// </summary>
        /// <returns></returns>
        public bool CheckIfCurrentDriversExist()
        {
            switch (Settings.ScraperWebDriver)
            {
                case "Chrome":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "chromedriver.exe"));
                case "Headless Chrome":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "chromedriver.exe"));
                case "Firefox":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "geckodriver.exe"));
                case "Internet Explorer":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "IEDriverServer.exe"));
                case "Edge":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "MicrosoftWebDriver.exe"));
                case "PhantomJS":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "phantomjs.exe"));
                case "Opera":
                    return File.Exists(Path.Combine(Settings.WebDriversPath, "operadriver.exe"));
                default:
                    return false;
            }
        }
    }
}
