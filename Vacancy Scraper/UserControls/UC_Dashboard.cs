using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vacancy_Scraper.Forms;

namespace Vacancy_Scraper.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        private static UC_Dashboard _instance;

        public static UC_Dashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Dashboard();
                return _instance;
            }
        }

        public UC_Dashboard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets called when the active tab in the tab control is changed
        /// This is to notify the user controls of the change and make adjustments based on the change
        /// </summary>
        public void NotifyTabChanged(MainForm.Tabs oldTab, MainForm.Tabs newTab)
        {
            if (newTab == MainForm.Tabs.Dashboard)
            {
                ReloadContent();
            }
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {

        }
    }
}
