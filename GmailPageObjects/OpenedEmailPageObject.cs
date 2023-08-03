using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;

namespace MailAuthorizationTests.GmailPageObjects
{
    public class OpenedEmailPageObject : BasePageObject
    {
        private readonly By _receivedEmailBody = By.CssSelector("[role='listitem'] div:nth-of-type(3)>div>:nth-of-type(2)>div:nth-of-type(1)");
        private By accountButton(string gmail) => By.XPath($"//a[contains(@aria-label, '{gmail}')]");
        private readonly By _goToAccountSettingsButton = By.CssSelector("[aria-label='Управление аккаунтом Google (открытие новой вкладки)']");
        private readonly By _frame = By.CssSelector("[name='account']");

        public OpenedEmailPageObject() : base(By.CssSelector("table[role='presentation']>tbody>tr>td>div>div>span:nth-of-type(2)"))
        {


        }

        public string GetNewUserPseudonim()
        {
            WaitUtil.WaitForElementIsDisplayed(_receivedEmailBody);
            return WebDriver.FindElement(_receivedEmailBody).Text;
        }

        public AccountSettingsPageObject GoToAccountSettings()
        {
            WaitUtil.WaitForElementIsDisplayed(accountButton(GmailTestConfig.GmailLogin));
            WebDriver.FindElement(accountButton(GmailTestConfig.GmailLogin)).Click();
            WaitUtil.WaitForElementIsDisplayed(_frame);
            WebDriver.SwitchTo().Frame(WebDriver.FindElement(_frame));
            WaitUtil.WaitForElementIsDisplayed(_goToAccountSettingsButton);
            WebDriver.FindElement(_goToAccountSettingsButton).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.Last());
            return new AccountSettingsPageObject();
        }

    }
}
