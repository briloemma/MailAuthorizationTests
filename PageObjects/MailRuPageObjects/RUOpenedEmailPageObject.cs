using MailAuthorizationTests.UIControls;
using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.MailRuPageObjects
{
    public class RUOpenedEmailPageObject : BasePageObject
    {
        private Button ResponseButton => new Button(By.CssSelector("div [class=letter__footer-button] span[title='Ответить']"));
        private Label SenderName(string email) => new Label(By.CssSelector($"[title='{email}']"));
        private Label EmailBody => new Label(By.CssSelector("[class='letter__body']"));
        public RUOpenedEmailPageObject() : base(By.CssSelector($"[title='{ApplicationConfig.GmailUserName}']"))
        {
        }

        public string GetSender()
        {
            return SenderName(ApplicationConfig.GmailLogin).GetText();
        }

        public string GetEmailBody()
        {
            return EmailBody.GetText();
        }

        public MailAuthorizationTests.MailRuPageObjects.RUResponsePageObject OpenResponsePage()
        {
            ResponseButton.Click();
            return new MailAuthorizationTests.MailRuPageObjects.RUResponsePageObject();
        }

    }
}
