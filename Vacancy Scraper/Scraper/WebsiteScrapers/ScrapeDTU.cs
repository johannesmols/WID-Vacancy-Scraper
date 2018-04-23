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
    /// Scraper implementation for DTU
    /// </summary>
    internal class ScrapeDTU : AbstractWebsiteScraper
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

                // Find the "View All" button if it exists
                var viewAllBtn = Driver.FindElement(By.XPath("//div[@class=\"all\"]/a"));
                if (viewAllBtn != null)
                {
                    ScrollElementIntoView(viewAllBtn);
                    viewAllBtn.Click();
                    WaitUntilLoaded();
                }

                // Find all vacancies
                var vacancies = Driver.FindElements(By.XPath("//*[@id=\"jobList\"]/tbody/tr/td[1]/a"));
                for (var i = 0; i < vacancies.Count; i++)
                {
                    foundVacancies.Add(new VacancyObject(
                        company.Name,
                        vacancies.ElementAt(i).GetAttribute("title"),
                        DateTime.Now,
                        vacancies.ElementAt(i).GetAttribute("href")));
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
