
using MailAuthorizationTests.Environment;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Collections;

namespace MailAuthorizationTests.Tests
{
    public class BaseTest
    {
        public const string SPECIAL_SETUP = "SpecialSetup";

        [TearDown]
        protected void DoAfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotUtil.TakeScreenShot();
            }
            WebDriverSingleton.GetInstance().Quit();
        }

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            ScreenshotUtil.DeleteScreenShots();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriverSingleton.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverSingleton.GetInstance().Manage().Window.Maximize();
            WebDriverSingleton.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
            if (CheckForSpecialSetup())
            {
                new Hooks().DoBeforeCheckGmailAccountPseudonimHasBeenChangedCorrectly();
                WebDriverSingleton.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
            }
        }

        private static bool CheckForSpecialSetup()
        {
            return TestContext.CurrentContext.Test.Properties["Category"].ToList().Contains(SPECIAL_SETUP);
        }
    }
}