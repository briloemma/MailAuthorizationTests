using MailAuthorizationTests.Environment.Utils;
using MailAuthorizationTests.PageObjects;
using MailAuthorizationTests.UIControls;
using MailAuthorizationTests.Users;
using NLog;
using OpenQA.Selenium;

namespace MailAuthorizationTests.MailRuPageObjects
{
    public class RUAuthorizationPageObject : BasePageObject
    {
        private Button AuthorizationButton => new Button(By.CssSelector("button[style]"));
        private TextInput AccountNameField => new TextInput(By.CssSelector("[autocomplete='username']"));
        private Button EnterPasswordButton => new Button(By.CssSelector("[data-test-id='next-button']"));
        private TextInput PasswordField => new TextInput(By.CssSelector("[name='password']"));
        private Button SignInButton => new Button(By.CssSelector("[class='submit-button-wrap']"));
        private By Iframe => By.CssSelector("[class='ag-popup__frame__layout__iframe']");

        Logger logger = LogManager.GetCurrentClassLogger();

        public RUAuthorizationPageObject() : base(By.CssSelector("[href='//mail.ru']"))
        {
        }

        public PageObjects.MailRuPageObjects.RUMainMenuPageObject Authorize(User user)
        {
            AuthorizationButton.Click();
            WaitUtil.WaitForElementIsDisplayed(Iframe);
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(Iframe));
            AccountNameField.SendKeys(user.GetLogin());
            EnterPasswordButton.Click();
            PasswordField.SendKeys(user.GetPassword());
            SignInButton.Click();
            logger.Info("Login perfomed");
            return new PageObjects.MailRuPageObjects.RUMainMenuPageObject();
        }
    }
}
