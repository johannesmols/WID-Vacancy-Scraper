using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Scraper.WebsiteScrapers
{
    /// <summary>
    /// Scraper implementation for Novo Nordisk
    /// </summary>
    internal class ScrapeNovoNordisk : AbstractWebsiteScraper
    {
        public override List<VacancyObject> Run(CompanyObject company)
        {
            var foundVacancies = new List<VacancyObject>();

            NavigateToUrlAndWaitUntilLoaded(company.Url);

            IReadOnlyCollection<IWebElement> dropDownButtons = Driver.FindElements(By.TagName("button"));
            IWebElement languageButton = null;
            for (var i = 0; i < dropDownButtons.Count; i++)
            {
                if (dropDownButtons.ElementAt(i).Text.Contains("Languages"))
                {
                    languageButton = dropDownButtons.ElementAt(i);
                }
            }

            if (languageButton != null)
            {
                // Open dropdown menu
                languageButton.Click();

                IReadOnlyCollection<IWebElement> languageCheckBoxes = Driver.FindElements(By.ClassName("custom-checked"));
                IWebElement danishCheckBox = null;
                for (var i = 0; i < languageCheckBoxes.Count; i++)
                {
                    if (languageCheckBoxes.ElementAt(i).Text.Equals("Danish"))
                    {
                        danishCheckBox = languageCheckBoxes.ElementAt(i);
                    }
                }

                if (danishCheckBox != null)
                {
                    // Deselect danish
                    danishCheckBox.Click();

                    ScrollToEndOfPage();

                    // Find all vacancies
                    IReadOnlyCollection<IWebElement> vacancies = Driver.FindElements(By.XPath("//tr[@class='row-record']"));
                    for (var i = 0; i < vacancies.Count; i++)
                    {
                        foundVacancies.Add(new VacancyObject(
                            company.Name,
                            vacancies.ElementAt(i).FindElement(By.ClassName("joblist-row-heading")).Text,
                            DateTime.Now,
                            vacancies.ElementAt(i).FindElement(By.TagName("a")).GetAttribute("href")));
                    }
                }
            }

            Driver.Close();

            return foundVacancies;
        }
    }
}
