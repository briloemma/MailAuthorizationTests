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


        public RUMainMenuPageObject() : base(By.CssSelector("[href='/inbox/?']"))
        {
        }

        public RUOpenedEmailPageObject CheckInbox()
        {
            WebDriver.FindElements(_newEmailLine).First().Click();
            return new RUOpenedEmailPageObject();
        }
    }
}
