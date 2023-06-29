using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.Environment
{
    public static class URL
    {
        public static void GoToURL (string url)
        {
            WebDriverFactory.GetInstance().Manage().Cookies.DeleteAllCookies();
            WebDriverFactory.GetInstance().Navigate().GoToUrl(url);
        }
    }
}
