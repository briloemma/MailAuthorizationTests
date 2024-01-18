using OpenQA.Selenium;

namespace MailAuthorizationTests.Environment.Utils
{
    public static class AlertUtil
    {
        public static bool CheckAlertPresence()
        {
            try
            {
                WebDriverFactory.GetInstance().SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException Ex)
            {
                return false;
            }
        }

    }
}
