﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Forms
{
    public partial class AddCompanyForm : Form
    {
        public List<CompanyObject> ReturnCompanies { get; private set; }

        public AddCompanyForm()
        {
            InitializeComponent();
            ReturnCompanies = new List<CompanyObject>();

            numCVR.Text = string.Empty;
            numPNo.Text = string.Empty;
            numTelephone.Text = string.Empty;
        }

        /// <summary>
        /// Try returning a Company object with the data and close the dialog.
        /// If the data is invalid, notify the user and leave the dialog open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdAdd_Click(object sender, EventArgs e)
        {
            var errors = GetInputFeedback();
            if (errors.Count == 0 && IsInputValid())
            {
                ReturnCompanies.Add(new CompanyObject(
                    txtName.Text,
                    (long) numCVR.Value,
                    (long) numPNo.Value,
                    (long) numTelephone.Value,
                    txtConsultants.Text,
                    false, // don't allow scraping by default, as new companies have to have a scraper implemented first. This can be manually changed in the file
                    true,
                    txtComment.Text,
                    txtCareerPage.Text));

                if (!checkAddMultiple.Checked)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ClearControls();

                    // Indicate on the close button how many companies are to be saved
                    cmdClose.Text = @"Close and Save (" + ReturnCompanies.Count + @")";
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Check if all user input fields meet the requirements
        /// </summary>
        /// <returns></returns>
        private bool IsInputValid()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return false;
            if (numCVR.Value < 0 || numCVR.Value > 99999999) return false;
            if (numPNo.Value < 0 || numPNo.Value > 9999999999) return false;
            if (numTelephone.Value < 0 || numTelephone.Value > 99999999) return false;
            if (string.IsNullOrWhiteSpace(txtConsultants.Text)) return false;
            if (txtConsultants.Text.Split(',').Length == 0) return false;
            if (string.IsNullOrWhiteSpace(txtCareerPage.Text)) return false;

            return true;
        }

        /// <summary>
        /// Get error messages regarding the input requirements
        /// </summary>
        /// <returns></returns>
        private List<string> GetInputFeedback()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(txtName.Text))
                errors.Add("Please enter a name");

            if (numCVR.Value < 0 || numCVR.Value > 99999999)
                errors.Add("Invalid CVR");

            if (numPNo.Value < 0 || numPNo.Value > 9999999999)
                errors.Add("Invalid P number");

            if (numTelephone.Value < 0 || numTelephone.Value > 99999999)
                errors.Add("Invalid phone number, only danish numbers allowed");

            if (string.IsNullOrWhiteSpace(txtConsultants.Text) || txtConsultants.Text.Split(',').Length == 0)
                errors.Add("Please add at least one consultant");

            if (string.IsNullOrWhiteSpace(txtCareerPage.Text))
                errors.Add("Please enter a URL");

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
                case TextBox box:
                    box.SelectAll();
                    break;
                case NumericUpDown num:
                    num.Select(0, num.Text.Length);
                    break;
            }
        }

        /// <summary>
        /// Empty all input controls so the user can add multiple companies
        /// </summary>
        private void ClearControls()
        {
            txtName.Text = string.Empty;
            numCVR.Text = string.Empty;
            numPNo.Text = string.Empty;
            numTelephone.Text = string.Empty;
            txtConsultants.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtCareerPage.Text = string.Empty;
        }
    }
}
