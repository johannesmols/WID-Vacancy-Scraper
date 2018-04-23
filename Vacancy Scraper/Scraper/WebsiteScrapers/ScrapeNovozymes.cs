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
    internal class ScrapeNovozymes : AbstractWebsiteScraper
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

                // Only needed if the link with the country ID doesn't work anymore

                //var dropdown = Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[1]/div[1]/div[1]/div/a/span"));
                //if (dropdown != null)
                //{
                //    ScrollElementIntoView(dropdown);
                //    dropdown.Click();

                //    var optionDk = Driver.FindElement(By.XPath("//*[@id=\"content\"]/div[1]/div[1]/div[1]/div/div/ul/li[contains(text(),'Denmark')]"));
                //    if (optionDk != null)
                //    {
                //        ScrollElementIntoView(optionDk);
                //        //optionDk.Click();
                //        WaitUntilLoaded();
                //    }
                //}

                var vacancies = Driver.FindElements(By.XPath("//*[@id=\"content\"]/div[2]/ul/li/a"));
                for (var i = 0; i < vacancies.Count; i++)
                {
                    foundVacancies.Add(new VacancyObject(
                        company.Name,
                        vacancies.ElementAt(i).FindElement(By.XPath(".//h2")).Text,
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
