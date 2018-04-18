using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Vacancy_Scraper.Forms;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.UserControls
{
    public partial class Companies : UserControl
    {
        private static Companies _instance;

        private CompaniesManager _companiesManager;
        private BindingList<CompanyObject> _bindingList;

        private bool _isSortedDescendingOrUnsorted = true;
        private bool _searchActive = false; // Indicates whether or not the user is searching, or otherwise the list would be filtered by the hint in the search box

        public static Companies Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Companies();
                return _instance;
            }
        }

        public Companies()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets called when the active tab in the tab control is changed
        /// This is to notify the user controls of the change and make adjustments based on the change
        /// </summary>
        public void NotifyTabChanged(MainForm.Tabs oldTab, MainForm.Tabs newTab)
        {
            if (newTab == MainForm.Tabs.Companies)
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
            _companiesManager = new CompaniesManager();
            _bindingList = new BindingList<CompanyObject>(_companiesManager.Companies);
            var source = new BindingSource(_bindingList, null);
            gridCompanies.DataSource = source;
            AdjustTableSettings();
        }

        /// <summary>
        /// Change some settings regarding the behaviour of the data grid view
        /// </summary>
        private void AdjustTableSettings()
        {
            int colCount = 9;
            if (gridCompanies.Columns.Count == colCount)
            {
                // Column Header Text
                gridCompanies.Columns[0].HeaderText = @"Name";
                gridCompanies.Columns[1].HeaderText = @"CVR";
                gridCompanies.Columns[2].HeaderText = @"P-No.";
                gridCompanies.Columns[3].HeaderText = @"Telephone";
                gridCompanies.Columns[4].HeaderText = @"Consultants";
                gridCompanies.Columns[5].HeaderText = @"Enabled";
                gridCompanies.Columns[6].HeaderText = @"Selected";
                gridCompanies.Columns[7].HeaderText = @"Comment";
                gridCompanies.Columns[8].HeaderText = @"URL";

                // Fill Weight when auto filling
                gridCompanies.Columns[0].FillWeight = 100;
                gridCompanies.Columns[1].FillWeight = 75;
                gridCompanies.Columns[2].FillWeight = 75;
                gridCompanies.Columns[3].FillWeight = 75;
                gridCompanies.Columns[4].FillWeight = 100;
                gridCompanies.Columns[5].FillWeight = 50;
                gridCompanies.Columns[6].FillWeight = 50;
                gridCompanies.Columns[7].FillWeight = 200;
                gridCompanies.Columns[8].FillWeight = 200;

                // Special settings for the enabled column
                gridCompanies.Columns[5].ReadOnly = true;
                gridCompanies.Columns[5].Resizable = DataGridViewTriState.False;
                gridCompanies.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                gridCompanies.Columns[5].Width = 50;
                gridCompanies.Columns[5].ToolTipText = @"This value can't be changed. Please contact the developer for activation.";

                // Hide the selected column, this should only be shown in the Scrape tab
                gridCompanies.Columns[6].Visible = false;

                // Show a tooltip that the user can open the URL by control clicking it
                gridCompanies.Columns[8].ToolTipText = @"Control-click to open URL";

                // Equal settings for all columns
                for (int i = 0; i < colCount; i++)
                {
                    gridCompanies.Columns[i].MinimumWidth = 50;
                    gridCompanies.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
        }

        /// <summary>
        /// Show cells with a valid URL with special formatting to show that it is clickable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCompanies_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gridCompanies.Rows)
            {
                var cell = row.Cells["URL"];
                if (System.Uri.IsWellFormedUriString(cell.Value.ToString(), UriKind.Absolute))
                {
                    cell.Style.Font = new Font(DefaultFont, FontStyle.Underline);
                    cell.Style.ForeColor = Color.Green;
                }
            }
        }

        /// <summary>
        /// Open the URL if it is valid and the user control-clicked the link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCompanies_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.Control)
            {
                var cell = gridCompanies.Rows[e.RowIndex].Cells[e.ColumnIndex];
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
        private void TxtSearch_Enter(object sender, EventArgs e)
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
        private void TxtSearch_Leave(object sender, EventArgs e)
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
                    gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.Where(m => m.Name.Contains(filter)).ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error while searching", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add a company to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddCompanyForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    CompanyObject newCompany = form.ReturnCompany;
                    _bindingList.Add(newCompany);
                    _companiesManager.SaveChangesToFile();
                    ReloadContent();
                }
            }
        }

        /// <summary>
        /// Delete one or more companies from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            var message = gridCompanies.SelectedRows.Count == 1 ? 
                @"Do you want to delete this company?" : "Do you want to delete " + gridCompanies.SelectedRows.Count + @" companies?";
            var title = gridCompanies.SelectedRows.Count == 1 ? @"Delete company" : @"Delete companies";
            DialogResult dialogResult = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in gridCompanies.SelectedRows)
                {
                    _bindingList.RemoveAt(row.Index);
                }
                _companiesManager.SaveChangesToFile();
                ReloadContent(); // refresh the page to avoid a bug that the row isn't visually getting removed from the table when the grid view wasn't focused at the point of clicking the delete button
            }  
        }

        /* --- Data Grid View Events --- */

        /// <summary>
        /// Show a message to the user if the given input is invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCompanies_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(@"This change cannot be made. Please only use the proper data type.", @"Error editing cell", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Write the changes to the file if the user changed a value in the table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCompanies_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            _companiesManager.SaveChangesToFile();
        }

        /// <summary>
        /// Sort by the column when clicking on the column header
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCompanies_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_isSortedDescendingOrUnsorted)
            {
                switch (e.ColumnIndex)
                {
                    case 0: // Name
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Name).ToList());
                        break;
                    case 1: // CVR
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Cvr).ToList());
                        break;
                    case 2: // P-No.
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.PNo).ToList());
                        break;
                    case 3: // Telephone
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Telephone).ToList());
                        break;
                    case 4: // Consultants
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Consultants).ToList());
                        break;
                    case 5: // Enabled
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Enabled).ToList());
                        break;
                    case 6:
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Selected).ToList());
                        break;
                    case 7: // Comment
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Comment).ToList());
                        break;
                    case 8: // Url
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderBy(x => x.Url).ToList());
                        break;
                }

                gridCompanies.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                _isSortedDescendingOrUnsorted = false;
            }
            else
            {
                switch (e.ColumnIndex)
                {
                    case 0: // Name
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Name).ToList());
                        break;
                    case 1: // CVR
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Cvr).ToList());
                        break;
                    case 2: // P-No.
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.PNo).ToList());
                        break;
                    case 3: // Telephone
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Telephone).ToList());
                        break;
                    case 4: // Consultants
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Consultants).ToList());
                        break;
                    case 5: // Enabled
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Enabled).ToList());
                        break;
                    case 6: // Selected
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Selected).ToList());
                        break;
                    case 7: // Comment
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Comment).ToList());
                        break;
                    case 8: // Url
                        gridCompanies.DataSource = new BindingList<CompanyObject>(_bindingList.OrderByDescending(x => x.Url).ToList());
                        break;
                }

                gridCompanies.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                _isSortedDescendingOrUnsorted = true;
            }
        }
    }
}
