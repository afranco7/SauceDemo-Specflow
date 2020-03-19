using NUnit.Framework;
using SauceDemo_Specflow.DriverProvider;
using SauceDemo_Specflow.Pages;
using TechTalk.SpecFlow;

namespace SauceDemo_Specflow.Steps
{
    [Binding]
    class LoginAndLogoutSteps
    {
        static LoginPage loginPage;
        static InventoryPage inventoryPage;
        [BeforeScenario]
        public static void TestInitialize()
        {
            loginPage = new LoginPage(DriverSetup.Driver);
            inventoryPage = new InventoryPage(DriverSetup.Driver);
        }
        [Given]
        public void GivenIAmOnTheLoginPage()
        {
            loginPage.GoToPage();
        }

        [When(@"I fill the form with (.*) and (.*)")]
        public void WhenIFillTheFormWith(string username, string password)
        {
            loginPage.FillLoginForm(username, password);
        }

        [When]
        public void WhenIPressLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then]
        public void ThenIShouldBeCorrectlyLoggedIn()
        {
            Assert.IsTrue(inventoryPage.IsProductLabelShown());
        }

        [When]
        public void WhenISelectLogoutOption()
        {
            inventoryPage.ClickBurguerButton();
            inventoryPage.ClickLogoutSidebarLink();
        }

        [Then]
        public void ThenIShouldBeLoggedOut()
        {
            Assert.IsTrue(loginPage.IsUsernameInputShown());
        }

        [Then(@"An Error Message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            string expectedText = "Epic sadface: Sorry, this user has been locked out.";
            Assert.AreEqual(expectedText, loginPage.GetErrorMessageH3Text());
        }

    }
}
