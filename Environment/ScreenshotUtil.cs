using OpenQA.Selenium;

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
                Screenshot TakeScreenshot = ((ITakesScreenshot)WebDriverFactory.GetInstance()).GetScreenshot();
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

        public static void DeleteScreenShots()
        {

            if (Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots")))
            {
                DirectoryInfo di = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots"));

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

            }
        }
    }
}
