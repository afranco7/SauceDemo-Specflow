using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo_Specflow.DriverProvider;
using SauceDemo_Specflow.Pages;

namespace SauceDemo_Specflow
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver;
        static LoginPage loginPage;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestMethod1()
        {
            loginPage = new LoginPage(DriverSetup.Driver);
            loginPage.GoToPage();
            loginPage.FillLoginForm("standard_user", "secret_sauce");
        }        

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
