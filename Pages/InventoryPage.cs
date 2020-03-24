using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo_Specflow.Pages
{
    class InventoryPage
    {
        private IWebDriver driver;
        private string baseUrl;
        private static string product=null;

        public InventoryPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.saucedemo.com/";
        }

        private readonly By burguerButtonBy = By.ClassName("bm-burger-button");
        public IWebElement BurguerButton => driver.FindElement(burguerButtonBy);

        private readonly By logoutSidebarLinkBy = By.Id("logout_sidebar_link");
        public IWebElement LogoutSidebarLink => driver.FindElement(logoutSidebarLinkBy);

        private readonly By productLabelBy = By.ClassName("product_label");
        public IWebElement ProductLabel => driver.FindElement(productLabelBy);

        private readonly By shoppingCartLink = By.Id("shopping_cart_container");
        public IWebElement ShoppingCart => driver.FindElement(shoppingCartLink);            

        private By GetAddToCartButtonBy(string item)
        {
            return By.XPath("//*[@class='inventory_item']//*[@class='inventory_item_name' and text()='" + item + "']/../../..//button");
        }

        public string CartButtonText(string item)
        {
            return driver.FindElement(GetAddToCartButtonBy(item)).Text;
        }

        public void ClickAddToCartButton(string item)
        {            
            Actions.ClickOn(driver, driver.FindElement(GetAddToCartButtonBy(item)));   
        }

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public void ClickBurguerButton()
        {
            Actions.ClickOn(driver, BurguerButton);
        }

        public void ClickLogoutSidebarLink()
        {
            Actions.ClickOn(driver, LogoutSidebarLink);
        }

        public bool IsProductLabelShown()
        {
            return Actions.VerifyElementDisplayed(driver, productLabelBy);
        }

        public void ClickShoppingCart()
        {
            Actions.ClickOn(driver, ShoppingCart);
        }
    }
}
