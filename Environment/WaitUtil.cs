using MailAuthorizationTests.MailRuPageObjects;
using MailAuthorizationTests.PageObjects;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailAuthorizationTests.Environment
{
    public static class WaitUtil
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        public static bool WaitForElementIsDisplayed(By locator, string errorMessage = "Element is not found")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            try
            {
                return wait.Until(webDriver =>
                {
                    IWebElement webElement = webDriver.FindElement(locator);
                    return webElement.Displayed;
                });
            }
            catch (Exception ex)
            {
                logger.Error($"{locator} {errorMessage}" + "\n" + $"{ex.Message}");
                throw new NotFoundException($"{locator} {errorMessage}" + "\n" + $"{ex.GetType} " + $"{ex.Message}");
            }
        }

        public static bool WaitForEmailInGMailInbox(string SentEmailBody, string errorMessage = "Sent email is different from received email")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromMinutes(10));
            wait.PollingInterval = TimeSpan.FromSeconds(10);
            try
            {
                return wait.Until(webDriver =>
                {
                    return new MainMenuPageObject().IsEmailReceived(SentEmailBody);
                });
            }
            catch (Exception ex)
            {
                logger.Error($"{SentEmailBody} {errorMessage}" + "\n" + $"{ex.Message}");
                throw new NotFoundException($"{errorMessage}" + "\n" + $"{ex.Message}");
            }
        }

        public static bool WaitForEmailInMailRuInbox(string receivedEmailBody, string errorMessage = "Sent email is different from received email")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromMinutes(10));
            wait.PollingInterval = TimeSpan.FromSeconds(10);
            try
            {
                return wait.Until(webDriver =>
                {
                    webDriver.Navigate().Refresh();
                    return new RUMainMenuPageObject().IsEmailReceived(receivedEmailBody);
                });
            }
            catch (Exception ex)
            {
                logger.Error($"{receivedEmailBody} {errorMessage}" + "\n" + $"{ex.Message}");
                throw new NotFoundException($"{errorMessage}" + "\n" + $"{ex.Message}");
            }
        }
    }
}
