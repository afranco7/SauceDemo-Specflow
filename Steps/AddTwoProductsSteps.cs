using NUnit.Framework;
using SauceDemo_Specflow.DriverProvider;
using SauceDemo_Specflow.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo_Specflow.Steps
{
    [Binding]
    class AddTwoProductsSteps
    {
        static LoginPage loginPage;
        static InventoryPage inventoryPage;
        static CartPage cartPage;
        static CheckOutStepOnePage checkOutStepOnePage;
        static CheckOutStepTwoPage checkOutStepTwoPage;
        static CheckOutCompletePage checkOutCompletePage;

        [BeforeScenario]
        public static void TestInitialize()
        {
            loginPage = new LoginPage(DriverSetup.Driver);
            inventoryPage = new InventoryPage(DriverSetup.Driver);
            cartPage = new CartPage(DriverSetup.Driver);
            checkOutStepOnePage = new CheckOutStepOnePage(DriverSetup.Driver);
            checkOutStepTwoPage = new CheckOutStepTwoPage(DriverSetup.Driver);
            checkOutCompletePage = new CheckOutCompletePage(DriverSetup.Driver);
        }

        [Given(@"I am logged in as a performance_glitch_user")]
        public void GivenIAmLoggedInAsAPerformance_glitch_user()
        {
            loginPage.GoToPage();
            loginPage.FillLoginForm("performance_glitch_user", "secret_sauce");
            loginPage.ClickLoginButton();
        }

        [When(@"I press add to cart button for two products")]
        public void WhenIPressAddToCartButtonFor()
        {
            inventoryPage.ClickAddToCartButton("Sauce Labs Onesie");
            inventoryPage.ClickAddToCartButton("Sauce Labs Bike Light");
        }

        [When(@"I select shopping cart link")]
        public void WhenISelectShoppingCartLink()
        {
            inventoryPage.ClickShoppingCart();
        }

        [Then(@"The Cart page is opened")]
        public void ThenTheCartPageIsOpened()
        {
            string expectedUrl = "https://www.saucedemo.com/cart.html";
            Assert.AreEqual(expectedUrl, DriverSetup.Driver.Url);
        }

        [When(@"I click checkout button")]
        public void WhenIClickCheckoutButton()
        {
            cartPage.ClickCheckoutButton();
        }

        [When(@"I fill the information Form")]
        public void WhenIFillTheInformationForm()
        {
            string expectedUrl = "https://www.saucedemo.com/checkout-step-one.html";
            Assert.AreEqual(expectedUrl, DriverSetup.Driver.Url);

            checkOutStepOnePage.FillInformationForm("Alejandro", "Franco", "13001");
        }

        [When(@"I click continue Button")]
        public void WhenIClickContinueButton()
        {
            checkOutStepOnePage.ClickContinueButton();
        }

        [When(@"I click Finish Button")]
        public void WhenIClickFinishButton()
        {
            string expectedUrl = "https://www.saucedemo.com/checkout-step-two.html";
            Assert.AreEqual(expectedUrl, DriverSetup.Driver.Url);

            checkOutStepTwoPage.ClickFinishButton();
        }

        [Then(@"Sucessfull message is displayed")]
        public void ThenSucessfullMessageIsDisplayed()
        {
            string expectedUrl = "https://www.saucedemo.com/checkout-complete.html";
            Assert.AreEqual(expectedUrl, DriverSetup.Driver.Url);

            string expectedMessage = "THANK YOU FOR YOUR ORDER";
            Assert.AreEqual(expectedMessage, checkOutCompletePage.GetSucessMessage());

        }

    }
}
