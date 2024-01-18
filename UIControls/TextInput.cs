using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.UIControls
{
    internal class TextInput : BaseControl
    {
        public TextInput(By locator) : base(locator)
        {
        }
        public void SendKeys(string text, bool withWait = true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            WebDriverFactory.GetInstance().FindElement(locator).SendKeys(text);
        }
    }
}
