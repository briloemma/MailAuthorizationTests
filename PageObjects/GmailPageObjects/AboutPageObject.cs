using MailAuthorizationTests.BaseUIControls;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AboutPageObject : BasePageObject
    {
        private Button SignInButton => new Button(By.CssSelector("[data-action='sign in']"));

        public AboutPageObject() : base(By.CssSelector("[data-action='sign in']"))
        {
        }

        public AuthorizationPageObject ClickSignInButton()
        {
            SignInButton.Click();
            return new AuthorizationPageObject();
        }
    }
}
