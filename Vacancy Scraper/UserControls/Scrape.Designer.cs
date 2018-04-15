namespace Vacancy_Scraper.UserControls
{
    partial class Scrape
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.cmdScrapeRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdScrapePause = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdScrapeStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblScrapeStatus = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerScrape = new System.Windows.Forms.SplitContainer();
            this.gridScrape = new System.Windows.Forms.DataGridView();
            this.colScrapeCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtScrapeLog = new System.Windows.Forms.RichTextBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScrape)).BeginInit();
            this.splitContainerScrape.Panel1.SuspendLayout();
            this.splitContainerScrape.Panel2.SuspendLayout();
            this.splitContainerScrape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridScrape)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(676, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "Tool Strip";
            // 
            // cmdScrapeRun
            // 
            this.cmdScrapeRun.Image = global::Vacancy_Scraper.Properties.Resources.ic_play_arrow_black_24dp_1x;
            this.cmdScrapeRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdScrapeRun.Name = "cmdScrapeRun";
            this.cmdScrapeRun.Size = new System.Drawing.Size(48, 22);
            this.cmdScrapeRun.Text = "Run";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdScrapePause
            // 
            this.cmdScrapePause.BackColor = System.Drawing.Color.Transparent;
            this.cmdScrapePause.Image = global::Vacancy_Scraper.Properties.Resources.ic_pause_black_24dp_1x;
            this.cmdScrapePause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdScrapePause.Name = "cmdScrapePause";
            this.cmdScrapePause.Size = new System.Drawing.Size(58, 22);
            this.cmdScrapePause.Text = "Pause";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdScrapeStop
            // 
            this.cmdScrapeStop.Image = global::Vacancy_Scraper.Properties.Resources.ic_stop_black_24dp_1x;
            this.cmdScrapeStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdScrapeStop.Name = "cmdScrapeStop";
            this.cmdScrapeStop.Size = new System.Drawing.Size(51, 22);
            this.cmdScrapeStop.Text = "Stop";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblScrapeStatus
            // 
            this.lblScrapeStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblScrapeStatus.Name = "lblScrapeStatus";
            this.lblScrapeStatus.Size = new System.Drawing.Size(50, 22);
            this.lblScrapeStatus.Text = "Status: -";
            // 
            // splitContainerScrape
            // 
            this.splitContainerScrape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerScrape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerScrape.Location = new System.Drawing.Point(0, 25);
            this.splitContainerScrape.Name = "splitContainerScrape";
            this.splitContainerScrape.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerScrape.Panel1
            // 
            this.splitContainerScrape.Panel1.Controls.Add(this.gridScrape);
            this.splitContainerScrape.Panel1MinSize = 100;
            // 
            // splitContainerScrape.Panel2
            // 
            this.splitContainerScrape.Panel2.Controls.Add(this.txtScrapeLog);
            this.splitContainerScrape.Panel2MinSize = 50;
            this.splitContainerScrape.Size = new System.Drawing.Size(676, 360);
            this.splitContainerScrape.SplitterDistance = 227;
            this.splitContainerScrape.TabIndex = 6;
            // 
            // gridScrape
            // 
            this.gridScrape.BackgroundColor = System.Drawing.Color.White;
            this.gridScrape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridScrape.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridScrape.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colScrapeCompany});
            this.gridScrape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridScrape.Location = new System.Drawing.Point(0, 0);
            this.gridScrape.Name = "gridScrape";
            this.gridScrape.Size = new System.Drawing.Size(674, 225);
            this.gridScrape.TabIndex = 0;
            // 
            // colScrapeCompany
            // 
            this.colScrapeCompany.HeaderText = "Company";
            this.colScrapeCompany.Name = "colScrapeCompany";
            this.colScrapeCompany.ReadOnly = true;
            // 
            // txtScrapeLog
            // 
            this.txtScrapeLog.BackColor = System.Drawing.Color.White;
            this.txtScrapeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtScrapeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScrapeLog.HideSelection = false;
            this.txtScrapeLog.Location = new System.Drawing.Point(0, 0);
            this.txtScrapeLog.Name = "txtScrapeLog";
            this.txtScrapeLog.ReadOnly = true;
            this.txtScrapeLog.Size = new System.Drawing.Size(674, 127);
            this.txtScrapeLog.TabIndex = 0;
            this.txtScrapeLog.Text = "";
            // 
            // Scrape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerScrape);
            this.Controls.Add(this.toolStrip);
            this.Name = "Scrape";
            this.Size = new System.Drawing.Size(676, 385);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainerScrape.Panel1.ResumeLayout(false);
            this.splitContainerScrape.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerScrape)).EndInit();
            this.splitContainerScrape.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridScrape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton cmdScrapeRun;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdScrapePause;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cmdScrapeStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel lblScrapeStatus;
        private System.Windows.Forms.SplitContainer splitContainerScrape;
        private System.Windows.Forms.DataGridView gridScrape;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScrapeCompany;
        private System.Windows.Forms.RichTextBox txtScrapeLog;
    }
}
