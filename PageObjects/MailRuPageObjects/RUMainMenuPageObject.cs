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

        public RUOpenedEmailPageObject CheckInbox(string receivedEmailBody)
        {
            WaitUtil.WaitForEmailInMailRuInbox(receivedEmailBody);
            FindEmailBySenderAndBody(receivedEmailBody).Click();
            return new RUOpenedEmailPageObject();
        }

        public bool IsEmailReceived(string receivedEmailBody)
        {
            WaitUtil.WaitForElementIsDisplayed(EmailLineByRow);
            return FindEmailBySenderAndBody(receivedEmailBody) is not null;
        }

        public bool IsEmailNotRead(string receivedEmailBody)
        {
            WaitUtil.WaitForEmailInMailRuInbox(receivedEmailBody);
            return FindEmailBySenderAndBody(receivedEmailBody).FindElement(ReadEmailButton).Displayed;
        }

        private IWebElement FindEmailBySenderAndBody(string receivedEmailBody)
        {
            return WebDriver.FindElements(EmailLineByRow).FirstOrDefault(element => element.FindElement(EmailLineByContent).Text.Contains(receivedEmailBody)
             && element.FindElement(EmailLineByUser(ApplicationConfig.GmailLogin)).Displayed);
        }
    }
}

