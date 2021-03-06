﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;
using Vacancy_Scraper.Forms;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.UserControls
{
    public partial class UC_Scrape : UserControl
    {
        private static UC_Scrape _instance;

        private JsonResourceManager<CompanyObject> _companiesManager;
        private BindingList<ScrapeGridObject> _bindingList;
        private readonly SettingsManager _settingsManager = new SettingsManager();

        private List<CompanyObject> _toBeScraped;
        private bool _scrapeRunning, _scrapePaused;

        public static UC_Scrape Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Scrape();
                return _instance;
            }
        }

        public UC_Scrape()
        {
            InitializeComponent();
            ReloadContent();
        }

        /// <summary>
        /// Gets called when the active tab in the tab control is changed
        /// This is to notify the user controls of the change and make adjustments based on the change
        /// </summary>
        public void NotifyTabChanged(MainForm.Tabs oldTab, MainForm.Tabs newTab)
        {
            if (newTab == MainForm.Tabs.Scrape)
            {
                ReloadContent();
            }
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {
            // Disable pause and stop buttons
            cmdScrapePause.Enabled = false;
            cmdScrapeStop.Enabled = false;

            _companiesManager = new JsonResourceManager<CompanyObject>(ResourceType.Companies);
            _bindingList = new BindingList<ScrapeGridObject>();

            // Add all enabled companies to the binding list and cast each object into an instance of ScrapeGridObject
            foreach (var company in _companiesManager.Resources.Where(o => o.Enabled))
            {
                _bindingList.Add(new ScrapeGridObject(company));
            }

            var source = new BindingSource(_bindingList, null);
            gridScrape.DataSource = source;
            AdjustTableSettings();

            // Update status on every item
            UpdateEveryStatus();
        }

        /// <summary>
        /// Update status on every object in the table
        /// </summary>
        private void UpdateEveryStatus()
        {
            foreach (var gridObject in _bindingList)
            {
                gridObject.Status = gridObject.Selected ? @"Waiting" : @"Disabled";
            }
        }

        /// <summary>
        /// Change some settings regarding the behaviour of the data grid view
        /// </summary>
        private void AdjustTableSettings()
        {
            const int colCount = 3;
            if (gridScrape.Columns.Count == colCount)
            {
                gridScrape.Columns[0].FillWeight = 25;
                gridScrape.Columns[1].FillWeight = 100;
                gridScrape.Columns[2].FillWeight = 150;

                gridScrape.Columns[0].MinimumWidth = 50;
                gridScrape.Columns[1].MinimumWidth = 50;
                gridScrape.Columns[2].MinimumWidth = 50;

                gridScrape.Columns[0].SortMode = DataGridViewColumnSortMode.Programmatic;
                gridScrape.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
                gridScrape.Columns[2].SortMode = DataGridViewColumnSortMode.Programmatic;

                gridScrape.Columns[0].ReadOnly = false;
                gridScrape.Columns[1].ReadOnly = true;
                gridScrape.Columns[2].ReadOnly = true;
            }
        }

        /// <summary>
        /// Save the changes in the table to the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridScrape_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Save all objects in the binding list to the real company list (to save the changed value of "Selected")
                foreach (var gridObject in _bindingList)
                {
                    _companiesManager.Resources.First(o => o.Equals(gridObject.Company)).Selected = gridObject.Selected;
                    _companiesManager.SaveChangesToFile();

                    // Update status
                    _bindingList.First(o => o.Name.Equals(gridObject.Company.Name)).Status = 
                        _companiesManager.Resources.First(o => o.Equals(gridObject.Company)).Selected ?
                        @"Waiting" : @"Disabled";
                }
            }
        }

        /// <summary>
        /// Fires the CellValueChanged event when changing a checkbox value, because it doesn't do it by itself for some reason
        /// https://stackoverflow.com/questions/11843488/how-to-detect-datagridview-checkbox-event-change?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridScrape_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gridScrape.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /// <summary>
        /// Create a list with all companies in the table that have the checkbox enabled
        /// </summary>
        /// <returns></returns>
        private List<CompanyObject> PrepareCompanyListFromTable()
        {
            var companies = new List<CompanyObject>();
            foreach (var company in _bindingList)
            {
                if (company.Selected)
                    companies.Add(company.Company);
            }

            return companies;
        }

        /// <summary>
        /// Start the scraping process by going through the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdScrapeRun_Click(object sender, EventArgs e)
        {
            // Only start the process if it's not already running
            if (!_scrapeRunning)
            {
                // Disable editing the table while running
                gridScrape.Columns[0].ReadOnly = true;

                // Disable this button, enable others
                cmdScrapeRun.Enabled = false;
                cmdScrapePause.Enabled = true;
                cmdScrapeStop.Enabled = true;

                // Update label
                lblScrapeStatus.Text = @"Status: Running";

                // Clear log
                txtScrapeLog.Text = string.Empty;

                // Set the status to be "Running"
                _scrapeRunning = true;

                // Only create a new list of tasks if the execution wasn't paused before.
                // If it was only paused, the remaining tasks should be completed
                if (!_scrapePaused)
                {
                    UpdateEveryStatus();
                    _toBeScraped = PrepareCompanyListFromTable();
                    WriteLineToLog("Starting");
                }

                // Unpause when continuing
                if (_scrapePaused)
                    _scrapePaused = false;

                // Go through the list until there are no tasks left
                while (_toBeScraped.Count > 0)
                {
                    // Only run the newest task if the process hasn't been stopped or paused
                    if (_scrapeRunning && !_scrapePaused)
                    {
                        var company = _toBeScraped[0]; // always use the first in the list
                        WriteLineToLog("Scraping " + company.Name);

                        // Update the status
                        _bindingList.First(o => o.Name.Equals(company.Name)).Status = "Running";

                        // Execute task and wait for result
                        if (_settingsManager.CheckIfCurrentDriversExist())
                        {
                            var result = await new Scraper.ScraperExecutor().Scrape(company);
                            WriteLineToLog(company.Name + @": " + result);
                            Console.WriteLine(@"Tasks remaining: " + (_toBeScraped.Count - 1));

                            // Update the status with the result
                            _bindingList.First(o => o.Name.Equals(company.Name)).Status = result;

                            _toBeScraped.Remove(company);
                        }
                        else
                        {
                            foreach (var scrapeGridObject in _bindingList)
                            {
                                scrapeGridObject.Status = "Cancelled: couldn't find driver";
                                _scrapeRunning = false;
                            }
                        }
                    }
                    else
                    {
                        // The execution has been paused, exit the loop and wait for further action
                        if (_scrapePaused)
                        {
                            WriteLineToLog("Paused");
                            break;
                        }
                        // The execution has been stopped, exit the loop, set the status to "Not Running" and wait for further action
                        // It is important to set the status to not running so that the list of tasks will be reset upon a restart
                        else if (!_scrapeRunning)
                        {
                            WriteLineToLog("Stopped");
                            _scrapeRunning = false;
                            break;
                        }
                    }
                }

                if (!_scrapePaused)
                    WriteLineToLog("Done with all tasks");

                // All tasks are complete, or the execution has been paused / stopped
                _scrapeRunning = false;

                // Reset buttons when done, but not when the process was only paused
                if (!_scrapePaused)
                {
                    // Update label
                    lblScrapeStatus.Text = @"Status: Complete";

                    // Update buttons
                    cmdScrapeRun.Enabled = true;
                    cmdScrapePause.Enabled = false;
                    cmdScrapeStop.Enabled = false;

                    // Reenable editing
                    gridScrape.Columns[0].ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// Pause the scraping process after finishing the currently running scrapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdScrapePause_Click(object sender, EventArgs e)
        {
            _scrapePaused = true;

            // Update label
            lblScrapeStatus.Text = @"Status: Paused";

            // Disable this button, enable others
            cmdScrapeRun.Enabled = true;
            cmdScrapePause.Enabled = false;
            cmdScrapeStop.Enabled = true;
        }

        /// <summary>
        /// Stop all scrapes after finishing the currently running scrapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdScrapeStop_Click(object sender, EventArgs e)
        {
            _scrapeRunning = false;
            _scrapePaused = false;

            // Update label
            lblScrapeStatus.Text = @"Status: Stopped";

            // Disable this button, enable others
            cmdScrapeRun.Enabled = true;
            cmdScrapePause.Enabled = false;
            cmdScrapeStop.Enabled = false;
        }

        /// <summary>
        /// Disable selection by instantly clearing a selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridScrape_SelectionChanged(object sender, EventArgs e)
        {
            gridScrape.ClearSelection();
        }

        /// <summary>
        /// Write a line to the log
        /// </summary>
        /// <param name="line"></param>
        private void WriteLineToLog(string line)
        {
            txtScrapeLog.Text += line + Environment.NewLine;
        }
    }
}
