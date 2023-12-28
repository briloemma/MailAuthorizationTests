using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.MailRuPageObjects
{
    public class RUOpenedEmailPageObject : BasePageObject
    {
        private readonly Button _responseButton = new Button(By.CssSelector("div [class=letter__footer-button] span[title='Ответить']"));
        private TextField SenderName(string email) => new TextField(By.CssSelector($"[title='{email}']"));
        private readonly TextField _emailBody = new TextField(By.CssSelector("[class='letter__body']"));
        public RUOpenedEmailPageObject() : base(By.CssSelector($"[title='{GmailTestConfig.GmailUserName}']"))
        {
        }

        public string GetSender()
        {
            return SenderName(GmailTestConfig.GmailLogin).GetText();
        }

        public string GetEmailBody()
        {
            return _emailBody.GetText();
        }

        public MailAuthorizationTests.MailRuPageObjects.RUResponsePageObject OpenResponsePage()
        {
            _responseButton.Click();
            return new MailAuthorizationTests.MailRuPageObjects.RUResponsePageObject();
        }

    }
}
