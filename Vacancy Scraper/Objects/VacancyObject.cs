using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Objects
{
    class VacancyObject
    {
        public string Company { get; set; }
        public string Title { get; set; }
        public DateTime Added { get; set; }
        public string Url { get; set; }
    }
}
