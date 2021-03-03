using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarcusMillichap
{
    public class SeleniumUtils
    {

        public SeleniumUtils()
        {
        }


        public static void NavigateTo(string url)
        {
            DriverUtils.driver.Navigate().GoToUrl(url);
            DriverUtils.driver.Manage().Window.Maximize();
        }

        public static IWebElement FindByLocator(By locator)
        {
            return DriverUtils.driver.FindElement(locator);
        }

        public static void Click(By locator)
        {
            FindByLocator(locator).Click();
        }

        public static void SetText(By locator, string text)
        {
            FindByLocator(locator).SendKeys(text);
        }

        public static void CloseWindow()
        {
            DriverUtils.driver.Close();
        }


        public static class Wait
        {

            public static IWebElement UntilElementExists(By locator, int timeout = 10)
            {
                try
                {
                    var wait = new WebDriverWait(DriverUtils.driver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with locator {locator} was not found");
                    throw;
                }
            }

            public static IWebElement UntilElementVisible(By locator, int timeout = 20)
            {
                try
                {
                    var wait = new WebDriverWait(DriverUtils.driver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with locator {locator} was not visible");
                    throw;
                }
            }

            public static IWebElement UntilElementClickable(By locator, int timeout = 10)
            {
                try
                {
                    var wait = new WebDriverWait(DriverUtils.driver, TimeSpan.FromSeconds(timeout));
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine($"Element with locator {locator} was not clickable");
                    throw;
                }
            }

        }


        public static class Assert
        {

            public static bool IsDisplayed(By locator)
            {
                try
                {
                    return FindByLocator(locator).Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

        }


    }
}
