using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace MobileAppUITests.BaseCore
{
    public class DriverFactory
    {
        private static IConfiguration configuration;
        
        public DriverFactory()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("testConfig.json", true);

            configuration = builder.Build();
        }

        private static string GetConfigurationProperty(string property)
        {
            return string.IsNullOrWhiteSpace(configuration[property])
                ? Environment.GetEnvironmentVariable(property)
                : configuration[property];
        }

        public AndroidDriver<AndroidElement> CreateAndroidDriver()
        {
            AppiumOptions desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability("app", GetConfigurationProperty("App"));
            desiredCapabilities.AddAdditionalCapability("platformName", GetConfigurationProperty("MobilePlatform"));
            desiredCapabilities.AddAdditionalCapability("deviceName", GetConfigurationProperty("AndroidDeviceName"));
            
            AndroidDriver<AndroidElement> androidDriver= new AndroidDriver<AndroidElement>
                (new Uri(GetConfigurationProperty("AndroidConnection")), desiredCapabilities);
            androidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            return androidDriver;
        }
    }
}
