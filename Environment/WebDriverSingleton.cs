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
                chromeOptions.AddArgument("enable-automation");
                chromeOptions.AddArgument("--headless");
                chromeOptions.AddArgument("--window-size=2560,1600");
                chromeOptions.AddArgument("--no-sandbox");
                chromeOptions.AddArgument("--disable-extensions");
                chromeOptions.AddArgument("--dns-prefetch-disable");
                chromeOptions.AddArgument("--disable-gpu");
                webDriver = new ChromeDriver(chromeOptions);
            }
            return webDriver;
        }
    }
}
