namespace Vacancy_Scraper.UserControls
{
    partial class Vacancies
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdAdd = new System.Windows.Forms.ToolStripButton();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.cmdAddToBlacklist = new System.Windows.Forms.ToolStripButton();
            this.cmdMarkAsDone = new System.Windows.Forms.ToolStripButton();
            this.gridVacancies = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVacancies)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAdd,
            this.toolStripSeparator1,
            this.cmdDelete,
            this.toolStripSeparator2,
            this.cmdAddToBlacklist,
            this.toolStripSeparator3,
            this.cmdMarkAsDone,
            this.txtSearch});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(676, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Tool Strip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Image = global::Vacancy_Scraper.Properties.Resources.ic_add_black_24dp_1x;
            this.cmdAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(49, 22);
            this.cmdAdd.Text = "Add";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.BackColor = System.Drawing.Color.Transparent;
            this.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDelete.Image = global::Vacancy_Scraper.Properties.Resources.ic_delete_black_24dp_1x;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(60, 22);
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAddToBlacklist
            // 
            this.cmdAddToBlacklist.Image = global::Vacancy_Scraper.Properties.Resources.ic_block_black_24dp_1x;
            this.cmdAddToBlacklist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAddToBlacklist.Name = "cmdAddToBlacklist";
            this.cmdAddToBlacklist.Size = new System.Drawing.Size(109, 22);
            this.cmdAddToBlacklist.Text = "Add to blacklist";
            this.cmdAddToBlacklist.Click += new System.EventHandler(this.cmdAddToBlacklist_Click);
            // 
            // cmdMarkAsDone
            // 
            this.cmdMarkAsDone.Image = global::Vacancy_Scraper.Properties.Resources.ic_done_black_24dp_1x;
            this.cmdMarkAsDone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMarkAsDone.Name = "cmdMarkAsDone";
            this.cmdMarkAsDone.Size = new System.Drawing.Size(98, 22);
            this.cmdMarkAsDone.Text = "Mark as done";
            this.cmdMarkAsDone.Click += new System.EventHandler(this.cmdMarkAsDone_Click);
            // 
            // gridVacancies
            // 
            this.gridVacancies.AllowUserToAddRows = false;
            this.gridVacancies.AllowUserToDeleteRows = false;
            this.gridVacancies.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridVacancies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridVacancies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVacancies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridVacancies.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridVacancies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridVacancies.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridVacancies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVacancies.Location = new System.Drawing.Point(0, 25);
            this.gridVacancies.Name = "gridVacancies";
            this.gridVacancies.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridVacancies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridVacancies.RowHeadersVisible = false;
            this.gridVacancies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.NullValue = null;
            this.gridVacancies.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridVacancies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVacancies.Size = new System.Drawing.Size(676, 360);
            this.gridVacancies.TabIndex = 2;
            this.gridVacancies.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridVacancies_CellMouseClick);
            this.gridVacancies.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVacancies_CellValueChanged);
            this.gridVacancies.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridVacancies_ColumnHeaderMouseClick);
            this.gridVacancies.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridVacancies_DataBindingComplete);
            this.gridVacancies.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridVacancies_DataError);
            // 
            // Vacancies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridVacancies);
            this.Controls.Add(this.toolStrip);
            this.Name = "Vacancies";
            this.Size = new System.Drawing.Size(676, 385);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVacancies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton cmdAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton cmdAddToBlacklist;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton cmdMarkAsDone;
        private System.Windows.Forms.DataGridView gridVacancies;
    }
}
