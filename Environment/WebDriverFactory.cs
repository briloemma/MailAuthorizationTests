using Amazon.RDS.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MailAuthorizationTests.Environment
{
    public sealed class WebDriverFactory
    {
        private static WebDriver? webDriver;
        public static WebDriver GetInstance()
        {
            if (webDriver?.SessionId == null)
            {
                //var options = new ChromeOptions();
                //options.AddArguments("--window-size=1920,1080", "--headless");
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                webDriver = new ChromeDriver();
            }
            return webDriver;
        }
    }
}
