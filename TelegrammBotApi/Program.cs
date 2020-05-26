using System;
using System.Collections.Generic;
using TelegrammBotApi.SQL;

namespace TelegrammBotApi
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Старт шаблона!");
            #region Справка
            /*
             * Официальная документация - https://core.telegram.org/bots/api
             * Частичная документация на русском - https://tlgrm.ru/docs/bots/api
             * Как создать бота - https://tlgrm.ru/docs/bots#kak-sozdat-bota
             */
            #endregion

            //Токен от бота Tellegram
            Settings.Token = "392463607:AAH2MyFC5A0PUPD0JFfwYILTErdtn45Civ8";
            //Запускаем бота в работу
            Modes mod = new Modes(Settings.Token);


   


            //IEnumerable<string> res = new RequestBd().GetProductsFromCategory("Супы");
            // Console.WriteLine(String.Join(Environment.NewLine, res));
        }

    }
}
