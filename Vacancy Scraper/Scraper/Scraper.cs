using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Scraper
{
    class Scraper
    {
        public async Task<string> Scrape(CompanyObject company)
        {
            await Task.Delay(2000);
            return @"Complete (24/31 vacancies added)";
        }
    }
}
