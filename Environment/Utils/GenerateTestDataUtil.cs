using System.Text;

namespace MailAuthorizationTests.Environment.Utils
{
    public static class GenerateTestDataUtil
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber()
        {
            return getrandom.Next(1, 10000);
        }
        public static string GenerateRandomString(int size, bool lowerCase = true)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringBuilder.Append(ch);
            }
            if (lowerCase)
                return stringBuilder.ToString().ToLower();

            return stringBuilder.ToString();
        }

    }
}
