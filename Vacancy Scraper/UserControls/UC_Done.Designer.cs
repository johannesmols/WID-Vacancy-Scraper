namespace Vacancy_Scraper.UserControls
{
    partial class UC_Done
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
            this.cmdAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRestore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdDelete = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.gridDoneVacancies = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoneVacancies)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAdd,
            this.toolStripSeparator1,
            this.cmdRestore,
            this.toolStripSeparator2,
            this.cmdDelete,
            this.txtSearch});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(676, 25);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "Tool Strip";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdRestore
            // 
            this.cmdRestore.BackColor = System.Drawing.Color.Transparent;
            this.cmdRestore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRestore.Image = global::Vacancy_Scraper.Properties.Resources.ic_restore_black_24dp_1x;
            this.cmdRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRestore.Name = "cmdRestore";
            this.cmdRestore.Size = new System.Drawing.Size(66, 22);
            this.cmdRestore.Text = "Restore";
            this.cmdRestore.Click += new System.EventHandler(this.cmdRestore_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Image = global::Vacancy_Scraper.Properties.Resources.ic_delete_black_24dp_1x;
            this.cmdDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(60, 22);
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
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
            // gridDoneVacancies
            // 
            this.gridDoneVacancies.AllowUserToAddRows = false;
            this.gridDoneVacancies.AllowUserToDeleteRows = false;
            this.gridDoneVacancies.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDoneVacancies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDoneVacancies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDoneVacancies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridDoneVacancies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDoneVacancies.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridDoneVacancies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDoneVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDoneVacancies.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridDoneVacancies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDoneVacancies.Location = new System.Drawing.Point(0, 25);
            this.gridDoneVacancies.Name = "gridDoneVacancies";
            this.gridDoneVacancies.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridDoneVacancies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridDoneVacancies.RowHeadersVisible = false;
            this.gridDoneVacancies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.NullValue = null;
            this.gridDoneVacancies.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDoneVacancies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDoneVacancies.Size = new System.Drawing.Size(676, 385);
            this.gridDoneVacancies.TabIndex = 4;
            this.gridDoneVacancies.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDoneVacancies_CellMouseClick);
            this.gridDoneVacancies.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDoneVacancies_CellValueChanged);
            this.gridDoneVacancies.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridDoneVacancies_ColumnHeaderMouseClick);
            this.gridDoneVacancies.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridDoneVacancies_DataBindingComplete);
            this.gridDoneVacancies.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDoneVacancies_DataError);
            // 
            // UC_Done
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridDoneVacancies);
            this.Controls.Add(this.toolStrip);
            this.Name = "UC_Done";
            this.Size = new System.Drawing.Size(676, 410);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDoneVacancies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton cmdAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cmdDelete;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.DataGridView gridDoneVacancies;
    }
}
