using System;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Leaf.xNet;
using System.Xml;
using Newtonsoft.Json;

namespace TelegrammBotApi
{
    internal class Modes
    {
        
        HttpClient client;
        //Порядковый номер сообщения
        long countUpdateId = 0;

        static string url {get;set;}
        public string result { get; set; }
        public Modes(string token)
        {
            string baseUrl = "https://api.telegram.org/bot";
            string Url = baseUrl + token + "/";

            url = Url;

            client = InitProxy(client);

            while (true)
            {
                GetUpdates();

            }
            



        }//public Modes

        //Получаем сообщения
        async void  GetUpdates()
        {
            //Запрос получение новых сообщений, offset - делает сообщение прочитанным
            var res = client.GetStringAsync(url + $"getUpdates?offset={countUpdateId.ToString()}").Result;
                Console.WriteLine(res);
                Console.WriteLine();


            JsonMessages.Finish MessageNew = JsonConvert.DeserializeObject<JsonMessages.Finish>(res.ToString());

            if (!MessageNew.ok || MessageNew.result.Length == 0) return;

            //Получаем порядковый номер сообщения
            countUpdateId = MessageNew.result[0].update_id;

            countUpdateId++;

            await Task.Delay(3000);

        }



        /// <summary>Устанавливаем прокси</summary>
        private HttpClient InitProxy(HttpClient Client)
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
            Client =  new HttpClient(handler: httpClientHandler, disposeHandler: true);

            return Client;


        }



    }//class Modes
}//namespace TelegrammBotApi
