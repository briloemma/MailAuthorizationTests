using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.MailRuPageObjects
{
    public class RUMainMenuPageObject : BasePageObject
    {
        private By EmailLineByUser(string gmail) => By.XPath($"//span[contains(@title, '{gmail}')]");
        private readonly By _readEmailButton = By.CssSelector("[title='Пометить прочитанным']");
        private By _emailLineByRow = By.CssSelector("a[data-draggable-id]");
        private By _emailLineByContent = By.CssSelector("span[class='ll-sp__normal']");

        public RUMainMenuPageObject() : base(By.CssSelector("[href='/inbox/?']"))
        {
        }

        public bool IsEmailReceivedAndNotRead(string receivedEmailBody)
        {
            return IsEmailReceived(receivedEmailBody) && IsEmailNotRead();
        }
        public RUOpenedEmailPageObject CheckInbox(string receivedEmailBody)
        {
            if (IsEmailReceivedAndNotRead(receivedEmailBody))
                WaitUtil.WaitForElementIsDisplayed(EmailLineByUser(GmailTestConfig.GmailUserName));
            WebDriver.FindElements(EmailLineByUser(GmailTestConfig.GmailUserName)).First().Click();
            return new RUOpenedEmailPageObject();
        }

        public bool IsEmailReceived(string receivedEmailBody)
        {
            WaitUtil.WaitForElementIsDisplayed(_emailLineByRow);
            return WebDriver.FindElements(_emailLineByRow).First().FindElement(_emailLineByContent).Text.Contains(receivedEmailBody) &&
            WebDriver.FindElements(_emailLineByRow).First().FindElement(EmailLineByUser(GmailTestConfig.GmailLogin)).Displayed;
        }

        private bool IsEmailNotRead()
        {
            WaitUtil.WaitForElementIsDisplayed(_readEmailButton);
            return WebDriver.FindElements(_emailLineByRow).First().FindElement(_readEmailButton).Displayed;
        }
    }
}

