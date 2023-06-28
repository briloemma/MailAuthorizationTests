using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUMainMenuPageObject : BasePageObject
    {
        private readonly By _newEmailLine = By.XPath("//span[contains(@title, 'Auto Tests')]");
        private readonly By _readEmailButton = By.CssSelector("[title='Пометить прочитанным']");

        public RUMainMenuPageObject() : base(By.CssSelector("[href='/inbox/?']"))
        {
        }

        public RUOpenedEmailPageObject CheckInbox()
        {
            WebDriver.FindElements(_newEmailLine).First().Click();
            return new RUOpenedEmailPageObject();
        }

        public bool CheckEmailIsReceived()
        {
            var _inboxButton = By.XPath("//a[contains(@title, '1 непрочитанное')]");
            try
            {
                WebDriver.FindElement(_inboxButton);
                WebDriver.FindElement(_readEmailButton).Click();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
