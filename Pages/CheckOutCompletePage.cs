using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_Specflow.Pages
{
    class CheckOutCompletePage
    {
        private IWebDriver driver;
        private string baseUrl;

        public CheckOutCompletePage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.saucedemo.com/checkout-complete.html";
        }

        private readonly By sucessMessageBy = By.XPath("//h2[@class='complete-header']");
        public IWebElement SucessMessage => driver.FindElement(sucessMessageBy);

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public string GetSucessMessage()
        {
            return SucessMessage.Text;
        }
    }
}
