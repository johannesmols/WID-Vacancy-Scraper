﻿using System;
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
    public partial class Vacancies : UserControl
    {
        private static Vacancies _instance;

        private JsonResourceManager<VacancyObject> _vacanciesManager;
        private BindingList<VacancyObject> _bindingList;

        private bool _isSortedDescendingOrUnsorted = true;
        private bool _searchActive = false; // Indicates whether or not the user is searching, or otherwise the list would be filtered by the hint in the search box

        public static Vacancies Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Vacancies();
                return _instance;
            }
        }

        public Vacancies()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets called when the active tab in the tab control is changed
        /// This is to notify the user controls of the change and make adjustments based on the change
        /// </summary>
        public void NotifyTabChanged(MainForm.Tabs oldTab, MainForm.Tabs newTab)
        {
            if (newTab == MainForm.Tabs.Vacancies)
            {
                ReloadContent();
            }
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {
            txtSearch.Text = @"Search...";
            txtSearch.ForeColor = SystemColors.GrayText;

            // Fill table
            _vacanciesManager = new JsonResourceManager<VacancyObject>(ResourceType.Vacancies);
            _bindingList = new BindingList<VacancyObject>(_vacanciesManager.Resources);
            var source = new BindingSource(_bindingList, null);
            gridVacancies.DataSource = source;
            AdjustTableSettings();
        }

        /// <summary>
        /// Change some settings regarding the behaviour of the data grid view
        /// </summary>
        private void AdjustTableSettings()
        {
            int colCount = 4;
            if (gridVacancies.Columns.Count == colCount)
            {
                // Column Header Text
                gridVacancies.Columns[0].HeaderText = @"Company";
                gridVacancies.Columns[1].HeaderText = @"Vacancy Title";
                gridVacancies.Columns[2].HeaderText = @"Date Added";
                gridVacancies.Columns[3].HeaderText = @"URL";

                // Fill Weight when auto filling
                gridVacancies.Columns[0].FillWeight = 75;
                gridVacancies.Columns[1].FillWeight = 150;
                gridVacancies.Columns[2].FillWeight = 75;
                gridVacancies.Columns[3].FillWeight = 100;

                // Date can't be changed
                gridVacancies.Columns[2].ReadOnly = true;

                // Show a tooltip that the user can open the URL by control clicking it
                gridVacancies.Columns[3].ToolTipText = @"Control-click to open URL";

                // Equal settings for all columns
                for (int i = 0; i < colCount; i++)
                {
                    gridVacancies.Columns[i].MinimumWidth = 50;
                    gridVacancies.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
        }

        /// <summary>
        /// Show cells with a valid URL with special formatting to show that it is clickable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVacancies_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatUrls();
        }

        /// <summary>
        /// Format valid URLs with a special style and reset all other cells to the default style
        /// This needs to be done, in case a valid URL gets changed to an invalid URL. This method will reset it's former URL style to the default again
        /// </summary>
        private void FormatUrls()
        {
            foreach (DataGridViewRow row in gridVacancies.Rows)
            {
                var cell = row.Cells["URL"];
                if (System.Uri.IsWellFormedUriString(cell.Value.ToString(), UriKind.Absolute))
                {
                    cell.Style.Font = new Font(DefaultFont, FontStyle.Underline);
                    cell.Style.ForeColor = Color.Green;
                }
                else
                {
                    cell.Style.Font = DefaultFont;
                    cell.Style.ForeColor = DefaultForeColor;
                }
            }
        }

        /// <summary>
        /// Open the URL if it is valid and the user control-clicked the link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVacancies_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
            {
                var cell = gridVacancies.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (System.Uri.IsWellFormedUriString(cell.Value.ToString(), UriKind.Absolute))
                {
                    System.Diagnostics.Process.Start(cell.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Clear placeholder of search box when entering focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            _searchActive = true;
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text.Equals("Search..."))
            {
                txtSearch.ForeColor = SystemColors.ControlText;
                txtSearch.Text = "";
            }
        }

        /// <summary>
        /// Add placeholder to the search box when leaving focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            _searchActive = false;
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = SystemColors.GrayText;
                txtSearch.Text = @"Search...";
            }
        }

        /// <summary>
        /// Filter data by the company name when searching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_searchActive)
                {
                    string filter = txtSearch.Text.Trim().Replace("'", "''");
                    gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.Where(m => m.Title.Contains(filter)).ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error while searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add a vacancy to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddVacancyForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<VacancyObject> newVacancies = form.ReturnVacancies;
                    foreach (var vacancy in newVacancies)
                    {
                        _bindingList.Add(vacancy);
                    }
                    _vacanciesManager.SaveChangesToFile();
                    ReloadContent();
                }
            }
        }

        /// <summary>
        /// Delete one or more vacancies from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (gridVacancies.SelectedRows.Count <= 0) return;

            var message = gridVacancies.SelectedRows.Count == 1 ?
                @"Do you want to delete this vacancy?" : "Do you want to delete " + gridVacancies.SelectedRows.Count + @" vacancies?";
            var title = gridVacancies.SelectedRows.Count == 1 ? @"Delete vacancy" : @"Delete vacancies";
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in gridVacancies.SelectedRows)
                {
                    _bindingList.RemoveAt(row.Index);
                }
                _vacanciesManager.SaveChangesToFile();
                ReloadContent(); // refresh the page to avoid a bug that the row isn't visually getting removed from the table when the grid view wasn't focused at the point of clicking the delete button
            }
        }

        /// <summary>
        /// Add a vacancy to the blacklist so that the scraper always ignores this vacancy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddToBlacklist_Click(object sender, EventArgs e)
        {
            if (gridVacancies.SelectedRows.Count <= 0) return;

            var message = gridVacancies.SelectedRows.Count > 1
                ? @"Add " + gridVacancies.SelectedRows.Count + @" vacancies to the blacklist?"
                : @"Add this vacancy to the blacklist?";

            var result = MessageBox.Show(message, @"Add to blacklist", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                JsonResourceManager<VacancyObject> blacklistManager = new JsonResourceManager<VacancyObject>(ResourceType.Blacklist);

                var rows = gridVacancies.SelectedRows;
                for (int i = 0; i < rows.Count; i++)
                {
                    // Add to blacklist
                    VacancyObject currentObject = (VacancyObject)rows[i].DataBoundItem;
                    currentObject.Added = DateTime.Now;
                    blacklistManager.Resources.Add(currentObject);

                    // Remove from vacancies list
                    _bindingList.RemoveAt(rows[i].Index);
                }
                blacklistManager.SaveChangesToFile();
                _vacanciesManager.SaveChangesToFile();
                ReloadContent();
            }
        }

        /// <summary>
        /// Mark this vacancy as done so that the scraper ignores this vacancy for a while, and is available for export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMarkAsDone_Click(object sender, EventArgs e)
        {
            if (gridVacancies.SelectedRows.Count <= 0) return;

            var message = gridVacancies.SelectedRows.Count > 1
                ? @"Mark " + gridVacancies.SelectedRows.Count + @" vacancies as done?"
                : @"Mark this vacancy as done?";

            var result = MessageBox.Show(message, @"Mark as done", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                JsonResourceManager<VacancyObject> doneManager = new JsonResourceManager<VacancyObject>(ResourceType.Done);

                var rows = gridVacancies.SelectedRows;
                for (int i = 0; i < rows.Count; i++)
                {
                    // Add to Done list
                    VacancyObject currentObject = (VacancyObject)rows[i].DataBoundItem;
                    currentObject.Added = DateTime.Now;
                    doneManager.Resources.Add(currentObject);

                    // Remove from vacancies list
                    _bindingList.RemoveAt(rows[i].Index);
                }
                doneManager.SaveChangesToFile();
                _vacanciesManager.SaveChangesToFile();
                ReloadContent();
            }
        }

        /* --- Data Grid View Events --- */

        /// <summary>
        /// Show a message to the user if the given input is invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVacancies_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(@"This change cannot be made. Please only use the proper data type.", @"Error editing cell", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Write the changes to the file if the user changed a value in the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVacancies_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _vacanciesManager.SaveChangesToFile();
            FormatUrls();
        }

        /// <summary>
        /// Sort by the column when clicking on the column header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridVacancies_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_isSortedDescendingOrUnsorted)
            {
                switch (e.ColumnIndex)
                {
                    case 0: // Name
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderBy(x => x.Company).ToList());
                        break;
                    case 1: // CVR
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderBy(x => x.Title).ToList());
                        break;
                    case 2: // P-No.
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderBy(x => x.Added).ToList());
                        break;
                    case 3: // Telephone
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderBy(x => x.Url).ToList());
                        break;
                }

                gridVacancies.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                _isSortedDescendingOrUnsorted = false;
            }
            else
            {
                switch (e.ColumnIndex)
                {
                    case 0: // Name
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderByDescending(x => x.Company).ToList());
                        break;
                    case 1: // CVR
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderByDescending(x => x.Title).ToList());
                        break;
                    case 2: // P-No.
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderByDescending(x => x.Added).ToList());
                        break;
                    case 3: // Telephone
                        gridVacancies.DataSource = new BindingList<VacancyObject>(_bindingList.OrderByDescending(x => x.Url).ToList());
                        break;
                }

                gridVacancies.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                _isSortedDescendingOrUnsorted = true;
            }
        }
    }
}
