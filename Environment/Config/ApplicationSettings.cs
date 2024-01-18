namespace MailAuthorizationTests.Environment.Config
{
    public class ApplicationSettings
    {
        public GmailSettings Gmail { get; set; }
        public MailRuSettings MailRu { get; set; }
        public BrowserSettings Browser { get; set; }
    }
    public class GmailSettings
    {
        public string GmailHostPrefix { get; set; }
        public string GmailLogin { get; set; }
        public string GmailPassword { get; set; }
        public string GmailUserName { get; set; }
        public string GmailWrongLogin { get; set; }
        public string GmailNotFoundError { get; set; }
        public string EnterGmailError { get; set; }
        public string SendEmailToAddress { get; set; }
        public string NewGmailPseudonim { get; set; }

    }

    public class MailRuSettings
    {
        public string MailRuHostPrefix { get; set; }
        public string MailRuLogin { get; set; }
        public string MailRuPassword { get; set; }

    }

    public class BrowserSettings
    {
        public string Browser { get; set; }
    }


}
