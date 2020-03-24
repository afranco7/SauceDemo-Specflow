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

        private readonly By label1By = By.Id("item_2_title_link");
        public IWebElement Label1 => driver.FindElement(label1By);

        private readonly By label2By = By.Id("item_0_title_link");
        public IWebElement Label2 => driver.FindElement(label2By);

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }        

        public void ClickCheckoutButton()
        {
            Actions.ClickOn(driver, CheckoutButton);
        }

        public string GetLabel1Text()
        {
            return Label1.Text;
        }

        public string GetLabel2Text()
        {
            return Label2.Text;
        }
    }
}
