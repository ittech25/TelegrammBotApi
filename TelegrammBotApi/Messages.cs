using System;
using System.Net.Http;
using System.Text;

namespace TelegrammBotApi
{
    /// <summary>
    ///  Класс всех сообщений
    /// </summary>
    internal class Messages
    {
        /// <summary>
        /// Обработка входящих сообщений
        /// </summary>
        /// <param name="ChatId">введите ChatId</param>
        /// <param name="Message">введите сообщение, которое нужно обработать</param>
        internal void ProcessMessage(string ChatId, string Message)
        {
            string answer = String.Empty; //ответ входящее на сообщение
            switch (Message.ToLower())
            {
                case @"/start":
                    answer = "Добро пожаловать! Вы запустили чат бот. \r\nЕсли не заете с чего начить введиде: /menu ";
                    break;

                default:
                    answer = $"Вы мне написали:\r\n{Message}\r\nЯ не знаю что ответить, воспользуйтесь командой: /menu";
                    break;
            }
            
            //отправка сообщения пользователю
            sendMessage(ChatId, answer);
        }


        /// <summary>
        /// Метод, для отправки текстового сообщения
        /// </summary>
        /// <param name="chat_id">ID чата</param>
        /// <param name="text">Текст отправляемого сообщения</param>
         async void sendMessage(string chat_id, string text, string replyMarkup = "")
        {
            string url = $"{Settings.Url}sendMessage";
            string data = $"chat_id={chat_id}&text={text}";

            if (replyMarkup != "") data = data + $"&reply_markup={ replyMarkup }";

            StringContent content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
            
            var res = await Settings.Client.PostAsync(url, content);

        }
    }
}
