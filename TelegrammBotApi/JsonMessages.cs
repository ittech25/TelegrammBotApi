using System;
using System.Collections.Generic;
using System.Text;

namespace TelegrammBotApi
{
    public class JsonMessages
    {
        public class Finish
        {
            /// <summary>
            /// Статус запроса
            /// </summary>
            public bool ok { get; set; }
            /// <summary>
            /// Результат ответа в виде массива
            /// </summary>
            public Result[] result { get; set; }
        }

        /// <summary>
        /// Класс отвечающий за все входящие сообщения
        /// </summary>
        public class Result
        {
            /// <summary>
            /// Порядковый номер входящего сообщения
            /// </summary>
            public long update_id { get; set; }
            /// <summary>
            /// класс входящих сообщения и все что с ними связано
            /// </summary>
            public Message message { get; set; }

            public CallbackQuery callback_query { get; set; }
        }


        public class CallbackQuery
        {
            public string id { get; set; }
            public From from { get; set; }
            public Message message { get; set; }
            public string chat_instance { get; set; }
            public string data { get; set; }
        }

        public class Message
        {
            public int message_id { get; set; }
            public From from { get; set; }
            /// <summary>
            /// класс отвечающий за Чат
            /// </summary>
            public Chat chat { get; set; }
            public int date { get; set; }
            public string text { get; set; }
            public Entity[] entities { get; set; }

            public ReplyMarkup reply_markup { get; set; }
        }


        public class ReplyMarkup
        {
            public List<List<object>> inline_keyboard { get; set; }
        }
        public class From
        {
            public int id { get; set; }
            public bool is_bot { get; set; }
            public string first_name { get; set; }
            public string username { get; set; }
            public string language_code { get; set; }
        }

        public class Chat
        {
            /// <summary>
            /// ID чата с которого пишут
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// Фамилия того кто пишет
            /// </summary>
            public string first_name { get; set; }
            /// <summary>
            /// Имя того кто пишет
            /// </summary>
            public string username { get; set; }
            /// <summary>
            /// тип сообщения
            /// </summary>
            public string type { get; set; }
        }

        public class Entity
        {
            public int offset { get; set; }
            public int length { get; set; }
            public string type { get; set; }
        }

    }//class JsonMessages
}
