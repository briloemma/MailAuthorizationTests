using MailAuthorizationTests.Environment;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.PageObjects
{
    public abstract class BasePageObject
    {
        private readonly By _locator;
        public BasePageObject(By locator)
        {
            _locator = locator;
        }

        public static IWebDriver WebDriver => WebDriverFactory.GetInstance();
        public bool WaitUntilPageIsDispayed()
        {
            return WaitExtensions.WaitForElementIsDisplayed(WebDriver,_locator, $"{GetType().Name} is not found"); 
        }
    }
}
