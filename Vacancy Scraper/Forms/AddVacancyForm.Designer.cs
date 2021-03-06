﻿namespace Vacancy_Scraper.Forms
{
    partial class AddVacancyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddVacancyForm));
            this.lblCompany = new System.Windows.Forms.Label();
            this.comboCompanies = new System.Windows.Forms.ComboBox();
            this.lblVacancy = new System.Windows.Forms.Label();
            this.txtVacancy = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.checkAddMultiple = new System.Windows.Forms.CheckBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblCVR = new System.Windows.Forms.Label();
            this.txtCVR = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.cmdCopyCVR = new System.Windows.Forms.Button();
            this.cmdCopyTelephone = new System.Windows.Forms.Button();
            this.cmdCopyComment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            resources.ApplyResources(this.lblCompany, "lblCompany");
            this.lblCompany.Name = "lblCompany";
            // 
            // comboCompanies
            // 
            this.comboCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCompanies.FormattingEnabled = true;
            resources.ApplyResources(this.comboCompanies, "comboCompanies");
            this.comboCompanies.Name = "comboCompanies";
            this.comboCompanies.Sorted = true;
            this.comboCompanies.SelectedIndexChanged += new System.EventHandler(this.ComboCompanies_SelectedIndexChanged);
            this.comboCompanies.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // lblVacancy
            // 
            resources.ApplyResources(this.lblVacancy, "lblVacancy");
            this.lblVacancy.Name = "lblVacancy";
            // 
            // txtVacancy
            // 
            resources.ApplyResources(this.txtVacancy, "txtVacancy");
            this.txtVacancy.Name = "txtVacancy";
            this.txtVacancy.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // txtUrl
            // 
            resources.ApplyResources(this.txtUrl, "txtUrl");
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // lblUrl
            // 
            resources.ApplyResources(this.lblUrl, "lblUrl");
            this.lblUrl.Name = "lblUrl";
            // 
            // checkAddMultiple
            // 
            resources.ApplyResources(this.checkAddMultiple, "checkAddMultiple");
            this.checkAddMultiple.Name = "checkAddMultiple";
            this.checkAddMultiple.TabStop = false;
            this.checkAddMultiple.UseVisualStyleBackColor = true;
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.CmdCloseAndSave_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // cmdAdd
            // 
            resources.ApplyResources(this.cmdAdd, "cmdAdd");
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // lblCVR
            // 
            resources.ApplyResources(this.lblCVR, "lblCVR");
            this.lblCVR.Name = "lblCVR";
            // 
            // txtCVR
            // 
            resources.ApplyResources(this.txtCVR, "txtCVR");
            this.txtCVR.Name = "txtCVR";
            this.txtCVR.ReadOnly = true;
            // 
            // txtTelephone
            // 
            resources.ApplyResources(this.txtTelephone, "txtTelephone");
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.ReadOnly = true;
            // 
            // lblTelephone
            // 
            resources.ApplyResources(this.lblTelephone, "lblTelephone");
            this.lblTelephone.Name = "lblTelephone";
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            // 
            // lblComment
            // 
            resources.ApplyResources(this.lblComment, "lblComment");
            this.lblComment.Name = "lblComment";
            // 
            // cmdCopyCVR
            // 
            this.cmdCopyCVR.BackgroundImage = global::Vacancy_Scraper.Properties.Resources.copy;
            resources.ApplyResources(this.cmdCopyCVR, "cmdCopyCVR");
            this.cmdCopyCVR.Name = "cmdCopyCVR";
            this.cmdCopyCVR.UseVisualStyleBackColor = true;
            this.cmdCopyCVR.Click += new System.EventHandler(this.CmdCopyCVR_Click);
            // 
            // cmdCopyTelephone
            // 
            this.cmdCopyTelephone.BackgroundImage = global::Vacancy_Scraper.Properties.Resources.copy;
            resources.ApplyResources(this.cmdCopyTelephone, "cmdCopyTelephone");
            this.cmdCopyTelephone.Name = "cmdCopyTelephone";
            this.cmdCopyTelephone.UseVisualStyleBackColor = true;
            this.cmdCopyTelephone.Click += new System.EventHandler(this.CmdCopyTelephone_Click);
            // 
            // cmdCopyComment
            // 
            this.cmdCopyComment.BackgroundImage = global::Vacancy_Scraper.Properties.Resources.copy;
            resources.ApplyResources(this.cmdCopyComment, "cmdCopyComment");
            this.cmdCopyComment.Name = "cmdCopyComment";
            this.cmdCopyComment.UseVisualStyleBackColor = true;
            this.cmdCopyComment.Click += new System.EventHandler(this.CmdCopyComment_Click);
            // 
            // AddVacancyForm
            // 
            this.AcceptButton = this.cmdAdd;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.cmdCopyComment);
            this.Controls.Add(this.cmdCopyTelephone);
            this.Controls.Add(this.cmdCopyCVR);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.txtCVR);
            this.Controls.Add(this.lblCVR);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.checkAddMultiple);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.txtVacancy);
            this.Controls.Add(this.lblVacancy);
            this.Controls.Add(this.comboCompanies);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddVacancyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddVacancyForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox comboCompanies;
        private System.Windows.Forms.Label lblVacancy;
        private System.Windows.Forms.TextBox txtVacancy;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.CheckBox checkAddMultiple;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblCVR;
        private System.Windows.Forms.TextBox txtCVR;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Button cmdCopyCVR;
        private System.Windows.Forms.Button cmdCopyTelephone;
        private System.Windows.Forms.Button cmdCopyComment;
    }
}