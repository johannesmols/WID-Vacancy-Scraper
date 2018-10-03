namespace Vacancy_Scraper.UserControls
{
    partial class UC_Settings
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
            this.comboBrowser = new System.Windows.Forms.ComboBox();
            this.lblBrowser = new System.Windows.Forms.Label();
            this.linkLblSettingsExportPath = new System.Windows.Forms.LinkLabel();
            this.lblSettingsExportStatus = new System.Windows.Forms.Label();
            this.cmdSettingsBrowseExportFolder = new System.Windows.Forms.Button();
            this.txtSettingsExportPath = new System.Windows.Forms.TextBox();
            this.lblExportPath = new System.Windows.Forms.Label();
            this.linkLblSettingsLogsPath = new System.Windows.Forms.LinkLabel();
            this.lblSettingsLogsStatus = new System.Windows.Forms.Label();
            this.cmdSettingsBrowseLogsFolder = new System.Windows.Forms.Button();
            this.txtSettingsLogsFolderPath = new System.Windows.Forms.TextBox();
            this.lblSettingsLogs = new System.Windows.Forms.Label();
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
            this.lblSavedStatus = new System.Windows.Forms.Label();
            this.groupSettingsScraper = new System.Windows.Forms.GroupBox();
            this.comboIgnoreDuplicatesTimeMode = new System.Windows.Forms.ComboBox();
            this.numIgnoreDuplicatesValue = new System.Windows.Forms.NumericUpDown();
            this.checkScraperIgnoreDuplicatesOlderThan = new System.Windows.Forms.CheckBox();
            this.lblMore = new System.Windows.Forms.Label();
            this.checkJobnet = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBannedKeywords = new System.Windows.Forms.TextBox();
            this.lblSettingsBannedKeywords = new System.Windows.Forms.Label();
            this.comboScraperWebDriver = new System.Windows.Forms.ComboBox();
            this.lblScraperSettingsWebDriver = new System.Windows.Forms.Label();
            this.groupSettingsPaths.SuspendLayout();
            this.groupSettingsScraper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIgnoreDuplicatesValue)).BeginInit();
            this.SuspendLayout();
            // 
            // groupSettingsPaths
            // 
            this.groupSettingsPaths.Controls.Add(this.comboBrowser);
            this.groupSettingsPaths.Controls.Add(this.lblBrowser);
            this.groupSettingsPaths.Controls.Add(this.linkLblSettingsExportPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsExportStatus);
            this.groupSettingsPaths.Controls.Add(this.cmdSettingsBrowseExportFolder);
            this.groupSettingsPaths.Controls.Add(this.txtSettingsExportPath);
            this.groupSettingsPaths.Controls.Add(this.lblExportPath);
            this.groupSettingsPaths.Controls.Add(this.linkLblSettingsLogsPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsLogsStatus);
            this.groupSettingsPaths.Controls.Add(this.cmdSettingsBrowseLogsFolder);
            this.groupSettingsPaths.Controls.Add(this.txtSettingsLogsFolderPath);
            this.groupSettingsPaths.Controls.Add(this.lblSettingsLogs);
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
            this.groupSettingsPaths.Size = new System.Drawing.Size(774, 239);
            this.groupSettingsPaths.TabIndex = 3;
            this.groupSettingsPaths.TabStop = false;
            this.groupSettingsPaths.Text = "Paths";
            // 
            // comboBrowser
            // 
            this.comboBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBrowser.FormattingEnabled = true;
            this.comboBrowser.Location = new System.Drawing.Point(81, 209);
            this.comboBrowser.Name = "comboBrowser";
            this.comboBrowser.Size = new System.Drawing.Size(687, 21);
            this.comboBrowser.TabIndex = 9;
            this.comboBrowser.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblBrowser
            // 
            this.lblBrowser.AutoSize = true;
            this.lblBrowser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBrowser.Location = new System.Drawing.Point(6, 212);
            this.lblBrowser.Name = "lblBrowser";
            this.lblBrowser.Size = new System.Drawing.Size(48, 13);
            this.lblBrowser.TabIndex = 21;
            this.lblBrowser.Text = "Browser:";
            // 
            // linkLblSettingsExportPath
            // 
            this.linkLblSettingsExportPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLblSettingsExportPath.AutoSize = true;
            this.linkLblSettingsExportPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLblSettingsExportPath.Location = new System.Drawing.Point(690, 191);
            this.linkLblSettingsExportPath.Name = "linkLblSettingsExportPath";
            this.linkLblSettingsExportPath.Size = new System.Drawing.Size(10, 13);
            this.linkLblSettingsExportPath.TabIndex = 19;
            this.linkLblSettingsExportPath.TabStop = true;
            this.linkLblSettingsExportPath.Text = "-";
            // 
            // lblSettingsExportStatus
            // 
            this.lblSettingsExportStatus.AutoSize = true;
            this.lblSettingsExportStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsExportStatus.Location = new System.Drawing.Point(78, 191);
            this.lblSettingsExportStatus.Name = "lblSettingsExportStatus";
            this.lblSettingsExportStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSettingsExportStatus.TabIndex = 18;
            this.lblSettingsExportStatus.Text = "Status:";
            // 
            // cmdSettingsBrowseExportFolder
            // 
            this.cmdSettingsBrowseExportFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSettingsBrowseExportFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsBrowseExportFolder.Location = new System.Drawing.Point(693, 165);
            this.cmdSettingsBrowseExportFolder.Name = "cmdSettingsBrowseExportFolder";
            this.cmdSettingsBrowseExportFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsBrowseExportFolder.TabIndex = 17;
            this.cmdSettingsBrowseExportFolder.Text = "Browse...";
            this.cmdSettingsBrowseExportFolder.UseVisualStyleBackColor = true;
            this.cmdSettingsBrowseExportFolder.Click += new System.EventHandler(this.CmdSettingsBrowseExportFolder_Click);
            // 
            // txtSettingsExportPath
            // 
            this.txtSettingsExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsExportPath.Location = new System.Drawing.Point(81, 168);
            this.txtSettingsExportPath.Name = "txtSettingsExportPath";
            this.txtSettingsExportPath.Size = new System.Drawing.Size(606, 20);
            this.txtSettingsExportPath.TabIndex = 15;
            this.txtSettingsExportPath.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblExportPath
            // 
            this.lblExportPath.AutoSize = true;
            this.lblExportPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblExportPath.Location = new System.Drawing.Point(6, 171);
            this.lblExportPath.Name = "lblExportPath";
            this.lblExportPath.Size = new System.Drawing.Size(40, 13);
            this.lblExportPath.TabIndex = 16;
            this.lblExportPath.Text = "Export:";
            // 
            // linkLblSettingsLogsPath
            // 
            this.linkLblSettingsLogsPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLblSettingsLogsPath.AutoSize = true;
            this.linkLblSettingsLogsPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLblSettingsLogsPath.Location = new System.Drawing.Point(690, 140);
            this.linkLblSettingsLogsPath.Name = "linkLblSettingsLogsPath";
            this.linkLblSettingsLogsPath.Size = new System.Drawing.Size(10, 13);
            this.linkLblSettingsLogsPath.TabIndex = 14;
            this.linkLblSettingsLogsPath.TabStop = true;
            this.linkLblSettingsLogsPath.Text = "-";
            // 
            // lblSettingsLogsStatus
            // 
            this.lblSettingsLogsStatus.AutoSize = true;
            this.lblSettingsLogsStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsLogsStatus.Location = new System.Drawing.Point(78, 140);
            this.lblSettingsLogsStatus.Name = "lblSettingsLogsStatus";
            this.lblSettingsLogsStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSettingsLogsStatus.TabIndex = 13;
            this.lblSettingsLogsStatus.Text = "Status:";
            // 
            // cmdSettingsBrowseLogsFolder
            // 
            this.cmdSettingsBrowseLogsFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSettingsBrowseLogsFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsBrowseLogsFolder.Location = new System.Drawing.Point(693, 115);
            this.cmdSettingsBrowseLogsFolder.Name = "cmdSettingsBrowseLogsFolder";
            this.cmdSettingsBrowseLogsFolder.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsBrowseLogsFolder.TabIndex = 12;
            this.cmdSettingsBrowseLogsFolder.Text = "Browse...";
            this.cmdSettingsBrowseLogsFolder.UseVisualStyleBackColor = true;
            this.cmdSettingsBrowseLogsFolder.Click += new System.EventHandler(this.cmdSettingsBrowseLogsFolder_Click);
            // 
            // txtSettingsLogsFolderPath
            // 
            this.txtSettingsLogsFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsLogsFolderPath.Location = new System.Drawing.Point(81, 117);
            this.txtSettingsLogsFolderPath.Name = "txtSettingsLogsFolderPath";
            this.txtSettingsLogsFolderPath.Size = new System.Drawing.Size(606, 20);
            this.txtSettingsLogsFolderPath.TabIndex = 2;
            this.txtSettingsLogsFolderPath.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblSettingsLogs
            // 
            this.lblSettingsLogs.AutoSize = true;
            this.lblSettingsLogs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsLogs.Location = new System.Drawing.Point(6, 120);
            this.lblSettingsLogs.Name = "lblSettingsLogs";
            this.lblSettingsLogs.Size = new System.Drawing.Size(33, 13);
            this.lblSettingsLogs.TabIndex = 10;
            this.lblSettingsLogs.Text = "Logs:";
            // 
            // linkLblSettingsResourcesPath
            // 
            this.linkLblSettingsResourcesPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.linkLblSettingsResourcesPath.AutoSize = true;
            this.linkLblSettingsResourcesPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.linkLblSettingsResourcesPath.Location = new System.Drawing.Point(690, 90);
            this.linkLblSettingsResourcesPath.Name = "linkLblSettingsResourcesPath";
            this.linkLblSettingsResourcesPath.Size = new System.Drawing.Size(10, 13);
            this.linkLblSettingsResourcesPath.TabIndex = 9;
            this.linkLblSettingsResourcesPath.TabStop = true;
            this.linkLblSettingsResourcesPath.Text = "-";
            this.linkLblSettingsResourcesPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLblSettingsResourcesPath_LinkClicked);
            // 
            // lblSettingsResourcesStatus
            // 
            this.lblSettingsResourcesStatus.AutoSize = true;
            this.lblSettingsResourcesStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsResourcesStatus.Location = new System.Drawing.Point(78, 90);
            this.lblSettingsResourcesStatus.Name = "lblSettingsResourcesStatus";
            this.lblSettingsResourcesStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSettingsResourcesStatus.TabIndex = 8;
            this.lblSettingsResourcesStatus.Text = "Status:";
            // 
            // cmdSettingsBrowseResourceFolder
            // 
            this.cmdSettingsBrowseResourceFolder.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSettingsBrowseResourceFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsBrowseResourceFolder.Location = new System.Drawing.Point(693, 65);
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
            this.txtSettingsResourcesPath.Location = new System.Drawing.Point(81, 67);
            this.txtSettingsResourcesPath.Name = "txtSettingsResourcesPath";
            this.txtSettingsResourcesPath.Size = new System.Drawing.Size(606, 20);
            this.txtSettingsResourcesPath.TabIndex = 1;
            this.txtSettingsResourcesPath.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblSettingsResources
            // 
            this.lblSettingsResources.AutoSize = true;
            this.lblSettingsResources.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsResources.Location = new System.Drawing.Point(6, 70);
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
            this.linkLblSettingsWebDriversPath.Location = new System.Drawing.Point(690, 42);
            this.linkLblSettingsWebDriversPath.Name = "linkLblSettingsWebDriversPath";
            this.linkLblSettingsWebDriversPath.Size = new System.Drawing.Size(10, 13);
            this.linkLblSettingsWebDriversPath.TabIndex = 4;
            this.linkLblSettingsWebDriversPath.TabStop = true;
            this.linkLblSettingsWebDriversPath.Text = "-";
            this.linkLblSettingsWebDriversPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLblSettingsWebDriversPath_LinkClicked);
            // 
            // lblSettingsWebDriversPathStatus
            // 
            this.lblSettingsWebDriversPathStatus.AutoSize = true;
            this.lblSettingsWebDriversPathStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsWebDriversPathStatus.Location = new System.Drawing.Point(78, 42);
            this.lblSettingsWebDriversPathStatus.Name = "lblSettingsWebDriversPathStatus";
            this.lblSettingsWebDriversPathStatus.Size = new System.Drawing.Size(40, 13);
            this.lblSettingsWebDriversPathStatus.TabIndex = 3;
            this.lblSettingsWebDriversPathStatus.Text = "Status:";
            // 
            // cmdSettingsBrowseWebDriversPath
            // 
            this.cmdSettingsBrowseWebDriversPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmdSettingsBrowseWebDriversPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsBrowseWebDriversPath.Location = new System.Drawing.Point(693, 17);
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
            this.txtSettingsWebDriversPath.Location = new System.Drawing.Point(81, 19);
            this.txtSettingsWebDriversPath.Name = "txtSettingsWebDriversPath";
            this.txtSettingsWebDriversPath.Size = new System.Drawing.Size(606, 20);
            this.txtSettingsWebDriversPath.TabIndex = 0;
            this.txtSettingsWebDriversPath.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblSettingsWebDrivers
            // 
            this.lblSettingsWebDrivers.AutoSize = true;
            this.lblSettingsWebDrivers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettingsWebDrivers.Location = new System.Drawing.Point(6, 22);
            this.lblSettingsWebDrivers.Name = "lblSettingsWebDrivers";
            this.lblSettingsWebDrivers.Size = new System.Drawing.Size(69, 13);
            this.lblSettingsWebDrivers.TabIndex = 0;
            this.lblSettingsWebDrivers.Text = "Web Drivers:";
            // 
            // cmdSettingsCancel
            // 
            this.cmdSettingsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSettingsCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmdSettingsCancel.Location = new System.Drawing.Point(612, 505);
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
            this.cmdSettingsApply.Location = new System.Drawing.Point(693, 505);
            this.cmdSettingsApply.Name = "cmdSettingsApply";
            this.cmdSettingsApply.Size = new System.Drawing.Size(75, 23);
            this.cmdSettingsApply.TabIndex = 4;
            this.cmdSettingsApply.Text = "Apply";
            this.cmdSettingsApply.UseVisualStyleBackColor = true;
            this.cmdSettingsApply.Click += new System.EventHandler(this.CmdSettingsApply_Click);
            // 
            // lblSavedStatus
            // 
            this.lblSavedStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSavedStatus.AutoSize = true;
            this.lblSavedStatus.Location = new System.Drawing.Point(9, 514);
            this.lblSavedStatus.Name = "lblSavedStatus";
            this.lblSavedStatus.Size = new System.Drawing.Size(37, 13);
            this.lblSavedStatus.TabIndex = 6;
            this.lblSavedStatus.Text = "Status";
            // 
            // groupSettingsScraper
            // 
            this.groupSettingsScraper.Controls.Add(this.comboIgnoreDuplicatesTimeMode);
            this.groupSettingsScraper.Controls.Add(this.numIgnoreDuplicatesValue);
            this.groupSettingsScraper.Controls.Add(this.checkScraperIgnoreDuplicatesOlderThan);
            this.groupSettingsScraper.Controls.Add(this.lblMore);
            this.groupSettingsScraper.Controls.Add(this.checkJobnet);
            this.groupSettingsScraper.Controls.Add(this.label1);
            this.groupSettingsScraper.Controls.Add(this.txtBannedKeywords);
            this.groupSettingsScraper.Controls.Add(this.lblSettingsBannedKeywords);
            this.groupSettingsScraper.Controls.Add(this.comboScraperWebDriver);
            this.groupSettingsScraper.Controls.Add(this.lblScraperSettingsWebDriver);
            this.groupSettingsScraper.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupSettingsScraper.Location = new System.Drawing.Point(0, 239);
            this.groupSettingsScraper.Name = "groupSettingsScraper";
            this.groupSettingsScraper.Size = new System.Drawing.Size(774, 151);
            this.groupSettingsScraper.TabIndex = 7;
            this.groupSettingsScraper.TabStop = false;
            this.groupSettingsScraper.Text = "Scraper";
            // 
            // comboIgnoreDuplicatesTimeMode
            // 
            this.comboIgnoreDuplicatesTimeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboIgnoreDuplicatesTimeMode.FormattingEnabled = true;
            this.comboIgnoreDuplicatesTimeMode.Location = new System.Drawing.Point(281, 119);
            this.comboIgnoreDuplicatesTimeMode.Name = "comboIgnoreDuplicatesTimeMode";
            this.comboIgnoreDuplicatesTimeMode.Size = new System.Drawing.Size(100, 21);
            this.comboIgnoreDuplicatesTimeMode.TabIndex = 11;
            this.comboIgnoreDuplicatesTimeMode.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // numIgnoreDuplicatesValue
            // 
            this.numIgnoreDuplicatesValue.Location = new System.Drawing.Point(175, 120);
            this.numIgnoreDuplicatesValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numIgnoreDuplicatesValue.Name = "numIgnoreDuplicatesValue";
            this.numIgnoreDuplicatesValue.Size = new System.Drawing.Size(100, 20);
            this.numIgnoreDuplicatesValue.TabIndex = 10;
            this.numIgnoreDuplicatesValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numIgnoreDuplicatesValue.ValueChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // checkScraperIgnoreDuplicatesOlderThan
            // 
            this.checkScraperIgnoreDuplicatesOlderThan.AutoSize = true;
            this.checkScraperIgnoreDuplicatesOlderThan.Location = new System.Drawing.Point(9, 123);
            this.checkScraperIgnoreDuplicatesOlderThan.Name = "checkScraperIgnoreDuplicatesOlderThan";
            this.checkScraperIgnoreDuplicatesOlderThan.Size = new System.Drawing.Size(160, 17);
            this.checkScraperIgnoreDuplicatesOlderThan.TabIndex = 9;
            this.checkScraperIgnoreDuplicatesOlderThan.Text = "Ignore duplicates older than:";
            this.checkScraperIgnoreDuplicatesOlderThan.UseVisualStyleBackColor = true;
            this.checkScraperIgnoreDuplicatesOlderThan.CheckedChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblMore
            // 
            this.lblMore.AutoSize = true;
            this.lblMore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMore.Location = new System.Drawing.Point(6, 84);
            this.lblMore.Name = "lblMore";
            this.lblMore.Size = new System.Drawing.Size(34, 13);
            this.lblMore.TabIndex = 8;
            this.lblMore.Text = "More:";
            // 
            // checkJobnet
            // 
            this.checkJobnet.AutoSize = true;
            this.checkJobnet.Location = new System.Drawing.Point(9, 100);
            this.checkJobnet.Name = "checkJobnet";
            this.checkJobnet.Size = new System.Drawing.Size(266, 17);
            this.checkJobnet.TabIndex = 7;
            this.checkJobnet.Text = "Additionally check jobnet.dk for possible duplicates";
            this.checkJobnet.UseVisualStyleBackColor = true;
            this.checkJobnet.CheckedChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Separate keywords by comma";
            // 
            // txtBannedKeywords
            // 
            this.txtBannedKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBannedKeywords.Location = new System.Drawing.Point(107, 46);
            this.txtBannedKeywords.Name = "txtBannedKeywords";
            this.txtBannedKeywords.Size = new System.Drawing.Size(661, 20);
            this.txtBannedKeywords.TabIndex = 5;
            this.txtBannedKeywords.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblSettingsBannedKeywords
            // 
            this.lblSettingsBannedKeywords.AutoSize = true;
            this.lblSettingsBannedKeywords.Location = new System.Drawing.Point(6, 49);
            this.lblSettingsBannedKeywords.Name = "lblSettingsBannedKeywords";
            this.lblSettingsBannedKeywords.Size = new System.Drawing.Size(95, 13);
            this.lblSettingsBannedKeywords.TabIndex = 4;
            this.lblSettingsBannedKeywords.Text = "Banned keywords:";
            // 
            // comboScraperWebDriver
            // 
            this.comboScraperWebDriver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboScraperWebDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScraperWebDriver.FormattingEnabled = true;
            this.comboScraperWebDriver.Location = new System.Drawing.Point(107, 19);
            this.comboScraperWebDriver.Name = "comboScraperWebDriver";
            this.comboScraperWebDriver.Size = new System.Drawing.Size(661, 21);
            this.comboScraperWebDriver.TabIndex = 3;
            this.comboScraperWebDriver.TextChanged += new System.EventHandler(this.ChangeDetected);
            // 
            // lblScraperSettingsWebDriver
            // 
            this.lblScraperSettingsWebDriver.AutoSize = true;
            this.lblScraperSettingsWebDriver.Location = new System.Drawing.Point(6, 22);
            this.lblScraperSettingsWebDriver.Name = "lblScraperSettingsWebDriver";
            this.lblScraperSettingsWebDriver.Size = new System.Drawing.Size(64, 13);
            this.lblScraperSettingsWebDriver.TabIndex = 0;
            this.lblScraperSettingsWebDriver.Text = "Web Driver:";
            // 
            // UC_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupSettingsScraper);
            this.Controls.Add(this.lblSavedStatus);
            this.Controls.Add(this.groupSettingsPaths);
            this.Controls.Add(this.cmdSettingsCancel);
            this.Controls.Add(this.cmdSettingsApply);
            this.Name = "UC_Settings";
            this.Size = new System.Drawing.Size(774, 533);
            this.groupSettingsPaths.ResumeLayout(false);
            this.groupSettingsPaths.PerformLayout();
            this.groupSettingsScraper.ResumeLayout(false);
            this.groupSettingsScraper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIgnoreDuplicatesValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblSavedStatus;
        private System.Windows.Forms.LinkLabel linkLblSettingsLogsPath;
        private System.Windows.Forms.Label lblSettingsLogsStatus;
        private System.Windows.Forms.Button cmdSettingsBrowseLogsFolder;
        private System.Windows.Forms.TextBox txtSettingsLogsFolderPath;
        private System.Windows.Forms.Label lblSettingsLogs;
        private System.Windows.Forms.GroupBox groupSettingsScraper;
        private System.Windows.Forms.Label lblScraperSettingsWebDriver;
        private System.Windows.Forms.ComboBox comboScraperWebDriver;
        private System.Windows.Forms.TextBox txtBannedKeywords;
        private System.Windows.Forms.Label lblSettingsBannedKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkJobnet;
        private System.Windows.Forms.Label lblMore;
        private System.Windows.Forms.LinkLabel linkLblSettingsExportPath;
        private System.Windows.Forms.Label lblSettingsExportStatus;
        private System.Windows.Forms.Button cmdSettingsBrowseExportFolder;
        private System.Windows.Forms.TextBox txtSettingsExportPath;
        private System.Windows.Forms.Label lblExportPath;
        private System.Windows.Forms.Label lblBrowser;
        private System.Windows.Forms.ComboBox comboBrowser;
        private System.Windows.Forms.ComboBox comboIgnoreDuplicatesTimeMode;
        private System.Windows.Forms.NumericUpDown numIgnoreDuplicatesValue;
        private System.Windows.Forms.CheckBox checkScraperIgnoreDuplicatesOlderThan;
    }
}
