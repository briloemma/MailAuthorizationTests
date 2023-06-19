using MailAuthorizationTests.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MailAuthorizationTests.GmailPageObjects
{
    public class AccountSettingsPageObject : BasePageObject
    {
        private readonly By _personalInfoButton = By.CssSelector("[href='personal-info']");
        private readonly By _changeAccountNameButton = By.XPath("//a[contains(@href, 'profile/name')]");
        private readonly By _changePseudonimButton = By.CssSelector("Изменить поле \"Псевдоним\"");
        private readonly By _pseudonimField = By.CssSelector("[id='c57']");
        private readonly By _saveButton = By.XPath("//span[text()='Сохранить']");
        private readonly By _pseudonim = By.CssSelector("[class='gWjfMb PL8bYd']");
        public AccountSettingsPageObject() : base(By.XPath("//a[contains(@href,'/privacy?')]"))
        {
        }

        public MainMenuPageObject ChangeAccountPseudonim (string pseudonim)
        {
            WebDriver.FindElements(_personalInfoButton).Last().Click();
            WebDriver.FindElement(_changeAccountNameButton).Click();
            WebDriver.FindElement(_changePseudonimButton).Click();
            WebDriver.FindElement(_pseudonimField).SendKeys(pseudonim);
            WebDriver.FindElement(_saveButton).Click();

            return new MainMenuPageObject();
        }

        public string GetAccountPseudonim ()
        {
            WebDriver.FindElements(_personalInfoButton).Last().Click();
            WebDriver.FindElement(_changeAccountNameButton).Click();
            return WebDriver.FindElement(_pseudonim).Text;
        }
    }
}
