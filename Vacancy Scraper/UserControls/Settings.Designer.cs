namespace Vacancy_Scraper.UserControls
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupSettingsPaths = new System.Windows.Forms.GroupBox();
            this.linkLblSettingsResourcesPath = new System.Windows.Forms.LinkLabel();
            this.lblSettingsResourcesStatus = new System.Windows.Forms.Label();
            this.cmdSettingsBrowseResourceFolder = new System.Windows.Forms.Button();
            this.txtSettingsResourcesPath = new System.Windows.Forms.TextBox();
            this.lblSettingsResources = new System.Windows.Forms.Label();
            this.linkLblSettingsWebDriversPath = new System.Windows.Forms.LinkLabel();
            this.lblSettingsWebDriversPathStatus = new System.Windows.Forms.Label();
            this.cmdSettingsBrowseWebDriversPath = new System.Windows.Forms.Button();
            this.txtSettingsWebDriversPath = new System.Windows.Forms.TextBox();
            this.lblSettingsWebDrivers = new System.Windows.Forms.Label();
            this.cmdSettingsCancel = new System.Windows.Forms.Button();
            this.cmdSettingsApply = new System.Windows.Forms.Button();
            this.groupSettingsPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupSettingsPaths
            // 
            this.groupSettingsPaths.Controls.Add(this.linkLblSettingsResourcesPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsResourcesStatus);
            this.groupSettingsPaths.Controls.Add(this.cmdSettingsBrowseResourceFolder);
            this.groupSettingsPaths.Controls.Add(this.txtSettingsResourcesPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsResources);
            this.groupSettingsPaths.Controls.Add(this.linkLblSettingsWebDriversPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsWebDriversPathStatus);
            this.groupSettingsPaths.Controls.Add(this.cmdSettingsBrowseWebDriversPath);
            this.groupSettingsPaths.Controls.Add(this.txtSettingsWebDriversPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsWebDrivers);
            this.groupSettingsPaths.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSettingsPaths.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupSettingsPaths.Location = new System.Drawing.Point(0, 0);
            this.groupSettingsPaths.Name = "groupSettingsPaths";
            this.groupSettingsPaths.Size = new System.Drawing.Size(676, 110);
            this.groupSettingsPaths.TabIndex = 3;
            this.groupSettingsPaths.TabStop = false;
            this.groupSettingsPaths.Text = "Paths";
            // 
            // linkLblSettingsResourcesPath
            // 
            this.linkLblSettingsResourcesPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLblSettingsResourcesPath.AutoSize = true;
            this.linkLblSettingsResourcesPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLblSettingsResourcesPath.Location = new System.Drawing.Point(595, 87);
            this.linkLblSettingsResourcesPath.Name = "linkLblSettingsResourcesPath";
            this.linkLblSettingsResourcesPath.Size = new System.Drawing.Size(10, 13);
            this.linkLblSettingsResourcesPath.TabIndex = 9;
            this.linkLblSettingsResourcesPath.TabStop = true;
            this.linkLblSettingsResourcesPath.Text = "-";
            // 
            // lblSettingsResourcesStatus
            // 
            this.lblSettingsResourcesStatus.AutoSize = true;
            this.lblSettingsResourcesStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsResourcesStatus.Location = new System.Drawing.Point(81, 88);
            this.lblSettingsResourcesStatus.Name = "lblSettingsResourcesStatus";
            this.lblSettingsResourcesStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSettingsResourcesStatus.TabIndex = 8;
            this.lblSettingsResourcesStatus.Text = "Status:";
            // 
            // cmdSettingsBrowseResourceFolder
            // 
            this.cmdSettingsBrowseResourceFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSettingsBrowseResourceFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsBrowseResourceFolder.Location = new System.Drawing.Point(595, 59);
            this.cmdSettingsBrowseResourceFolder.Name = "cmdSettingsBrowseResourceFolder";
            this.cmdSettingsBrowseResourceFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsBrowseResourceFolder.TabIndex = 7;
            this.cmdSettingsBrowseResourceFolder.Text = "Browse...";
            this.cmdSettingsBrowseResourceFolder.UseVisualStyleBackColor = true;
            this.cmdSettingsBrowseResourceFolder.Click += new System.EventHandler(this.CmdSettingsBrowseResourceFolder_Click);
            // 
            // txtSettingsResourcesPath
            // 
            this.txtSettingsResourcesPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsResourcesPath.Location = new System.Drawing.Point(81, 61);
            this.txtSettingsResourcesPath.Name = "txtSettingsResourcesPath";
            this.txtSettingsResourcesPath.Size = new System.Drawing.Size(508, 20);
            this.txtSettingsResourcesPath.TabIndex = 6;
            // 
            // lblSettingsResources
            // 
            this.lblSettingsResources.AutoSize = true;
            this.lblSettingsResources.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsResources.Location = new System.Drawing.Point(6, 64);
            this.lblSettingsResources.Name = "lblSettingsResources";
            this.lblSettingsResources.Size = new System.Drawing.Size(61, 13);
            this.lblSettingsResources.TabIndex = 5;
            this.lblSettingsResources.Text = "Resources:";
            // 
            // linkLblSettingsWebDriversPath
            // 
            this.linkLblSettingsWebDriversPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLblSettingsWebDriversPath.AutoSize = true;
            this.linkLblSettingsWebDriversPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLblSettingsWebDriversPath.Location = new System.Drawing.Point(595, 39);
            this.linkLblSettingsWebDriversPath.Name = "linkLblSettingsWebDriversPath";
            this.linkLblSettingsWebDriversPath.Size = new System.Drawing.Size(10, 13);
            this.linkLblSettingsWebDriversPath.TabIndex = 4;
            this.linkLblSettingsWebDriversPath.TabStop = true;
            this.linkLblSettingsWebDriversPath.Text = "-";
            // 
            // lblSettingsWebDriversPathStatus
            // 
            this.lblSettingsWebDriversPathStatus.AutoSize = true;
            this.lblSettingsWebDriversPathStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsWebDriversPathStatus.Location = new System.Drawing.Point(81, 40);
            this.lblSettingsWebDriversPathStatus.Name = "lblSettingsWebDriversPathStatus";
            this.lblSettingsWebDriversPathStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSettingsWebDriversPathStatus.TabIndex = 3;
            this.lblSettingsWebDriversPathStatus.Text = "Status:";
            // 
            // cmdSettingsBrowseWebDriversPath
            // 
            this.cmdSettingsBrowseWebDriversPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSettingsBrowseWebDriversPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsBrowseWebDriversPath.Location = new System.Drawing.Point(595, 11);
            this.cmdSettingsBrowseWebDriversPath.Name = "cmdSettingsBrowseWebDriversPath";
            this.cmdSettingsBrowseWebDriversPath.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsBrowseWebDriversPath.TabIndex = 2;
            this.cmdSettingsBrowseWebDriversPath.Text = "Browse...";
            this.cmdSettingsBrowseWebDriversPath.UseVisualStyleBackColor = true;
            this.cmdSettingsBrowseWebDriversPath.Click += new System.EventHandler(this.CmdSettingsBrowseWebDriversPath_Click);
            // 
            // txtSettingsWebDriversPath
            // 
            this.txtSettingsWebDriversPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsWebDriversPath.Location = new System.Drawing.Point(81, 13);
            this.txtSettingsWebDriversPath.Name = "txtSettingsWebDriversPath";
            this.txtSettingsWebDriversPath.Size = new System.Drawing.Size(508, 20);
            this.txtSettingsWebDriversPath.TabIndex = 1;
            // 
            // lblSettingsWebDrivers
            // 
            this.lblSettingsWebDrivers.AutoSize = true;
            this.lblSettingsWebDrivers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsWebDrivers.Location = new System.Drawing.Point(6, 16);
            this.lblSettingsWebDrivers.Name = "lblSettingsWebDrivers";
            this.lblSettingsWebDrivers.Size = new System.Drawing.Size(69, 13);
            this.lblSettingsWebDrivers.TabIndex = 0;
            this.lblSettingsWebDrivers.Text = "Web Drivers:";
            // 
            // cmdSettingsCancel
            // 
            this.cmdSettingsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSettingsCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsCancel.Location = new System.Drawing.Point(510, 357);
            this.cmdSettingsCancel.Name = "cmdSettingsCancel";
            this.cmdSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsCancel.TabIndex = 5;
            this.cmdSettingsCancel.Text = "Cancel";
            this.cmdSettingsCancel.UseVisualStyleBackColor = true;
            this.cmdSettingsCancel.Click += new System.EventHandler(this.CmdSettingsCancel_Click);
            // 
            // cmdSettingsApply
            // 
            this.cmdSettingsApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSettingsApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsApply.Location = new System.Drawing.Point(591, 357);
            this.cmdSettingsApply.Name = "cmdSettingsApply";
            this.cmdSettingsApply.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsApply.TabIndex = 4;
            this.cmdSettingsApply.Text = "Apply";
            this.cmdSettingsApply.UseVisualStyleBackColor = true;
            this.cmdSettingsApply.Click += new System.EventHandler(this.CmdSettingsApply_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupSettingsPaths);
            this.Controls.Add(this.cmdSettingsCancel);
            this.Controls.Add(this.cmdSettingsApply);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(676, 385);
            this.groupSettingsPaths.ResumeLayout(false);
            this.groupSettingsPaths.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupSettingsPaths;
        private System.Windows.Forms.LinkLabel linkLblSettingsResourcesPath;
        private System.Windows.Forms.Label lblSettingsResourcesStatus;
        private System.Windows.Forms.Button cmdSettingsBrowseResourceFolder;
        private System.Windows.Forms.TextBox txtSettingsResourcesPath;
        private System.Windows.Forms.Label lblSettingsResources;
        private System.Windows.Forms.LinkLabel linkLblSettingsWebDriversPath;
        private System.Windows.Forms.Label lblSettingsWebDriversPathStatus;
        private System.Windows.Forms.Button cmdSettingsBrowseWebDriversPath;
        private System.Windows.Forms.TextBox txtSettingsWebDriversPath;
        private System.Windows.Forms.Label lblSettingsWebDrivers;
        private System.Windows.Forms.Button cmdSettingsCancel;
        private System.Windows.Forms.Button cmdSettingsApply;
    }
}
