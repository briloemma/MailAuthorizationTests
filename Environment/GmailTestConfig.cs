using AuthorizationCianPageTests.Environment;

namespace MailAuthorizationTests.Environment
{
    public class GmailTestConfig
    {
        private const string _jsonFileName = "D:\\С#\\Epam\\MailAuthorizationTests\\Users\\GmailLogin.json";
        public static string GmailHostPrefix => settings.GmailHostPrefix;
        public static string GmailLogin => settings.GmailLogin;
        public static string GmailWrongLogin => settings.GmailWrongLogin;
        public static string GmailPassword => settings.GmailPassword;
        public static string GmailUserName => settings.GmailUserName;
        public static string SendEmailToAddress => settings.SendEmailToAddress;
        public static string NewGmailPseudonim => settings.NewGmailPseudonim;
        public static string GmailNotFoundError => settings.GmailNotFoundError;
        public static string EnterGmailError => settings.EnterGmailError;

        private static readonly TestSettings settings;
        static GmailTestConfig()
        {
            JsonUtil.Provide(out TestSettings testSettings, _jsonFileName);
            settings = testSettings;
        }
    }
}
