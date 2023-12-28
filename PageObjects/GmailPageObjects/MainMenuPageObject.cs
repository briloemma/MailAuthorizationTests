using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using NLog;
using OpenQA.Selenium;
using System.Net.Mail;

namespace MailAuthorizationTests.PageObjects
{
    public class MainMenuPageObject : BasePageObject
    {

        private readonly Button _writeNewEmailButton = new Button(By.CssSelector("[style='user-select: none']"));
        private readonly By _newMessageTab = By.CssSelector("[aria-label='Новое сообщение']");
        private readonly TextInput _emailInput = new TextInput(By.CssSelector("[aria-autocomplete='list']"));
        private readonly TextInput _emailTextField = new TextInput(By.CssSelector("[role='textbox']"));
        private readonly Button _sendButton = new Button(By.XPath("//div[contains(@data-tooltip, 'Enter')]"));
        private By EmailLineByUser(string email) => By.CssSelector($"tr>td>div:nth-of-type(2) span[email='{email}']");
        private By _emailLineByRow = By.CssSelector("tbody>tr[role='row']");
        private By _emailLineByContent = By.CssSelector("td[role='gridcell']>div>div>span");
        private readonly TextField _messageSuccessfullySent = new TextField(By.XPath("//span[contains(text(),'Сообщение отправлено')]"));
        private readonly By _newMessageLabel = By.XPath("//div[contains(text(),'новое')]");
        NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public MainMenuPageObject() : base(By.XPath("//img[@role='presentation']"))
        {

        }

        public MainMenuPageObject SendEmail(string emailAddress, string emailText)
        {
            logger.Info($"Sending email to  {emailAddress}");
            WriteNewEmail(emailAddress, emailText);
            SendNewEmail();
            HasEmailBeenSentSuccessfully();
            return new MainMenuPageObject();
        }

        public bool HasEmailBeenSentSuccessfully()
        {
            return _messageSuccessfullySent.IsDisplayed();
        }
        public OpenedEmailPageObject OpenReceivedEmail()
        {
            WaitUntilPageIsDispayed();
            WaitUtil.WaitUntilElementIsNotDisplayed(_newMessageLabel, 15, 2);
            var firstEmailLineRow = WebDriver.FindElements(_emailLineByRow).First();
            firstEmailLineRow.Click();
            return new OpenedEmailPageObject();
        }

        public bool IsEmailReceived(string receivedEmailBody)
        {
            WaitUntilPageIsDispayed();
            WaitUtil.WaitUntilElementIsNotDisplayed(_newMessageLabel, 15, 2);
            var firstEmailLineRow = WebDriver.FindElements(_emailLineByRow).First();
            return (firstEmailLineRow.FindElements(_emailLineByContent).FirstOrDefault()?.Text.Contains(receivedEmailBody) ?? false) &&
                (firstEmailLineRow.FindElements(EmailLineByUser(GmailTestConfig.SendEmailToAddress)).FirstOrDefault()?.Displayed ?? false);
        }

        private MainMenuPageObject WriteNewEmail(string emailAddress, string emailText)
        {
            _writeNewEmailButton.Click();
            WaitUtil.WaitForElementIsDisplayed(_newMessageTab);
            _emailInput.SendKeys(emailAddress);
            _emailTextField.SendKeys(emailText);
            return new MainMenuPageObject();
        }

        private MainMenuPageObject SendNewEmail()
        {
            _sendButton.Click();
            _messageSuccessfullySent.IsDisplayed();
            return new MainMenuPageObject();
        }
    }
}
