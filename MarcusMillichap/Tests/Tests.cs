using System;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarcusMillichap
{
    public class Tests
    {
        [OneTimeSetUp]
        public void SetUpDriver()
        {
            DriverUtils.SetDriver();
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            SeleniumUtils.CloseWindow();
        }

        [Test]
        public static void NavigateToHomePage_HomePageOpenedSuccessfully()
        {
            HomePage.NavigateToHomePage();

            SeleniumUtils.Assert.IsDisplayed(HomePage.Elements.HeaderLogo);
        }


        [Test]
        public static void NavigateToPropertiesPage_FilterByPropertyType_CorrectResultsReturned()
        {
            List<PropertiesPage.PropertyType> properties = 
            new List<PropertiesPage.PropertyType> { PropertiesPage.PropertyType.Apartments, PropertiesPage.PropertyType.Industrial };

            PropertiesPage.NavigateToPropertiesPage();
            PropertiesPage.SelectPropertyType(properties);
            PropertiesPage.ShowMap(false);

            //verifying at least one record was returned
            SeleniumUtils.Assert.IsDisplayed(By.XPath("//li[@propertytype='Apartments'"));

            //System.Threading.Thread.Sleep(3000);
        }


        [Test]
        public static void NavigateToAdvisorsPage_SearchByName_ResultsReturned()
        {
            string advisorsLastName = "DeLoney";

            AdvisorsPage.NavigateToAdvisorsPage();
            AdvisorsPage.SearchByAdvisorsName(advisorsLastName);

            SeleniumUtils.Assert.IsDisplayed(AdvisorsPage.Elements.resultCard);

            System.Threading.Thread.Sleep(3000);
        }

    }
}
