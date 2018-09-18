using System;

namespace Vacancy_Scraper.Objects
{
    /// <summary>
    /// Holds values that are read from the settings file or should be written to it
    /// </summary>
    class SettingsObject
    {
        public string WebDriversPath { get; set; }
        public string ResourceFolderPath { get; set; }
        public string LogsFolderPath { get; set; }
        public string ExportFolderPath { get; set; }
        public string Browser { get; set; }
        public string ScraperWebDriver { get; set; }
        public string ScraperBannedKeywords { get; set; }
        public bool ScraperCheckJobnet { get; set; }
        public DateTime LastDriveUpload { get; set; }
        public DateTime LastDriveDownload { get; set; }
        public string GoogleDriveVacanciesFileId { get; set; }
        public string GoogleDriveBlacklistFileId { get; set; }
        public string GoogleDriveDoneFileId { get; set; }
        public string GoogleDriveCompaniesFileId { get; set; }

        public SettingsObject(string webDriversPath, 
            string resourceFolderPath, 
            string logsFolderPath, 
            string exportFolderPath, 
            string browser,
            string scraperWebDriver, 
            string scraperBannedKeywords, 
            bool scraperCheckJobnet, 
            DateTime lastDriveUpload,
            DateTime lastDriveDownload,
            string googleDriveVacanciesFileId,
            string googleDriveBlacklistFileId,
            string googleDriveDoneFileId,
            string googleDriveCompaniesFileId)
        {
            WebDriversPath = webDriversPath;
            ResourceFolderPath = resourceFolderPath;
            LogsFolderPath = logsFolderPath;
            ExportFolderPath = exportFolderPath;
            Browser = browser;
            ScraperWebDriver = scraperWebDriver;
            ScraperBannedKeywords = scraperBannedKeywords;
            ScraperCheckJobnet = scraperCheckJobnet;
            LastDriveUpload = lastDriveUpload;
            LastDriveDownload = lastDriveDownload;
            GoogleDriveVacanciesFileId = googleDriveVacanciesFileId;
            GoogleDriveBlacklistFileId = googleDriveBlacklistFileId;
            GoogleDriveDoneFileId = googleDriveDoneFileId;
            GoogleDriveCompaniesFileId = googleDriveCompaniesFileId;
        }
    }
}