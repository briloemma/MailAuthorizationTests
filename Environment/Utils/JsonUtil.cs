using System.Text.Json;

namespace MailAuthorizationTests.Environment.Utils
{
    public static class JsonUtil
    {
        public static void Provide<T>(out T Tobject, string fileName)
        {
            string objectJsonFile = File.ReadAllText(fileName);
            Tobject = JsonSerializer.Deserialize<T>(objectJsonFile);
        }
    }
}
