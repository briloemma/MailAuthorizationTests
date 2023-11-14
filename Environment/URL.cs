namespace MailAuthorizationTests.Environment
{
    public static class URL
    {
        public static void GoToURL(string url)
        {
            //WebDriverSingleton.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverSingleton.GetInstance().Navigate().GoToUrl(url);
        }
    }
}
