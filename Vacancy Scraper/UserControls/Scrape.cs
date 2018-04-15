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
    public partial class Scrape : UserControl
    {
        private static Scrape _instance;

        public static Scrape Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Scrape();
                return _instance;
            }
        }

        public Scrape()
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
