using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHelpers
{
    public static class Helpers
    {
        private static ChromeDriver Driver;
        private static WebDriverWait DriverWait;
        public enum SelectTypes { XPath, Id, Name }

        static Helpers()
        {
            Driver = new ChromeDriver();
            DriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public static IWebElement SelectElementByType(SelectTypes type, string val)
        {            
            InvisibilityOfElement(By.XPath(val), val);
            switch (type)
            {
                case SelectTypes.Id:
                    return Driver.FindElement(By.Id(val));
                case SelectTypes.Name:
                    return Driver.FindElement(By.Name(val));
                case SelectTypes.XPath:
                    return Driver.FindElement(By.XPath(val));
                default:
                    return Driver.FindElement(By.XPath(val));
            }
        }

        public static void Click(this IWebElement element)
        {
            element.Click();
        }

        public static void Key(this IWebElement element, string key)
        {
            element.SendKeys(key);
        }

        public static void InvisibilityOfElement(By type, string val, int duration = 10)
        {
            WebDriverWait waitTask = new WebDriverWait(Driver, TimeSpan.FromSeconds(duration));
            waitTask.Until(ExpectedConditions.InvisibilityOfElementLocated(type));
        }

        public static void Go(string url) => Driver.Navigate().GoToUrl(url);

        private static void WaitUntilPageLoad()
        {
            DriverWait.Until(Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static IWebDriver GetDriver()
        {
            return Driver;
        }

        public static WebDriverWait GetDriverWait()
        {
            return DriverWait;
        }
    }
}
