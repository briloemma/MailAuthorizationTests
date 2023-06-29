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
            Assert.IsTrue(LogInReceiverInbox().CheckEmailIsReceived());
        }

        [Test]
        public void CheckSender ()
        {
            LogInAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            string actual = LogInReceiverInboxdOpenEmailCheckSender();
            Assert.That(actual, Is.EqualTo(GmailTestConfig.GmailUserName));
            RUOpenedEmailPageObject rUOpenedEmailPageObject = new RUOpenedEmailPageObject();
            rUOpenedEmailPageObject.DeleteEmail();
        }

        [Test]
        public void CheckEmailBody ()
        {
            string expected = LogInAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            string actual = LogInReceiverInboxdOpenEmailCheckEmailBody();
            Assert.That (actual, Is.EqualTo(expected));
            RUOpenedEmailPageObject rUOpenedEmailPageObject = new RUOpenedEmailPageObject();
            rUOpenedEmailPageObject.SendInResponceNewUserName();
        }

        [Test]
        public void ChangeGmailAccountName()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            OpenedEmailPageObject openedEmailPage = new OpenedEmailPageObject();
            AccountSettingsPageObject accountSettingsPage = new AccountSettingsPageObject();
            string newUserName = authorizationPageObject
                .Login(UserCreator.GetGmailUser())
                .OpenNewEmail()
                .GetNewUserName();
            mainMenuPageObject.GoToAccountSettings().ChangeAccountPseudonim(newUserName);
            Assert.That(GmailTestConfig.NewGmailPseudonim, Is.EqualTo(accountSettingsPage.GetAccountPseudonim()));
        }

        private string LogInAndSendEmail ()
        {
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            string message = GenerateStringForTests.GenerateRandomString(35);
            authorizationPageObject
                .Login(UserCreator.GetGmailUser())
                .SendEmail(GmailTestConfig.SendEmailToAddress, message);
            return message;
        }

        private RUMainMenuPageObject LogInReceiverInbox ()
        {
            RUAuthorizationPageObject ruAuthorization = new RUAuthorizationPageObject();
            return ruAuthorization.Authorize(UserCreator.GetMailRuUser());
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
        

       
    }
}
