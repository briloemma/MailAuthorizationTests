using AngleSharp.Css.Parser;
using MailAuthorizationTests.Environment;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.BaseUIControls
{
    internal class Button : BaseControl
    {
        public Button(By locator) : base(locator)
        {
            
        }

        public void Click (bool withWait=true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            WebDriverSingleton.GetInstance().FindElement(_locator).Click();
        }

    }
}
