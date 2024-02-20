
using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Environment.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

[assembly: LevelOfParallelism(7), Parallelizable(ParallelScope.All)]

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
            WebDriverFactory.GetInstance().Quit();
            WebDriverFactory.Drivers.Remove(Thread.CurrentThread);
        }

        [OneTimeSetUp]
        protected void DoBeforeAllTests()
        {
            ScreenshotUtil.DeleteScreenShots();
        }

        [SetUp]
        protected void DoBeforeEachTest()
        {
            WebDriverFactory.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverFactory.GetInstance().Manage().Window.Maximize();
            WebDriverFactory.GetInstance().Navigate().GoToUrl(ApplicationConfig.GmailHostPrefix);
            if (CheckForSpecialSetup())
            {
                new Hooks().DoBeforeCheckGmailAccountPseudonimHasBeenChangedCorrectly();
                WebDriverFactory.GetInstance().Navigate().GoToUrl(ApplicationConfig.GmailHostPrefix);
            }
        }

        private static bool CheckForSpecialSetup()
        {
            return TestContext.CurrentContext.Test.Properties["Category"].ToList().Contains(SPECIAL_SETUP);
        }
    }
}