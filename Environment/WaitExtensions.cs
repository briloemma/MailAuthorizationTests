using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.Environment
{
    public static class WaitExtensions
    {
        public static bool WaitForElementIsDisplayed(IWebDriver webDriver, By locator, string errorMessage = "Element is not found")
        {
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(webDriver =>
                {

                    IWebElement webElement = webDriver.FindElement(locator);
                    return webElement.Displayed;
                });
            }
            catch(Exception ex)
            {
                throw new NotFoundException($"{locator} {errorMessage}" + "\n"+ $"{ex.Message}");
            }
        }
    }
}
