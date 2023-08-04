using OpenQA.Selenium;

namespace MailAuthorizationTests.Environment
{
    public static class IsAlertPresent
    {
        public static bool CheckAlertPresence()
        {
            try
            {
                WebDriver.GetInstance().SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException Ex)
            {
                return false;
            }
        }

    }
}
