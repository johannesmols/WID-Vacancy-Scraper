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
        public async Task<bool> Scrape(CompanyObject company)
        {
            await Task.Delay(1000);
            return true;
        }
    }
}
