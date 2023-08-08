using Amazon.RDS.Model;
using Microsoft.Extensions.Options;
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
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("headless",  "window-size=1920,1200");
                webDriver = new ChromeDriver(options);
            }
            return webDriver;
        }
    }
}
