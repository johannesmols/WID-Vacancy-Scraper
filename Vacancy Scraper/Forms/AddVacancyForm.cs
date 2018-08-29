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

        private JsonResourceManager<CompanyObject> _companyManager = new JsonResourceManager<CompanyObject>(ResourceType.Companies);

        private bool _askToClose = true;
        private bool _askedToClose = false;

        public AddVacancyForm()
        {
            InitializeComponent();
            ReturnVacancies = new List<VacancyObject>();

            var companiesManager = new JsonResourceManager<CompanyObject>(ResourceType.Companies);
            foreach (var company in companiesManager.Resources)
            {
                comboCompanies.Items.Add(company.Name);
            }
            comboCompanies.Sorted = true;
        }

        /// <summary>
        /// Try returning a Vacancy object list with the data and close the dialog.
        /// If the data is invalid, notify the user and leave the dialog open.
        /// If the data already exists in a resource, ask the user if he still wants to add the duplicate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdAdd_Click(object sender, EventArgs e)
        {
            _askToClose = false;

            var errors = GetInputFeedback();
            if (errors.Count == 0 && IsInputValid())
            {
                var toCheck = new VacancyObject(comboCompanies.Text, txtVacancy.Text, DateTime.Now, string.Empty);

                string msg = null;
                if (IsDuplicate(ResourceType.Vacancies, toCheck) && msg == null)
                    msg = @"Vacancy already exists in vacancies list. Do you still want to add it? (Duplicate: " + GetDuplicate(ResourceType.Vacancies, toCheck).Added + @")";

                if (IsDuplicate(ResourceType.Done, toCheck) && msg == null)
                    msg = @"Vacancy already exists in completed vacancies list. Do you still want to add it? (Duplicate: " + GetDuplicate(ResourceType.Done, toCheck).Added + @")";

                if (IsDuplicate(ResourceType.Blacklist, toCheck) && msg == null)
                    msg = @"Vacancy already exists in blacklist. Do you still want to add it? (Duplicate: " + GetDuplicate(ResourceType.Blacklist, toCheck).Added + @")";

                if (ReturnVacancies.Contains(toCheck) && msg == null) // check if vacancy was already entered before in this session
                    msg = @"Vacancy already entered. Do you still want to add it?";


                if (msg != null)
                {
                    var dialogResult = MessageBox.Show(msg, @"Found duplicate", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult != DialogResult.Yes)
                    {
                        return;
                    }
                }

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
            _askToClose = false;
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
            _askToClose = true;
            //doesn't assign anything
            AskToClose();
        }

        /// <summary>
        /// Check if the user really wants to close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVacancyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_askToClose)
            {
                if (!_askedToClose)
                {
                    _askedToClose = true;
                    e.Cancel = AskToClose();
                }
            }
        }

        /// <summary>
        /// Ask the user if he really wants to close the dialog without saving
        /// </summary>
        /// <returns>determines if the dialog should stay open</returns>
        private bool AskToClose()
        {
            if (ReturnVacancies.Count > 0)
            {
                var result = MessageBox.Show(@"Are you sure?", @"Close without saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return false;
                }
                else if (result == DialogResult.No)
                {
                    this.DialogResult = DialogResult.None;
                    return true;
                }
            }

            return false;
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
                errors.Add("Please enter a URL");

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

        /// <summary>
        /// Update the CVR info box according to the selected company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCVR.Text = _companyManager.Resources.First(i => i.Name == comboCompanies.Text).Cvr.ToString();
                txtTelephone.Text = _companyManager.Resources.First(i => i.Name == comboCompanies.Text).Telephone;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Check a new vacancy for local duplicates in all three vacancy lists (only company and title are considered in the comparison)
        /// <param name="type">the object type</param>
        /// <param name="vacancy">the object to find a duplicate of</param>
        /// </summary>
        /// <returns>if the vacancy already exists in a resource</returns>
        private bool IsDuplicate(ResourceType type, VacancyObject vacancy)
        {
            return new JsonResourceManager<VacancyObject>(type).Resources.Contains(vacancy);
        }

        /// <summary>
        /// Find a duplicate in the resource and return it (only company and title are considered in the comparison)
        /// </summary>
        /// <param name="type">the object type</param>
        /// <param name="vacancy">the object to find a duplicate of</param>
        /// <returns></returns>
        private VacancyObject GetDuplicate(ResourceType type, VacancyObject vacancy)
        {
            return new JsonResourceManager<VacancyObject>(type).Resources.Find(v => Equals(v, vacancy));
        }
    }
}
