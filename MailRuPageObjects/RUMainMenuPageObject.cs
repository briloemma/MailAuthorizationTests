using MailAuthorizationTests.Environment;
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
        private readonly By _unreadEmailButton = By.CssSelector("[title='Пометить непрочитанным']");
        private readonly By _inboxButton = By.XPath("//a[contains(@title, 'непрочитанн')]");

        public RUMainMenuPageObject() : base(By.CssSelector("[href='/inbox/?']"))
        {
        }

        public RUOpenedEmailPageObject CheckInbox()
        {
                WaitExtensions.WaitForElementIsDisplayed(WebDriver, _newEmailLine);
                WebDriver.FindElements(_newEmailLine).First().Click();
                return new RUOpenedEmailPageObject();
        }

        public bool ReadReceivedEmail()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _inboxButton);
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _readEmailButton);
            WebDriver.FindElement(_readEmailButton).Click();
            WaitExtensions.WaitForElementIsDisplayed( WebDriver,_unreadEmailButton);
            return true;
        }
    }
}
