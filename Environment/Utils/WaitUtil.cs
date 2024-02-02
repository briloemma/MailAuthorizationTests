using MailAuthorizationTests.PageObjects;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MailAuthorizationTests.Environment.Utils
{
    public static class WaitUtil
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        public static bool WaitForElementIsDisplayed(By locator, string errorMessage = "Element is not found")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(webDriver =>
                {
                    var webElements = webDriver.FindElements(locator);
                    return webElements.FirstOrDefault()?.Displayed ?? false;
                });
            }
            catch (Exception ex)
            {
                logger.Error($"{locator} {errorMessage}" + "\n" + $"{ex.Message}");
                throw new NotFoundException($"{locator} {errorMessage}" + "\n" + $"{ex.GetType} " + $"{ex.Message}");
            }
        }

        public static bool WaitForElementIsEnabled(By locator, string errorMessage = "Element is not found")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(10));
            try
            {
                return wait.Until(webDriver =>
                {
                    var webElements = webDriver.FindElements(locator);
                    return webElements.FirstOrDefault()?.Enabled ?? false;
                });
            }
            catch (Exception ex)
            {
                logger.Error($"{locator} {errorMessage}" + "\n" + $"{ex.Message}");
                throw new NotFoundException($"{locator} {errorMessage}" + "\n" + $"{ex.GetType} " + $"{ex.Message}");
            }
        }

        public static bool WaitUntilElementIsNotDisplayed(By locator, int waitSeconds = 5, int pollingIntervalSeconds = 1, string errorMessage = "Element is displayed but it shouldn't")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(waitSeconds));
            wait.PollingInterval = TimeSpan.FromSeconds(pollingIntervalSeconds);
            try
            {
                return wait.Until(webDriver =>
                {
                    var webElements = webDriver.FindElements(locator);
                    return !webElements.FirstOrDefault()?.Displayed ?? true;
                });
            }
            catch (Exception ex)
            {
                logger.Error($"{locator} {errorMessage}" + "\n" + $"{ex.Message}");
                throw new Exception($"{locator} {errorMessage}" + "\n" + $"{ex.GetType} " + $"{ex.Message}");
            }
        }

        public static bool WaitForElementIsDisplayedOnParentElement(IWebElement element, By locator, string errorMessage = "Element is not found")
        {
            var webDriver = WebDriverFactory.GetInstance();
            WebDriverWait wait = new(webDriver, TimeSpan.FromSeconds(30));
            try
            {
                return wait.Until(webDriver =>
                {
                    var webElements = element.FindElements(locator);
                    return webElements.FirstOrDefault()?.Displayed ?? false;
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
            wait.PollingInterval = TimeSpan.FromSeconds(15);
            try
            {
                return wait.Until(webDriver =>
                {
                    webDriver.Navigate().Refresh();
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
            object locker = new object();
            lock (locker)
            {
                var webDriver = WebDriverFactory.GetInstance();
                WebDriverWait wait = new(webDriver, TimeSpan.FromMinutes(10));
                wait.PollingInterval = TimeSpan.FromSeconds(10);

                try
                {
                    return wait.Until(webDriver =>
                    {
                        webDriver.Navigate().Refresh();
                        return new PageObjects.MailRuPageObjects.RUMainMenuPageObject().IsEmailReceived(receivedEmailBody);
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
}
