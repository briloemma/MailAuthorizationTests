using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Environment.Utils;
using OpenQA.Selenium;

namespace MailAuthorizationTests.UIControls
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
        public string GetText(bool withWait = true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            return WebDriverFactory.GetInstance().FindElement(locator).Text;
        }
    }
}
