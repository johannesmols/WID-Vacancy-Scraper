using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;
using Vacancy_Scraper.Scraper.WebsiteScrapers;

namespace Vacancy_Scraper.Scraper
{
    /// <summary>
    /// Enum-like class to give keys for a dictionary to return values when scraping
    /// </summary>
    public class KeyCategory
    {
        private KeyCategory(string key) { Key = key; }

        public string Key { get; set; }

        public static KeyCategory Vacancies => new KeyCategory("Vacancies");
        public static KeyCategory Errors => new KeyCategory("Errors");
    }

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
            var log = new StringBuilder();

            var scrapeResults = new Dictionary<string, object>();

            await Task.Run(() =>
            {
                switch (company.Name)
                {
                    case "Novo Nordisk":
                        scrapeResults = new ScrapeNovoNordisk().Run(company);
                        break;
                    default:
                        return;
                }
            });

            var foundVacancies = scrapeResults[KeyCategory.Vacancies.Key] as List<VacancyObject> ?? new List<VacancyObject>();
            var exceptions = scrapeResults[KeyCategory.Errors.Key] as List<Exception> ?? new List<Exception>();

            // Logging
            log.Append("Company: " + company.Name + Environment.NewLine);
            log.Append(DateTime.Now.ToString(CultureInfo.CurrentCulture) + Environment.NewLine);
            log.Append(Environment.NewLine);

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

                        log.Append("Found vacancy, removed by keyword match '" + bannedKeyword + "' : " + foundVacancies[i].Title + Environment.NewLine);
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
                {
                    log.Append("Found vacancy, removed by duplicate in 'vacancies' : " + foundVacancies[i].Title + Environment.NewLine);

                    foundVacancies.RemoveAt(i);
                }
            }

            // Check for items in the blacklist
            for (var i = foundVacancies.Count - 1; i >= 0; i--)
            {
                if (_blacklistManager.Resources.Contains(foundVacancies[i]))
                {
                    log.Append("Found vacancy, removed by duplicate in 'blacklist' : " + foundVacancies[i].Title + Environment.NewLine);

                    foundVacancies.RemoveAt(i);
                }
            }

            // Check for items in the done list
            for (var i = foundVacancies.Count - 1; i >= 0; i--)
            {
                if (_doneManager.Resources.Contains(foundVacancies[i]))
                {
                    log.Append("Found vacancy, removed by duplicate in 'done' : " + foundVacancies[i].Title + Environment.NewLine);

                    foundVacancies.RemoveAt(i);
                }
            }

            // Check jobnet for duplicates
            var jobnetResults = new Dictionary<string, object>();
            if (_settingsManager.Settings.ScraperCheckJobnet)
            {
                await Task.Run(() =>
                {
                    jobnetResults = new ScraperJobnet().Run(company);
                });

                var foundVacanciesJobnet = jobnetResults[KeyCategory.Vacancies.Key] as List<string> ?? new List<string>();
                var exceptionsJobnet = jobnetResults[KeyCategory.Errors.Key] as List<Exception> ?? new List<Exception>();

                exceptions.AddRange(exceptionsJobnet);

                // Filter out duplicates
                for (var i = foundVacancies.Count - 1; i >= 0; i--)
                {
                    if (foundVacanciesJobnet.Contains(foundVacancies[i].Title))
                    {
                        log.Append("Found vacancy, removed by duplicate on jobnet.dk : " + foundVacancies[i].Title + Environment.NewLine);

                        foundVacancies.RemoveAt(i);
                    }
                }
            }

            // All checks complete, save leftover vacancies
            foreach (var vacancy in foundVacancies)
            {
                _vacancyManager.Resources.Add(vacancy);
                _vacancyManager.SaveChangesToFile();
            }

            // Add all leftover vacancies to the log
            foreach (var vacancy in foundVacancies)
            {
                log.Append("Found and added : " + vacancy.Title + Environment.NewLine);
            }

            // Normal Log ending
            log.Append(Environment.NewLine);
            log.Append("Found: " + totalVacanciesFound + Environment.NewLine);
            log.Append("Added: " + foundVacancies.Count + Environment.NewLine);

            // Log exceptions
            if (exceptions.Count > 0)
            {
                log.Append(Environment.NewLine + "Exceptions:" + Environment.NewLine + Environment.NewLine);
                foreach (var exception in exceptions)
                {
                    log.Append(exception.Message + Environment.NewLine + exception.StackTrace + Environment.NewLine + Environment.NewLine);
                }
            }
            
            // Write complete log to file
            if (Directory.Exists(_settingsManager.Settings.LogsFolderPath))
            {
                File.WriteAllText(Path.Combine(_settingsManager.Settings.LogsFolderPath, (DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + " " + company.Name + ".txt")), log.ToString());
            }

            if (exceptions.Count > 0)
            {
                return @"Error (Check logs for more info)";
            }

            return @"Complete (" + foundVacancies.Count + " of " + totalVacanciesFound + " vacancies addded)";
        }
    }
}
