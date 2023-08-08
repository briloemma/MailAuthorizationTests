using MailAuthorizationTests.Environment;
using NUnit.Framework.Interfaces;

namespace MailAuthorizationTests.Tests
{
    public class BaseTest
    {
        [TearDown]
        protected void DoAfterEachTest()
        {
            TestListener testListener = new TestListener();
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                testListener.TestFailed();
            }
            WebDriverFactory.GetInstance().Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriverFactory.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverFactory.GetInstance().Manage().Window.Size = new System.Drawing.Size(width: 1600, height: 1200);
            WebDriverFactory.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
        }

    }
}