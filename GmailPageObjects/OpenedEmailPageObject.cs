using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.GmailPageObjects
{
    public class OpenedEmailPageObject : BasePageObject
    {
        private readonly By _receivedEmailBody = By.CssSelector("[class='adM']");
        public OpenedEmailPageObject() : base(By.CssSelector("[class='iH bzn']"))
        {
           

        }

        public string GetNewUserName ()
        {
           return WebDriver.FindElement(_receivedEmailBody).Text;
        }
    }
}
