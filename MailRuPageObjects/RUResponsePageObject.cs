using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUResponsePageObject : BasePageObject
    {
        private readonly By _emailBodyInput = By.CssSelector("[data-cke-eol]");
        private readonly By _sendButton = By.XPath("//span[text()='Отправить']");

        public RUResponsePageObject() : base(By.XPath("//div[contains(@class, 'contactsContainer')]"))
        {
        }

        public RUOpenedEmailPageObject SendResponse (string emailBody)
        {
            WebDriver.FindElement(_emailBodyInput).SendKeys(emailBody);
            WebDriver.FindElement(_sendButton).Click();
            return new RUOpenedEmailPageObject();
        }

    }
}
