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
                
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("window-size=1400,600");
                webDriver = new ChromeDriver(chromeOptions);
            }
            return webDriver;
        }
    }
}
