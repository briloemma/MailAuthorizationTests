using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.PageObjects.MailRuPageObjects;

namespace MailAuthorizationTests.Tests
{
    public class CheckEmailHasBeenSentAndReceived : BaseTest
    {
        [Test]
        public void CheckEmailHasBeenReceived()
        {
            string sentMessage = LogInGmailAndSendEmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
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
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
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
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(expected);
            string actual = rUMainMenu.CheckInbox(expected).GetEmailBody();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category(SPECIAL_SETUP)]
        [Test]
        public void ChekGmailAccountPseudonimHasBeenChangedCorrectly()
        {
            string expectedPseudonim = $"{GmailTestConfig.NewGmailPseudonim}" + $"{GenerateTestData.GetRandomNumber()}";
            string sentMessage = SendEmailFromGmail();
            URL.GoToURL(MailRuConfig.MailRuHostPrefix);
            if (IsAlertPresent.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            LogInMailRuInboxAndSendResponce(sentMessage, expectedPseudonim);
            URL.GoToURL(GmailTestConfig.GmailHostPrefix);

            WaitUtil.WaitForEmailInGMailInbox(sentMessage);
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            string newPseudonim = mainMenuPageObject.OpenReceivedEmail().GetNewUserPseudonim();
            OpenedEmailPageObject openedEmailPageObject = new OpenedEmailPageObject();
            string actualPseudonim = openedEmailPageObject.GoToAccountSettings().ChangeAccountPseudonim(newPseudonim).GetAccountPseudonim();
            Assert.That(actualPseudonim, Is.EqualTo(expectedPseudonim));
        }

        private string LogInGmailAndSendEmail()
        {
            new AuthorizationPageObject().Login(UserCreator.GetGmailUser());
            string message = SendEmailFromGmail();
            return message;
        }

        private string SendEmailFromGmail()
        {
            string message = GenerateTestData.GenerateRandomString(35);
            new MainMenuPageObject().SendEmail(GmailTestConfig.SendEmailToAddress, message);
            return message;
        }

        private RUMainMenuPageObject LogInMailRuReceiverInbox()
        {
            MailRuPageObjects.RUAuthorizationPageObject ruAuthorization = new MailRuPageObjects.RUAuthorizationPageObject();
            return ruAuthorization.Authorize(UserCreator.GetMailRuUser());
        }

        private MailAuthorizationTests.MailRuPageObjects.RUResponsePageObject LogInMailRuInboxAndSendResponce(string sentMessage, string expectedPseudonim)
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
