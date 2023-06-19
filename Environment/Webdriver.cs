using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace MailAuthorizationTests.Environment
{
    public sealed class Webdriver
    {
        private static IWebDriver webDriver;
        public static IWebDriver GetInstance()
        {
            if (webDriver == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                webDriver = new ChromeDriver();
            }
            return webDriver;
        }
    }
}
