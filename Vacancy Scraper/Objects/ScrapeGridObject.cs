using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Vacancy_Scraper.Objects
{
    /// <summary>
    /// This object serves in the data grid view of the scrape window
    /// It's purpose is to display only two properties of a company object, and add a third, while maintaining the reference to the entire company object
    /// </summary>
    public class ScrapeGridObject
    {
        private CompanyObject _company;
        [Browsable(false)]
        public CompanyObject Company
        {
            get { return _company; }
            set
            {
                _company = value;
                Name = value.Name;
                Selected = value.Selected;
            }
        }

        private bool _selected;
        [DisplayName("Run")]
        public bool Selected {
            get { return _selected; }
            set
            {
                _selected = value;
                _company.Selected = value;
            }
        }

        [DisplayName("Company")]
        public string Name { get; private set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        public ScrapeGridObject(CompanyObject company)
        {
            Company = company;
            Selected = company.Selected;
            Name = company.Name;
            Status = "Waiting";
        }
    }
}
