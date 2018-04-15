using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vacancy_Scraper.UserControls
{
    public partial class Companies : UserControl
    {
        private static Companies _instance;

        public static Companies Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Companies();
                return _instance;
            }
        }

        public Companies()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reloads the content of the user control
        /// </summary>
        public void ReloadContent()
        {

        }
    }
}
