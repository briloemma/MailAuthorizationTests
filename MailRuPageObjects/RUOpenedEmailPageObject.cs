using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUOpenedEmailPageObject : BasePageObject
    {
        private readonly By _responseButton = By.CssSelector("div [class=letter__footer-button] span[title='Ответить']");
        private By SenderName(string email) => By.CssSelector($"[title='{email}']");
        private readonly By _emailBody = By.CssSelector("[class='letter__body']");
        public RUOpenedEmailPageObject() : base(By.CssSelector($"[title='{GmailTestConfig.GmailUserName}']"))
        {
        }

        public string GetSender()
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, SenderName(GmailTestConfig.GmailLogin));
            string sender = WebDriver.FindElement(SenderName(GmailTestConfig.GmailLogin)).Text;
            return sender;
        }

        public string GetEmailBody()
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _emailBody);
            string emailBody = WebDriver.FindElement(_emailBody).Text;
            return emailBody;
        }

        public RUResponsePageObject OpenResponsePage()
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _responseButton);
            WebDriver.FindElement(_responseButton).Click();
            return new RUResponsePageObject();
        }

    }
}
