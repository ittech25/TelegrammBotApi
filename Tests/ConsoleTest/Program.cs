using ConsoleTest.SQL;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {


        static void Main(string[] args)
        {
            var res = new RequestBd().CountProducts();
            Console.WriteLine(res);
        }
    }
}
