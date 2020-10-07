using OpenQA.Selenium.Appium.Android;

namespace MobileAppUITests.BaseCore
{
    class BasePage
    {
        AndroidDriver<AndroidElement> AndroidDriver { get; set; }
        public BasePage(AndroidDriver<AndroidElement> androidDriver)
        {
            AndroidDriver = androidDriver;
        }


        public void ClickElementById(string id)
        {
            var element = AndroidDriver.FindElementById(id);
            element.Click();
        }
    }
}
