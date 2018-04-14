namespace Vacancy_Scraper
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TabControl tabControl;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.tabScrape = new System.Windows.Forms.TabPage();
            this.tabVacancies = new System.Windows.Forms.TabPage();
            this.tabPageBlacklist = new System.Windows.Forms.TabPage();
            this.tabCompanies = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.cmdScrapeRun = new System.Windows.Forms.ToolStripButton();
            this.cmdScrapePause = new System.Windows.Forms.ToolStripButton();
            this.cmdScrapeStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblScrapeStatus = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerScrape = new System.Windows.Forms.SplitContainer();
            this.txtScrapeLog = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colScrapeCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabControl = new System.Windows.Forms.TabControl();
            tabControl.SuspendLayout();
            this.tabScrape.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScrape)).BeginInit();
            this.splitContainerScrape.Panel1.SuspendLayout();
            this.splitContainerScrape.Panel2.SuspendLayout();
            this.splitContainerScrape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(this.tabDashboard);
            tabControl.Controls.Add(this.tabScrape);
            tabControl.Controls.Add(this.tabVacancies);
            tabControl.Controls.Add(this.tabPageBlacklist);
            tabControl.Controls.Add(this.tabCompanies);
            tabControl.Controls.Add(this.tabSettings);
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.HotTrack = true;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl.TabStop = false;
            // 
            // tabDashboard
            // 
            this.tabDashboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tabDashboard, "tabDashboard");
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // tabScrape
            // 
            this.tabScrape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabScrape.Controls.Add(this.splitContainerScrape);
            this.tabScrape.Controls.Add(this.toolStrip);
            resources.ApplyResources(this.tabScrape, "tabScrape");
            this.tabScrape.Name = "tabScrape";
            this.tabScrape.UseVisualStyleBackColor = true;
            // 
            // tabVacancies
            // 
            this.tabVacancies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tabVacancies, "tabVacancies");
            this.tabVacancies.Name = "tabVacancies";
            this.tabVacancies.UseVisualStyleBackColor = true;
            // 
            // tabPageBlacklist
            // 
            this.tabPageBlacklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tabPageBlacklist, "tabPageBlacklist");
            this.tabPageBlacklist.Name = "tabPageBlacklist";
            this.tabPageBlacklist.UseVisualStyleBackColor = true;
            // 
            // tabCompanies
            // 
            this.tabCompanies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tabCompanies, "tabCompanies");
            this.tabCompanies.Name = "tabCompanies";
            this.tabCompanies.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdScrapeRun,
            this.toolStripSeparator1,
            this.cmdScrapePause,
            this.toolStripSeparator2,
            this.cmdScrapeStop,
            this.toolStripSeparator3,
            this.lblScrapeStatus});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // cmdScrapeRun
            // 
            this.cmdScrapeRun.Image = global::Vacancy_Scraper.Properties.Resources.ic_play_arrow_black_24dp_1x;
            resources.ApplyResources(this.cmdScrapeRun, "cmdScrapeRun");
            this.cmdScrapeRun.Name = "cmdScrapeRun";
            // 
            // cmdScrapePause
            // 
            this.cmdScrapePause.BackColor = System.Drawing.Color.Transparent;
            this.cmdScrapePause.Image = global::Vacancy_Scraper.Properties.Resources.ic_pause_black_24dp_1x;
            resources.ApplyResources(this.cmdScrapePause, "cmdScrapePause");
            this.cmdScrapePause.Name = "cmdScrapePause";
            // 
            // cmdScrapeStop
            // 
            this.cmdScrapeStop.Image = global::Vacancy_Scraper.Properties.Resources.ic_stop_black_24dp_1x;
            resources.ApplyResources(this.cmdScrapeStop, "cmdScrapeStop");
            this.cmdScrapeStop.Name = "cmdScrapeStop";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // lblScrapeStatus
            // 
            this.lblScrapeStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblScrapeStatus.Name = "lblScrapeStatus";
            resources.ApplyResources(this.lblScrapeStatus, "lblScrapeStatus");
            // 
            // splitContainerScrape
            // 
            this.splitContainerScrape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.splitContainerScrape, "splitContainerScrape");
            this.splitContainerScrape.Name = "splitContainerScrape";
            // 
            // splitContainerScrape.Panel1
            // 
            this.splitContainerScrape.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainerScrape.Panel2
            // 
            this.splitContainerScrape.Panel2.Controls.Add(this.txtScrapeLog);
            // 
            // txtScrapeLog
            // 
            this.txtScrapeLog.BackColor = System.Drawing.Color.White;
            this.txtScrapeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtScrapeLog, "txtScrapeLog");
            this.txtScrapeLog.HideSelection = false;
            this.txtScrapeLog.Name = "txtScrapeLog";
            this.txtScrapeLog.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScrapeCompany});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            // 
            // colScrapeCompany
            // 
            resources.ApplyResources(this.colScrapeCompany, "colScrapeCompany");
            this.colScrapeCompany.Name = "colScrapeCompany";
            this.colScrapeCompany.ReadOnly = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tabControl);
            this.Name = "MainForm";
            tabControl.ResumeLayout(false);
            this.tabScrape.ResumeLayout(false);
            this.tabScrape.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainerScrape.Panel1.ResumeLayout(false);
            this.splitContainerScrape.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScrape)).EndInit();
            this.splitContainerScrape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabScrape;
        private System.Windows.Forms.TabPage tabVacancies;
        private System.Windows.Forms.TabPage tabPageBlacklist;
        private System.Windows.Forms.TabPage tabCompanies;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton cmdScrapeRun;
        private System.Windows.Forms.ToolStripButton cmdScrapePause;
        private System.Windows.Forms.ToolStripButton cmdScrapeStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblScrapeStatus;
        private System.Windows.Forms.SplitContainer splitContainerScrape;
        private System.Windows.Forms.RichTextBox txtScrapeLog;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScrapeCompany;
    }
}

