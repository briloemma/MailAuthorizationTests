using MailAuthorizationTests.BaseUIControls;
using MailAuthorizationTests.Environment;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class OpenedEmailPageObject : BasePageObject
    {
        private readonly TextField _receivedEmailBody = new TextField(By.CssSelector("[role='listitem'] div:nth-of-type(3)>div>:nth-of-type(2)>div:nth-of-type(1)"));
        private Button accountButton(string gmail) => new Button(By.XPath($"//a[contains(@aria-label, '{gmail}')]"));
        private readonly Button _goToAccountSettingsButton = new Button(By.CssSelector("[aria-label='Управление аккаунтом Google (открытие новой вкладки)']"));
        private readonly By _frame = By.CssSelector("[name='account']");

        public OpenedEmailPageObject() : base(By.CssSelector("table[role='presentation']>tbody>tr>td>div>div>span:nth-of-type(2)"))
        {


        }

        public string GetNewUserPseudonim()
        {
            Thread.Sleep(5000);
            return _receivedEmailBody.GetText();
        }

        public AccountSettingsPageObject GoToAccountSettings()
        {
            accountButton(GmailTestConfig.GmailLogin).Click();
            WaitUtil.WaitForElementIsDisplayed(_frame);
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(_frame));
            _goToAccountSettingsButton.Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
            return new AccountSettingsPageObject();
        }

    }
}
