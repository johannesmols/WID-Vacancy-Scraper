using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Google.Apis.Drive.v3;
using Newtonsoft.Json;
using Vacancy_Scraper.Forms;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;
using Vacancy_Scraper.Tools;
using UserControl = System.Windows.Forms.UserControl;

namespace Vacancy_Scraper.UserControls
{
    public partial class UC_Export : UserControl
    {
        private static UC_Export _instance;

        private readonly SettingsManager _settingsManager = new SettingsManager();
        private JsonResourceManager<CompanyObject> _companyManager = new JsonResourceManager<CompanyObject>(ResourceType.Companies);
        private JsonResourceManager<VacancyObject> _vacancyManager = new JsonResourceManager<VacancyObject>(ResourceType.Vacancies);
        private JsonResourceManager<VacancyObject> _doneManager = new JsonResourceManager<VacancyObject>(ResourceType.Done);
        private JsonResourceManager<VacancyObject> _blacklistManager = new JsonResourceManager<VacancyObject>(ResourceType.Blacklist);

        public static UC_Export Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Export();
                return _instance;
            }
        }

        public UC_Export()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets called when the active tab in the tab control is changed
        /// This is to notify the user controls of the change and make adjustments based on the change
        /// </summary>
        public void NotifyTabChanged(MainForm.Tabs oldTab, MainForm.Tabs newTab)
        {
            if (newTab == MainForm.Tabs.Export)
            {
                ReloadContent();
            }
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {
            // Refresh company list
            _companyManager = new JsonResourceManager<CompanyObject>(ResourceType.Companies);
            _vacancyManager = new JsonResourceManager<VacancyObject>(ResourceType.Vacancies);
            _doneManager = new JsonResourceManager<VacancyObject>(ResourceType.Done);
            _blacklistManager = new JsonResourceManager<VacancyObject>(ResourceType.Blacklist);

            // Populate combo box of data source
            comboDataSource.Items.Clear();
            comboDataSource.Items.AddRange(new object[]{"Done", "Vacancies", "Blacklist"});
            comboDataSource.SelectedIndex = 0;

            // Set start date to start of week, end date to today
            datePickerStart.Value = StartOfWeek(DateTime.Today, DayOfWeek.Monday);
            datePickerEnd.Value = DateTime.Today;

            // Add items to the list of consultants
            checkedListConsultants.Items.Clear();
            foreach (var company in _companyManager.Resources)
            {
                if (!checkedListConsultants.Items.Contains(company.Consultants))
                {
                    checkedListConsultants.Items.Add(company.Consultants, true);
                }
            }

            // Add path from settings to text field
            txtExportDirectory.Text = _settingsManager.Settings.ExportFolderPath;

            // Display count of already existing items in the files in the import page
            lblImportVacancies.Text = @"Vacancies in queue: " + _vacancyManager.Resources.Count;
            lblImportBlacklist.Text = @"Vacancies in blacklist: " + _blacklistManager.Resources.Count;
            lblImportCompleted.Text = @"Vacancies completed: " + _doneManager.Resources.Count;
            lblImportCompanies.Text = @"Companies: " + _companyManager.Resources.Count;

            // Display last Google Drive Synchronization Date
            UpdateLastDriveUploadLabel();
            UpdateLastDriveDownloadLabel();

            // Add items in the file type checkbox list
            checkedListDownloadUploadFiles.Items.Clear();
            checkedListDownloadUploadFiles.Items.Add(ResourceType.Vacancies.ToString(), true);
            checkedListDownloadUploadFiles.Items.Add(ResourceType.Blacklist.ToString(), true);
            checkedListDownloadUploadFiles.Items.Add(ResourceType.Done.ToString(), true);
            checkedListDownloadUploadFiles.Items.Add(ResourceType.Companies.ToString(), true);
        }

        /// <summary>
        /// Get a DateTime of the start of the week
        /// </summary>
        /// <param name="dateTime">the week to search in</param>
        /// <param name="startOfWeek">the day in which the week starts</param>
        /// <returns>the first day of the given week</returns>
        public static DateTime StartOfWeek(DateTime dateTime, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Browse for a path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdBrowseDirectory_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtExportDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Check all options and export the file afterwards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdExport_Click(object sender, EventArgs e)
        {
            var optionsError = false;
            var errors = new List<string>();

            JsonResourceManager<VacancyObject> resourceManager;
            switch (comboDataSource.SelectedItem)
            {
                case "Done":
                    resourceManager = _doneManager;
                    break;
                case "Vacancies":
                    resourceManager = _vacancyManager;
                    break;
                case "Blacklist":
                    resourceManager = _blacklistManager;
                    break;
                default:
                    optionsError = true;
                    errors.Add("Invalid Data Source");
                    return;
            }

            if (datePickerStart.Value.CompareTo(datePickerEnd.Value) > 0)
            {
                optionsError = true;
                errors.Add("Dates are overlapping");
            }

            if (checkedListConsultants.CheckedItems.Count == 0)
            {
                optionsError = true;
                errors.Add("No consultant group selected");
            }

            if (!Directory.Exists(txtExportDirectory.Text))
            {
                optionsError = true;
                errors.Add("Invalid path");
            }

            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                optionsError = true;
                errors.Add("File name is empty");
            }

            if (txtFileName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                optionsError = true;
                errors.Add("File name contains invalid characters");
            }

            // Export or show message
            if (optionsError)
            {
                var errorMessage = string.Empty;
                foreach (var error in errors)
                {
                    errorMessage += error + Environment.NewLine;
                }
                MessageBox.Show(errorMessage, @"Invalid options", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Go through each company and find the matching vacancies
                var exportVacancies = new List<VacancyObject>();
                foreach (var company in _companyManager.Resources)
                {
                    // Only export companies that have the consultants selected
                    if (checkedListConsultants.CheckedItems.Contains(company.Consultants))
                    {
                        // Go through each vacancy in the resource and check if the company name matches the current company
                        foreach (var vacancy in resourceManager.Resources)
                        {
                            if (vacancy.Company.Equals(company.Name))
                            {
                                // Check if the time is in the range of the selected dates, setting the selected end date to the end of the day
                                if (datePickerStart.Value.CompareTo(vacancy.Added) <= 0 &&
                                    datePickerEnd.Value.AddHours(23).AddMinutes(59).AddSeconds(59).CompareTo(vacancy.Added) >= 0)
                                {
                                    exportVacancies.Add(vacancy);
                                }
                            }
                        }
                    }
                }

                // Create string to be written to export file
                var exportBuilder = new StringBuilder();
                var previousCompany = string.Empty;
                var firstItem = true;
                foreach (var vacancy in exportVacancies)
                {
                    if (!vacancy.Company.Equals(previousCompany))
                    {
                        if (!firstItem)
                        {
                            exportBuilder.AppendLine();
                        }

                        exportBuilder.AppendLine("@" + vacancy.Company);
                        exportBuilder.AppendLine(vacancy.Title);

                        previousCompany = vacancy.Company;
                        firstItem = false;
                    }
                    else
                    {
                        exportBuilder.AppendLine(vacancy.Title);
                    }
                }

                // Write to file
                if (Directory.Exists(txtExportDirectory.Text))
                {
                    if (File.Exists(Path.Combine(txtExportDirectory.Text, txtFileName.Text + ".txt")))
                    {
                        var dialogResult = MessageBox.Show(@"File already exists. Do you want to ovewrite it?", @"File exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    File.WriteAllText(Path.Combine(txtExportDirectory.Text, txtFileName.Text + ".txt"), exportBuilder.ToString().Trim());

                    var result = MessageBox.Show(@"Export sucessful! Open file location?", @"Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", txtExportDirectory.Text);
                    }
                }
                else
                {
                    MessageBox.Show(@"Path does not exist", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Import a file filled with vacancies and add to existing one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdImportVacancies_Click(object sender, EventArgs e)
        {
            ImportVacancyFile(_vacancyManager);
        }

        /// <summary>
        /// Import a file filled with blacklisted vacancies and add to existing one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdImportBlacklist_Click(object sender, EventArgs e)
        {
            ImportVacancyFile(_blacklistManager);
        }

        /// <summary>
        /// Import a file filled with completed vacancies and add to existing one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdImportCompleted_Click(object sender, EventArgs e)
        {
            ImportVacancyFile(_doneManager);
        }

        private void CmdImportCompanies_Click(object sender, EventArgs e)
        {
            ImportCompanyFile(_companyManager);
        }

        /// <summary>
        /// Import a list of vacancies to a specific file
        /// </summary>
        /// <param name="manager"></param>
        private void ImportVacancyFile(JsonResourceManager<VacancyObject> manager)
        {
            var countBefore = manager.Resources.Count;

            var filePath = BrowseForJsonFile();
            if (string.IsNullOrEmpty(filePath)) return;

            var file = File.ReadAllText(filePath);
            var imported = JsonConvert.DeserializeObject<IList<VacancyObject>>(file);

            if (imported.Any(vacancy => vacancy.Company == null || vacancy.Title == null || vacancy.Url == null))
            {
                MessageBox.Show(@"Error while processing file. Please make sure the file contains only vacancies.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var vacanciesWaitingForConfirmation = new List<VacancyObject>();
            foreach (var vacancy in imported)
            {
                if (manager.Resources.Any(o => o.Equals(vacancy)))
                    vacanciesWaitingForConfirmation.Add(vacancy);
                else
                    manager.Resources.Add(vacancy);
            }

            if (vacanciesWaitingForConfirmation.Count > 0)
            {
                var result = MessageBox.Show(@"Found " + vacanciesWaitingForConfirmation.Count + @" duplicates. Skip those?", @"Found duplicates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    manager.Resources.AddRange(vacanciesWaitingForConfirmation);
                }
            }

            manager.SaveChangesToFile();
            if (manager.Resources.Count - countBefore > 0)
                MessageBox.Show(@"Added " + (manager.Resources.Count - countBefore) + @" vacancies!");

            ReloadContent();
        }

        /// <summary>
        /// Import a list of companies to the existing list
        /// </summary>
        /// <param name="manager"></param>
        private void ImportCompanyFile(JsonResourceManager<CompanyObject> manager)
        {
            var countBefore = manager.Resources.Count;

            var filePath = BrowseForJsonFile();
            if (string.IsNullOrEmpty(filePath)) return;

            var file = File.ReadAllText(filePath);
            var imported = JsonConvert.DeserializeObject<IList<CompanyObject>>(file);

            if (imported.Any(company => company.Name == null || company.Consultants == null || company.Url == null || company.Telephone == null))
            {
                MessageBox.Show(@"Error while processing file. Please make sure the file contains only companies.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var companiesWaitingForConfirmation = new List<CompanyObject>();
            foreach (var company in imported)
            {
                if (manager.Resources.Any(o => o.Equals(company)))
                    companiesWaitingForConfirmation.Add(company);
                else
                    manager.Resources.Add(company);
            }

            if (companiesWaitingForConfirmation.Count > 0)
            {
                var result = MessageBox.Show(@"Found " + companiesWaitingForConfirmation.Count + @" duplicates. Skip those?", @"Found duplicates", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    manager.Resources.AddRange(companiesWaitingForConfirmation);
                }
            }

            manager.SaveChangesToFile();
            if (manager.Resources.Count - countBefore > 0)
                MessageBox.Show(@"Added " + (manager.Resources.Count - countBefore) + @" companies!");

            ReloadContent();
        }

        /// <summary>
        /// Open a file dialog and search for JSON files
        /// </summary>
        /// <returns>the file path</returns>
        private static string BrowseForJsonFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"JSON|*.json",
                Title = @"Select a JSON file"
            };

            var result = openFileDialog.ShowDialog();
            return result == DialogResult.OK ? openFileDialog.FileName : string.Empty;
        }

        /// <summary>
        /// Synchronize files with Google Drive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdDriveUpload_Click(object sender, EventArgs e)
        {
            // Change label to display that the upload is in progress
            lblDriveLastUploaded.Text = @"Upload in progres...";

            var filesList = new List<string>();
            foreach (var fileItem in checkedListDownloadUploadFiles.CheckedItems)
            {
                filesList.Add(Path.Combine(_settingsManager.Settings.ResourceFolderPath, fileItem.ToString().ToLower() + ".json"));
            }

            var driveManager = new GoogleDriveManager();
            for (var i = 0; i < filesList.Count; i++)
            {
                // Update label
                lblDriveLastUploaded.Text = @"Upload in progress... (" + (i + 1) + @"/" + filesList.Count + @")";  

                Google.Apis.Drive.v3.Data.File responseFile;

                // save response file id to settings to find the file later
                switch (i)
                {
                    case 0:
                        responseFile = await driveManager.UploadFile(filesList[i], ResourceType.Vacancies);
                        _settingsManager.SetGoogleDriveVacanciesFileId(responseFile.Id);
                        break;
                    case 1:
                        responseFile = await driveManager.UploadFile(filesList[i], ResourceType.Blacklist);
                        _settingsManager.SetGoogleDriveBlacklistFileId(responseFile.Id);
                        break;
                    case 2:
                        responseFile = await driveManager.UploadFile(filesList[i], ResourceType.Done);
                        _settingsManager.SetGoogleDriveDoneFileId(responseFile.Id);
                        break;
                    case 3:
                        responseFile = await driveManager.UploadFile(filesList[i], ResourceType.Companies);
                        _settingsManager.SetGoogleDriveCompaniesFileId(responseFile.Id);
                        break;
                    default:
                        break;
                }
            }

            _settingsManager.SetLastDriveUpload(DateTime.Now);
            UpdateLastDriveUploadLabel();
        }

        /// <summary>
        /// Download files from Google Drive and replace them locally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdDownload_Click(object sender, EventArgs e)
        {
            // Warn user about overwriting files
            var dialogResult = MessageBox.Show(@"Are you sure? This will overwrite all your local resource files. It is irreversible.", @"Confirm overwrite",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel) return;

            // Change label to display that the download is in progress
            lblDriveLastDownloaded.Text = @"Download in progres...";

            var driveManager = new GoogleDriveManager();

            var cnt = 1;
            foreach (var checkedItem in checkedListDownloadUploadFiles.CheckedItems)
            {
                // Update label
                lblDriveLastDownloaded.Text = @"Download in progress... (" + cnt++ + @"/" +
                                              checkedListDownloadUploadFiles.CheckedItems.Count + @")"; 

                switch (checkedItem.ToString())
                {
                    case "Vacancies":
                        await driveManager.DownloadAndReplaceFile(ResourceType.Vacancies);
                        break;
                    case "Blacklist":
                        await driveManager.DownloadAndReplaceFile(ResourceType.Blacklist);
                        break;
                    case "Done":
                        await driveManager.DownloadAndReplaceFile(ResourceType.Done);
                        break;
                    case "Companies":
                        await driveManager.DownloadAndReplaceFile(ResourceType.Companies);
                        break;
                    default:
                        break;
                }
            }

            _settingsManager.SetLastDriveDownload(DateTime.Now);
            UpdateLastDriveDownloadLabel();
        }

        /// <summary>
        /// Display last Google Drive Synchronization Date
        /// </summary>
        private void UpdateLastDriveUploadLabel()
        {
            var lastDriveUpload = _settingsManager.Settings.LastDriveUpload;
            if (!lastDriveUpload.Equals(DateTime.MinValue))
            {
                lblDriveLastUploaded.Text = @"Last uploaded: " + lastDriveUpload.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                lblDriveLastUploaded.Text = @"Last uploaded: Never";
            }
        }

        /// <summary>
        /// Display last Google Drive Synchronization Date
        /// </summary>
        private void UpdateLastDriveDownloadLabel()
        {
            var lastDriveDownload = _settingsManager.Settings.LastDriveDownload;
            if (!lastDriveDownload.Equals(DateTime.MinValue))
            {
                lblDriveLastDownloaded.Text = @"Last downloaded: " + lastDriveDownload.ToString(CultureInfo.CurrentCulture);
            }
            else
            {
                lblDriveLastDownloaded.Text = @"Last downloaded: Never";
            }
        }
    }
}
