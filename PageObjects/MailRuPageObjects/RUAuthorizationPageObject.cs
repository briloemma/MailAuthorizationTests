using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.Users;
using NLog;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUAuthorizationPageObject : BasePageObject
    {
        private readonly Button _authorizationButton = new Button(By.CssSelector("[data-testid='enter-mail-primary']"));
        private readonly TextInput _accountNameField = new TextInput(By.CssSelector("[autocomplete='username']"));
        private readonly Button _enterPasswordButton = new Button(By.CssSelector("[data-test-id='next-button']"));
        private readonly TextInput _passwordField = new TextInput(By.CssSelector("[name='password']"));
        private readonly Button _signInButton = new Button(By.CssSelector("[class='submit-button-wrap']"));
        private readonly By iframe = By.CssSelector("[frameborder='0']");
        Logger logger = LogManager.GetCurrentClassLogger();

        public RUAuthorizationPageObject() : base(By.CssSelector("[href='//mail.ru']"))
        {
        }

        public PageObjects.MailRuPageObjects.RUMainMenuPageObject Authorize(User user)
        {
            _authorizationButton.Click();
            WaitUtil.WaitForElementIsDisplayed(iframe);
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(iframe));
            _accountNameField.SendKeys(user.GetLogin());
            _enterPasswordButton.Click();
            _passwordField.SendKeys(user.GetPassword());
            _signInButton.Click();
            logger.Info("Login perfomed");
            return new PageObjects.MailRuPageObjects.RUMainMenuPageObject();
        }
    }
}
