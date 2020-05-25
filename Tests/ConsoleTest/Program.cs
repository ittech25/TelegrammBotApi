using ConsoleTest.SQL;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {


        static void Main(string[] args)
        {
            //IEnumerable<string> res = new RequestBd().GetCategory();
            string x = "";
            for (int a = 0; a < 5; a++)
            {

                var res = new RequestBd().GetProductsFromCategory("Супы");
                System.Console.WriteLine(string.Join(Environment.NewLine, res));
            }
        


            //System.Console.WriteLine(string.Join(Environment.NewLine, res));
            Console.ReadKey();




        }

    }

}