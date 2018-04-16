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
        public List<Company> Companies = new List<Company>();

        private readonly SettingsManager _settings = new SettingsManager();
        private readonly string _filepath;

        public CompaniesManager()
        {
            _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "companies.json");
            ReadCompanies();
        }

        /// <summary>
        /// Read the companies JSON file and read the objects into a list of the type Company
        /// </summary>
        private void ReadCompanies()
        {
            // Determine if the user has set a path to the file
            if (!string.IsNullOrWhiteSpace(_settings.Settings.ResourceFolderPath) && Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                // Create an empty file if the file doesn't exist already
                if (!File.Exists(_filepath))
                {
                    using (StreamWriter sw = File.CreateText(_filepath))
                    {
                        sw.WriteLine(JsonConvert.SerializeObject(Companies, Formatting.Indented));
                    }
                }
                else
                {
                    // Read the JSON file into the company list. If there is an error, the user will be notified that there is an error in the file
                    try
                    {
                        Companies = JsonConvert.DeserializeObject<List<Company>>(File.ReadAllText(_filepath));
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
                MessageBox.Show(
                    @"Resource path is invalid. Please set the path in the settings.",
                    @"Resource path invalid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
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
                MessageBox.Show(
                    @"Resource path is invalid. Please set the path in the settings.",
                    @"Resource path invalid", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
            }
        }
    }
}
