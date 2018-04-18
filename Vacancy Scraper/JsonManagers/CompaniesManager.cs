using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vacancy_Scraper.Objects;
using Newtonsoft.Json;

namespace Vacancy_Scraper.JsonManagers
{
    class CompaniesManager
    {
        public List<Company> Companies { get; private set; }

        private readonly SettingsManager _settings = new SettingsManager();
        private readonly string _filepath;

        private bool _showedPathWarning = false; // to prevent having an infinite amount of message boxes from popping up when not having a path

        /// <summary>
        /// Initialize the local copy of all companies and get the path of the file
        /// </summary>
        public CompaniesManager()
        {
            Companies = new List<Company>();
            _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "companies.json");
            ReadCompanies();
        }

        /// <summary>
        /// Write the changes in the local copy of companies to the file
        /// </summary>
        public void SaveChangesToFile()
        {
            WriteCompanies(Companies);
        }

        /// <summary>
        /// Read the companies JSON file and read the objects into a list of the type Company
        /// </summary>
        private void ReadCompanies()
        {
            // Determine if the user has set a path to the file
            if (!string.IsNullOrWhiteSpace(_settings.Settings.ResourceFolderPath) && Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                if (!File.Exists(_filepath))
                {
                    MessageBox.Show(
                        @"The companies file doesn't exist. Please create it by going to the settings.",
                        @"File doesn't exist",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    // Read the JSON file into the company list. If there is an error, the user will be notified that there is an error in the file
                    try
                    {
                        // The list will be set to NULL, if the read file is empty. Initialize new empty list in that case to avoid null pointer exceptions
                        Companies = JsonConvert.DeserializeObject<List<Company>>(File.ReadAllText(_filepath)) ?? new List<Company>();
                    }
                    catch
                    {
                        DialogResult dialogResult = MessageBox.Show(
                            @"There seems to be an error in the companies file. Would you like to reset it? This will cause you to lose all data in that specific file.",
                            @"Error in file",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            WriteCompanies(new List<Company>());
                            ReadCompanies();
                        }
                    }
                }
            }
            else
            {
                if (!_showedPathWarning)
                {
                    MessageBox.Show(
                        @"Resource path is invalid. Please set the path in the settings.",
                        @"Resource path invalid",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    _showedPathWarning = true;
                }
            }
        }

        /// <summary>
        /// Write a list of companies to a JSON file
        /// </summary>
        /// <param name="companies"></param>
        private void WriteCompanies(List<Company> companies)
        {
            if (Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                File.WriteAllText(_filepath, JsonConvert.SerializeObject(companies, Formatting.Indented));
            }
            else
            {
                if (!_showedPathWarning)
                {
                    MessageBox.Show(
                        @"Resource path is invalid. Please set the path in the settings.",
                        @"Resource path invalid",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    _showedPathWarning = true;
                }
            }
        }
    }
}
