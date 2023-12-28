using MailAuthorizationTests.BaseUIControls;
using NLog;
using OpenQA.Selenium;
using User = MailAuthorizationTests.Users.User;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AuthorizationPageObject : BasePageObject
    {
        private readonly TextInput _emailInput = new TextInput(By.CssSelector("[type='email']"));
        private readonly Button _proceedButton = new Button(By.XPath("//span[text()='Next']"));
        private readonly TextInput _passwordInput = new TextInput(By.CssSelector("[name='Passwd']"));
        private readonly TextField _emailNotFoundMessage = new TextField(By.XPath("//div[contains(@class, 'o6')]"));
        private readonly Button _mainMenuButton = new Button(By.XPath("//img[@role='presentation']"));
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public AuthorizationPageObject() : base(By.XPath("//span[text()='Выберите аккаунт']"))
        {
        }



        public MainMenuPageObject Login(User user)
        {
            SendUserEmail(user);
            SendUserPassword(user);
            _mainMenuButton.IsDisplayed();
            logger.Info("Login perfomed");
            return new MainMenuPageObject();
        }

        public AuthorizationPageObject SendUserEmail(User user)
        {
            _emailInput.SendKeys(user.GetLogin());
            _proceedButton.Click();
            return new AuthorizationPageObject();
        }

        public bool GetEmailNotFoundMessage()
        {
            return _emailNotFoundMessage.IsDisplayed();
        }

        public string GetEmailNotFoundTextMessage()
        {
            return _emailNotFoundMessage.GetText();
        }

        private AuthorizationPageObject SendUserPassword(User user)
        {
            _passwordInput.SendKeys(user.GetPassword());
            _proceedButton.Click();
            return new AuthorizationPageObject();
        }
    }
}
