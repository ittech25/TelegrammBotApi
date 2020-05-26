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
            Console.WriteLine("Старт шаблона");
            //var res = new RequestBd().GetProducts();

        
            Console.WriteLine(string.Join(Environment.NewLine, new SqlProductData(new ApplicationContext()).GetProductById("Беговые дорожки")));

            //DbInitializer ini = new DbInitializer(new ApplicationContext());
            //ini.Initialize();

            // Console.WriteLine(string.Join(Environment.NewLine, new RequestBd().CountProducts()));

            //System.Console.WriteLine(string.Join(Environment.NewLine, res));
            Console.WriteLine("Завершон шаблона");
            Console.ReadKey();




        }

    }

}