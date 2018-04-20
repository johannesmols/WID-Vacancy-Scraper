using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vacancy_Scraper.Forms;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.UserControls
{
    public partial class Scrape : UserControl
    {
        private static Scrape _instance;

        private JsonResourceManager<CompanyObject> _companiesManager;
        private BindingList<ScrapeGridObject> _bindingList;

        private List<CompanyObject> _toBeScraped;
        private bool _scrapeRunning, _scrapePaused;

        public static Scrape Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Scrape();
                return _instance;
            }
        }

        public Scrape()
        {
            InitializeComponent();
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
        private void gridScrape_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                // Save all objects in the binding list to the real company list (to save the changed value of "Selected")
                foreach (var gridObject in _bindingList)
                {
                    _companiesManager.Resources.First(o => o.Equals(gridObject.Company)).Selected = gridObject.Selected;
                    _companiesManager.SaveChangesToFile();
                }
            }
        }

        /// <summary>
        /// Fires the CellValueChanged event when changing a checkbox value, because it doesn't do it by itself for some reason
        /// https://stackoverflow.com/questions/11843488/how-to-detect-datagridview-checkbox-event-change?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridScrape_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        private async void cmdScrapeRun_Click(object sender, EventArgs e)
        {
            // Only start the process if it's not already running
            if (!_scrapeRunning)
            {
                // Disable this button, enable others
                cmdScrapeRun.Enabled = false;
                cmdScrapePause.Enabled = true;
                cmdScrapeStop.Enabled = true;

                // Set the status to be "Running"
                _scrapeRunning = true;

                // Only create a new list of tasks if the execution wasn't paused before.
                // If it was only paused, the remaining tasks should be completed
                if (!_scrapePaused)
                    _toBeScraped = PrepareCompanyListFromTable();

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
                        bool result = await new Scraper.Scraper().Scrape(company);
                        Console.WriteLine(@"Successful: " + result);
                        Console.WriteLine(@"Tasks remaining: " + (_toBeScraped.Count - 1));
                        _toBeScraped.Remove(company);
                    }
                    else
                    {
                        // The execution has been paused, exit the loop and wait for further action
                        if (_scrapePaused)
                        {
                            Console.WriteLine(@"Paused tasks");
                            break;
                        }
                        // The execution has been stopped, exit the loop, set the status to "Not Running" and wait for further action
                        // It is important to set the status to not running so that the list of tasks will be reset upon a restart
                        else if (!_scrapeRunning)
                        {
                            Console.WriteLine(@"Stopped tasks");
                            _scrapeRunning = false;
                            break;
                        }
                    }
                }

                if (!_scrapePaused)
                    Console.WriteLine(@"Done with all tasks");

                // All tasks are complete, or the execution has been paused / stopped
                _scrapeRunning = false;

                // Reset buttons when done, but not when the process was only paused
                if (!_scrapePaused)
                {
                    cmdScrapeRun.Enabled = true;
                    cmdScrapePause.Enabled = false;
                    cmdScrapeStop.Enabled = false;
                }
            }
            else
            {
                Console.WriteLine(@"Already executing list of tasks");
            }
        }

        /// <summary>
        /// Pause the scraping process after finishing the currently running scrapes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdScrapePause_Click(object sender, EventArgs e)
        {
            _scrapePaused = true;

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
        private void cmdScrapeStop_Click(object sender, EventArgs e)
        {
            _scrapeRunning = false;
            _scrapePaused = false;

            // Disable this button, enable others
            cmdScrapeRun.Enabled = true;
            cmdScrapePause.Enabled = false;
            cmdScrapeStop.Enabled = false;
        }
    }
}
