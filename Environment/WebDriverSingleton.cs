using Amazon.RDS.Model;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MailAuthorizationTests.Environment
{
    public sealed class WebDriverSingleton
    {
        private static WebDriver? webDriver;
        public static WebDriver GetInstance()
        {
            if (webDriver?.SessionId == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--incognito");
                chromeOptions.AddArgument("--window-size=1920,1080");
                chromeOptions.AddArgument("--start-maximized");
                webDriver = new ChromeDriver(chromeOptions);
            }
            return webDriver;
        }
    }
}
