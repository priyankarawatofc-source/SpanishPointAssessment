using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AssessmentSpanishPoint.Pages;

namespace Assessment.Tests
{
    public class AutomationTests : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;
        private readonly RepertoireManagementPage repertoirePage;

        public AutomationTests()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);

            homePage = new HomePage(driver);
            repertoirePage = new RepertoireManagementPage(driver);
        }

        [Fact]
        public void VerifySupportedProducts()
        {
            homePage.GoToSite();
            homePage.ExpandModules();
            homePage.ClickRepertoireManagement();
            repertoirePage.ScrollToAdditionalFeatures();
            repertoirePage.OpenProductsSupported();
            Assert.True(repertoirePage.IsProductsHeadingDisplayed());
            string[] expectedProducts =
            {
                "Singles",
                "Albums",
                "Compilations",
                "Box Sets",
                "Digital Downloads",
                "Ringtones"
            };

            var actualProducts = repertoirePage.GetProductItems();

            foreach (var expected in expectedProducts)
            {
                Assert.Contains(actualProducts, item => item.Text.Contains(expected, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
