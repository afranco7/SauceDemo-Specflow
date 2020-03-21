using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_Specflow.Pages
{
    class CartPage
    {
        private IWebDriver driver;
        private string baseUrl;

        public CartPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.saucedemo.com/cart.html";
        }

        private readonly By checkoutButtonBy = By.XPath("//a[@class='btn_action checkout_button']");
        public IWebElement CheckoutButton => driver.FindElement(checkoutButtonBy);             

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }        

        public void ClickCheckoutButton()
        {
            Actions.ClickOn(driver, CheckoutButton);
        }
    }
}
