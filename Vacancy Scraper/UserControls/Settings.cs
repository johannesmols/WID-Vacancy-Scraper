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

using Vacancy_Scraper.Settings;

namespace Vacancy_Scraper.UserControls
{
    public partial class Settings : UserControl
    {
        private static Settings _instance;
        private SettingsManager settingsManager;

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

            settingsManager = new SettingsManager();
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
                if (contentChanged())
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save all unsaved settings?", "Save changes", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        saveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {
            settingsManager = new SettingsManager();
            txtSettingsWebDriversPath.Text = settingsManager.Settings.WebDriversPath;
            txtSettingsResourcesPath.Text = settingsManager.Settings.ResourceFolderPath;

            SetStatus();
        }

        /// <summary>
        /// Check the the user input and give feedback if the given input is valid
        /// </summary>
        private void SetStatus()
        {
            // Web Drivers Path
            if (Directory.Exists(txtSettingsWebDriversPath.Text))
            {
                lblSettingsWebDriversPathStatus.Text = "Status: OK!";
                linkLblSettingsWebDriversPath.Visible = false;
            }
            else
            {
                lblSettingsWebDriversPathStatus.Text = "Path does not exist";
                linkLblSettingsWebDriversPath.Visible = false;
            }

            // Web Drivers Path
            if (Directory.Exists(txtSettingsResourcesPath.Text))
            {
                lblSettingsResourcesStatus.Text = "Status: OK!";
                linkLblSettingsResourcesPath.Visible = false;
            }
            else
            {
                lblSettingsResourcesStatus.Text = "Path does not exist";
                linkLblSettingsResourcesPath.Visible = false;
            }
        }

        /// <summary>
        /// Assert whether any of the settings were changed by the user
        /// </summary>
        /// <returns></returns>
        private bool contentChanged()
        {
            if (txtSettingsWebDriversPath.Text.Equals(settingsManager.Settings.WebDriversPath) &&
                txtSettingsResourcesPath.Text.Equals(settingsManager.Settings.ResourceFolderPath))
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
        private void saveChanges()
        {
            if (Directory.Exists(txtSettingsWebDriversPath.Text))
                settingsManager.SetWebDriversPath(txtSettingsWebDriversPath.Text.Trim());

            if (Directory.Exists(txtSettingsResourcesPath.Text))
                settingsManager.SetResourceFolderPath(txtSettingsResourcesPath.Text.Trim());
        }

        /// <summary>
        /// Apply the given settings and write them to the settings file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSettingsApply_Click(object sender, EventArgs e)
        {
            saveChanges();
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
    }
}
