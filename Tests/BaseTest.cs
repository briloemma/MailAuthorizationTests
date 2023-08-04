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
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                //add test name to screeshot name TestContext.CurrentContext.Test.FullName
                testListener.TestFailed();
            }
            WebDriver.GetInstance().Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriver.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriver.GetInstance().Manage().Window.Maximize();
            WebDriver.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
        }

    }
}