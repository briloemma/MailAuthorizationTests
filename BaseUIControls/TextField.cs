using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.BaseUIControls
{
    internal class TextField : BaseControl
    {
        public TextField(By locator) : base(locator)
        {

        }

        public string GetText(bool withWait = true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            return WebDriverSingleton.GetInstance().FindElement(_locator).Text;
        }
    }
}
