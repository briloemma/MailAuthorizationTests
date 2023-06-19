using MailAuthorizationTests.Environment;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

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
                testListener.TestFailed();
            }
            Webdriver.GetInstance().Quit();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            Webdriver.GetInstance().Manage().Cookies.DeleteAllCookies();
            Webdriver.GetInstance().Navigate().GoToUrl(GmailTestConfig.GmailHostPrefix);
            Webdriver.GetInstance().Manage().Window.Maximize();
        }

    }
}