using System;
using System.Net;

namespace TelegrammBotApi
{
    internal class Modes
    {
        WebClient client;

        static string url {get;set;}
        public Modes(string token)
        {
            string baseUrl = "https://api.telegram.org/bot";
            string Url = baseUrl + token + "/";

            url = Url;
        }//public Modes


        void Init()
        {
            client = new WebClient();
            InitProxy();
        
        }

        /// <summary>Устанавливаем прокси</summary>
        private void InitProxy()
        {
            //установка прокси
            WebProxy proxy = new WebProxy("216.158.228.233", 7384);
            proxy.Credentials = new NetworkCredential("iusa3000334", "Kpoe0eSXDv");
            client.Proxy = proxy;
        }



    }//class Modes
}//namespace TelegrammBotApi
