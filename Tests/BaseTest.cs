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
            WebDriverFactory.GetInstance().Manage().Window.Maximize();
            WebDriverFactory.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
        }

    }
}