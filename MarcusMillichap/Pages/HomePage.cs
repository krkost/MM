using System;
using OpenQA.Selenium;


namespace MarcusMillichap
{
    public class HomePage
    {
        private static readonly string URL = "https://www.marcusmillichap.com/";

        #region Methods

        public static void NavigateToHomePage()
        {
            SeleniumUtils.NavigateTo(URL);
        }

        public static void SelectLinkOnHomePage(string linkName)
        {
            switch (linkName)
            {
                case "Properties":
                    SeleniumUtils.Click(Elements.PropertiesLink);
                    SeleniumUtils.Wait.UntilElementExists(PropertiesPage.Elements.PropertyTypeDropdown, 20);
                    break;
                case "Financing":
                    SeleniumUtils.Click(Elements.FinancingLink);
                    break;
                case "Research":
                    SeleniumUtils.Click(Elements.ResearchLink);
                    break;
                case "Advisors":
                    SeleniumUtils.Click(Elements.AdvisorsLink);
                    break;
                case "Services":
                    SeleniumUtils.Click(Elements.ServicesLink);
                    break;
            }
        }

        #endregion


        #region Elements

        public static class Elements
        {
            public static By
                HeaderLogo = By.XPath("//div[@class='navbar-header score-navbar-header']"),

                PropertiesLink = By.XPath("//li[@class='score-megamenu-basic-item']/a[@href='/properties']"),
                FinancingLink = By.XPath("//li[@class='score-megamenu-basic-item']/a[@href='/financing']"),
                ResearchLink = By.XPath("//li[@class='score-megamenu-basic-item']/a[@href='/research']"),
                AdvisorsLink = By.XPath("//li[@class='score-megamenu-dropdown dropdown']/a[@href='/advisors']"),
                ServicesLink = By.XPath("//li[@class='score-megamenu-basic-item']/a[@href='/services']");
        }


        #endregion


    }
}
