using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Objects
{
    class Company
    {
        public string Name { get; set; }
        public int Cvr { get; set; }
        public int PNo { get; set; }
        public int Telephone { get; set; }
        public string Consultants { get; set; }
        public bool Enabled { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }

        public Company(string name, int cvr, int pNo, int telephone, string consultants, bool enabled, string comment, string url)
        {
            Name = name;
            Cvr = cvr;
            PNo = pNo;
            Telephone = telephone;
            Consultants = consultants;
            Enabled = enabled;
            Comment = comment;
            Url = url;
        }
    }
}
