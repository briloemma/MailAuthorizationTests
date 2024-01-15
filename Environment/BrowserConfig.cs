using AuthorizationCianPageTests.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.Environment
{
    public class BrowserConfig
    {
        private const string _jsonFileName = "D:\\С#\\Epam\\MailAuthorizationTests\\Users\\Browser.json";
        public static string Browser => settings.Browser;

        private static readonly TestSettings settings;
        static BrowserConfig()
        {
            JsonUtil.Provide(out TestSettings testSettings, _jsonFileName);
            settings = testSettings;
        }
    }
}
