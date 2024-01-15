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
            return WaitUtil.WaitForElementIsDisplayed(locator);
        }
        public virtual bool IsEnabled()
        {
            return WaitUtil.WaitForElementIsEnabled(locator);
        }
    }
}
