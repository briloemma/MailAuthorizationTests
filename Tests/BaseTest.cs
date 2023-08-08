using MailAuthorizationTests.Environment;
using NUnit.Framework.Interfaces;

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
            WebDriverFactory.GetInstance().Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriverFactory.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverFactory.GetInstance().Manage().Window.Maximize();
            WebDriverFactory.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
        }

    }
}