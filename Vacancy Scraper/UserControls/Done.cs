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
    public partial class Done : UserControl
    {
        private static Done _instance;

        public static Done Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Done();
                return _instance;
            }
        }

        public Done()
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
