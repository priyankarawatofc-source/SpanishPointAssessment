using OpenQA.Selenium;

namespace AssessmentSpanishPoint.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ModulesMenu => driver.FindElement(By.XPath("//a[text()='Modules']"));
        private IWebElement RepertoireManagementLink => driver.FindElement(By.XPath("//a[contains(text(),'Repertoire Management Module')]"));

        public void GoToSite()
        {
            driver.Navigate().GoToUrl("https://www.matchingengine.com/");
        }

        public void ExpandModules()
        {
            ModulesMenu.Click();
        }

        public void ClickRepertoireManagement()
        {
            RepertoireManagementLink.Click();
        }
    }
}
