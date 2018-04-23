using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Scraper
{
    /// <inheritdoc/>
    /// <summary>
    /// Scraper implementation to scrape all vacancies on jobnet for a specific company
    /// This is to detect duplicates
    /// </summary>
    internal class ScraperJobnet : AbstractWebsiteScraper
    {
        public override Dictionary<string, object> Run(CompanyObject company)
        {
            var foundVacancies = new List<string>();

            var dictionary = new Dictionary<string, object>();
            var errors = new List<Exception>();

            // Jobnet URL
            const string jobnetUrl = "https://job.jobnet.dk/";

            try
            {
                if (IsValidHttpUrl(jobnetUrl))
                    NavigateToUrlAndWaitUntilLoaded(jobnetUrl);
                else
                    throw new WebDriverException("Invalid URL (" + jobnetUrl + ")");

                // Search for company
                var searchField = Driver.FindElement(By.XPath("//*[@id=\"SearchField\"]"));
                searchField.SendKeys(company.Cvr.ToString());

                // Commit search
                var searchButton = Driver.FindElement(By.XPath("//*[@id=\"btnSearch\"]"));
                ScrollElementIntoView(searchButton);
                searchButton.Click();

                WaitUntilLoaded();

                foundVacancies.AddRange(FindVacanciesOnPage());

                // Check if the next button exists and then go through the pages
                const string nextBtnXPath = "//*[@data-jn-click=\"nextPage()\"]";
                if (Driver.FindElements(By.XPath(nextBtnXPath)).Count != 0)
                {
                    while (TryClickingNextButton(nextBtnXPath))
                    {
                        foundVacancies.AddRange(FindVacanciesOnPage());
                    }
                }
            }
            catch (Exception e)
            {
                errors.Add(e);
                Console.WriteLine(e);
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

        /// <summary>
        /// Try clicking the "Next" button and check if the URL changed
        /// </summary>
        /// <param name="nextButtonXPath">the next button's xpath</param>
        /// <returns>true if the button was clickable and changed the url</returns>
        private bool TryClickingNextButton(string nextButtonXPath)
        {
            var nextButton = Driver.FindElement(By.XPath(nextButtonXPath));

            var currentUrl = Driver.Url;
            ScrollElementIntoView(nextButton);
            nextButton.Click();
            WaitUntilLoaded();
            var newUrl = Driver.Url;

            return !currentUrl.Equals(newUrl);
        }

        /// <summary>
        /// Find vacancies on the current page
        /// </summary>
        private IEnumerable<string> FindVacanciesOnPage()
        {
            var vacancies = new List<string>();

            // todo: this is shit. but waiting for other stuff doesn't do shit either
            // https://stackoverflow.com/questions/49971328/selenium-stale-element-reference-works-fine-when-debugging
            Thread.Sleep(3000);

            var list = Driver.FindElements(By.XPath("//*[@data-ng-bind=\"item.JobHeadline\"]"));
            foreach (var vacancy in list)
            {
                vacancies.Add(vacancy.Text);
            }

            return vacancies;
        }
    }
}
