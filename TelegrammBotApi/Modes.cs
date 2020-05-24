using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegrammBotApi
{
    internal class Modes
    {
        
        //Порядковый номер сообщения
        long countUpdateId = 0;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="token"></param>
        public Modes(string token)
        {
            string baseUrl = "https://api.telegram.org/bot";
            Settings.Url = baseUrl + token + "/";

            

            //Устанавливаем прокси
            InitProxy();

            while (true)
            {
                //Получаем входящие сообщщения
                GetUpdates();
            }
            



        }//public Modes

        /// <summary>
        /// Метод, получания сообщения
        /// </summary>
        /// <param name="wait">ожидание в секундах</param>
        async void  GetUpdates(int wait = 3)
        {
            //получаем ожидание в секундах
            wait = wait * 1000;

            //Запрос получение новых сообщений, offset - делает сообщение прочитанным
            var res = Settings.Client.GetStringAsync(Settings.Url + $"getUpdates?offset={countUpdateId.ToString()}").Result;
                Console.WriteLine(res);
                Console.WriteLine();

            //Серилизация объекта
            JsonMessages.Finish MessageNew = JsonConvert.DeserializeObject<JsonMessages.Finish>(res.ToString());

            if (!MessageNew.ok || MessageNew.result.Length == 0) return;

            //Получаем порядковый номер сообщения
            countUpdateId = MessageNew.result[0].update_id;
            

            //перебор входящих сообщений
            /*
             * На данный момент 2 типа сообщений
             * 1 - el.message - обработка простых кнопок и сообщений
             * 2 - el.callback_query - обработка запроса от Inline кнопок
             * Взависимости от типа сообщения обрабатываем его
             */
            foreach (var el in MessageNew.result)
            {
                //Получаем порядковый номер сообщения
                countUpdateId = el.update_id;

                //Проверка на получение текстового сообщения или кнопочного меню
                if (el.message != null)
                {
                    Console.WriteLine("Обработка сообщения 1 способом");
                    //Обрабатываем текстовое сообщение от пользователя или от кнопочного меню
                    new Messages().ProcessMessage(el.message.chat.id.ToString(), el.message.text);
                }

                //Проверка на получение сообщения от Inline кнопок
                if (el.callback_query != null)
                {
                    Console.WriteLine("Обработка INLINE сообщений - 2 способ");
                    //получаем ChatId
                    string ChatId = el.callback_query.message.chat.id.ToString();
                    
                    //получаем replyMarkup
                    string replyMarkup = new Menu().InlineMenuFromBd(ChatId);
                    //обрабатываем запрос от Inline кнопок
                    new Messages().MsgCallback(el, replyMarkup);
                }
            }
            countUpdateId++;

            // Пауза для получения новых сообщений
            await Task.Delay(wait);

        }


    #region Устанавка прокси
        /// <summary>Устанавливаем прокси</summary>
        private void InitProxy()
        {

            string proxyHost = "216.158.228.233";
            string proxyPort = "7384";
            string proxyUserName = "iusa3000334";
            string proxyPassword = "Kpoe0eSXDv";

            // First create a proxy object
            var proxy = new WebProxy
            {
                Address = new Uri($"http://{proxyHost}:{proxyPort}"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,

                // *** These creds are given to the proxy server, not the web server ***
                Credentials = new NetworkCredential(
                    userName: proxyUserName,
                    password: proxyPassword)
            };

            // Now create a client handler which uses that proxy
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = proxy,
            };

            // Omit this part if you don't need to authenticate with the web server:
            /*
            if (needServerAuthentication)
            {
                httpClientHandler.PreAuthenticate = true;
                httpClientHandler.UseDefaultCredentials = false;

                // *** These creds are given to the web server, not the proxy server ***
                httpClientHandler.Credentials = new NetworkCredential(
                    userName: serverUserName,
                    password: serverPassword);
            }
            */

            // Finally, create the HTTP client object
            Settings.Client =  new HttpClient(handler: httpClientHandler, disposeHandler: true);

        }

    #endregion

    }//class Modes
}//namespace TelegrammBotApi
