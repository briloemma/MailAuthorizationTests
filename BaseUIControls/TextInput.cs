using MailAuthorizationTests.Environment;
using NUnit.Core;
using OpenQA.Selenium;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.BaseUIControls
{
    internal class TextInput : BaseControl
    {
        public TextInput(By locator) : base(locator)
        {
        }
        public void SendKeys(string text, bool withWait = true)
        {
            if (withWait)
            {
                IsDisplayed();
            }
            WebDriverSingleton.GetInstance().FindElement(_locator).SendKeys(text);
        }
    }
}
