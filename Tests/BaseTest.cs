using Amazon.CloudWatch.Model;
using MailAuthorizationTests.Environment;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.DevTools.V111.SystemInfo;

namespace MailAuthorizationTests.Tests
{
    public class BaseTest
    {
        [TearDown]
        protected void DoAfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenshotUtil.TakeScreenShot();
            }
            WebDriverSingleton.GetInstance().Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriverSingleton.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverSingleton.GetInstance().Manage().Window.Maximize();
            WebDriverSingleton.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
        }

    }
}