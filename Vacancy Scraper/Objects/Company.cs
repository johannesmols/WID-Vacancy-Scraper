using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Objects
{
    public class Company
    {
        public string Name { get; set; }
        public long Cvr { get; set; }
        public long PNo { get; set; }
        public long Telephone { get; set; }
        public string Consultants { get; set; }
        public bool Enabled { get; set; }
        public bool Selected { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }

        public Company(string name, long cvr, long pNo, long telephone, string consultants, bool enabled, bool selected, string comment, string url)
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
