using System.Net.Http;

namespace TelegrammBotApi
{
    public static class Settings
    {
        /// <summary>
        /// Токен от Бота
        /// </summary>
        public static string Token { get; set; }

        public static HttpClient Client { get; set; }

        /// <summary> Базовый Url для запроса к Api</summary>
        public static string Url { get; set; }
    }
}
