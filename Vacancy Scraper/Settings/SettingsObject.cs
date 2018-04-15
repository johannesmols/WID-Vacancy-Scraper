using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Settings
{
    /// <summary>
    /// Holds values that are read from the settings file or should be written to it
    /// </summary>
    class SettingsObject
    {
        public string WebDriversPath { get; set; }
        public string ResourceFolderPath { get; set; }

        public SettingsObject(string webDriversPath, string resourceFolderPath)
        {
            this.WebDriversPath = webDriversPath;
            this.ResourceFolderPath = resourceFolderPath;
        }
    }
}