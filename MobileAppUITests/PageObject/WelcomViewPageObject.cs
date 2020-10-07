using MobileAppUITests.BaseCore;
using MobileAppUITests.Selectors;
using OpenQA.Selenium.Appium.Android;

namespace MobileAppUITests.PageObject
{
    class WelcomViewPageObject: BasePage
    {
        public WelcomViewPageObject(AndroidDriver<AndroidElement> androidDriver) : base(androidDriver)
        {

        }

        public void ClickSignInButton()
        {
            ClickElementById(WelcomeViewSelectos.SignInButtonId);
        }
    }
}
