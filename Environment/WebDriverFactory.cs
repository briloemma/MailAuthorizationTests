using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MailAuthorizationTests.Environment
{
    public sealed class WebDriverFactory
    {
        public static Dictionary<Thread, WebDriver> Drivers = new Dictionary<Thread, WebDriver>();

        private WebDriverFactory()
        {

        }

        public static WebDriver GetInstance()
        {
            if (!Drivers.ContainsKey(Thread.CurrentThread))
            {
                switch (ApplicationConfig.Browser)
                {
                    case "Chrome":
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                            ChromeOptions chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("enable-automation");
                            chromeOptions.AddArgument("--window-size=2560,1600");
                            chromeOptions.AddArgument("--no-sandbox");
                            chromeOptions.AddArgument("--disable-extensions");
                            chromeOptions.AddArgument("disable-infobars");
                            chromeOptions.AddArgument("--dns-prefetch-disable");
                            chromeOptions.AddArgument("--disable-gpu");
                            Drivers.Add(Thread.CurrentThread, new ChromeDriver(chromeOptions));
                            return Drivers[Thread.CurrentThread];
                        }

                    case "Edge":
                        {
                            new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                            EdgeOptions edgeOptions = new EdgeOptions();
                            edgeOptions.AddArgument("enable-automation");
                            edgeOptions.AddArgument("start-maximized");
                            edgeOptions.AddArgument("--no-sandbox");
                            edgeOptions.AddArgument("--disable-extensions");
                            edgeOptions.AddArgument("disable-infobars");
                            edgeOptions.AddArgument("--dns-prefetch-disable");
                            edgeOptions.AddArgument("--disable-gpu");
                            edgeOptions.AddArgument("--disable-dev-shm-usage");
                            Drivers.Add(Thread.CurrentThread, new EdgeDriver(edgeOptions));
                            return Drivers[Thread.CurrentThread];
                        }

                    default:
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.Latest);
                            ChromeOptions chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("enable-automation");
                            chromeOptions.AddArgument("--window-size=2560,1600");
                            chromeOptions.AddArgument("--no-sandbox");
                            chromeOptions.AddArgument("--disable-extensions");
                            chromeOptions.AddArgument("disable-infobars");
                            chromeOptions.AddArgument("--dns-prefetch-disable");
                            chromeOptions.AddArgument("--disable-gpu");
                            Drivers.Add(Thread.CurrentThread, new ChromeDriver(chromeOptions));
                            return Drivers[Thread.CurrentThread];
                        }
                }
            }
            return Drivers[Thread.CurrentThread];
        }

    }
}
