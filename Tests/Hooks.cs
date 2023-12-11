using MailAuthorizationTests.Environment;
using MailAuthorizationTests.PageObjects.GmailPageObjects;

namespace MailAuthorizationTests.Tests
{
    public class Hooks
    {
        public void DoBeforeCheckGmailAccountPseudonimHasBeenChangedCorrectly()
        {
            new AuthorizationPageObject().Login(UserCreator.GetGmailUser());
            string actualPseudonim = new OpenedEmailPageObject().GoToAccountSettings().GoToUserPseudonim().GetAccountPseudonim();

            if (!actualPseudonim.Equals("Псевдонима нет"))
            {
                new AccountSettingsPageObject().DeleteAccountPseudonim();
            }
        }
    }
}
