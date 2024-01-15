using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V116.Debugger;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MailAuthorizationTests.Environment
{
    public sealed class WebDriverFactory
    {
        private static WebDriver? webDriver;
        private WebDriverFactory()
        {

        }

        public static WebDriver GetInstance()
        {
            if (webDriver?.SessionId == null)
            {
                switch (BrowserConfig.Browser)
                {
                    case "Chrome":
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                            ChromeOptions chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("enable-automation");
                            chromeOptions.AddArgument("--window-size=2560,1600");
                            chromeOptions.AddArgument("--no-sandbox");
                            chromeOptions.AddArgument("--disable-extensions");
                            chromeOptions.AddArgument("--dns-prefetch-disable");
                            chromeOptions.AddArgument("--disable-gpu");
                            webDriver = new ChromeDriver(chromeOptions);
                        }
                        break;

                    case "Edge":
                        {
                            new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.Latest);
                            EdgeOptions edgeOptions = new EdgeOptions();
                            edgeOptions.AddArgument("enable-automation");
                            edgeOptions.AddArgument("--window-size=2560,1600");
                            edgeOptions.AddArgument("--no-sandbox");
                            edgeOptions.AddArgument("--disable-extensions");
                            edgeOptions.AddArgument("--dns-prefetch-disable");
                            edgeOptions.AddArgument("--disable-gpu");
                            webDriver = new EdgeDriver(edgeOptions);
                        }
                        break;

                    default:
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                            ChromeOptions chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("enable-automation");
                            chromeOptions.AddArgument("--window-size=2560,1600");
                            chromeOptions.AddArgument("--no-sandbox");
                            chromeOptions.AddArgument("--disable-extensions");
                            chromeOptions.AddArgument("--dns-prefetch-disable");
                            chromeOptions.AddArgument("--disable-gpu");
                            webDriver = new ChromeDriver(chromeOptions);
                        }
                        break;
                }
            }
            return webDriver;
        }
    }
}
