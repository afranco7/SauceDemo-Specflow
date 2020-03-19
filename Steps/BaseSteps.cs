using SauceDemo_Specflow.DriverProvider;
using TechTalk.SpecFlow;

namespace SauceDemo_Specflow.Steps
{
    [Binding]
    class BaseSteps
    {
        [AfterTestRun]
        public static void Cleanup()
        {
            DriverSetup.Driver.Quit();
        }
    }
}
