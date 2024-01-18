using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Environment.Utils;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.MailRuPageObjects
{
    public class RUMainMenuPageObject : BasePageObject
    {
        private By EmailLineByUser(string gmail) => By.XPath($"//span[contains(@title, '{gmail}')]");
        private By ReadEmailButton => By.CssSelector("[title='Пометить прочитанным']");
        private By EmailLineByRow => By.CssSelector("a[data-draggable-id]");
        private By EmailLineByContent => By.CssSelector("span[class='ll-sp__normal']");

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
                WaitUtil.WaitForElementIsDisplayed(EmailLineByUser(ApplicationConfig.GmailUserName));
            WebDriver.FindElements(EmailLineByUser(ApplicationConfig.GmailUserName)).First().Click();
            return new RUOpenedEmailPageObject();
        }

        public bool IsEmailReceived(string receivedEmailBody)
        {
            WaitUtil.WaitForElementIsDisplayed(EmailLineByRow);
            return WebDriver.FindElements(EmailLineByRow).First().FindElement(EmailLineByContent).Text.Contains(receivedEmailBody) &&
            WebDriver.FindElements(EmailLineByRow).First().FindElement(EmailLineByUser(ApplicationConfig.GmailLogin)).Displayed;
        }

        private bool IsEmailNotRead()
        {
            WaitUtil.WaitForElementIsDisplayed(ReadEmailButton);
            return WebDriver.FindElements(EmailLineByRow).First().FindElement(ReadEmailButton).Displayed;
        }
    }
}

