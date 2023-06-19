using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.Environment
{
    public static class WaitUntil
    {
        public static IWebElement GetElementIfDisplayed(IWebDriver webDriver, By locator, string errorMessage = "Element is not found")
        {
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(driver =>
                {
                    IWebElement webElement;
                    webElement = driver.FindElement(locator);
                    if (!webElement.Displayed)
                    {
                        throw new Exception();
                    }
                    return webElement;
                });
            }
            catch
            {
                throw new NotFoundException(errorMessage);
            }
        }
    }
}
