using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Environment.Utils;
using MailAuthorizationTests.UIControls;
using OpenQA.Selenium;

namespace MailAuthorizationTests.PageObjects.GmailPageObjects
{
    public class OpenedEmailPageObject : BasePageObject
    {
        private Label ReceivedEmailBody => new Label(By.CssSelector("[role='listitem'] div:nth-of-type(3)>div>:nth-of-type(2)>div:nth-of-type(1)"));
        private Button AccountButton(string gmail) => new Button(By.XPath($"//a[contains(@aria-label, '{gmail}')]"));
        private Button GoToAccountSettingsButton => new Button(By.CssSelector("[aria-label='Управление аккаунтом Google (открытие новой вкладки)']"));
        private By Frame => By.CssSelector("[name='account']");

        public OpenedEmailPageObject() : base(By.CssSelector("table[role='presentation']>tbody>tr>td>div>div>span:nth-of-type(2)"))
        {


        }

        public string GetNewUserPseudonim()
        {
            Thread.Sleep(5000);
            return ReceivedEmailBody.GetText();
        }

        public AccountSettingsPageObject GoToAccountSettings()
        {
            AccountButton(ApplicationConfig.GmailLogin).Click();
            WaitUtil.WaitForElementIsDisplayed(Frame);
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(Frame));
            GoToAccountSettingsButton.Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
            return new AccountSettingsPageObject();
        }

    }
}
