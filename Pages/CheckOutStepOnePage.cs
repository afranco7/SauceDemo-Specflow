using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_Specflow.Pages
{
    class CheckOutStepOnePage
    {
        private IWebDriver driver;
        private string baseUrl;

        public CheckOutStepOnePage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.saucedemo.com/checkout-step-one.html";
        }

        private readonly By firstNameBy = By.Id("first-name");
        public IWebElement FirstNameTextBox => driver.FindElement(firstNameBy);

        private readonly By lastNameBy = By.Id("last-name");
        public IWebElement LastNameTextBox => driver.FindElement(lastNameBy);

        private readonly By zipCodeBy = By.Id("postal-code");
        public IWebElement ZipCodeTextBox => driver.FindElement(zipCodeBy);

        private readonly By continueButtonBy = By.XPath("//input[@class='btn_primary cart_button']");
        public IWebElement ContinueButton => driver.FindElement(continueButtonBy);

        private readonly By errorMessageBy = By.XPath("//h3[@data-test='error']");
        public IWebElement errorMessage => driver.FindElement(errorMessageBy);


        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public void ClickContinueButton()
        {
            Actions.ClickOn(driver, ContinueButton);
        }

        public void FillInformationForm(string firstName, string lastName, string zipCode)
        {
            Actions.Type(FirstNameTextBox, firstName);
            Actions.Type(LastNameTextBox, lastName);
            Actions.Type(ZipCodeTextBox, zipCode);
        }
    }
}
