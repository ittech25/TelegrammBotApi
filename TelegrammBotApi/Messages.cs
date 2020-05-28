using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using TelegrammBotApi.SQL;

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
                    string replyMarkup = "";
                    string text = new Menu().InlineMenuFromBd(out replyMarkup,2);
                    sendMessage(ChatId, text, replyMarkup);
                    return;

                case @"/кнопочное меню":
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
        /// Обработка запросов от Inline кнопки
        /// </summary>
        /// <param name="result">Результат от запроса JsonMessages.Result</param>
        /// <param name="replyMarkup"></param>
        internal void ProcessMessageToInline(JsonMessages.Result result, string replyMarkup="")
        {
            //получаем chatId - идентификатор чата
            string chatId = result.callback_query.message.chat.id.ToString();
            //получаем message_id - идентификатор сообщения
            string messageId = result.callback_query.message.message_id.ToString();
            //получаем текст от callback_query
            string messageCallback = result.callback_query.data;
            
            //получаем название кнопки
            string titleButton = result.callback_query.message.text;

            
            string answer = String.Empty; //ответ входящее на сообщение
            
            //обработка сообщения полученого от Inline кнопки от callback_query
            switch (messageCallback.ToLower())
            {
                case @"help":
                    titleButton = "Спаравка по продуктам";
                    new Menu().InlineMenuFromBd(out replyMarkup);
                    break;

                case @"about":
                    titleButton = "Тут будет описание компании";
                    new Menu().InlineMenuFromBd(out replyMarkup);
                    break;

                case @"next":
                    titleButton = messageCallback;
                    Settings.Number = Settings.Number + 5;
                    new Menu().InlineMenuProductsFromCategory(messageCallback, out replyMarkup);
                    
                    break;


                default:
                    titleButton = messageCallback;
                    var res = new Menu().InlineMenuProductsFromCategory(messageCallback, out replyMarkup);

                    //проверка на NULL
                    if (String.IsNullOrEmpty(res)) break;
                    //если ответ выдал больше 30 символов, значит это не категория и не товар, а описание товара
                    if (res.Length > 30 || !res.Any()) titleButton = res;
                    break;
            }

            //titleButton = answer + Environment.NewLine + messageCallback;
            //отправка сообщения пользователю
            //sendMessage(chatId, answer, replyMarkup); ;


            editMessageText(chatId, messageId, titleButton, replyMarkup);
        }
        #endregion


        #region Правка сообщений от Inline запросов - 1
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
        #endregion
        #region Правка сообщений от Inline запросов - 2
        /// <summary>
        ///Метод, Правки сообщения
        /// </summary>
        /// <param name="chatId">введите chatId</param>
        /// <param name="messageId">введите идентификатор сообщения messageId</param>
        /// <param name="text">введите текст изменяемого сообщения</param>
        /// <param name="replyMarkup">введите replyMarkup</param>  
        async void editMessageText(string chatId, string messageId,string text, string replyMarkup = "")
        {
            string url = $@"{Settings.Url}editMessageText";

            string data = $"chat_id={chatId}&text={text}&message_id={messageId}";

            if (replyMarkup != "") data = data + $"&reply_markup={replyMarkup}";

            StringContent content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");

            var res = await Settings.Client.PostAsync(url, content);

        }
        #endregion

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
