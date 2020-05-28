using System.Collections.Generic;
using System.Net.Http;
using static TelegrammBotApi.Buttons;

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


        public static int Number { get; set; }

        /// <summary> Создание кнопок</summary>
        // public static List<List<InlineKeyboardButton>> Keybort { get; set; }
        /// <summary> Создание линий из кнопок</summary>
        //public static List<InlineKeyboardButton> Line { get; set; }


    }
}
