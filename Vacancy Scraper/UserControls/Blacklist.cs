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
    public partial class Blacklist : UserControl
    {
        private static Blacklist _instance;

        public static Blacklist Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Blacklist();
                return _instance;
            }
        }

        public Blacklist()
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
