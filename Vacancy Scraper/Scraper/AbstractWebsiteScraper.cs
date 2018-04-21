﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using Vacancy_Scraper.JsonManagers;
using Vacancy_Scraper.Objects;

namespace Vacancy_Scraper.Scraper
{
    /// <summary>
    /// Structure for setting up and using a scraper, as well as returning found vacancies
    /// </summary>
    internal abstract class AbstractWebsiteScraper
    {
        protected IWebDriver Driver { get; private set; }
        protected SettingsManager SettingsManager { get; private set; } = new SettingsManager();

        /// <summary>
        /// Initialize the relevant web driver
        /// </summary>
        protected AbstractWebsiteScraper()
        {
            InitializeWebDriver();
        }

        /// <summary>
        /// Run the scraper and return information on the result
        /// </summary>
        /// <returns></returns>
        public abstract List<VacancyObject> Run(CompanyObject company);

        /// <summary>
        /// Navigate the browser to a url and wait until the website is fully loaded
        /// </summary>
        /// <param name="url"></param>
        protected void NavigateToUrlAndWaitUntilLoaded(String url)
        {
            Driver.Navigate().GoToUrl(url);
            WaitUntilLoaded();
        }

        /// <summary>
        /// Wait until the website is fully loaded
        /// </summary>
        protected void WaitUntilLoaded()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(x => ((IJavaScriptExecutor) Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Scroll to the the end of the website
        /// This can be useful for inifinetly scrolling pages
        /// </summary>
        protected void ScrollToEndOfPage()
        {
            try
            {
                long lastHeight = (long) ((IJavaScriptExecutor) Driver).ExecuteScript("return document.body.scrollHeight");

                while (true)
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");

                    // TODO: Implement a better way to wait
                    System.Threading.Thread.Sleep(2000);

                    long newHeight = (long)((IJavaScriptExecutor)Driver).ExecuteScript("return document.body.scrollHeight");
                    if (newHeight == lastHeight)
                    {
                        break;
                    }
                    lastHeight = newHeight;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Initialize the web driver that the user has selected in the settings screen
        /// </summary>
        private void InitializeWebDriver()
        {
            switch (SettingsManager.Settings.ScraperWebDriver)
            {
                case "Chrome":
                    var pathChrome = Path.Combine(SettingsManager.Settings.WebDriversPath, "chromedriver.exe");
                    if (File.Exists(pathChrome))
                    {
                        Environment.SetEnvironmentVariable("webdriver.chrome.driver", pathChrome);

                        var chromeDriverService = ChromeDriverService.CreateDefaultService();
                        chromeDriverService.HideCommandPromptWindow = true;

                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--start-maximized");

                        Driver = new ChromeDriver(chromeDriverService, chromeOptions);
                    }
                    break;
                case "Headless Chrome":
                    var pathChrome2 = Path.Combine(SettingsManager.Settings.WebDriversPath, "chromedriver.exe");
                    if (File.Exists(pathChrome2))
                    {
                        Environment.SetEnvironmentVariable("webdriver.chrome.driver", pathChrome2);

                        var chromeDriverService = ChromeDriverService.CreateDefaultService();
                        chromeDriverService.HideCommandPromptWindow = true;

                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--start-maximized");

                        Driver = new ChromeDriver(chromeDriverService, chromeOptions);
                    }
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "Internet Explorer":
                    Driver = new InternetExplorerDriver();
                    break;
                case "Edge":
                    Driver = new EdgeDriver();
                    break;
                case "PhantomJS":
                    Driver = new PhantomJSDriver();
                    break;
                case "Opera":
                    Driver = new OperaDriver();
                    break;
                default:
                    Driver = new InternetExplorerDriver();
                    break;
            }
        }
    }
}