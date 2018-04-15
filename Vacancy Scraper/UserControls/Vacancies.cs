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
    public partial class Vacancies : UserControl
    {
        private static Vacancies _instance;

        public static Vacancies Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Vacancies();
                return _instance;
            }
        }

        public Vacancies()
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
