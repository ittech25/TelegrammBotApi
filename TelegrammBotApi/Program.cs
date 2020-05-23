using System;

namespace TelegrammBotApi
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Старт шаблона!");

            Settings.Token = "392463607:AAH2MyFC5A0PUPD0JFfwYILTErdtn45Civ8";

            Modes mod = new Modes(Settings.Token);
            
            
        }




    }
}
