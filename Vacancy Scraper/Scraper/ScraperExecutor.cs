using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;
using Vacancy_Scraper.Scraper.WebsiteScrapers;

namespace Vacancy_Scraper.Scraper
{
    /// <summary>
    /// This class handles execution of the different scrapers and checks for duplicates afterwards
    /// </summary>
    public class ScraperExecutor
    {
        private SettingsManager _settingsManager = new SettingsManager();

        /// <summary>
        /// Run the relevant scraper
        /// </summary>
        /// <param name="company">the company to be scraped</param>
        /// <returns>a list of all found vacancies</returns>
        public async Task<string> Scrape(CompanyObject company)
        {
            var returnValue = new List<VacancyObject>();
            await Task.Run(() =>
            {
                switch (company.Name)
                {
                    case "Novo Nordisk":
                        var scraper = new ScrapeNovoNordisk();
                        returnValue = scraper.Run(company);
                        break;
                }
            });

            // Check for duplicates here and add to files afterwards

            return @"Complete (" + returnValue.Count + " vacancies found)";
        }
    }
}
