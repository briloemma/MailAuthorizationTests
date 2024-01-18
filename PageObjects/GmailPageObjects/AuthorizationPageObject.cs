using MailAuthorizationTests.UIControls;
using NLog;
using OpenQA.Selenium;
using User = MailAuthorizationTests.Users.User;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AuthorizationPageObject : BasePageObject
    {
        private TextInput EmailInput => new TextInput(By.CssSelector("[type='email']"));
        private Button ProceedButton => new Button(By.XPath("//span[text()='Next']"));
        private TextInput PasswordInput => new TextInput(By.CssSelector("[name='Passwd']"));
        private Label EmailNotFoundMessage => new Label(By.XPath("//div[contains(@class, 'o6')]"));
        private Button MainMenuButton => new Button(By.XPath("//img[@role='presentation']"));
        private Logger logger => LogManager.GetCurrentClassLogger();

        public AuthorizationPageObject() : base(By.XPath("//span[text()='Выберите аккаунт']"))
        {
        }



        public MainMenuPageObject Login(User user)
        {
            SendUserEmail(user);
            SendUserPassword(user);
            MainMenuButton.IsDisplayed();
            logger.Info("Login perfomed");
            return new MainMenuPageObject();
        }

        public AuthorizationPageObject SendUserEmail(User user)
        {
            EmailInput.SendKeys(user.GetLogin());
            ProceedButton.Click();
            return new AuthorizationPageObject();
        }

        public bool GetEmailNotFoundMessage()
        {
            return EmailNotFoundMessage.IsDisplayed();
        }

        public string GetEmailNotFoundTextMessage()
        {
            return EmailNotFoundMessage.GetText();
        }

        private AuthorizationPageObject SendUserPassword(User user)
        {
            PasswordInput.SendKeys(user.GetPassword());
            ProceedButton.Click();
            return new AuthorizationPageObject();
        }
    }
}
