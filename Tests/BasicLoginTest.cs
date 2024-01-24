using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.Users;
using NUnit.Framework;

namespace MailAuthorizationTests.Tests
{
    [TestFixture]
    public class BasicLoginTest : BaseTest
    {
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void BasicLoginTestCorrectInput()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject.Login(UserCreator.GetGmailUser());
            Assert.That(mainMenuPageObject.WaitUntilPageIsDispayed());
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        [TestCaseSource(nameof(UserList))]
        public void BasicLoginTestIncorrectEmailInput(User user, string errorMessage)
        {
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject.SendUserEmail(user);
            Assert.That(authorizationPageObject.GetEmailNotFoundMessage());
            Assert.That(authorizationPageObject.GetEmailNotFoundTextMessage(), Is.EqualTo(errorMessage));
        }

        private static IEnumerable<TestCaseData> UserList()
        {
            yield return new TestCaseData(UserCreator.GetGmailUserWrongLogin(), ApplicationConfig.GmailNotFoundError);
            yield return new TestCaseData(UserCreator.GetEmptyGmailUser(), ApplicationConfig.EnterGmailError);
        }
    }
}
