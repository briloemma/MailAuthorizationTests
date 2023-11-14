using Amazon.DeviceFarm.Model;
using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.PageObjects.MailRuPageObjects;
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
                WebDriverSingleton.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(sentMessage);
            Assert.IsTrue(rUMainMenu.IsEmailReceivedAndNotRead(sentMessage));
        }

        [Test]
        public void CheckSender()
        {
            string sentMessage = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverSingleton.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(sentMessage);
            string actual = rUMainMenu.CheckInbox(sentMessage).GetSender();
            Assert.That(actual, Is.EqualTo(GmailTestConfig.GmailUserName));
        }

        [Test]
        public void CheckEmailBody()
        {
            string expected = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverSingleton.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(expected);
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
                WebDriverSingleton.GetInstance().SwitchTo().Alert().Accept();
            LogInMailRuInboxAndSendResponce(sentMessage, expectedPseudonim);
            URL.GoToURL(GmailTestConfig.GmailHostPrefix);

            WaitUtil.WaitForEmailInGMailInbox(sentMessage);
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            string newPseudonim = mainMenuPageObject.OpenReceivedEmail().GetNewUserPseudonim();
            OpenedEmailPageObject openedEmailPageObject = new OpenedEmailPageObject();
            string actualPseudonim = openedEmailPageObject.GoToAccountSettings().ChangeAccountPseudonim(newPseudonim).GetAccountPseudonim();
            //string actualPseudonim = openedEmailPageObject.GoToAccountSettings().GetAccountPseudonim();
            Assert.That(expectedPseudonim, Is.EqualTo(actualPseudonim));
            AccountSettingsPageObject accountSettingsPageObject = new AccountSettingsPageObject();
            Assert.IsTrue(accountSettingsPageObject.DeleteAccountPseudonim().Equals("Псевдонима нет"));
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
            MailRuPageObjects.RUAuthorizationPageObject ruAuthorization = new MailRuPageObjects.RUAuthorizationPageObject();
            return ruAuthorization.Authorize(UserCreator.GetMailRuUser());
        }

        private MailAuthorizationTests.MailRuPageObjects.RUResponsePageObject LogInMailRuInboxAndSendResponce (string sentMessage, string expectedPseudonim)
        {
            RUMainMenuPageObject ruMainPage = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(sentMessage);
            ruMainPage
               .CheckInbox(sentMessage)
               .OpenResponsePage()
               .SendResponse(expectedPseudonim);
            return new MailRuPageObjects.RUResponsePageObject();
        }
    }
}
