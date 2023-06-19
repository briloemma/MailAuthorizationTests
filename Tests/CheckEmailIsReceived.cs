using Amazon.DeviceFarm.Model;
using MailAuthorizationTests.Environment;
using MailAuthorizationTests.GmailPageObjects;
using MailAuthorizationTests.MailRuPageObjects;
using MailAuthorizationTests.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MailAuthorizationTests.Tests
{
    public class CheckEmailIsSendAndReceived:BaseTest
    {
        [Category("SmokeTest")]
        [Test]
        public void CheckEmailHasBeenReceived ()
        {
            LogInAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            LogInReceiverInbox();
            Assert.IsTrue(CheckEmailIsReceived());
        }

        [Test]
        public void CheckSender ()
        {
            LogInAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            string actual = LogInReceiverInboxdOpenEmailCheckSender();
            Assert.That(actual, Is.EqualTo(GmailTestConfig.GmailUserName));
        }

        [Test]
        public void CheckEmailBody ()
        {
            string expected = LogInAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            string actual = LogInReceiverInboxdOpenEmailCheckEmailBody();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ChangeGmailAccountName()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            OpenedEmailPageObject openedEmailPage = new OpenedEmailPageObject();
            AccountSettingsPageObject accountSettingsPage = new AccountSettingsPageObject();
            string newUserName = authorizationPageObject
                .Login(UserCreator.GetGmailUserWrongLogin())
                .OpenNewEmail()
                .GetNewUserName();
            mainMenuPageObject.GoToAccountSettings().ChangeAccountPseudonim(newUserName);
            Assert.That(GmailTestConfig.NewGmailPseudonim, Is.EqualTo(accountSettingsPage.GetAccountPseudonim()));
        }

        private string LogInAndSendEmail ()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject
                .Login(UserCreator.GetGmailUserWrongLogin())
                .SendEmail(GmailTestConfig.SendEmailToAddress, GenerateStringForTests.GenerateRandomString(35));
            return GenerateStringForTests.GenerateRandomString(35);
        }

        private void LogInReceiverInbox ()
        {
            RUAuthorizationPageObject ruAuthorization = new RUAuthorizationPageObject();
            ruAuthorization.Authorize(UserCreator.GetMailRuUser());
        }

        private string LogInReceiverInboxdOpenEmailCheckSender()
        {
            RUMainMenuPageObject ruMainMenu = new RUMainMenuPageObject();
            RUAuthorizationPageObject ruAuthorization = new RUAuthorizationPageObject();
            string senderEmail = ruAuthorization
                .Authorize(UserCreator.GetMailRuUser())
                .CheckInbox()
                .GetSender();
            return senderEmail;
        }

        private string LogInReceiverInboxdOpenEmailCheckEmailBody()
        {
            RUMainMenuPageObject ruMainMenu = new RUMainMenuPageObject();
            RUAuthorizationPageObject ruAuthorization = new RUAuthorizationPageObject();
            string emailBody = ruAuthorization
                .Authorize(UserCreator.GetMailRuUser())
                .CheckInbox()
                .GetEmailBody();
            return emailBody;
        }
        private bool CheckEmailIsReceived ()
        {
            var _inboxButton = By.XPath("//a[contains(@title, '1 непрочитанное')]");
                try
                {
                    BasePageObject.WebDriver.FindElement(_inboxButton);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
        }

       
    }
}
