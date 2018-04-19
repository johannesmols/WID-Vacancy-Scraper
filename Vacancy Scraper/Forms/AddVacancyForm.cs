using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Forms
{
    public partial class AddVacancyForm : Form
    {
        public List<VacancyObject> ReturnVacancies { get; }

        public AddVacancyForm()
        {
            InitializeComponent();
            ReturnVacancies = new List<VacancyObject>();

            JsonResourceManager<CompanyObject> companiesManager = new JsonResourceManager<CompanyObject>(ResourceType.Companies);
            foreach (var company in companiesManager.Resources)
            {
                comboCompanies.Items.Add(company.Name);
            }
        }

        /// <summary>
        /// Try returning a Vacancy object list with the data and close the dialog.
        /// If the data is invalid, notify the user and leave the dialog open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            var errors = GetInputFeedback();
            if (errors.Count == 0 && IsInputValid())
            {
                ReturnVacancies.Add(new VacancyObject(
                    comboCompanies.Text,
                    txtVacancy.Text,
                    DateTime.Now, 
                    txtUrl.Text));

                if (!checkAddMultiple.Checked)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ClearControls();

                    // Indicate on the close button how many vacancies are to be saved
                    cmdClose.Text = @"Close and Save (" + ReturnVacancies.Count + @")";
                }
            }
            else
            {
                var errorMsg = string.Empty;
                foreach (var error in errors)
                {
                    errorMsg += error + Environment.NewLine;
                }

                MessageBox.Show(errorMsg, @"Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Close the dialog with saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdCloseAndSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Close the dialog without saving
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdCancel_Click(object sender, EventArgs e)
        {
            if (ReturnVacancies.Count > 0)
            {
                var result = MessageBox.Show(@"Are you sure?", @"Close without saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                }
            }
        }

        /// <summary>
        /// Check if all user input fields meet the requirements
        /// </summary>
        /// <returns></returns>
        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(comboCompanies.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtVacancy.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtUrl.Text)) return false;
            if (!Uri.IsWellFormedUriString(txtUrl.Text, UriKind.Absolute)) return false;

            return true;
        }

        /// <summary>
        /// Get error messages regarding the input requirements
        /// </summary>
        /// <returns></returns>
        private List<string> GetInputFeedback()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(comboCompanies.Text))
                errors.Add("Please select a company");

            if (string.IsNullOrWhiteSpace(txtVacancy.Text))
                errors.Add("Please enter a vacancy title");

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
                errors.Add("Please enter an URL");

            if (!Uri.IsWellFormedUriString(txtUrl.Text, UriKind.Absolute))
                errors.Add("URL has invalid format");

            return errors;
        }

        /// <summary>
        /// Select all text in a user control when the control gains focus, for quicker editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlFocusEnter(object sender, EventArgs e)
        {
            switch (sender)
            {
                case ComboBox combo:
                    combo.SelectAll();
                    break;
                case TextBox box:
                    box.SelectAll();
                    break;
            }
        }

        /// <summary>
        /// Empty all input controls so the user can add multiple companies
        /// </summary>
        private void ClearControls()
        {
            txtVacancy.Text = string.Empty;
            txtUrl.Text = string.Empty;
        }
    }
}
