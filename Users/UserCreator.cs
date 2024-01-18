using MailAuthorizationTests.Users;

namespace MailAuthorizationTests.Environment
{
    public static class UserCreator
    {
        public static User GetGmailUser()
        {
            return new User(ApplicationConfig.GmailLogin, ApplicationConfig.GmailPassword);
        }

        public static User GetGmailUserWrongLogin()
        {
            return new User(ApplicationConfig.GmailWrongLogin, "");
        }

        public static User GetEmptyGmailUser()
        {
            return new User("", "");
        }

        public static User GetMailRuUser()
        {
            return new User(ApplicationConfig.MailRuLogin, ApplicationConfig.MailRuPassword);
        }
    }
}
