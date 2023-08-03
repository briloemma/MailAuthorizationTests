using MailAuthorizationTests.Environment;
using MailAuthorizationTests.GmailPageObjects;
using NLog;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects
{
    public class MainMenuPageObject : BasePageObject
    {

        private readonly By _writeNewEmailButton = By.CssSelector("[style='user-select: none']");
        private readonly By _newMessageTab = By.CssSelector("[aria-label='Новое сообщение']");
        private readonly By _emailInput = By.CssSelector("[aria-autocomplete='list']");
        private readonly By _emailTextField = By.CssSelector("[role='textbox']");
        private readonly By _sendButton = By.XPath("//div[contains(@data-tooltip, 'Enter')]");
        private By EmailLineByUser(string email) => By.CssSelector($"tr>td>div:nth-of-type(2) span[email='{email}']");
        private By _emailLineByRow = By.CssSelector("tbody>tr[role='row']");
        private By _emailLineByContent = By.CssSelector("td[role='gridcell']>div>div>span");
        private readonly By _messageSuccessfullySent = By.XPath("//span[contains(text(),'Сообщение отправлено')]");
        NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public MainMenuPageObject() : base(By.XPath("//img[@role='presentation']"))
        {

        }

        public MainMenuPageObject SendEmail(string emailAddress, string emailText)
        {
            logger.Info($"Sending email to  {emailAddress}");
            WriteNewEmail();
            GetEmailAddress(emailAddress);
            GetEmailText(emailText);
            SendNewEmail();
            HasEmailBeenSentSuccessfully();
            return new MainMenuPageObject();
        }

        public bool HasEmailBeenSentSuccessfully()
        {
            return WebDriver.FindElement(_messageSuccessfullySent).Displayed;
        }
        public OpenedEmailPageObject OpenReceivedEmail()
        {
            WaitUtil.WaitForElementIsDisplayed(EmailLineByUser(GmailTestConfig.SendEmailToAddress));
            WebDriver.FindElements(EmailLineByUser(GmailTestConfig.SendEmailToAddress)).First().Click();
            return new OpenedEmailPageObject();
        }

        public bool IsEmailReceived(string receivedEmailBody)
        {
            return WebDriver.FindElements(_emailLineByRow).First().FindElement(_emailLineByContent).Text.Contains(receivedEmailBody) &&
                WebDriver.FindElements(_emailLineByRow).First().FindElement(EmailLineByUser(GmailTestConfig.SendEmailToAddress)).Displayed;
        }

        private MainMenuPageObject WriteNewEmail()
        {
            WaitUtil.WaitForElementIsDisplayed(_writeNewEmailButton);
            WebDriver.FindElement(_writeNewEmailButton).Click();
            return new MainMenuPageObject();
        }

        private MainMenuPageObject GetEmailAddress(string emailAddress)
        {
            WaitUtil.WaitForElementIsDisplayed(_newMessageTab);
            WaitUtil.WaitForElementIsDisplayed(_emailInput);
            WebDriver.FindElement(_emailInput).SendKeys(emailAddress);
            return new MainMenuPageObject();
        }

        private MainMenuPageObject GetEmailText(string emailText)
        {
            WaitUtil.WaitForElementIsDisplayed(_emailTextField);
            WebDriver.FindElement(_emailTextField).SendKeys(emailText);
            return new MainMenuPageObject();
        }

        private MainMenuPageObject SendNewEmail()
        {
            WaitUtil.WaitForElementIsDisplayed(_sendButton);
            WebDriver.FindElement(_sendButton).Click();
            WaitUtil.WaitForElementIsDisplayed(_messageSuccessfullySent);
            return new MainMenuPageObject();
        }
    }
}
