using OpenQA.Selenium;
using System;
using System.Threading;

namespace DesafioNUnit.Test.Utils
{
    public static class SeleniumExtensions
    {
        public static void LoadPage(this IWebDriver webDriver, TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }
        public static void Esperar(int secondsTimeout)
        {
            var millisecondsTimeout = secondsTimeout * 1000;

            Thread.Sleep(millisecondsTimeout);
        }
        public static bool TryFindElement(this IWebDriver webDriver, By by, out IWebElement webElement)
        {
            try
            {
                webElement = webDriver.FindElement(by);

                return true;
            }
            catch (NoSuchElementException)
            {
                webElement = null;

                return false;
            }
        }

    }
}
