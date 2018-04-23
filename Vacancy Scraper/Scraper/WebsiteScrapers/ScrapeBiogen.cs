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
    /// Scraper implementation for Biogen
    /// </summary>
    internal class ScrapeBiogen : AbstractWebsiteScraper
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
                
                // Select Denmark as location
                var locationPanel = Driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div[3]/div[2]/div[2]/div[1]"));
                if (locationPanel != null)
                {
                    ScrollElementIntoView(locationPanel);
                    locationPanel.Click();

                    var locations = Driver.FindElements(By.XPath("//*[@id=\"location\"]"));
                    foreach (var location in locations)
                    {
                        if (location.GetAttribute("value").Contains("Denmark"))
                        {
                            ScrollElementIntoView(location);
                            if (!location.Selected)
                                location.Click();
                            WaitUntilLoaded();
                        }
                    }
                }
                else
                {
                    throw new WebDriverException("Couldn't find location panel");
                }

                // Find vacancies
                var vacancies = Driver.FindElements(By.ClassName("results-main"));
                foreach (var vacancy in vacancies)
                {
                    foundVacancies.Add(new VacancyObject(
                        company.Name,
                        vacancy.FindElement(By.ClassName("job-title")).Text,
                        DateTime.Now, 
                        vacancy.FindElement(By.ClassName("job-link-btn")).GetAttribute("href")));
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
