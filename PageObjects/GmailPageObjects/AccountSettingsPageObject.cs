using MailAuthorizationTests.BaseUIControls;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AccountSettingsPageObject : BasePageObject
    {
        private readonly Button _personalInfoButton = new Button(By.CssSelector("a[href='personal-info'] div[style]"));
        private readonly Button _changeAccountNameButton = new Button(By.XPath("//a[contains(@href, 'profile/name')]"));
        private readonly Button _changePseudonimButton = new Button(By.XPath("//button[contains(@aria-label, \"Псевдоним\")]"));
        private readonly TextInput _pseudonimField = new TextInput(By.CssSelector("span input[type='text']"));
        private readonly Button _saveButton = new Button(By.XPath("//span[text()='Сохранить']"));
        private readonly By _pseudonim = By.CssSelector("c-wiz>div[class]>div[class]>div[class]>div>div:nth-of-type(2)>div:nth-of-type(1)>div:nth-of-type(2)");
        private readonly Button _deletePseudonimButton = new Button(By.XPath("//button//span[contains(text(),\"Удалить\")]"));
        private readonly Button _confirmDeletePseudonumBtn = new Button(By.CssSelector("[data-mdc-dialog-action='ok']"));
        public AccountSettingsPageObject() : base(By.XPath("//a[contains(@href,'/privacy?')]"))
        {
        }

        public AccountSettingsPageObject ChangeAccountPseudonim(string pseudonim)
        {
            GoToUserPseudonim();
            ChangePseudonim(pseudonim);
            return new AccountSettingsPageObject();
        }

        public string GetAccountPseudonim()
        {
            Thread.Sleep(5000);
            WaitUntilPageIsDispayed();
            return WebDriver.FindElements(_pseudonim).Last().Text;
        }
        public AccountSettingsPageObject GoToUserPseudonim()
        {
            _personalInfoButton.Click();
            _changeAccountNameButton.Click();
            return this;
        }

        public void DeleteAccountPseudonim()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
            WebDriver.Navigate().Refresh();
            _changePseudonimButton.Click();
            _deletePseudonimButton.Click();
            _confirmDeletePseudonumBtn.Click();
            WebDriver.Navigate().Refresh();
        }

        private void ChangePseudonim(string pseudonim)
        {
            _changePseudonimButton.Click();
            _pseudonimField.SendKeys(pseudonim);
            _saveButton.Click();
        }
    }
}
