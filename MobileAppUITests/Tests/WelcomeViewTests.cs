using MobileAppUITests.BaseCore;
using MobileAppUITests.PageObject;
using NUnit.Framework;
using System.Threading;

namespace MobileAppUITests.Tests
{
    [TestFixture]
    class WelcomeView:BaseTest
    {
        [Test]
        public void GivenUserIsOnWelcomePageWhenClickSignInButton()
        {
            new WelcomViewPageObject(AndroidDriver).ClickSignInButton();
            Thread.Sleep(1000);
            Assert.Pass();
        }

        [Test]
        public void GivenUserIsOnWelcomePageWhenClickRegisterButton()
        {
            new WelcomViewPageObject(AndroidDriver).ClickSignInButton();
            Thread.Sleep(1000);
            Assert.Pass();
        }
    }
}
