namespace Vacancy_Scraper.Forms
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
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.tabPageScrape = new System.Windows.Forms.TabPage();
            this.panelScrape = new System.Windows.Forms.Panel();
            this.tabVacancies = new System.Windows.Forms.TabPage();
            this.panelVacancies = new System.Windows.Forms.Panel();
            this.tabPageBlacklist = new System.Windows.Forms.TabPage();
            this.panelBlacklist = new System.Windows.Forms.Panel();
            this.tabPageDone = new System.Windows.Forms.TabPage();
            this.panelDone = new System.Windows.Forms.Panel();
            this.tabCompanies = new System.Windows.Forms.TabPage();
            this.panelCompanies = new System.Windows.Forms.Panel();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.panelSettings = new System.Windows.Forms.Panel();
            tabControl = new System.Windows.Forms.TabControl();
            tabControl.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            this.tabPageScrape.SuspendLayout();
            this.tabVacancies.SuspendLayout();
            this.tabPageBlacklist.SuspendLayout();
            this.tabPageDone.SuspendLayout();
            this.tabCompanies.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(this.tabDashboard);
            tabControl.Controls.Add(this.tabPageScrape);
            tabControl.Controls.Add(this.tabVacancies);
            tabControl.Controls.Add(this.tabPageBlacklist);
            tabControl.Controls.Add(this.tabPageDone);
            tabControl.Controls.Add(this.tabCompanies);
            tabControl.Controls.Add(this.tabSettings);
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.HotTrack = true;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            tabControl.TabStop = false;
            tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
            // 
            // tabDashboard
            // 
            this.tabDashboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDashboard.Controls.Add(this.panelDashboard);
            resources.ApplyResources(this.tabDashboard, "tabDashboard");
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.UseVisualStyleBackColor = true;
            // 
            // panelDashboard
            // 
            resources.ApplyResources(this.panelDashboard, "panelDashboard");
            this.panelDashboard.Name = "panelDashboard";
            // 
            // tabPageScrape
            // 
            this.tabPageScrape.Controls.Add(this.panelScrape);
            resources.ApplyResources(this.tabPageScrape, "tabPageScrape");
            this.tabPageScrape.Name = "tabPageScrape";
            this.tabPageScrape.UseVisualStyleBackColor = true;
            // 
            // panelScrape
            // 
            resources.ApplyResources(this.panelScrape, "panelScrape");
            this.panelScrape.Name = "panelScrape";
            // 
            // tabVacancies
            // 
            this.tabVacancies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabVacancies.Controls.Add(this.panelVacancies);
            resources.ApplyResources(this.tabVacancies, "tabVacancies");
            this.tabVacancies.Name = "tabVacancies";
            this.tabVacancies.UseVisualStyleBackColor = true;
            // 
            // panelVacancies
            // 
            resources.ApplyResources(this.panelVacancies, "panelVacancies");
            this.panelVacancies.Name = "panelVacancies";
            // 
            // tabPageBlacklist
            // 
            this.tabPageBlacklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageBlacklist.Controls.Add(this.panelBlacklist);
            resources.ApplyResources(this.tabPageBlacklist, "tabPageBlacklist");
            this.tabPageBlacklist.Name = "tabPageBlacklist";
            this.tabPageBlacklist.UseVisualStyleBackColor = true;
            // 
            // panelBlacklist
            // 
            resources.ApplyResources(this.panelBlacklist, "panelBlacklist");
            this.panelBlacklist.Name = "panelBlacklist";
            // 
            // tabPageDone
            // 
            this.tabPageDone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageDone.Controls.Add(this.panelDone);
            resources.ApplyResources(this.tabPageDone, "tabPageDone");
            this.tabPageDone.Name = "tabPageDone";
            this.tabPageDone.UseVisualStyleBackColor = true;
            // 
            // panelDone
            // 
            resources.ApplyResources(this.panelDone, "panelDone");
            this.panelDone.Name = "panelDone";
            // 
            // tabCompanies
            // 
            this.tabCompanies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCompanies.Controls.Add(this.panelCompanies);
            resources.ApplyResources(this.tabCompanies, "tabCompanies");
            this.tabCompanies.Name = "tabCompanies";
            this.tabCompanies.UseVisualStyleBackColor = true;
            // 
            // panelCompanies
            // 
            resources.ApplyResources(this.panelCompanies, "panelCompanies");
            this.panelCompanies.Name = "panelCompanies";
            // 
            // tabSettings
            // 
            this.tabSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSettings.Controls.Add(this.panelSettings);
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // panelSettings
            // 
            resources.ApplyResources(this.panelSettings, "panelSettings");
            this.panelSettings.Name = "panelSettings";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tabControl);
            this.Name = "MainForm";
            tabControl.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.tabPageScrape.ResumeLayout(false);
            this.tabVacancies.ResumeLayout(false);
            this.tabPageBlacklist.ResumeLayout(false);
            this.tabPageDone.ResumeLayout(false);
            this.tabCompanies.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabVacancies;
        private System.Windows.Forms.TabPage tabPageBlacklist;
        private System.Windows.Forms.TabPage tabCompanies;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabPageDone;
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelBlacklist;
        private System.Windows.Forms.TabPage tabPageScrape;
        private System.Windows.Forms.Panel panelScrape;
        private System.Windows.Forms.Panel panelVacancies;
        private System.Windows.Forms.Panel panelDone;
        private System.Windows.Forms.Panel panelCompanies;
        private System.Windows.Forms.Panel panelSettings;
    }
}

