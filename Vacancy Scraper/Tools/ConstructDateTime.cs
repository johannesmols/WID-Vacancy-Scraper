using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Vacancy_Scraper.JsonManagers;

namespace Vacancy_Scraper.Tools
{
    class ConstructDateTime
    {
        /// <summary>
        /// Construct a DateTime that acts as a boundary to decide whether a duplicate is too old and can be ignored
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateToIgnoreDuplicatesBefore()
        {
            var settingsManager = new SettingsManager();
            var result = DateTime.Now;

            try
            {
                switch (settingsManager.Settings.ScraperIgnoreDuplicatesTimeMode)
                {
                    case "Days":
                        result = result.AddDays(settingsManager.Settings.ScraperIgnoreDuplicatesValue * -1);
                        break;
                    case "Weeks":
                        result = result.AddDays(settingsManager.Settings.ScraperIgnoreDuplicatesValue * -1 * 7);
                        break;
                    case "Months":
                        result = result.AddMonths((int)settingsManager.Settings.ScraperIgnoreDuplicatesValue * -1);
                        break;
                    case "Years":
                        result = result.AddYears((int)settingsManager.Settings.ScraperIgnoreDuplicatesValue * -1);
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(
                    @"Setting to ignore duplicates before a certain time is too far back. Please consider a date after Jesus was born.",
                    @"Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }

            return result;
        }
    }
}
