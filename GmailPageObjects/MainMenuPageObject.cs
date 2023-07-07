using MailAuthorizationTests.Environment;
using MailAuthorizationTests.GmailPageObjects;
using Microsoft.Extensions.Logging;
using NLog;
using NPOI.SS.Formula.Functions;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System.Net.Mail;

namespace MailAuthorizationTests.PageObjects
{
    public class MainMenuPageObject : BasePageObject
    {

        private readonly By _writeNewEmailButton = By.CssSelector("[style='user-select: none']");
        private readonly By _newMessageTab = By.CssSelector("[aria-label='Новое сообщение']");
        private readonly By _emailInput = By.CssSelector("[aria-autocomplete='list']");
        private readonly By _emailTextField = By.CssSelector("[role='textbox']");
        private readonly By _sendButton = By.XPath("//div[contains(@data-tooltip, 'Enter')]");
        private By OpenEmailLine(string email) => By.CssSelector($"[email={email}]");
        private readonly By _accountButton = By.CssSelector("[class='gb_k gbii']");
        private readonly By _goToAccountSettingsButton = By.XPath("//a[contains(@href, 'myaccount.google.com/?utm')]");
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
            EmailSentSuccessfully();
            return new MainMenuPageObject();
        }

        public bool EmailSentSuccessfully ()
        {
            return WebDriver.FindElement(_messageSuccessfullySent).Displayed;
        }
        public OpenedEmailPageObject OpenNewEmail()
        {
            WebDriver.FindElements(OpenEmailLine(GmailTestConfig.SendEmailToAddress)).First().Click();
            logger.Error("Couldn't open an email");
            return new OpenedEmailPageObject();
        }

        public AccountSettingsPageObject GoToAccountSettings()
        {
            WebDriver.FindElement(_accountButton).Click();
            WebDriver.FindElement(_goToAccountSettingsButton).Click();
            return new AccountSettingsPageObject();
        }

        private MainMenuPageObject WriteNewEmail ()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _writeNewEmailButton);
            WebDriver.FindElement(_writeNewEmailButton).Click();
            return new MainMenuPageObject();
        }

        private MainMenuPageObject GetEmailAddress(string emailAddress)
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _newMessageTab);
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _emailInput);
            WebDriver.FindElement(_emailInput).SendKeys(emailAddress);
            return new MainMenuPageObject();
        }

        private MainMenuPageObject GetEmailText(string emailText)
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _emailTextField);
            WebDriver.FindElement(_emailTextField).SendKeys(emailText);
            return new MainMenuPageObject();
        }

        private MainMenuPageObject SendNewEmail()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _sendButton);
            WebDriver.FindElement(_sendButton).Click();
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _messageSuccessfullySent);
            return new MainMenuPageObject();
        }

    }
}
