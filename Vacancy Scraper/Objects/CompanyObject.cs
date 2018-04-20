using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Objects
{
    public class CompanyObject
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("CVR")]
        public long Cvr { get; set; }
        [DisplayName("P-No.")]
        public long PNo { get; set; }
        [DisplayName("Telephone")]
        public string Telephone { get; set; }
        [DisplayName("Consultants")]
        public string Consultants { get; set; }
        [DisplayName("Enabled")]
        public bool Enabled { get; set; }
        [DisplayName("Selected"), Browsable(false)] // Browsable determines if the property should be displayed in a DataGridView
        public bool Selected { get; set; }
        [DisplayName("Comment")]
        public string Comment { get; set; }
        [DisplayName("URL")]
        public string Url { get; set; }

        public CompanyObject(string name, long cvr, long pNo, string telephone, string consultants, bool enabled, bool selected, string comment, string url)
        {
            Name = name;
            Cvr = cvr;
            PNo = pNo;
            Telephone = telephone;
            Consultants = consultants;
            Enabled = enabled;
            Selected = selected;
            Comment = comment;
            Url = url;
        }
    }
}
