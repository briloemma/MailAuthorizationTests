using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.PageObjects.GmailPageObjects;
using MailAuthorizationTests.Users;
using NUnit.Framework;
[assembly: LevelOfParallelism(3)]

namespace MailAuthorizationTests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
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
            yield return new TestCaseData(UserCreator.GetGmailUserWrongLogin(), ApplicationConfig.GmailNotFoundError);
            yield return new TestCaseData(UserCreator.GetEmptyGmailUser(), ApplicationConfig.EnterGmailError);
        }
    }
}
