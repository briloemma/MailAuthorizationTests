using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects
{
    public abstract class BasePageObject
    {
        private readonly By _locator;
        public BasePageObject(By locator)
        {
            _locator = locator;
        }

        public static IWebDriver WebDriver => WebDriverSingleton.GetInstance();
        public bool WaitUntilPageIsDispayed()
        {
            return WaitUtil.WaitForElementIsDisplayed(_locator, $"{GetType().Name} is not found");
        }
    }
}
