﻿namespace Vacancy_Scraper.UserControls
{
    partial class Blacklist
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
            this.gridBlacklistedVacancies = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlacklistedVacancies)).BeginInit();
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
            this.toolStrip.TabIndex = 2;
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
            // gridBlacklistedVacancies
            // 
            this.gridBlacklistedVacancies.AllowUserToAddRows = false;
            this.gridBlacklistedVacancies.AllowUserToDeleteRows = false;
            this.gridBlacklistedVacancies.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridBlacklistedVacancies.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridBlacklistedVacancies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBlacklistedVacancies.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridBlacklistedVacancies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridBlacklistedVacancies.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.gridBlacklistedVacancies.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridBlacklistedVacancies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridBlacklistedVacancies.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridBlacklistedVacancies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBlacklistedVacancies.Location = new System.Drawing.Point(0, 25);
            this.gridBlacklistedVacancies.Name = "gridBlacklistedVacancies";
            this.gridBlacklistedVacancies.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gridBlacklistedVacancies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridBlacklistedVacancies.RowHeadersVisible = false;
            this.gridBlacklistedVacancies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.NullValue = null;
            this.gridBlacklistedVacancies.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridBlacklistedVacancies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBlacklistedVacancies.Size = new System.Drawing.Size(676, 360);
            this.gridBlacklistedVacancies.TabIndex = 3;
            this.gridBlacklistedVacancies.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridBlacklistedVacancies_CellMouseClick);
            this.gridBlacklistedVacancies.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBlacklistedVacancies_CellValueChanged);
            this.gridBlacklistedVacancies.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridBlacklistedVacancies_ColumnHeaderMouseClick);
            this.gridBlacklistedVacancies.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridBlacklistedVacancies_DataBindingComplete);
            this.gridBlacklistedVacancies.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridBlacklistedVacancies_DataError);
            // 
            // Blacklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridBlacklistedVacancies);
            this.Controls.Add(this.toolStrip);
            this.Name = "Blacklist";
            this.Size = new System.Drawing.Size(676, 385);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBlacklistedVacancies)).EndInit();
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
        private System.Windows.Forms.DataGridView gridBlacklistedVacancies;
    }
}
