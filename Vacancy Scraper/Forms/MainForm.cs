using System.Windows.Forms;

namespace Vacancy_Scraper.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Holds the currently selected tab as an enum of the type Tabs
        /// </summary>
        private Tabs currentTab = Tabs.Dashboard;

        /// <summary>
        /// An enumeration to store the currently selected tab
        /// </summary>
        public enum Tabs { Dashboard, Scrape, Vacancies, Blacklist, Done, Companies, Settings }

        /// <summary>
        /// The constructor of the class
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            LoadTabContent();
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
                case "Dashboard":
                    NotifyTabChanged(Tabs.Dashboard);
                    currentTab = Tabs.Dashboard;
                    break;
                case "Scrape":
                    NotifyTabChanged(Tabs.Scrape);
                    currentTab = Tabs.Scrape;
                    break;
                case "Vacancies":
                    NotifyTabChanged(Tabs.Vacancies);
                    currentTab = Tabs.Vacancies;
                    break;
                case "Blacklist":
                    NotifyTabChanged(Tabs.Blacklist);
                    currentTab = Tabs.Blacklist;
                    break;
                case "Done":
                    NotifyTabChanged(Tabs.Done);
                    currentTab = Tabs.Done;
                    break;
                case "Companies":
                    NotifyTabChanged(Tabs.Companies);
                    currentTab = Tabs.Companies;
                    break;
                case "Settings":
                    NotifyTabChanged(Tabs.Settings);
                    currentTab = Tabs.Settings;
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
            switch (currentTab)
            {
                case Tabs.Dashboard:
                    if (!panelDashboard.Controls.Contains(UserControls.Dashboard.Instance))
                    {
                        panelDashboard.Controls.Add(UserControls.Dashboard.Instance);
                        UserControls.Dashboard.Instance.Dock = DockStyle.Fill;
                        UserControls.Dashboard.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Dashboard.Instance.BringToFront();
                    }
                    break;
                case Tabs.Scrape:
                    if (!panelScrape.Controls.Contains(UserControls.Scrape.Instance))
                    {
                        panelScrape.Controls.Add(UserControls.Scrape.Instance);
                        UserControls.Scrape.Instance.Dock = DockStyle.Fill;
                        UserControls.Scrape.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Scrape.Instance.BringToFront();
                    }
                    break;
                case Tabs.Vacancies:
                    if (!panelVacancies.Controls.Contains(UserControls.Vacancies.Instance))
                    {
                        panelVacancies.Controls.Add(UserControls.Vacancies.Instance);
                        UserControls.Vacancies.Instance.Dock = DockStyle.Fill;
                        UserControls.Vacancies.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Vacancies.Instance.BringToFront();
                    }
                    break;
                case Tabs.Blacklist:
                    if (!panelBlacklist.Controls.Contains(UserControls.Blacklist.Instance))
                    {
                        panelBlacklist.Controls.Add(UserControls.Blacklist.Instance);
                        UserControls.Blacklist.Instance.Dock = DockStyle.Fill;
                        UserControls.Blacklist.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Blacklist.Instance.BringToFront();
                    }
                    break;
                case Tabs.Done:
                    if (!panelDone.Controls.Contains(UserControls.Done.Instance))
                    {
                        panelDone.Controls.Add(UserControls.Done.Instance);
                        UserControls.Done.Instance.Dock = DockStyle.Fill;
                        UserControls.Done.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Done.Instance.BringToFront();
                    }
                    break;
                case Tabs.Companies:
                    if (!panelCompanies.Controls.Contains(UserControls.Companies.Instance))
                    {
                        panelCompanies.Controls.Add(UserControls.Companies.Instance);
                        UserControls.Companies.Instance.Dock = DockStyle.Fill;
                        UserControls.Companies.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Companies.Instance.BringToFront();
                    }
                    break;
                case Tabs.Settings:
                    if (!panelSettings.Controls.Contains(UserControls.Settings.Instance))
                    {
                        panelSettings.Controls.Add(UserControls.Settings.Instance);
                        UserControls.Settings.Instance.Dock = DockStyle.Fill;
                        UserControls.Settings.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.Settings.Instance.BringToFront();
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
            UserControls.Dashboard.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Scrape.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Vacancies.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Blacklist.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Done.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Companies.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Settings.Instance.NotifyTabChanged(currentTab, newTab);
        }
    }
}
