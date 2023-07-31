using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.GmailPageObjects
{
    public class AccountSettingsPageObject : BasePageObject
    {
        private readonly By _personalInfoButton = By.CssSelector("a[href='personal-info'] img[class]");
        private readonly By _changeAccountNameButton = By.XPath("//a[contains(@href, 'profile/name')]");
        private readonly By _changePseudonimButton = By.XPath("//button[contains(@aria-label, \"Псевдоним\")]");
        private readonly By _pseudonimField = By.CssSelector("[id='c57']");
        private readonly By _saveButton = By.XPath("//span[text()='Сохранить']");
        private readonly By _pseudonim = By.CssSelector("c-wiz>div:nth-of-type(2)>div>div>div:nth-of-type(1)>div:nth-of-type(2)>div:nth-of-type(1)>div:nth-of-type(2)");
        private readonly By _deletePseudonimButton = By.XPath("//button//span[contains(text(),\"Удалить\")]");
        private readonly By _confirmDeletePseudonumBtn = By.XPath("//button[2]//span[contains(text(),\"Удалить\")]");
        public AccountSettingsPageObject() : base(By.XPath("//a[contains(@href,'/privacy?')]"))
        {
        }

        public OpenedEmailPageObject ChangeAccountPseudonim(string pseudonim)
        {
            GoToUserPseudonim();
            WebDriver.FindElement(_pseudonimField).SendKeys(pseudonim);
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _saveButton);
            WebDriver.FindElement(_saveButton).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            return new OpenedEmailPageObject();
        }

        public string GetAccountPseudonim()
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _personalInfoButton);
            WebDriver.FindElement(_personalInfoButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _changeAccountNameButton);
            WebDriver.FindElement(_changeAccountNameButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _pseudonim);
            return WebDriver.FindElement(_pseudonim).Text;
        }

        public void DeleteAccountPseudonim()
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _changePseudonimButton);
            WebDriver.FindElement(_changePseudonimButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _deletePseudonimButton);
            WebDriver.FindElement(_deletePseudonimButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _confirmDeletePseudonumBtn);
            WebDriver.FindElement(_confirmDeletePseudonumBtn).Click();
        }
        private void GoToUserPseudonim ()
        {
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _personalInfoButton);
            WebDriver.FindElement(_personalInfoButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _changeAccountNameButton);
            WebDriver.FindElement(_changeAccountNameButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _changePseudonimButton);
            WebDriver.FindElement(_changePseudonimButton).Click();
            WaitUtil.WaitForElementIsDisplayed(WebDriver, _pseudonimField);
        }
    }
}
