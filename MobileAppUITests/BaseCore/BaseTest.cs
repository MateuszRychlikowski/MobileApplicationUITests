using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace MobileAppUITests.BaseCore
{
    public class BaseTest
    {
        protected AndroidDriver<AndroidElement> AndroidDriver { get; set; }
        protected AppiumLocalService AppiumService { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

            AppiumService = new DriverFactory().CreateAppiumLocalService();
            AppiumService.Start();
        }
        [SetUp]
        public void SetUp()
        {
            if (AndroidDriver != null)
            {
                AndroidDriver.Quit();
            }
            AndroidDriver = new DriverFactory().CreateAndroidDriverForService(AppiumService);
        }

        [TearDown]
        public void TearDown()
        {
            AndroidDriver.CloseApp();
            AndroidDriver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AppiumService.Dispose();
        }
    }
}
