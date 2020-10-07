using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace MobileAppUITests.BaseCore
{
    public class DriverFactory
    {
        private static IConfiguration configuration;
        private static IConfigurationBuilder driverConfig;
        private static IConfigurationBuilder serviceConfig;

        private static string GetConfigurationProperty(string property)
        {
            return string.IsNullOrWhiteSpace(configuration[property])
                ? Environment.GetEnvironmentVariable(property)
                : configuration[property];
        }

        public AndroidDriver<AndroidElement> CreateAndroidDriverForService(AppiumLocalService appiumService)
        {
            driverConfig = new ConfigurationBuilder().AddJsonFile("driverConfig.json", true);
            configuration =driverConfig.Build();
            AppiumOptions desiredCapabilities = new AppiumOptions();
            desiredCapabilities.AddAdditionalCapability("app", GetConfigurationProperty("App"));
            desiredCapabilities.AddAdditionalCapability("platformName", GetConfigurationProperty("MobilePlatform"));
            desiredCapabilities.AddAdditionalCapability("deviceName", GetConfigurationProperty("AndroidDeviceName"));
            
            AndroidDriver<AndroidElement> androidDriver= new AndroidDriver<AndroidElement>
                (appiumService,desiredCapabilities);
            androidDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            return androidDriver;
        }

        public AppiumLocalService CreateAppiumLocalService()
        {
            serviceConfig = new ConfigurationBuilder().AddJsonFile("serviceConfig.json", true);
            configuration = serviceConfig.Build();

            return new AppiumServiceBuilder()
                .WithIPAddress(GetConfigurationProperty("IpAddress"))
                .UsingPort(Int32.Parse(GetConfigurationProperty("Port")))
                .WithLogFile(new FileInfo(GetConfigurationProperty("LogFilePath")))
                .Build();

        }
    }
}
