using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Documents;
using Vacancy_Scraper.Forms;
using Vacancy_Scraper.JsonManagers;

namespace Vacancy_Scraper.UserControls
{
    public partial class Settings : UserControl
    {
        private static Settings _instance;
        private SettingsManager _settingsManager;

        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Settings();
                return _instance;
            }
        }

        public Settings()
        {
            InitializeComponent();

            _settingsManager = new SettingsManager();
        }

        /// <summary>
        /// Gets called when the active tab in the tab control is changed
        /// This is to notify the user controls of the change and make adjustments based on the change
        /// </summary>
        public void NotifyTabChanged(MainForm.Tabs oldTab, MainForm.Tabs newTab)
        {
            if (newTab == MainForm.Tabs.Settings)
            {
                ReloadContent();
            }
            else if (oldTab == MainForm.Tabs.Settings)
            {
                // Ask if the user wants to save any unchanged settings
                if (ContentChanged())
                {
                    DialogResult dialogResult = MessageBox.Show(@"Do you want to save all unsaved settings?", @"Save changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {
            _settingsManager = new SettingsManager();
            txtSettingsWebDriversPath.Text = _settingsManager.Settings.WebDriversPath;
            txtSettingsResourcesPath.Text = _settingsManager.Settings.ResourceFolderPath;
            txtSettingsLogsFolderPath.Text = _settingsManager.Settings.LogsFolderPath;
            txtBannedKeywords.Text = _settingsManager.Settings.ScraperBannedKeywords;
            checkJobnet.Checked = _settingsManager.Settings.ScraperCheckJobnet;

            comboScraperWebDriver.Items.Clear();
            foreach (var webDriver in InstalledWebDrivers(_settingsManager.Settings.WebDriversPath))
            {
                comboScraperWebDriver.Items.Add(webDriver);
            }
            comboScraperWebDriver.SelectedItem = _settingsManager.Settings.ScraperWebDriver;

            SetStatus();
        }

        /// <summary>
        /// Check the the user input and give feedback if the given input is valid
        /// </summary>
        private void SetStatus()
        {
            // Change the status label in the lower left corner if all changes are saved or not
            SwitchSaveStatusLabel(!ContentChanged());

            // Check if all settings are valid
            bool allSettingsValid = true;

            // Check which web drivers are installed
            if (Directory.Exists(txtSettingsWebDriversPath.Text))
            {
                List<string> installedWebDrivers = InstalledWebDrivers(txtSettingsWebDriversPath.Text);
                if (installedWebDrivers.Count > 0)
                {
                    lblSettingsWebDriversPathStatus.ForeColor = SystemColors.ControlText;
                    lblSettingsWebDriversPathStatus.Text = @"Installed: " + string.Join(", ", installedWebDrivers);
                }
                else
                {
                    lblSettingsWebDriversPathStatus.ForeColor = Color.Red;
                    lblSettingsWebDriversPathStatus.Text = @"Path valid, but no drivers found";
                }
                linkLblSettingsWebDriversPath.Visible = true;
                linkLblSettingsWebDriversPath.Text = @"Download more";
            }
            else
            {
                allSettingsValid = false;
                lblSettingsWebDriversPathStatus.ForeColor = Color.Red;
                lblSettingsWebDriversPathStatus.Text = @"Path does not exist or is invalid";
                linkLblSettingsWebDriversPath.Visible = false;
            }

            // Check whether all resource files are present
            if (Directory.Exists(txtSettingsResourcesPath.Text))
            {
                bool vacancies = File.Exists(Path.Combine(txtSettingsResourcesPath.Text, "vacancies.json"));
                bool blacklist = File.Exists(Path.Combine(txtSettingsResourcesPath.Text, "blacklist.json"));
                bool done = File.Exists(Path.Combine(txtSettingsResourcesPath.Text, "done.json"));
                bool companies = File.Exists(Path.Combine(txtSettingsResourcesPath.Text, "companies.json"));

                if (vacancies && blacklist && done && companies)
                {
                    lblSettingsResourcesStatus.ForeColor = SystemColors.ControlText;
                    lblSettingsResourcesStatus.Text = @"All files are present";
                    linkLblSettingsResourcesPath.Visible = false;
                }
                else
                {
                    lblSettingsResourcesStatus.ForeColor = Color.Red;
                    lblSettingsResourcesStatus.Text = @"Path valid, but files are missing";
                    linkLblSettingsResourcesPath.Visible = true;
                    linkLblSettingsResourcesPath.Text = @"Create files";
                }
            }
            else
            {
                allSettingsValid = false;
                lblSettingsResourcesStatus.ForeColor = Color.Red;
                lblSettingsResourcesStatus.Text = @"Path does not exist or is invalid";
                linkLblSettingsResourcesPath.Visible = false;
            }

            // Logs Folder Path
            if (Directory.Exists(txtSettingsLogsFolderPath.Text))
            {
                lblSettingsLogsStatus.ForeColor = SystemColors.ControlText;
                lblSettingsLogsStatus.Text = @"Path valid";
                linkLblSettingsLogsPath.Visible = false;
            }
            else
            {
                allSettingsValid = false;
                lblSettingsLogsStatus.ForeColor = Color.Red;
                lblSettingsLogsStatus.Text = @"Path does not exist or is invalid";
                linkLblSettingsLogsPath.Visible = false;
            }

            // Enable or disable the apply button based on if all changes are valid
            cmdSettingsApply.Enabled = allSettingsValid;
        }

        /// <summary>
        /// Get a list of all installed web drivers in a given path
        /// </summary>
        /// <param name="path">the directory path where the drivers should be</param>
        /// <returns>a list of all web drivers in that directory, as name</returns>
        private List<string> InstalledWebDrivers(string path)
        {
            List<string> drivers = new List<string>();
            if (Directory.Exists(path))
            {
                bool chrome = File.Exists(Path.Combine(txtSettingsWebDriversPath.Text, "chromedriver.exe"));
                bool edge = File.Exists(Path.Combine(txtSettingsWebDriversPath.Text, "MicrosoftWebDriver.exe"));
                bool firefox = File.Exists(Path.Combine(txtSettingsWebDriversPath.Text, "geckodriver.exe"));
                bool opera = File.Exists(Path.Combine(txtSettingsWebDriversPath.Text, "operadriver.exe"));
                bool phantomjs = File.Exists(Path.Combine(txtSettingsWebDriversPath.Text, "phantomjs.exe"));

                if (firefox || chrome || opera || edge || phantomjs)
                {
                    if (chrome) { drivers.Add("Chrome"); }
                    if (edge) { drivers.Add("Edge"); }
                    if (firefox) { drivers.Add("Firefox"); }
                    if (opera) { drivers.Add("Opera"); }
                    if (phantomjs) { drivers.Add("PhantomJS"); }
                }
            }

            return drivers;
        }

        /// <summary>
        /// Assert whether any of the settings were changed by the user
        /// </summary>
        /// <returns></returns>
        private bool ContentChanged()
        {
            if (txtSettingsWebDriversPath.Text.Equals(_settingsManager.Settings.WebDriversPath) &&
                txtSettingsResourcesPath.Text.Equals(_settingsManager.Settings.ResourceFolderPath) &&
                txtSettingsLogsFolderPath.Text.Equals(_settingsManager.Settings.LogsFolderPath) &&
                comboScraperWebDriver.Text.Equals(_settingsManager.Settings.ScraperWebDriver) &&
                txtBannedKeywords.Text.Equals(_settingsManager.Settings.ScraperBannedKeywords) &&
                checkJobnet.Checked == _settingsManager.Settings.ScraperCheckJobnet)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Save changes to the settings to the file, if valid
        /// </summary>
        private void SaveChanges()
        {
            bool errorsWhileSaving = false;

            if (Directory.Exists(txtSettingsWebDriversPath.Text))
                _settingsManager.SetWebDriversPath(txtSettingsWebDriversPath.Text.Trim());
            else
                errorsWhileSaving = true;

            if (Directory.Exists(txtSettingsResourcesPath.Text))
                _settingsManager.SetResourceFolderPath(txtSettingsResourcesPath.Text.Trim());
            else
                errorsWhileSaving = true;

            if (Directory.Exists(txtSettingsLogsFolderPath.Text))
                _settingsManager.SetLogsFolderPath(txtSettingsLogsFolderPath.Text.Trim());
            else
                errorsWhileSaving = true;

            _settingsManager.SetScraperWebDriver(comboScraperWebDriver.Text);
            _settingsManager.SetScraperBannedKeywords(txtBannedKeywords.Text);
            _settingsManager.SetScraperCheckJobnet(checkJobnet.Checked);

            // This should never show, because the "Apply" button is disabled if there are invalid changes
            if (errorsWhileSaving)
            {
                MessageBox.Show(@"There was one or more erros while saving, because the settings are invalid", @"Error while saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Change between the modes of saying that all changes are saved and that there are unsaved changes
        /// </summary>
        /// <param name="allChangesAreSaved">true if there are no changes</param>
        private void SwitchSaveStatusLabel(bool allChangesAreSaved)
        {
            if (allChangesAreSaved)
            {
                lblSavedStatus.Text = @"All changes saved";
                lblSavedStatus.ForeColor = Color.Green;
            }
            else
            {
                lblSavedStatus.Text = @"There are unsaved changes";
                lblSavedStatus.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Apply the given settings and write them to the settings file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSettingsApply_Click(object sender, EventArgs e)
        {
            SaveChanges();
            SetStatus();
        }

        /// <summary>
        /// Cancel the given settings and revert to the old settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSettingsCancel_Click(object sender, EventArgs e)
        {
            ReloadContent();
        }

        /// <summary>
        /// Browse for a path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSettingsBrowseWebDriversPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSettingsWebDriversPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Browse for a path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSettingsBrowseResourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSettingsResourcesPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Browse for a path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSettingsBrowseLogsFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSettingsLogsFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Update the status when changing the path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSettingsWebDriversPath_TextChanged(object sender, EventArgs e)
        {
            SetStatus();
        }

        /// <summary>
        /// Update the status when changing the path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSettingsResourcesPath_TextChanged(object sender, EventArgs e)
        {
            SetStatus();
        }

        /// <summary>
        /// Update the status when changing the path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSettingsLogsFolderPath_TextChanged(object sender, EventArgs e)
        {
            SetStatus();
        }

        /// <summary>
        /// Update the status when changing the web driver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboScraperWebDriver_TextChanged(object sender, EventArgs e)
        {
            SetStatus();
        }

        /// <summary>
        /// Update the status when changing the banned keywords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBannedKeywords_TextChanged(object sender, EventArgs e)
        {
            SetStatus();
        }

        /// <summary>
        /// Update the status when changing the jobnet checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkJobnet_CheckedChanged(object sender, EventArgs e)
        {
            SetStatus();
        }

        /// <summary>
        /// Open the browser and take the user to the download page of web drivers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLblSettingsWebDriversPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.seleniumhq.org/download/");
        }

        /// <summary>
        /// Create the resource files that are missing as empty JSON files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLblSettingsResourcesPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string vacancies = Path.Combine(txtSettingsResourcesPath.Text, "vacancies.json");
            if (!File.Exists(vacancies)) { File.Create(vacancies).Dispose(); }

            string blacklist = Path.Combine(txtSettingsResourcesPath.Text, "blacklist.json");
            if (!File.Exists(blacklist)) { File.Create(blacklist).Dispose(); }

            string done = Path.Combine(txtSettingsResourcesPath.Text, "done.json");
            if (!File.Exists(done)) { File.Create(done).Dispose(); }

            string companies = Path.Combine(txtSettingsResourcesPath.Text, "companies.json");
            if (!File.Exists(companies)) { File.Create(companies).Dispose(); }

            SetStatus(); // refresh status labels
        }
    }
}
