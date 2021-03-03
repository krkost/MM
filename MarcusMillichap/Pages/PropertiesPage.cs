using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace MarcusMillichap
{
    public static class PropertiesPage
    {
       
        public enum PropertyType
        {
            All,
            Apartments,
            HospitalityGolf,
            Industrial,
            Land,
            ManufacturedHousing,
            MedicalOffice,
            MixedUse,
            NetLease,
            Office,
            Retail,
            SelfStorage,
            SeniorsHousing
        }

        public static void NavigateToPropertiesPage()
        {
            HomePage.NavigateToHomePage();
            HomePage.SelectLinkOnHomePage("Properties");
        }

        public static void SelectPropertyType(List <PropertyType> properties)
        {
            SeleniumUtils.Click(Elements.PropertyTypeDropdown);
            SeleniumUtils.Wait.UntilElementVisible(Elements.PropertyTypeDropDownBody);

            foreach(var property in properties)
            {
                switch (property)
                {
                    case PropertyType.All:
                        SeleniumUtils.Click(Elements.All);
                        break;
                    case PropertyType.Apartments:
                        SeleniumUtils.Click(Elements.Apartments);
                        break;
                    case PropertyType.HospitalityGolf:
                        SeleniumUtils.Click(Elements.HospitalityGolf);
                        break;
                    case PropertyType.Industrial:
                        SeleniumUtils.Click(Elements.Industrial);
                        break;
                }
            }
        }

        public static void ShowMap(bool show = true)
        {
            bool ShowMapToggleState = bool.Parse(DriverUtils.driver.FindElement(Elements.MapToggle).GetAttribute("checked"));

            if(show != ShowMapToggleState)
            {
                SeleniumUtils.Click(Elements.MapToggle);
            }
        }


        public static class Elements
        {
            public static By
                PropertyTypeDropdown = By.XPath("//div[@class='score-facet-title js-facet']"),
                PropertyTypeDropDownBody = By.XPath("(//fieldset)[1]"),
                LocationField = By.XPath("//input[@placeholder='Any Location']"),

                //Property Types
                All = By.XPath("//label[@for='NaN']"),
                Apartments = By.XPath("//label[@for='propertytype-Apartments']"),
                HospitalityGolf = By.XPath("//label[@for='propertytype-Hospitality/Golf']"),
                Industrial = By.XPath("//label[@for='propertytype-Industrial']"),
                Land = By.XPath("//label[@for='propertytype-Land']"),
                ManufacturedHousing = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                MedicalOffice = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                MixedUse = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                NetLease = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                Office = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                Retail = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                SelfStorage = By.XPath("//label[@for='propertytype-Manufactured Housing']"),
                SeniorsHousing = By.XPath("//label[@for='propertytype-Manufactured Housing']"),

                //Hide/Show Map toggle
                MapToggle = By.Name("map-toggle")

                ;
        }
    }
}
