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
    }
}
