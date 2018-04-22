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
    /// <inheritdoc/>
    /// <summary>
    /// Scraper implementation for Novo Nordisk
    /// </summary>
    internal class ScrapeNovoNordisk : AbstractWebsiteScraper
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
                    throw new WebDriverException("Invalid URL");

                IReadOnlyCollection<IWebElement> dropDownButtons = Driver.FindElements(By.TagName("button"));
                IWebElement languageButton = null;

                if (dropDownButtons.Count == 0)
                    throw new WebDriverException("Couldn't find language dropdown buttons");

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

                    if (languageCheckBoxes.Count == 0)
                        throw new WebDriverException("Couldn't find language checkboxes");

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
                    else
                    {
                        throw new WebDriverException("Couldn't find checkbox for danish language");
                    }
                }
                else
                {
                    throw new WebDriverException("Couldn't find language button");
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
