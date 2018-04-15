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
        /// Apply the given settings and write them to the settings file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdSettingsApply_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSettingsWebDriversPath.Text))
                settingsManager.SetWebDriversPath(txtSettingsWebDriversPath.Text.Trim());

            if (Directory.Exists(txtSettingsResourcesPath.Text))
                settingsManager.SetResourceFolderPath(txtSettingsResourcesPath.Text.Trim());

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

        private void CmdSettingsBrowseWebDriversPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSettingsWebDriversPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void CmdSettingsBrowseResourceFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSettingsResourcesPath.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
