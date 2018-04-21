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
                    if (!panelDashboard.Controls.Contains(UserControls.UC_Dashboard.Instance))
                    {
                        panelDashboard.Controls.Add(UserControls.UC_Dashboard.Instance);
                        UserControls.UC_Dashboard.Instance.Dock = DockStyle.Fill;
                        UserControls.UC_Dashboard.Instance.BringToFront();
                    }
                    else
                    {
                        UserControls.UC_Dashboard.Instance.BringToFront();
                    }
                    break;
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
            UserControls.UC_Dashboard.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.UC_Scrape.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.Vacancies.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.UC_Blacklist.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.UC_Done.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.UC_Companies.Instance.NotifyTabChanged(currentTab, newTab);
            UserControls.UC_Settings.Instance.NotifyTabChanged(currentTab, newTab);
        }
    }
}
