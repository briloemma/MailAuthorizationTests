using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.Users;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public void BasicLoginTestIncorrectEmailInput()
        {

            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            Assert.That(authorizationPageObject.Login(UserCreator.GetGmailUserWrongLogin()), Is.EqualTo(null));
            Assert.IsTrue(authorizationPageObject.GetEmailNotFoundMessage());
        }

        [Test]
        public void BasicLoginTestEmptyInput()
        {
            MainMenuPageObject mainMenuPageObject = new MainMenuPageObject();
            AuthorizationPageObject authorizationPageObject = new AuthorizationPageObject();
            Assert.That(authorizationPageObject.Login(UserCreator.GetEmptyGmailUser()), Is.EqualTo(null));
            Assert.IsTrue(authorizationPageObject.GetEmailNotFoundMessage());
        }

    }
}
