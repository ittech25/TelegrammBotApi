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
        #region Обработка текстового сообщения
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

                case @"/menu":
                    string replyMarkup = new Menu().InlineMenu(ChatId);
                    sendMessage(ChatId, "INLINE Меню", replyMarkup);
                    
                    return;


                case @"кнопочное меню":
                    string ReplyMarkup = new Menu().MyMenu();
                    sendMessage(ChatId, "Кнопочное Меню", ReplyMarkup);

                    return;

                    



                default:
                    answer = $"Вы мне написали:\r\n{Message}\r\nЯ не знаю что ответить, воспользуйтесь командой: /menu";
                    break;
            }
            
            //отправка сообщения пользователю
            sendMessage(ChatId, answer);
        }
        #endregion


        #region Обработка запросов от Inline кнопки
        /// <summary>
        /// Обработка входящено сообщения через Callback
        /// </summary>
        /// <param name="result"></param>
        internal void MsgCallback(JsonMessages.Result result, string replyMarkup = "")
        {
            //Получаем текст который нужно обработать
            string text = result.callback_query.data;
            //Получаем chatId
            string chatId = result.callback_query.message.chat.id.ToString();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"{result.callback_query.id} --> {text}");
            Console.ResetColor();

            //отправка всплывающей подсказки
            answerCallbackQuery(result, result.callback_query.message.text);
            
            //Вызываем метод для обработки нашего текста
            //ProcessMessage(chatId, text);

            //Правка сообщения
            editMessageText(result, replyMarkup);
        }
        #endregion



        /// <summary>
        /// Правка сообщений (реализовал пока только для Сallback)
        /// </summary>
        /// <param name="result"></param>
        /// <param name="replyMarkup"> введите replyMarkup</param>
        async void editMessageText(JsonMessages.Result result, string replyMarkup = "")
        {
            //https://core.telegram.org/bots/api#editmessagetext

            string text = result.callback_query.data;
            string url = $@"{Settings.Url}editMessageText";

            //текст text.UrlEncode() нужно кодировать

            string data = $"chat_id={result.callback_query.message.chat.id.ToString()}&text={text}&message_id={result.callback_query.message.message_id.ToString()}";

            if (replyMarkup != "") data = data + $"&reply_markup={replyMarkup}";

            StringContent content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

            var res = await Settings.Client.PostAsync(url, content);



        }



        #region Отправка сообщения
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
        #endregion

        #region Отправка всплывающей подсказки
        /// <summary>
        ///  Метод, для отправки всплывающей подсказаки для Inline кнопок
        /// </summary>
        /// <param name="result"></param>
        async void answerCallbackQuery(JsonMessages.Result result, string text)
        {
            //адрес для запроса
            string url = $@"{Settings.Url}answerCallbackQuery";

            //текст всплывающей подсказки
            //string text = result.callback_query.data;

            //передаваемые параметры callback_query_id и text
            string data = $"callback_query_id={result.callback_query.id}&text={text}";

            StringContent content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

            var res = await Settings.Client.PostAsync(url, content);

        }
        #endregion



    }//class Messages
}//namespace TelegrammBotApi
