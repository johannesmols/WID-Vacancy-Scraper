using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vacancy_Scraper
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
        private enum Tabs { Dashboard, Scrape, Vacancies, Blacklist, Done, Companies, Settings }

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
                    currentTab = Tabs.Dashboard;
                    break;
                case "Scrape":
                    currentTab = Tabs.Scrape;
                    break;
                case "Vacancies":
                    currentTab = Tabs.Vacancies;
                    break;
                case "Blacklist":
                    currentTab = Tabs.Blacklist;
                    break;
                case "Done":
                    currentTab = Tabs.Done;
                    break;
                case "Companies":
                    currentTab = Tabs.Companies;
                    break;
                case "Settings":
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
                    UserControls.Dashboard.Instance.ReloadContent();
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
                    UserControls.Scrape.Instance.ReloadContent();
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
                    UserControls.Vacancies.Instance.ReloadContent();
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
                    UserControls.Blacklist.Instance.ReloadContent();
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
                    UserControls.Done.Instance.ReloadContent();
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
                    UserControls.Companies.Instance.ReloadContent();
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
                    UserControls.Settings.Instance.ReloadContent();
                    break;
                default:
                    break;
            }
        }
    }
}
