namespace MailAuthorizationTests.Environment.Utils
{
    public static class UrlUtil
    {
        public static void GoToURL(string url)
        {
            WebDriverFactory.GetInstance().Navigate().GoToUrl(url);
        }
    }
}
