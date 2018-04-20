using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacancy_Scraper.Scraper
{
    class Scraper
    {
        public async Task<string> Scrape(int delay)
        {
            await Task.Delay(delay);
            return "done " + delay;
        }
    }
}
