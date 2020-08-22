using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MobileAppUITests.BaseCore
{
    public class BaseTest
    {
        protected AndroidDriver<AndroidElement> androidDriver { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

        }
        [SetUp]
        public void SetUp()
        {
            if (androidDriver != null)
            {
                androidDriver.Quit();
            }
            androidDriver = new DriverFactory().CreateAndroidDriver();
        }

        [TearDown]
        public void TearDown()
        {
            androidDriver.CloseApp();
            androidDriver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            
        }
    }
}
