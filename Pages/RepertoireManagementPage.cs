using System.Collections.Generic;
using OpenQA.Selenium;

namespace AssessmentSpanishPoint.Pages
{
    public class RepertoireManagementPage
    {
        private readonly IWebDriver driver;

        public RepertoireManagementPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement AdditionalFeaturesSection => driver.FindElement(By.XPath("//h2[contains(text(),'Additional Features')]"));
        private IWebElement ProductsSupportedButton => driver.FindElement(By.XPath("//button[contains(.,'Products Supported')]"));
        private IWebElement ProductsHeading => driver.FindElement(By.XPath("//h3[contains(text(),'There are several types of Product Supported:')]"));
        private IReadOnlyCollection<IWebElement> ProductItems => driver.FindElements(By.XPath("//h3[contains(text(),'There are several types')]/following-sibling::ul/li"));

        public void ScrollToAdditionalFeatures()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", AdditionalFeaturesSection);
        }

        public void OpenProductsSupported()
        {
            ProductsSupportedButton.Click();
        }

        public bool IsProductsHeadingDisplayed()
        {
            return ProductsHeading.Displayed;
        }

        public IReadOnlyCollection<IWebElement> GetProductItems()
        {
            return ProductItems;
        }
    }
}
