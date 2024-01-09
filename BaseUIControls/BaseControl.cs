using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.BaseUIControls
{
    internal abstract class BaseControl : IControl
    {
        protected IWebElement webElement;
        protected By locator;
        public BaseControl(By locator)
        {
            webElement = WebDriverSingleton.GetInstance().FindElement(locator);
            this.locator = locator;
        }

        public virtual bool IsDisplayed()
        {
            WaitUtil.WaitForElementIsDisplayed(locator);
            return webElement.Displayed;
        }
        public virtual bool IsEnabled()
        {
            WaitUtil.WaitForElementIsDisplayed(locator);
            return webElement.Enabled;
        }
    }
}
