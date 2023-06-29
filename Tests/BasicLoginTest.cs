using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.Users;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.Tests
{
    [TestFixture]
    public class BasicLoginTest : BaseTest
    {
        [TestOf("SmokeTest")]
        [Test]
        public void BasicLoginTestCorrectInput()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject.Login(UserCreator.GetGmailUser());
            Assert.IsTrue(mainMenuPageObject.WaitUntilPageIsDispayed());
        }

        [Test]
        [TestCaseSource(nameof(UsersList))]
        public void BasicLoginTestIncorrectEmailInput(User user, string errorMessage)
        {
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            authorizationPageObject.SendUserEmail(user);
            Assert.IsTrue(authorizationPageObject.GetEmailNotFoundMessage());
            Assert.That(authorizationPageObject.GetEmailNotFoundTextMessage(), Is.EqualTo(errorMessage));
        }

        private static IEnumerable<TestCaseData> UsersList()
        {
            yield return new TestCaseData(UserCreator.GetGmailUserWrongLogin(), GmailTestConfig.GmailNotFoundError);
            yield return new TestCaseData(UserCreator.GetEmptyGmailUser(), GmailTestConfig.EnterGmailError);
        }

    }
}
