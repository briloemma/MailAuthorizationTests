using MailAuthorizationTests.BaseUIControls;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class AccountSettingsPageObject : BasePageObject
    {
        public AccountSettingsPageObject() : base(By.XPath("//a[contains(@href,'/privacy?')]"))
        {
        }

        private Button PersonalInfoButton => new Button(By.CssSelector("a[href='personal-info'] div[style]"));
        private Button ChangeAccountNameButton => new Button(By.XPath("//a[contains(@href, 'profile/name')]"));
        private Button ChangePseudonimButton => new Button(By.XPath("//button[contains(@aria-label, \"Псевдоним\")]"));
        private TextInput PseudonimField => new TextInput(By.CssSelector("span input[type='text']"));
        private Button SaveButton => new Button(By.XPath("//span[text()='Сохранить']"));
        private By Pseudonim => By.CssSelector("c-wiz>div[class]>div[class]>div[class]>div>div:nth-of-type(2)>div:nth-of-type(1)>div:nth-of-type(2)");
        private Button DeletePseudonimButton => new Button(By.XPath("//button//span[contains(text(),\"Удалить\")]"));
        private Button ConfirmDeletePseudonumBtn => new Button(By.CssSelector("[data-mdc-dialog-action='ok']"));

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
            return WebDriver.FindElements(Pseudonim).Last().Text;
        }
        public AccountSettingsPageObject GoToUserPseudonim()
        {
            PersonalInfoButton.Click();
            ChangeAccountNameButton.Click();
            return this;
        }

        public void DeleteAccountPseudonim()
        {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
            WebDriver.Navigate().Refresh();
            ChangePseudonimButton.Click();
            DeletePseudonimButton.Click();
            ConfirmDeletePseudonumBtn.Click();
            WebDriver.Navigate().Refresh();
        }

        private void ChangePseudonim(string pseudonim)
        {
            ChangePseudonimButton.Click();
            PseudonimField.SendKeys(pseudonim);
            SaveButton.Click();
        }
    }
}
