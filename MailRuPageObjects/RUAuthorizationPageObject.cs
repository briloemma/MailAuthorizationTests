using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.Users;
using NLog;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUAuthorizationPageObject : BasePageObject
    {
        private readonly By _authorizationButton = By.CssSelector("[data-testid='enter-mail-primary']");
        private readonly By _accountNameField = By.CssSelector("[autocomplete='username']");
        private readonly By _enterPasswordButton = By.CssSelector("[data-test-id='next-button']");
        private readonly By _passwordField = By.CssSelector("[name='password']");
        private readonly By _signInButton = By.CssSelector("[class='submit-button-wrap']");
        private readonly By iframe = By.CssSelector("[frameborder='0']");
        Logger logger = LogManager.GetCurrentClassLogger();

        public RUAuthorizationPageObject() : base(By.CssSelector("[href='//mail.ru']"))
        {
        }

        public RUMainMenuPageObject Authorize(User user)
        {
            WebDriver.FindElement(_authorizationButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, iframe);
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(iframe));
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _accountNameField);
            WebDriver.FindElement(_accountNameField).SendKeys(user.GetLogin());
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _enterPasswordButton);
            WebDriver.FindElement(_enterPasswordButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _passwordField);
            WebDriver.FindElement(_passwordField).SendKeys(user.GetPassword());
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _signInButton);
            WebDriver.FindElement(_signInButton).Click();
            logger.Info("Login perfomed");
            return new RUMainMenuPageObject();
        }
    }
}
