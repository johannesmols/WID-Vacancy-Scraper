using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.JsonManagers
{
    class VacanciesManager
    {
        public List<VacancyObject> Vacancies { get; private set; }

        private readonly  SettingsManager _settings = new SettingsManager();
        private readonly string _filepath;

        private bool _showedPathWarning = false; // to prevent having an infinite amount of message boxes from popping up when not having a path

        /// <summary>
        /// Initialize the local copy of all vacancies and get the path of the file
        /// </summary>
        public VacanciesManager()
        {
            Vacancies = new List<VacancyObject>();
            _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "vacancies.json");
            ReadVacancies();
        }

        /// <summary>
        /// Write the changes in the local copy of vacancies to the file
        /// </summary>
        public void SaveChangesToFile()
        {
            WriteVacancies(Vacancies);
        }

        /// <summary>
        /// Read the vacancies JSON file and read the objects into a list of the type VacancyObject
        /// </summary>
        public void ReadVacancies()
        {
            // Determine if the user has set a path to the file
            if (!string.IsNullOrWhiteSpace(_settings.Settings.ResourceFolderPath) && Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                if (!File.Exists(_filepath))
                {
                    MessageBox.Show(
                        @"The vacancies file doesn't exist. Please create it by going to the settings.",
                        @"File doesn't exist",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    // Read the JSON file into the vacancy list. If there is an error, the user will be notified that there is an error in the file
                    try
                    {
                        // The list will be set to NULL, if the read file is empty. Initialize new empty list in that case to avoid null pointer exceptions
                        Vacancies = JsonConvert.DeserializeObject<List<VacancyObject>>(File.ReadAllText(_filepath)) ?? new List<VacancyObject>();
                    }
                    catch
                    {
                        DialogResult dialogResult = MessageBox.Show(
                            @"There seems to be an error in the vacancies file. Would you like to reset it? This will cause you to lose all data in that specific file.",
                            @"Error in file",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            WriteVacancies(new List<VacancyObject>());
                            ReadVacancies();
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
        /// Write a list of vacancies to a JSON file
        /// </summary>
        /// <param name="vacancies"></param>
        public void WriteVacancies(List<VacancyObject> vacancies)
        {
            if (Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                File.WriteAllText(_filepath, JsonConvert.SerializeObject(vacancies, Formatting.Indented));
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
