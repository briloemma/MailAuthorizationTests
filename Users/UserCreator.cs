using MailAuthorizationTests.Users;

namespace MailAuthorizationTests.Environment
{
    public static class UserCreator
    {
        public static User GetGmailUser()
        {
            return new User(GmailTestConfig.GmailLogin, GmailTestConfig.GmailPassword);
        }

        public static User GetGmailUserWrongLogin()
        {
            return new User(GmailTestConfig.GmailWrongLogin, "");
        }

        public static User GetEmptyGmailUser()
        {
            return new User("", "");
        }

        public static User GetMailRuUser()
        {
            return new User(MailRuConfig.MailRuLogin, MailRuConfig.MailRuPassword);
        }
    }
}
