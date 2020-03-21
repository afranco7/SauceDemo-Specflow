using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_Specflow.Pages
{
    class CheckOutStepTwoPage
    {
        private IWebDriver driver;
        private string baseUrl;

        public CheckOutStepTwoPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.saucedemo.com/checkout-step-two.html";
        }

        private readonly By finishButtonBy = By.XPath("//a[@class='btn_action cart_button']");
        public IWebElement FinishButton => driver.FindElement(finishButtonBy);

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public void ClickFinishButton()
        {
            Actions.ClickOn(driver, FinishButton);
        }
    }
}
