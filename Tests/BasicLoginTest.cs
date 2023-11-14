using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.Users;

namespace MailAuthorizationTests.Tests
{
    [TestFixture]
    public class BasicLoginTest : BaseTest
    {
        [Test]
        public void BasicLoginTestCorrectInput()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject.Login(UserCreator.GetGmailUser());
            Assert.IsTrue(mainMenuPageObject.WaitUntilPageIsDispayed());
        }

        [Test]
        [TestCaseSource(nameof(UserList))]
        public void BasicLoginTestIncorrectEmailInput(User user, string errorMessage)
        {
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject.SendUserEmail(user);
            Assert.IsTrue(authorizationPageObject.GetEmailNotFoundMessage());
            Assert.That(authorizationPageObject.GetEmailNotFoundTextMessage(), Is.EqualTo(errorMessage));
        }

        private static IEnumerable<TestCaseData> UserList()
        {
            yield return new TestCaseData(UserCreator.GetGmailUserWrongLogin(), GmailTestConfig.GmailNotFoundError);
            yield return new TestCaseData(UserCreator.GetEmptyGmailUser(), GmailTestConfig.EnterGmailError);
        }
    }
}
