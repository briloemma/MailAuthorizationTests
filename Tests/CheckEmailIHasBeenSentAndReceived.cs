using Amazon.DeviceFarm.Model;
using MailAuthorizationTests.Environment;
using MailAuthorizationTests.GmailPageObjects;
using MailAuthorizationTests.MailRuPageObjects;
using MailAuthorizationTests.PageObjects;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace MailAuthorizationTests.Tests
{
    public class CheckEmailHasBeenSentAndReceived : BaseTest
    {
        [Category("SmokeTest")]
        [Test]
        public void CheckEmailHasBeenReceived()
        {
            string sentMessage = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(WebDriverFactory.GetInstance(), sentMessage);
            Assert.IsTrue(rUMainMenu.IsEmailReceivedAndNotRead(sentMessage));
        }

        [Test]
        public void CheckSender()
        {
            string sentMessage = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(WebDriverFactory.GetInstance(), sentMessage);
            string actual = rUMainMenu.CheckInbox(sentMessage).GetSender();
            Assert.That(actual, Is.EqualTo(GmailTestConfig.GmailUserName));
        }

        [Test]
        public void CheckEmailBody()
        {
            string expected = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(WebDriverFactory.GetInstance(), expected);
            string actual = rUMainMenu.CheckInbox(expected).GetEmailBody();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ChekGmailAccountPseudonimHasBeenChangedCorrectly()
        {
            string expectedPseudonim = $"{GmailTestConfig.NewGmailPseudonim}" + $"{GenerateTestData.GetRandomNumber()}";
            string sentMessage = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            LogInMailRuInboxAndSendResponce(sentMessage, expectedPseudonim);
            URL.GoToURL(GmailTestConfig.GmailHostPrefix);
            AboutPageObject aboutPageObject = new AboutPageObject();
            OpenedEmailPageObject openedEmailPageObject = new OpenedEmailPageObject();
            AccountSettingsPageObject accountSettingsPageObject = new AccountSettingsPageObject();
            MainMenuPageObject mainMenuPageObject =  aboutPageObject.ClickSignInButton().Login(UserCreator.GetGmailUser());
            WaitUtil.WaitForEmailInGMailInbox(WebDriverFactory.GetInstance(), expectedPseudonim);

            string newPseudonim = mainMenuPageObject.OpenReceivedEmail().GetNewUserPseudonim();
            openedEmailPageObject.GoToAccountSettings().ChangeAccountPseudonim(newPseudonim);
            string actualPseudonim = openedEmailPageObject.GoToAccountSettings().GetAccountPseudonim();
            Assert.That(expectedPseudonim, Is.EqualTo(actualPseudonim));
            accountSettingsPageObject.DeleteAccountPseudonim();
        }

        private string LogInGmailAndSendEmail()
        {
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            string message = GenerateTestData.GenerateRandomString(35);
            authorizationPageObject
                .Login(UserCreator.GetGmailUser())
                .SendEmail(GmailTestConfig.SendEmailToAddress, message);
            return message;
        }

        private RUMainMenuPageObject LogInMailRuReceiverInbox()
        {
            RUAuthorizationPageObject ruAuthorization = new RUAuthorizationPageObject();
            return ruAuthorization.Authorize(UserCreator.GetMailRuUser());
        }

        private RUResponsePageObject LogInMailRuInboxAndSendResponce (string sentMessage, string expectedPseudonim)
        {
                LogInMailRuReceiverInbox()
               .CheckInbox(sentMessage)
               .OpenResponsePage()
               .SendResponse(expectedPseudonim);
            return new RUResponsePageObject();
        }
    }
}
