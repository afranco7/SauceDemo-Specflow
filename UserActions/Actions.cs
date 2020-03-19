using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemo_Specflow
{
    class Actions
    {
        public static void GoToPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            JavaScriptActions.VerifyPageCompleteStateJs(driver);
        }

        public static void Type(IWebElement element, string text, int timeToWait = 15)
        {
            try
            {
                element.SendKeys(text);
            }
            catch
            {
                throw new TimeoutException("after a " + timeToWait + " second wait, was not possible to type the text: " + text + " in the element");
            }
        }

        public static void ClickOn(IWebDriver driver, IWebElement element, int timeToWait = 15)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

                element.Click();
            }
            catch
            {
                throw new TimeoutException("after a " + timeToWait + " second wait, the element could not be clicked");
            }

        }

        public static bool VerifyElementDisplayed(IWebDriver driver, By element, int timeToWait = 15)
        {
            bool isDisplayed = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
                isDisplayed = true;
            }
            catch
            {
                return false;
            }

            return isDisplayed;
        }
    }
}
