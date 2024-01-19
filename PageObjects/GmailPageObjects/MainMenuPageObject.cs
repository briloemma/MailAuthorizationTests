using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Environment.Utils;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.UIControls;
using NLog;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects
{
    public class MainMenuPageObject : BasePageObject
    {

        private Button WriteNewEmailButton => new Button(By.CssSelector("[style='user-select: none']"));
        private By NewMessageTab => By.CssSelector("[aria-label='Новое сообщение']");
        private TextInput EmailInput => new TextInput(By.CssSelector("[aria-autocomplete='list']"));
        private TextInput EmailTextField => new TextInput(By.CssSelector("[role='textbox']"));
        private Button SendButton => new Button(By.XPath("//div[contains(@data-tooltip, 'Enter')]"));
        private By EmailLineByUser(string email) => By.CssSelector($"tr>td>div:nth-of-type(2) span[email='{email}']");
        private By EmailLineByRow => By.CssSelector("tbody>tr[role='row']");
        private By EmailLineByContent => By.CssSelector("td[role='gridcell']>div>div>span");
        private Label MessageSuccessfullySent => new Label(By.XPath("//span[contains(text(),'Сообщение отправлено')]"));
        private By NewMessageLabel => By.XPath("//div[contains(text(),'новое')]");
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
            return MessageSuccessfullySent.IsDisplayed();
        }
        public OpenedEmailPageObject OpenReceivedEmail()
        {
            var firstEmailLineRow = WebDriver.FindElements(EmailLineByRow).First();
            firstEmailLineRow.Click();
            return new OpenedEmailPageObject();
        }

        public bool IsEmailReceived(string receivedEmailBody)
        {
            WaitUntilPageIsDispayed();
            WaitUtil.WaitUntilElementIsNotDisplayed(NewMessageLabel, 15, 2);
            var firstEmailLineRow = WebDriver.FindElements(EmailLineByRow).First();
            return (firstEmailLineRow.FindElements(EmailLineByContent).FirstOrDefault()?.Text.Contains(receivedEmailBody) ?? false) &&
                (firstEmailLineRow.FindElements(EmailLineByUser(ApplicationConfig.SendEmailToAddress)).FirstOrDefault()?.Displayed ?? false);
        }

        private MainMenuPageObject WriteNewEmail(string emailAddress, string emailText)
        {
            WriteNewEmailButton.Click();
            WaitUtil.WaitForElementIsDisplayed(NewMessageTab);
            EmailInput.SendKeys(emailAddress);
            EmailTextField.SendKeys(emailText);
            return new MainMenuPageObject();
        }

        private MainMenuPageObject SendNewEmail()
        {
            SendButton.Click();
            MessageSuccessfullySent.IsDisplayed();
            return new MainMenuPageObject();
        }
    }
}
