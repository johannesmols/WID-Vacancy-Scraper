using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Objects
{
    public class VacancyObject
    {
        [DisplayName("Company")]
        public string Company { get; set; }
        [DisplayName("Vacancy Title")]
        public string Title { get; set; }
        [DisplayName("Date Added")]
        public DateTime Added { get; set; }
        [DisplayName("URL")]
        public string Url { get; set; }

        public VacancyObject(string company, string title, DateTime added, string url)
        {
            Company = company;
            Title = title;
            Added = added;
            Url = url;
        }
    }
}
