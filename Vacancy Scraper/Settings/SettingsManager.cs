using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Vacancy_Scraper.Settings
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

        /// <summary>
        /// Read the settings from the JSON file into the local copy as an object
        /// If the file does not exist, a new one will be created
        /// </summary>
        private void ReadSettings()
        {
            if (!File.Exists(GetSettingsFilePath()))
            {
                WriteSettings(new SettingsObject("", "", GetDefaultLogsDirectory()));
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
        private string GetSettingsFilePath()
        {
            return Path.Combine(GetSettingsDirectory(), "settings.json");
        }

        /// <summary>
        /// Get the directory path of the settings file, which is located in the local user's documents folder
        /// </summary>
        /// <returns>the file path as a string</returns>
        private string GetSettingsDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vacancy Scraper");
        }

        /// <summary>
        /// Get the default directory of the logs folder
        /// </summary>
        /// <returns></returns>
        private string GetDefaultLogsDirectory()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vacancy Scraper", "logs");
        }

        /// <summary>
        /// Verifies if the settings that were read from the file are valid and contain every property
        /// </summary>
        private void VerifySettings()
        {
            if (Settings == null)
            {
                WriteSettings(new SettingsObject("", "", GetDefaultLogsDirectory()));
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
            if (!String.IsNullOrEmpty(webDriversPath))
            {
                Settings.WebDriversPath = webDriversPath;
                WriteSettings(Settings);
            }
        }

        /// <summary>
        /// Set the resource folder path setting and write it to the settings file
        /// </summary>
        /// <param name="webDriversPath">the path</param>
        public void SetResourceFolderPath(string resourceFolderPath)
        {
            if (!String.IsNullOrEmpty(resourceFolderPath))
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
            if (!String.IsNullOrEmpty(logsFolderPath))
            {
                Settings.LogsFolderPath = logsFolderPath;
                WriteSettings(Settings);
            }
        }
    }
}
