

using OpenQA.Selenium;

namespace SauceDemo_Specflow.Pages
{
    class LoginPage
    {
        private IWebDriver driver;
        private string baseUrl;

        public LoginPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.saucedemo.com/";
        }

        private readonly By usernameInputBy = By.Id("user-name");
        public IWebElement UsernameInput => driver.FindElement(usernameInputBy);

        private readonly By ErrorMessageH3By = By.XPath("//h3[@data-test='error']");
        public IWebElement ErrorMessageH3 => driver.FindElement(ErrorMessageH3By);

        private readonly By passwordInputBy = By.Id("password");
        public IWebElement PasswordInput => driver.FindElement(passwordInputBy);

        private readonly By loginButtonBy = By.ClassName("btn_action");
        public IWebElement LoginButton => driver.FindElement(loginButtonBy);

        public bool IsUsernameInputShown()
        {
            return Actions.VerifyElementDisplayed(driver, usernameInputBy);
        }

        public void GoToPage()
        {
            Actions.GoToPage(driver, baseUrl);
        }

        public string GetErrorMessageH3Text()
        {
            return ErrorMessageH3.Text;
        }

        public void FillLoginForm(string username, string password)
        {
            Actions.Type(UsernameInput, username);
            Actions.Type(PasswordInput, password);

        }

        public void ClickLoginButton()
        {
            Actions.ClickOn(driver, LoginButton);
        }

    }
}
