using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.BaseUIControls
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
            WebDriverSingleton.GetInstance().FindElement(_locator).SendKeys(text);
        }
    }
}
