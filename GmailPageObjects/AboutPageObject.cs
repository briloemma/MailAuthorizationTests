using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.GmailPageObjects
{
    public class AboutPageObject : BasePageObject
    {
        private readonly By _signInButton = By.CssSelector("[data-action='sign in']");

        public AboutPageObject() : base(By.CssSelector("[data-action='sign in']"))
        {
        }

        public AuthorizationPageObject ClickSignInButton()
        {
            WaitUtil.WaitForElementIsDisplayed(_signInButton);
            WebDriver.FindElement(_signInButton).Click();
            return new AuthorizationPageObject();
        }
    }
}
