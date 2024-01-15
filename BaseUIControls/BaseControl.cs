using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.BaseUIControls
{
    internal abstract class BaseControl : IControl
    {
        protected By locator;

        public BaseControl(By locator)
        {
            this.locator = locator;
        }

        public virtual bool IsDisplayed()
        {
            WaitUtil.WaitForElementIsDisplayed(locator);
            return WebDriverFactory.GetInstance().FindElement(locator).Displayed;
        }
        public virtual bool IsEnabled()
        {
            WaitUtil.WaitForElementIsDisplayed(locator);
            return WebDriverFactory.GetInstance().FindElement(locator).Enabled;
        }
    }
}
