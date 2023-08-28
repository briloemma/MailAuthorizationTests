
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
            WebDriverSingleton.GetInstance().Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriverSingleton.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverSingleton.GetInstance().Manage().Window.Size = new System.Drawing.Size(1536,960);
            WebDriverSingleton.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
        }

    }
}