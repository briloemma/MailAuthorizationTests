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
            Webdriver.GetInstance().Manage().Cookies.DeleteAllCookies();
            Webdriver.GetInstance().Navigate().GoToUrl(url); ;
            Webdriver.GetInstance().Manage().Window.Maximize();
        }
    }
}
