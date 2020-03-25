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
    class FieldsValidationSteps
    {
        static LoginPage loginPage;
        static InventoryPage inventoryPage;
        static CartPage cartPage;
        static CheckOutStepOnePage checkOutStepOnePage;
        static string fieldName;

        [BeforeScenario]
        public static void TestInitialize()
        {
            loginPage = new LoginPage(DriverSetup.Driver);
            inventoryPage = new InventoryPage(DriverSetup.Driver);
            cartPage = new CartPage(DriverSetup.Driver);
            checkOutStepOnePage = new CheckOutStepOnePage(DriverSetup.Driver);
        }

        [Given(@"I am on checkout-step-one page with items added on cart")]
        public void GivenIAmOnCheckout_Step_OnePageWithItemsAddedOnCart()
        {
            loginPage.GoToPage();
            loginPage.FillLoginForm("performance_glitch_user", "secret_sauce");
            loginPage.ClickLoginButton();
            inventoryPage.ClickAddToCartButton("Sauce Labs Onesie");
            inventoryPage.ClickAddToCartButton("Sauce Labs Bike Light");
            inventoryPage.ClickShoppingCart();
            cartPage.ClickCheckoutButton();
        }

        [When(@"I press continue button without information on (.*)")]
        public void WhenIPressContinueButtonWithoutInformationOn(string field)
        {
            fieldName = field;
            if (fieldName.Equals("First Name"))
            {
                checkOutStepOnePage.FillInformationForm("", "Franco", "13001");
            }
            else if (fieldName.Equals("Last Name"))
            {
                checkOutStepOnePage.FillInformationForm("Alejandro", "", "13001");
            }
            else if (fieldName.Equals("Postal Code"))
            {
                checkOutStepOnePage.FillInformationForm("Alejandro", "Franco", "");
            }

            checkOutStepOnePage.ClickContinueButton();
        }

        [Then(@"Error message is shown")]
        public void ThenErrorMessageIsShown()
        {
            if (fieldName.Equals("First Name"))
            {
                string expectedErrorMessage = "Error: First Name is required";
                Assert.AreEqual(expectedErrorMessage, checkOutStepOnePage.GetErrorMessage());
            }
            else if (fieldName.Equals("Last Name"))
            {
                string expectedErrorMessage = "Error: Last Name is required";
                Assert.AreEqual(expectedErrorMessage, checkOutStepOnePage.GetErrorMessage());
            }
            else if (fieldName.Equals("Postal Code"))
            {
                string expectedErrorMessage = "Error: Postal Code is required";
                Assert.AreEqual(expectedErrorMessage, checkOutStepOnePage.GetErrorMessage());
            }
        }


    }
}
