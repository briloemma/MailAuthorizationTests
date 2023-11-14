using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AccountSettingsPageObject : BasePageObject
    {
        private readonly Button _personalInfoButton = new Button (By.CssSelector("a[href='personal-info'] div[style]"));
        private readonly Button _changeAccountNameButton = new Button(By.XPath("//a[contains(@href, 'profile/name')]"));
        private readonly Button _changePseudonimButton = new Button(By.XPath("//button[contains(@aria-label, \"Псевдоним\")]"));
        private readonly TextInput _pseudonimField = new TextInput(By.CssSelector("span input[type='text']"));
        private readonly Button _saveButton = new Button(By.XPath("//span[text()='Сохранить']"));
        private readonly TextField _pseudonim = new TextField(By.CssSelector("c-wiz:nth-of-type(5)>div>div:nth-of-type(2)>div:nth-of-type(2)>c-wiz>div[class]>div>div>div:nth-of-type(1)>div:nth-of-type(2)>div:nth-of-type(1)>div:nth-of-type(2)"));
        private readonly Button _deletePseudonimButton = new Button(By.XPath("//button//span[contains(text(),\"Удалить\")]"));
        private readonly Button _confirmDeletePseudonumBtn = new Button(By.CssSelector("[data-mdc-dialog-action='ok']"));
        public AccountSettingsPageObject() : base(By.XPath("//a[contains(@href,'/privacy?')]"))
        {
        }

        public AccountSettingsPageObject ChangeAccountPseudonim(string pseudonim)
        {
            GoToUserPseudonim();
            _pseudonimField.SendKeys(pseudonim);
            _saveButton.Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            return new AccountSettingsPageObject();
        }

        public string GetAccountPseudonim()
        {
            return _pseudonim.GetText();
        }

        public string DeleteAccountPseudonim()
        {
            _changePseudonimButton.Click();
            _deletePseudonimButton.Click();
            _confirmDeletePseudonumBtn.Click();
            return GetAccountPseudonim();
        }
        private void GoToUserPseudonim ()
        {
            _personalInfoButton.Click();
            Thread.Sleep(5000);
            _changeAccountNameButton.Click();
            _changePseudonimButton.Click();
        }
    }
}
