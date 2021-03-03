using System;
using OpenQA.Selenium;

namespace MarcusMillichap
{
    public class AdvisorsPage
    {

        public static void NavigateToAdvisorsPage()
        {
            HomePage.NavigateToHomePage();
            HomePage.SelectLinkOnHomePage("Advisors");
        }

        public static void SearchByAdvisorsName(string name)
        {
            SeleniumUtils.Click(Elements.searchField);
            SeleniumUtils.SetText(Elements.searchField, name);
            SeleniumUtils.Click(Elements.searchButton);
            SeleniumUtils.Wait.UntilElementVisible(Elements.resultsArea);
        }


        public static class Elements
        {
            public static By
                searchField = By.XPath("(//input[@class='tt-input'])[2]"),
                searchButton = By.XPath("//a[@class='button score-button ']"),

                resultsArea = By.XPath("(//div[@class='displaying-results'])[2]"),
                resultCard = By.XPath("//div[@class='mm-tile']")


                ;

        }
    }
}
