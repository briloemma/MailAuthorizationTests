using MailAuthorizationTests.Environment;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.BaseUIControls
{
    internal class TextField : BaseControl
    {
        public TextField(By locator) : base(locator)
        {
            
        }

        public string GetText (bool withWait = true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            return WebDriverSingleton.GetInstance().FindElement(_locator).Text;
        }
    }
}
