using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Scraper.WebsiteScrapers
{
    /// <inheritdoc/>
    /// <summary>
    /// Scraper implementation for Novozymes
    /// </summary>
    internal class ScrapeAgcBiologics : AbstractWebsiteScraper
    {
        public override Dictionary<string, object> Run(CompanyObject company)
        {
            var dictionary = new Dictionary<string, object>();

            var foundVacancies = new List<VacancyObject>();
            var errors = new List<Exception>();

            try
            {
                if (IsValidHttpUrl(company.Url))
                    NavigateToUrlAndWaitUntilLoaded(company.Url);
                else
                    throw new WebDriverException("Invalid URL (" + company.Url + ")");

                var languageDropdown = Driver.FindElement(By.XPath("//*[@id=\"DDL_Language\"]"));
                if (languageDropdown != null)
                {
                    ScrollElementIntoView(languageDropdown);
                    languageDropdown.Click();
                }
                else
                {
                    throw new WebDriverException("Couldn't find language dropdown");
                }
            }
            catch (Exception e)
            {
                errors.Add(e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Driver.Close();
                Driver.Quit();
            }

            dictionary.Add(KeyCategory.Vacancies.Key, foundVacancies);
            dictionary.Add(KeyCategory.Errors.Key, errors);

            return dictionary;
        }
    }
}
