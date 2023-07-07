using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUOpenedEmailPageObject : BasePageObject
    {
        private readonly By _respondButton = By.CssSelector("span[title='Ответить']");
        private readonly By _deleteEmailButton = By.CssSelector("[title='Удалить']");
        private readonly By _responceButton = By.XPath("//div[contains(@class, 'element_reply')]");
        private readonly By _textBox = By.CssSelector("[role='textbox']");
        private readonly By _sendButton = By.CssSelector("[data-test-id='send']");
        private  By SenderName(string email) => By.CssSelector($"[title='{email}']");
        private readonly By _emailBody = By.CssSelector("[class='letter__body']");
        public RUOpenedEmailPageObject() : base(By.CssSelector($"[title='{GmailTestConfig.GmailUserName}']"))
        {
        }

        public string GetSender ()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, SenderName(GmailTestConfig.GmailUserName));
            string sender = WebDriver.FindElement(SenderName(GmailTestConfig.GmailUserName)).Text;
            return sender;
        }

        public string GetEmailBody ()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _emailBody);
            string emailBody = WebDriver.FindElement(_emailBody).Text;
            return emailBody;
        }

        public RUResponsePageObject SendResponse ()
        {
            WebDriver.FindElements(_respondButton).First().Click();
            return new RUResponsePageObject();
        }

        public void DeleteEmail ()
        {
            WebDriver.FindElement(_deleteEmailButton).Click();
        }

        public void SendInResponceNewUserName ()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _responceButton);
            WebDriver.FindElement(_responceButton).Click();
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _textBox);
            WebDriver.FindElement(_textBox).SendKeys(GmailTestConfig.NewGmailPseudonim);
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _sendButton);
            WebDriver.FindElement (_sendButton).Click();
        }
    }
}
