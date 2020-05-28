using ConsoleTest.SQL;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{




    class Program
    {
        public static void Main()
        {

             var res = new RequestBd().GetProductsFromCategory("Беговые дорожки",5,5);

            Console.WriteLine(string.Join(Environment.NewLine, res));
            //Begovia dorojka electricheski
            //Беговая дорожка электрическая LifeSpan TR1200iC
            var x = GetString("Беговая дорожка электрическая", 30);
            Console.WriteLine(x);
        }



        public static string GetString(string text, int sizeArrMax = 62)
        {
            string newString = String.Empty;
            //выбираем кодировку
            Encoding u8 = Encoding.UTF8;

            //кодируем 
            byte[] bytes = u8.GetBytes(text);
            //получаем размер
            int sizeArr = u8.GetByteCount(text);

            if (sizeArr <= sizeArrMax) 
                newString = u8.GetString(bytes, 0, sizeArr);
            else
                newString = u8.GetString(bytes, 0, sizeArrMax);
            return newString;
        }


    }
}
