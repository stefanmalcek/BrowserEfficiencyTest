using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace BrowserEfficiencyTest.Scenarios
{
    internal class MuniSearch : Scenario
    {
        public MuniSearch()
        {
            Name = "MuniSearch";
            DefaultDuration = 45;
        }

        public override void Run(RemoteWebDriver driver, string browser, CredentialManager credentialManager, ResponsivenessTimer timer)
        {
            // Navigate
            driver.NavigateToUrl("https://www.muni.cz/");
            driver.Wait(3);

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Search for 'Software Quality'");

            var search = driver.FindElementByCssSelector("input[id$='search']");
            driver.TypeIntoField(search, "Software Quality" + Keys.Enter);
            driver.WaitForPageLoad(3);
            driver.Wait(3);
            ScenarioEventSourceProvider.EventLog.ScenarioActionStop("Search for 'Software Quality'");

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Click on the first item");
            //Click on the first item
            driver.ClickElement(driver.FindElement(By.XPath("//a[contains(@class,'gs-title')]")));

            driver.WaitForPageLoad();
            driver.Wait(2);

            ScenarioEventSourceProvider.EventLog.ScenarioActionStop("Click on the first item");

            ScenarioEventSourceProvider.EventLog.ScenarioActionStart("Scroll down page");
            // Scroll down to reviews
            driver.ScrollPage(5);
            ScenarioEventSourceProvider.EventLog.ScenarioActionStop("Scroll down page");
        }
    }
}
