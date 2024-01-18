using MailAuthorizationTests.Environment.Utils;
using System.Reflection;
using System.IO;
using OpenQA.Selenium.Chrome;
using NPOI.SS.Formula.Functions;
using static MailAuthorizationTests.Environment.ApplicationConfig;
using MailAuthorizationTests.Environment.Config;
using OpenQA.Selenium.DevTools.V117.Schema;
using NPOI.POIFS.Properties;
using NPOI.OpenXmlFormats.Dml.Chart;

namespace MailAuthorizationTests.Environment
{
    public class ApplicationConfig
    {
        private static string _jsonFileName = "\\applicationSettings.json";
        private static string parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        private static string _fullFileName = parent + _jsonFileName;


        private static readonly ApplicationSettings settings;

        static ApplicationConfig()
        {
            JsonUtil.Provide(out ApplicationSettings settings, _fullFileName);
            ApplicationConfig.settings = settings;
        }

        public static string GmailHostPrefix => settings.Gmail.GmailHostPrefix;
        public static string GmailLogin => settings.Gmail.GmailLogin;
        public static string GmailWrongLogin => settings.Gmail.GmailWrongLogin;
        public static string GmailPassword => settings.Gmail.GmailPassword;
        public static string GmailUserName => settings.Gmail.GmailUserName;
        public static string SendEmailToAddress => settings.Gmail.SendEmailToAddress;
        public static string NewGmailPseudonim => settings.Gmail.NewGmailPseudonim;
        public static string GmailNotFoundError => settings.Gmail.GmailNotFoundError;
        public static string EnterGmailError => settings.Gmail.EnterGmailError;
        public static string MailRuHostPrefix => settings.MailRu.MailRuHostPrefix;
        public static string MailRuLogin => settings.MailRu.MailRuLogin;
        public static string MailRuPassword => settings.MailRu.MailRuPassword;
        public static string Browser => settings.Browser.Browser;
    }
}
