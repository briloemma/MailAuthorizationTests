using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Environment.Utils;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.PageObjects.MailRuPageObjects;
using NUnit.Framework;

namespace MailAuthorizationTests.Tests
{
    [TestFixture]
    public class CheckEmailHasBeenSentAndReceived : BaseTest
    {
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void CheckEmailHasBeenReceived()
        {
            string sentMessage = LogInGmailAndSendEmail();
            UrlUtil.GoToURL(ApplicationConfig.MailRuHostPrefix);
            if (AlertUtil.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(sentMessage);
            Assert.That(rUMainMenu.IsEmailReceivedAndNotRead(sentMessage));
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void CheckSender()
        {
            string sentMessage = LogInGmailAndSendEmail();
            UrlUtil.GoToURL(ApplicationConfig.MailRuHostPrefix);
            if (AlertUtil.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(sentMessage);
            string actual = rUMainMenu.CheckInbox(sentMessage).GetSender();
            Assert.That(actual, Is.EqualTo(ApplicationConfig.GmailUserName));
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void CheckEmailBody()
        {
            string expected = LogInGmailAndSendEmail();
            UrlUtil.GoToURL(ApplicationConfig.MailRuHostPrefix);
            if (AlertUtil.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            RUMainMenuPageObject rUMainMenu = LogInMailRuReceiverInbox();
            WaitUtil.WaitForEmailInMailRuInbox(expected);
            string actual = rUMainMenu.CheckInbox(expected).GetEmailBody();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category(SPECIAL_SETUP)]
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void ChekGmailAccountPseudonimHasBeenChangedCorrectly()
        {
            string expectedPseudonim = $"{ApplicationConfig.NewGmailPseudonim}" + $"{GenerateTestDataUtil.GetRandomNumber()}";
            string sentMessage = SendEmailFromGmail();
            UrlUtil.GoToURL(ApplicationConfig.MailRuHostPrefix);
            if (AlertUtil.CheckAlertPresence())
                WebDriverFactory.GetInstance().SwitchTo().Alert().Accept();
            LogInMailRuInboxAndSendResponce(sentMessage, expectedPseudonim);
            UrlUtil.GoToURL(ApplicationConfig.GmailHostPrefix);

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
            string message = GenerateTestDataUtil.GenerateRandomString(35);
            new MainMenuPageObject().SendEmail(ApplicationConfig.SendEmailToAddress, message);
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
