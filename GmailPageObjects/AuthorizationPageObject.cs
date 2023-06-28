using MailAuthorizationTests.Environment;
using MailAuthorizationTests.Users;
using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.PageObjects
{
    public class AuthorizationPageObject : BasePageObject
    {
        private readonly By _emailInput = By.CssSelector("[type='email']");
        private readonly By _proceedButton = By.XPath("//span[text()='Next']");
        private readonly By _passwordInput = By.CssSelector("[name='Passwd']");
        private readonly By _emailNotFoundMessage = By.XPath("//div[contains(@class, 'o6')]");
        private readonly By _mainMenuButton = By.XPath("//img[@role='presentation']");
        Logger logger = LogManager.GetCurrentClassLogger();
        public AuthorizationPageObject() : base(By.XPath("//span[text()='Выберите аккаунт']"))
        {
        }

        public MainMenuPageObject Login(User user)
        {
            SendUserEmail(user);
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _passwordInput);
            WebDriver.FindElement(_passwordInput).SendKeys(user.GetPassword());
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _proceedButton);
            WebDriver.FindElement(_proceedButton).Click();
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _mainMenuButton);
            logger.Info("Login perfomed");
            return new MainMenuPageObject();
        }

        public AuthorizationPageObject SendUserEmail(User user)
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _emailInput);
            WebDriver.FindElement(_emailInput).SendKeys(user.GetLogin());
            WebDriver.FindElement(_proceedButton).Click();
            return new AuthorizationPageObject();
        }

        public bool GetEmailNotFoundMessage()
        {
            WaitExtensions.WaitForElementIsDisplayed(WebDriver, _emailNotFoundMessage);
            return WebDriver.FindElement(_emailNotFoundMessage).Displayed;
        }
    }
}
