using System;
using System.Collections.Generic;

namespace TelegrammBotApi
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Старт шаблона!");

            Settings.Token = "392463607:AAH2MyFC5A0PUPD0JFfwYILTErdtn45Civ8";

           // Settings.Keybort = new List<List<Buttons.InlineKeyboardButton>>();
           // Settings.Line = new List<Buttons.InlineKeyboardButton>();

            Modes mod = new Modes(Settings.Token);
            
            
        }




    }
}
