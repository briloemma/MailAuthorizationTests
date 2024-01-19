using MailAuthorizationTests.Environment.Config;
using MailAuthorizationTests.Environment.Utils;

namespace MailAuthorizationTests.Environment
{
    public class ApplicationConfig
    {
        private static readonly ApplicationSettings settings;

        static ApplicationConfig()
        {
            JsonUtil.Provide(out ApplicationSettings settings,
                $"{Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent}/applicationSettings.json");
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
