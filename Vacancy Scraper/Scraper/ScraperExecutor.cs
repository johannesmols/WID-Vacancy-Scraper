using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly SettingsManager _settingsManager = new SettingsManager();
        private readonly JsonResourceManager<VacancyObject> _vacancyManager = new JsonResourceManager<VacancyObject>(ResourceType.Vacancies);
        private readonly JsonResourceManager<VacancyObject> _blacklistManager = new JsonResourceManager<VacancyObject>(ResourceType.Blacklist);
        private readonly JsonResourceManager<VacancyObject> _doneManager = new JsonResourceManager<VacancyObject>(ResourceType.Done);

        /// <summary>
        /// Run the relevant scraper
        /// </summary>
        /// <param name="company">the company to be scraped</param>
        /// <returns>a list of all found vacancies</returns>
        public async Task<string> Scrape(CompanyObject company)
        {
            var foundVacancies = new List<VacancyObject>();
            await Task.Run(() =>
            {
                switch (company.Name)
                {
                    case "Novo Nordisk":
                        foundVacancies = new ScrapeNovoNordisk().Run(company);
                        break;
                }
            });

            var totalVacanciesFound = foundVacancies.Count;

            // Check for vacancies that contain the banned keywords
            var bannedKeywords = _settingsManager.Settings.ScraperBannedKeywords.Split(',');
            for (var i = foundVacancies.Count - 1; i >= 0; i--)
            {
                var remove = false;
                foreach (var bannedKeyword in bannedKeywords)
                {
                    if (string.IsNullOrWhiteSpace(bannedKeyword)) continue;

                    if (foundVacancies[i].Title.IndexOf(bannedKeyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        remove = true;
                    }
                }

                if (remove)
                {
                    foundVacancies.RemoveAt(i);
                }
            }

            // Check for duplicates in the already added vacancies
            for (var i = foundVacancies.Count - 1; i >= 0; i--)
            {
                if (_vacancyManager.Resources.Contains(foundVacancies[i]))
                    foundVacancies.RemoveAt(i);
            }

            // Check for items in the blacklist
            for (var i = foundVacancies.Count - 1; i >= 0; i--)
            {
                if (_blacklistManager.Resources.Contains(foundVacancies[i]))
                    foundVacancies.RemoveAt(i);
            }

            // Check for items in the done list
            for (var i = foundVacancies.Count - 1; i >= 0; i--)
            {
                if (_doneManager.Resources.Contains(foundVacancies[i]))
                    foundVacancies.RemoveAt(i);
            }

            if (_settingsManager.Settings.ScraperCheckJobnet)
            {
                // Check jobnet for duplicates
            }

            // All checks complete, save leftover vacancies
            foreach (var vacancy in foundVacancies)
            {
                _vacancyManager.Resources.Add(vacancy);
                _vacancyManager.SaveChangesToFile();
            }

            return @"Complete (" + foundVacancies.Count + " of " + totalVacanciesFound + " vacancies addded)";
        }
    }
}
