using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.BaseUIControls
{
    internal class Button : BaseControl
    {
        public Button(By locator) : base(locator)
        {

        }

        public void Click(bool withWait = true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            WebDriverSingleton.GetInstance().FindElement(_locator).Click();
        }

    }
}
