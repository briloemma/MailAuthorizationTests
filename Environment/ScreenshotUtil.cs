using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Reflection;

namespace MailAuthorizationTests.Environment
{
    public static class ScreenshotUtil
    {
        private static string fileName = String.Format("{0}-{1}-{2} {3}-{4}",
        DateTime.Now.Day,
        DateTime.Now.Month,
        DateTime.Now.Year,
        DateTime.Now.Hour,
        DateTime.Now.Minute);

        public static void TakeScreenShot()
        {

            try
            {
                Screenshot TakeScreenshot = ((ITakesScreenshot)WebDriverSingleton.GetInstance()).GetScreenshot();
                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots")))
                {
                    Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots"));
                }

                TakeScreenshot.SaveAsFile($"Screenshots/{TestContext.CurrentContext.Test.MethodName} {fileName}.png");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
