using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarcusMillichap
{
    public class DriverUtils
    {
        public static IWebDriver driver;

        private const string driverPath = "/home/kristina/Projects/chromedriver88_linux64";
        private const string driverExecutableFilename = "chromedriver";

        public DriverUtils()
        {
            ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService
            (@driverPath, "chromedriver");
            driver = new ChromeDriver(chromeService);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static string getDriverPath()
        {
            return driverPath;
        }

        public static string getDriverExecutableFilename()
        {
            return driverExecutableFilename;
        }

        public static void SetDriver()
        {
            ChromeDriverService chromeService = ChromeDriverService.CreateDefaultService
            (getDriverPath(), getDriverExecutableFilename());
            driver = new ChromeDriver(chromeService);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void SetDriver(IWebDriver driver)
        {
            DriverUtils.driver = driver;
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

    }
}
