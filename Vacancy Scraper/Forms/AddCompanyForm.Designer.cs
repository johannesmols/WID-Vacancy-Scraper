namespace Vacancy_Scraper.Forms
{
    partial class AddCompanyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCompanyForm));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCVR = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numCVR = new System.Windows.Forms.NumericUpDown();
            this.numPNo = new System.Windows.Forms.NumericUpDown();
            this.lblPNo = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtConsultants = new System.Windows.Forms.TextBox();
            this.lblConsultants = new System.Windows.Forms.Label();
            this.lblConsultantsInfo = new System.Windows.Forms.Label();
            this.txtCareerPage = new System.Windows.Forms.TextBox();
            this.lblCareerPage = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.checkAddMultiple = new System.Windows.Forms.CheckBox();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCVR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNo)).BeginInit();
            this.SuspendLayout();
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
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblCVR
            // 
            resources.ApplyResources(this.lblCVR, "lblCVR");
            this.lblCVR.Name = "lblCVR";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // numCVR
            // 
            resources.ApplyResources(this.numCVR, "numCVR");
            this.numCVR.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numCVR.Name = "numCVR";
            this.numCVR.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // numPNo
            // 
            resources.ApplyResources(this.numPNo, "numPNo");
            this.numPNo.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numPNo.Name = "numPNo";
            this.numPNo.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // lblPNo
            // 
            resources.ApplyResources(this.lblPNo, "lblPNo");
            this.lblPNo.Name = "lblPNo";
            // 
            // lblTelephone
            // 
            resources.ApplyResources(this.lblTelephone, "lblTelephone");
            this.lblTelephone.Name = "lblTelephone";
            // 
            // txtConsultants
            // 
            resources.ApplyResources(this.txtConsultants, "txtConsultants");
            this.txtConsultants.Name = "txtConsultants";
            this.txtConsultants.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // lblConsultants
            // 
            resources.ApplyResources(this.lblConsultants, "lblConsultants");
            this.lblConsultants.Name = "lblConsultants";
            // 
            // lblConsultantsInfo
            // 
            resources.ApplyResources(this.lblConsultantsInfo, "lblConsultantsInfo");
            this.lblConsultantsInfo.Name = "lblConsultantsInfo";
            // 
            // txtCareerPage
            // 
            resources.ApplyResources(this.txtCareerPage, "txtCareerPage");
            this.txtCareerPage.Name = "txtCareerPage";
            this.txtCareerPage.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // lblCareerPage
            // 
            resources.ApplyResources(this.lblCareerPage, "lblCareerPage");
            this.lblCareerPage.Name = "lblCareerPage";
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            this.txtComment.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // lblComment
            // 
            resources.ApplyResources(this.lblComment, "lblComment");
            this.lblComment.Name = "lblComment";
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
            // txtTelephone
            // 
            resources.ApplyResources(this.txtTelephone, "txtTelephone");
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Enter += new System.EventHandler(this.ControlFocusEnter);
            // 
            // AddCompanyForm
            // 
            this.AcceptButton = this.cmdAdd;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.checkAddMultiple);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtCareerPage);
            this.Controls.Add(this.lblCareerPage);
            this.Controls.Add(this.lblConsultantsInfo);
            this.Controls.Add(this.txtConsultants);
            this.Controls.Add(this.lblConsultants);
            this.Controls.Add(this.lblTelephone);
            this.Controls.Add(this.numPNo);
            this.Controls.Add(this.lblPNo);
            this.Controls.Add(this.numCVR);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblCVR);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCompanyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.numCVR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCVR;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numCVR;
        private System.Windows.Forms.NumericUpDown numPNo;
        private System.Windows.Forms.Label lblPNo;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.TextBox txtConsultants;
        private System.Windows.Forms.Label lblConsultants;
        private System.Windows.Forms.Label lblConsultantsInfo;
        private System.Windows.Forms.TextBox txtCareerPage;
        private System.Windows.Forms.Label lblCareerPage;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.CheckBox checkAddMultiple;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtTelephone;
    }
}