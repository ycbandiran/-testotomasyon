using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace Helpers
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementExtension(this IWebDriver driver, By by, double timeOutInSeconds)
        {
            if(timeOutInSeconds > 0)
            {
                var task = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return task.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
}
