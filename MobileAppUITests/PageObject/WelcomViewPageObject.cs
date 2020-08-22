using MobileAppUITests.BaseCore;
using MobileAppUITests.Selectors;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

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
