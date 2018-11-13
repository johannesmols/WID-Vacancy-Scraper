using System.Windows.Forms;
using Vacancy_Scraper.Tools;

namespace Vacancy_Scraper.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Holds the currently selected tab as an enum of the type Tabs
        /// </summary>
        private Tabs _currentTab = Tabs.Scrape;

        /// <summary>
        /// An enumeration to store the currently selected tab
        /// </summary>
        public enum Tabs { Scrape, Vacancies, Blacklist, Done, Companies, Export, Settings }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            LoadTabContent();

            Text = @"Vacancy Scraper by Johannes Mols [v0.9.1]";

            var driveManager = new GoogleDriveManager();
            driveManager.UploadAllFiles();
        }

        /// <summary>
        /// Event to change the current tab. Handle tab loading here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Text)
            {
                case "Scrape":
                    NotifyTabChanged(Tabs.Scrape);
                    _currentTab = Tabs.Scrape;
                    break;
                case "Vacancies":
                    NotifyTabChanged(Tabs.Vacancies);
                    _currentTab = Tabs.Vacancies;
                    break;
                case "Blacklist":
                    NotifyTabChanged(Tabs.Blacklist);
                    _currentTab = Tabs.Blacklist;
                    break;
                case "Done":
                    NotifyTabChanged(Tabs.Done);
                    _currentTab = Tabs.Done;
                    break;
                case "Companies":
                    NotifyTabChanged(Tabs.Companies);
                    _currentTab = Tabs.Companies;
                    break;
                case "Export":
                    NotifyTabChanged(Tabs.Export);
                    _currentTab = Tabs.Export;
                    break;
                case "Settings":
                    NotifyTabChanged(Tabs.Settings);
                    _currentTab = Tabs.Settings;
                    break;
                default:
                    break;
            }

            LoadTabContent();
        }

        /// <summary>
        /// Load the user control of a certain tab and refresh it's content
        /// </summary>
        private void LoadTabContent()
        {
            switch (_currentTab)
            {
                case Tabs.Scrape:
                    if (!panelScrape.Controls.Contains(UserControls.UC_Scrape.Instance))
                    {
                        panelScrape.Controls.Add(UserControls.UC_Scrape.Instance);
                        UserControls.UC_Scrape.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Scrape.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Scrape.Instance.BringToFront();
                    }
                    break;
                case Tabs.Vacancies:
                    if (!panelVacancies.Controls.Contains(UserControls.UC_Vacancies.Instance))
                    {
                        panelVacancies.Controls.Add(UserControls.UC_Vacancies.Instance);
                        UserControls.UC_Vacancies.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Vacancies.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Vacancies.Instance.BringToFront();
                    }
                    break;
                case Tabs.Blacklist:
                    if (!panelBlacklist.Controls.Contains(UserControls.UC_Blacklist.Instance))
                    {
                        panelBlacklist.Controls.Add(UserControls.UC_Blacklist.Instance);
                        UserControls.UC_Blacklist.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Blacklist.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Blacklist.Instance.BringToFront();
                    }
                    break;
                case Tabs.Done:
                    if (!panelDone.Controls.Contains(UserControls.UC_Done.Instance))
                    {
                        panelDone.Controls.Add(UserControls.UC_Done.Instance);
                        UserControls.UC_Done.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Done.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Done.Instance.BringToFront();
                    }
                    break;
                case Tabs.Companies:
                    if (!panelCompanies.Controls.Contains(UserControls.UC_Companies.Instance))
                    {
                        panelCompanies.Controls.Add(UserControls.UC_Companies.Instance);
                        UserControls.UC_Companies.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Companies.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Companies.Instance.BringToFront();
                    }
                    break;
                case Tabs.Export:
                    if (!panelCompanies.Controls.Contains(UserControls.UC_Export.Instance))
                    {
                        panelExport.Controls.Add(UserControls.UC_Export.Instance);
                        UserControls.UC_Export.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Export.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Export.Instance.BringToFront();
                    }
                    break;
                case Tabs.Settings:
                    if (!panelSettings.Controls.Contains(UserControls.UC_Settings.Instance))
                    {
                        panelSettings.Controls.Add(UserControls.UC_Settings.Instance);
                        UserControls.UC_Settings.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Settings.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Settings.Instance.BringToFront();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Notify every tab that the active tab has changed
        /// </summary>
        /// <param name="newTab">the new active tab</param>
        private void NotifyTabChanged(Tabs newTab) 
        {
            UserControls.UC_Scrape.Instance.NotifyTabChanged(_currentTab, newTab);
            UserControls.UC_Vacancies.Instance.NotifyTabChanged(_currentTab, newTab);
            UserControls.UC_Blacklist.Instance.NotifyTabChanged(_currentTab, newTab);
            UserControls.UC_Done.Instance.NotifyTabChanged(_currentTab, newTab);
            UserControls.UC_Companies.Instance.NotifyTabChanged(_currentTab, newTab);
            UserControls.UC_Export.Instance.NotifyTabChanged(_currentTab, newTab);
            UserControls.UC_Settings.Instance.NotifyTabChanged(_currentTab, newTab);
        }
    }
}
