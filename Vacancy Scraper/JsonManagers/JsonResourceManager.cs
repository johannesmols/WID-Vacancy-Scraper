using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.JsonManagers
{
    public enum ResourceType { Companies, Vacancies, Blacklist, Done }

    public class JsonResourceManager<T>
    {
        public List<T> Resources { get; private set; }

        private readonly SettingsManager _settings = new SettingsManager();
        private readonly string _filepath;

        private bool _showedPathWarning = false; // to prevent having an infinite amount of message boxes from popping up when not having a path

        public JsonResourceManager(ResourceType type)
        {
            Resources = new List<T>();
            switch (type)
            {
                case ResourceType.Companies:
                    _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "companies.json");
                    break;
                case ResourceType.Vacancies:
                    _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "vacancies.json");
                    break;
                case ResourceType.Blacklist:
                    _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "blacklist.json");
                    break;
                case ResourceType.Done:
                    _filepath = Path.Combine(_settings.Settings.ResourceFolderPath, "done.json");
                    break;
            }
            ReadResources();
        }

        /// <summary>
        /// Write the changes in the local copy of the file to the actual file
        /// </summary>
        public void SaveChangesToFile()
        {
            WriteResources(Resources);
        }

        /// <summary>
        /// Read the JSON file and read the objects into a list
        /// </summary>
        private void ReadResources()
        {
            // Determine if the user has set a path to the file
            if (!string.IsNullOrWhiteSpace(_settings.Settings.ResourceFolderPath) && Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                if (!File.Exists(_filepath))
                {
                    MessageBox.Show(
                        @"The file """ + Path.GetFileName(_filepath) + @""" doesn't exist. Please create it by going to the settings.",
                        @"File doesn't exist",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    // Read the JSON file into the list. If there is an error, the user will be notified that there is an error in the file
                    try
                    {
                        // The list will be set to NULL, if the read file is empty. Initialize new empty list in that case to avoid null pointer exceptions
                        Resources = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(_filepath)) ?? new List<T>();
                    }
                    catch
                    {
                        DialogResult dialogResult = MessageBox.Show(
                            @"There seems to be an error in the file """ + Path.GetFileName(_filepath) + @""". Would you like to reset it? This will cause you to lose all data in that specific file.",
                            @"Error in file",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (dialogResult == DialogResult.Yes)
                        {
                            WriteResources(new List<T>());
                            ReadResources();
                        }
                    }
                }
            }
            else
            {
                if (_showedPathWarning)
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
        /// Write a list to the JSON file
        /// </summary>
        /// <param name="resources"></param>
        private void WriteResources(IReadOnlyCollection<T> resources)
        {
            if (Directory.Exists(_settings.Settings.ResourceFolderPath))
            {
                File.WriteAllText(_filepath, JsonConvert.SerializeObject(resources, Formatting.Indented));
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
