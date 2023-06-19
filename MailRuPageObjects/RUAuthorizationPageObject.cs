using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.Users;
using NLog;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUAuthorizationPageObject : BasePageObject
    {
        private readonly By _authorizationButton = By.CssSelector("[data-testid='enter-mail-primary']");
        private readonly By _accountNameField = By.CssSelector("[name='username']");
        private readonly By _enterPasswordButton = By.CssSelector("next-button");
        private readonly By _passwordField = By.CssSelector("[name='password']");
        private readonly By _signInButton = By.CssSelector("submit-button-wrap");
        Logger logger = LogManager.GetCurrentClassLogger();

        public RUAuthorizationPageObject() : base(By.CssSelector("[href='//mail.ru']"))
        {
        }

        public RUMainMenuPageObject Authorize (User user)
        {
            WebDriver.FindElement(_authorizationButton).Click();
            WebDriver.FindElement(_accountNameField).SendKeys(user.GetLogin());
            WebDriver.FindElement(_enterPasswordButton).Click();
            WebDriver.FindElement(_passwordField).SendKeys(user.GetPassword());
            WebDriver.FindElement(_signInButton).Click();
            logger.Info("Login perfomed");
            return new RUMainMenuPageObject();
        }
    }
}
