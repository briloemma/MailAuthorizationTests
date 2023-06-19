using Microsoft.VisualBasic;
using NLog;
using NPOI.Util;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAuthorizationTests.Environment
{
    public class TestListener : ITestListener
    {
        string filePath = "D:\\Screenshots";
        string fileName = String.Format("{0}_{1}_{2}_{3}_{4}", 
            DateTime.Now.Day, 
            DateTime.Now.Month, 
            DateTime.Now.Year, 
            DateTime.Now.Hour, 
            DateTime.Now.Minute);

        public void TestFailed()
        {
            TakeScreenShot();
        }
        public void SendMessage(TestMessage message)
        {
            throw new NotImplementedException();
        }

        public void TestFinished(ITestResult result)
        {
            throw new NotImplementedException();
        }

        public void TestOutput(TestOutput output)
        {
            throw new NotImplementedException();
        }

        public void TestStarted(ITest test)
        {
            throw new NotImplementedException();
        }

        private void TakeScreenShot()
        {

            try
            {
                Screenshot TakeScreenshot = ((ITakesScreenshot)Webdriver.GetInstance()).GetScreenshot();

                TakeScreenshot.SaveAsFile($"{filePath}\\{fileName}.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
