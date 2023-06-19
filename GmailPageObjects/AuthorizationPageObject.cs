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

        public MainMenuPageObject Login (User user)
        {
            try
            {
                WaitUntil.GetElementIfDisplayed(WebDriver, _emailInput);
                WebDriver.FindElement(_emailInput).SendKeys(user.GetLogin());
                WebDriver.FindElement(_proceedButton).Click();
                WaitUntil.GetElementIfDisplayed(WebDriver, _passwordInput);
                WebDriver.FindElement(_passwordInput).SendKeys(user.GetPassword());
                WaitUntil.GetElementIfDisplayed(WebDriver, _proceedButton);
                WebDriver.FindElement(_proceedButton).Click();
                WaitUntil.GetElementIfDisplayed(WebDriver, _mainMenuButton);
                logger.Info("Login perfomed");
                return new MainMenuPageObject();
            }
            catch (NotFoundException ex) 
            {
                Console.WriteLine("Couldn't return MainMenuPageObject");
                logger.Error("Couldn't perfrom login");
            }
            return null;
        }

        public bool GetEmailNotFoundMessage ()
        {
            if (WebDriver.FindElement(_emailNotFoundMessage).Displayed)
            return true;
            else
            return false;
        }
    }
}
