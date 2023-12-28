using MailAuthorizationTests.BaseUIControls;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AboutPageObject : BasePageObject
    {
        private readonly Button _signInButton = new Button(By.CssSelector("[data-action='sign in']"));

        public AboutPageObject() : base(By.CssSelector("[data-action='sign in']"))
        {
        }

        public AuthorizationPageObject ClickSignInButton()
        {
            _signInButton.Click();
            return new AuthorizationPageObject();
        }
    }
}
