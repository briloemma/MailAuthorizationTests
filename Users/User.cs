namespace MailAuthorizationTests.Users
{
    public class User
    {
        private string Login;
        private string Password;
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string GetLogin()
        {
            return Login;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}
