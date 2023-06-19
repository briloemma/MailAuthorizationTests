using AuthorizationCianPageTests.Environment;

namespace MailAuthorizationTests.Environment
{
    public class MailRuConfig
    {
        private const string _jsonFileName = "D:\\С#\\Epam\\MailAuthorizationTests\\Users\\MailRuLogin";
        public static string MailRuHostPrefix => settings.MailRuHostPrefix;
        public static string MailRuLogin => settings.MailRuLogin;
        public static string MailRuPassword => settings.MailRuPassword;

        private static readonly TestSettings settings;
        static MailRuConfig()
        {
            JsonUtil.Provide(out TestSettings testSettings, _jsonFileName);
            settings = testSettings;
        }
    }
}
