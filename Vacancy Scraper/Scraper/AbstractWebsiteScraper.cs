using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
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

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// Run the scraper and return information on the result
        /// </summary>
        /// <returns></returns>
        public abstract Dictionary<string, object> Run(CompanyObject company);

        /// <summary>
        /// Checks if the given url is a vlid Http or Https formatted url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        protected bool IsValidHttpUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Navigate the browser to a url and wait until the website is fully loaded
        /// </summary>
        /// <param name="url"></param>
        protected void NavigateToUrlAndWaitUntilLoaded(string url)
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
        /// Scroll a given element into the view
        /// </summary>
        /// <param name="element"></param>
        protected void ScrollElementIntoView(IWebElement element)
        {
            while (!element.Displayed)
            {
                var actions = new Actions(Driver);
                actions.MoveToElement(element);
                actions.Perform();
            }
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
                    Thread.Sleep(1000);

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
                        // Environment.SetEnvironmentVariable("webdriver.chrome.driver", pathChrome);

                        var chromeDriverService = ChromeDriverService.CreateDefaultService(SettingsManager.Settings.WebDriversPath);
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
                        // Environment.SetEnvironmentVariable("webdriver.chrome.driver", pathChrome2);

                        var chromeDriverService = ChromeDriverService.CreateDefaultService(SettingsManager.Settings.WebDriversPath);
                        chromeDriverService.HideCommandPromptWindow = true;

                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--start-maximized");

                        Driver = new ChromeDriver(chromeDriverService, chromeOptions);
                    }
                    break;
                case "Firefox":
                    var pathFirefox = Path.Combine(SettingsManager.Settings.WebDriversPath, "geckodriver.exe");
                    if (File.Exists(pathFirefox))
                    {
                        // Environment.SetEnvironmentVariable("webdriver.gecko.driver", pathFirefox);

                        var firefoxDriverService = FirefoxDriverService.CreateDefaultService(SettingsManager.Settings.WebDriversPath);
                        firefoxDriverService.HideCommandPromptWindow = true;
                        firefoxDriverService.FirefoxBinaryPath = pathFirefox;

                        Driver = new FirefoxDriver(firefoxDriverService);
                    }
                    break;
                case "Internet Explorer":
                    var pathIE = Path.Combine(SettingsManager.Settings.WebDriversPath, "IEDriverServer.exe");
                    if (File.Exists(pathIE))
                    {
                        var ieDriverService = InternetExplorerDriverService.CreateDefaultService(SettingsManager.Settings.WebDriversPath);
                        ieDriverService.HideCommandPromptWindow = true;

                        Driver = new InternetExplorerDriver(ieDriverService);
                    }
                    break;
                case "Edge":
                    var pathEdge = Path.Combine(SettingsManager.Settings.WebDriversPath, "MicrosoftWebDriver.exe");
                    if (File.Exists(pathEdge))
                    {
                        var edgeDriverService = EdgeDriverService.CreateDefaultService(SettingsManager.Settings.WebDriversPath);
                        edgeDriverService.HideCommandPromptWindow = true;

                        Driver = new EdgeDriver(edgeDriverService);
                    }
                    break;
                case "Opera":
                    var pathOpera = Path.Combine(SettingsManager.Settings.WebDriversPath, "operadriver.exe");
                    if (File.Exists(pathOpera))
                    {
                        var operaDriverService = OperaDriverService.CreateDefaultService(SettingsManager.Settings.WebDriversPath);
                        operaDriverService.HideCommandPromptWindow = true;

                        var operaOptions = new OperaOptions();
                        operaOptions.BinaryLocation = pathOpera;

                        Driver = new OperaDriver(operaDriverService, operaOptions);
                    }
                    break;
                default:
                    break;
            }
        }

        /* --- USE THESE WITH CARE --- */
        /* The usage of Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); should make this redundant */

        /// <summary>
        /// Get an IWebElement by waiting until it appears
        /// </summary>
        /// <param name="selector">the selector</param>
        /// <returns>the element</returns>
        protected IWebElement GetWebElementAsync(By selector)
        {
            return GetWebElementAsync(selector, 0, 50, 15000);
        }

        /// <summary>
        /// Gets an IWebElement by waiting until it appears
        /// </summary>
        /// <param name="selector">the selector</param>
        /// <param name="waitedTime">the total waited time</param>
        /// <param name="interval">the interval between tries</param>
        /// <param name="maxWaitTime">the maximum time to wait before throwing the exception</param>
        /// <returns></returns>
        protected IWebElement GetWebElementAsync(By selector, int waitedTime, int interval, int maxWaitTime)
        {
            try
            {
                var item = Driver.FindElement(selector);
                return item;
            }
            catch (Exception)
            {
                if (waitedTime >= maxWaitTime) throw;

                Thread.Sleep(interval);
                waitedTime += interval;

                return GetWebElementAsync(selector, waitedTime, interval, maxWaitTime);
            }
        }

        /// <summary>
        /// Get an IWebElement by waiting until it appears
        /// </summary>
        /// <param name="selector">the selector</param>
        /// <returns>the element</returns>
        protected ICollection<IWebElement> GetWebElementsAsync(By selector)
        {
            return GetWebElementsAsync(selector, 0, 50, 15000);
        }

        /// <summary>
        /// Gets an IWebElement by waiting until it appears
        /// </summary>
        /// <param name="selector">the selector</param>
        /// <param name="waitedTime">the total waited time</param>
        /// <param name="interval">the interval between tries</param>
        /// <param name="maxWaitTime">the maximum time to wait before throwing the exception</param>
        /// <returns></returns>
        protected ICollection<IWebElement> GetWebElementsAsync(By selector, int waitedTime, int interval, int maxWaitTime)
        {
            var items = Driver.FindElements(selector);

            if (items.Count == 0)
            {
                if (waitedTime >= maxWaitTime) return new List<IWebElement>();

                Thread.Sleep(interval);
                waitedTime += interval;

                return GetWebElementsAsync(selector, waitedTime, interval, maxWaitTime);
            }

            return items;
        }
    }
}
