namespace MailAuthorizationTests.Environment
{
    public static class URL
    {
        public static void GoToURL(string url)
        {
            WebDriver.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriver.GetInstance().Navigate().GoToUrl(url);
        }
    }
}
