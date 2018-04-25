namespace Vacancy_Scraper.UserControls
{
    partial class UC_Export
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.checkedListConsultants = new System.Windows.Forms.CheckedListBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.txtExportDirectory = new System.Windows.Forms.TextBox();
            this.cmdBrowseDirectory = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.lblConsultants = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.datePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.datePickerStart = new System.Windows.Forms.DateTimePicker();
            this.comboDataSource = new System.Windows.Forms.ComboBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel.SuspendLayout();
            this.groupBoxExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.groupBoxExport, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.groupBoxImport, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(676, 410);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.checkedListConsultants);
            this.groupBoxExport.Controls.Add(this.lblFileName);
            this.groupBoxExport.Controls.Add(this.txtFileName);
            this.groupBoxExport.Controls.Add(this.lblDirectory);
            this.groupBoxExport.Controls.Add(this.txtExportDirectory);
            this.groupBoxExport.Controls.Add(this.cmdBrowseDirectory);
            this.groupBoxExport.Controls.Add(this.cmdExport);
            this.groupBoxExport.Controls.Add(this.lblConsultants);
            this.groupBoxExport.Controls.Add(this.lblEndDate);
            this.groupBoxExport.Controls.Add(this.datePickerEnd);
            this.groupBoxExport.Controls.Add(this.lblStartDate);
            this.groupBoxExport.Controls.Add(this.datePickerStart);
            this.groupBoxExport.Controls.Add(this.comboDataSource);
            this.groupBoxExport.Controls.Add(this.lblDataSource);
            this.groupBoxExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxExport.Location = new System.Drawing.Point(3, 3);
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.Size = new System.Drawing.Size(332, 404);
            this.groupBoxExport.TabIndex = 0;
            this.groupBoxExport.TabStop = false;
            this.groupBoxExport.Text = "Export";
            // 
            // checkedListConsultants
            // 
            this.checkedListConsultants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListConsultants.CheckOnClick = true;
            this.checkedListConsultants.FormattingEnabled = true;
            this.checkedListConsultants.Location = new System.Drawing.Point(83, 96);
            this.checkedListConsultants.Name = "checkedListConsultants";
            this.checkedListConsultants.Size = new System.Drawing.Size(243, 214);
            this.checkedListConsultants.Sorted = true;
            this.checkedListConsultants.TabIndex = 15;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(20, 352);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 14;
            this.lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(83, 349);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(243, 20);
            this.txtFileName.TabIndex = 13;
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(24, 326);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(52, 13);
            this.lblDirectory.TabIndex = 11;
            this.lblDirectory.Text = "Directory:";
            // 
            // txtExportDirectory
            // 
            this.txtExportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportDirectory.Location = new System.Drawing.Point(82, 323);
            this.txtExportDirectory.Name = "txtExportDirectory";
            this.txtExportDirectory.Size = new System.Drawing.Size(162, 20);
            this.txtExportDirectory.TabIndex = 10;
            // 
            // cmdBrowseDirectory
            // 
            this.cmdBrowseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseDirectory.Location = new System.Drawing.Point(251, 321);
            this.cmdBrowseDirectory.Name = "cmdBrowseDirectory";
            this.cmdBrowseDirectory.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseDirectory.TabIndex = 9;
            this.cmdBrowseDirectory.Text = "Browse...";
            this.cmdBrowseDirectory.UseVisualStyleBackColor = true;
            this.cmdBrowseDirectory.Click += new System.EventHandler(this.CmdBrowseDirectory_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Location = new System.Drawing.Point(83, 375);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(243, 23);
            this.cmdExport.TabIndex = 8;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.CmdExport_Click);
            // 
            // lblConsultants
            // 
            this.lblConsultants.AutoSize = true;
            this.lblConsultants.Location = new System.Drawing.Point(12, 96);
            this.lblConsultants.Name = "lblConsultants";
            this.lblConsultants.Size = new System.Drawing.Size(65, 13);
            this.lblConsultants.TabIndex = 6;
            this.lblConsultants.Text = "Consultants:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(22, 76);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "End Date:";
            // 
            // datePickerEnd
            // 
            this.datePickerEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerEnd.Location = new System.Drawing.Point(83, 70);
            this.datePickerEnd.Name = "datePickerEnd";
            this.datePickerEnd.Size = new System.Drawing.Size(243, 20);
            this.datePickerEnd.TabIndex = 4;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(19, 50);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "Start Date:";
            // 
            // datePickerStart
            // 
            this.datePickerStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datePickerStart.CustomFormat = "";
            this.datePickerStart.Location = new System.Drawing.Point(83, 44);
            this.datePickerStart.Name = "datePickerStart";
            this.datePickerStart.Size = new System.Drawing.Size(243, 20);
            this.datePickerStart.TabIndex = 2;
            // 
            // comboDataSource
            // 
            this.comboDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboDataSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDataSource.FormattingEnabled = true;
            this.comboDataSource.Location = new System.Drawing.Point(83, 17);
            this.comboDataSource.Name = "comboDataSource";
            this.comboDataSource.Size = new System.Drawing.Size(243, 21);
            this.comboDataSource.TabIndex = 1;
            // 
            // lblDataSource
            // 
            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Location = new System.Drawing.Point(7, 20);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(70, 13);
            this.lblDataSource.TabIndex = 0;
            this.lblDataSource.Text = "Data Source:";
            // 
            // groupBoxImport
            // 
            this.groupBoxImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxImport.Location = new System.Drawing.Point(341, 3);
            this.groupBoxImport.Name = "groupBoxImport";
            this.groupBoxImport.Size = new System.Drawing.Size(332, 404);
            this.groupBoxImport.TabIndex = 1;
            this.groupBoxImport.TabStop = false;
            this.groupBoxImport.Text = "Import";
            // 
            // UC_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "UC_Export";
            this.Size = new System.Drawing.Size(676, 410);
            this.tableLayoutPanel.ResumeLayout(false);
            this.groupBoxExport.ResumeLayout(false);
            this.groupBoxExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxExport;
        private System.Windows.Forms.GroupBox groupBoxImport;
        private System.Windows.Forms.DateTimePicker datePickerStart;
        private System.Windows.Forms.ComboBox comboDataSource;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker datePickerEnd;
        private System.Windows.Forms.Label lblConsultants;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.TextBox txtExportDirectory;
        private System.Windows.Forms.Button cmdBrowseDirectory;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.CheckedListBox checkedListConsultants;
    }
}
