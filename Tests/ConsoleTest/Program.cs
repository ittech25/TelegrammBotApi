﻿using ConsoleTest.SQL;
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
            IEnumerable<string> res = new RequestBd().GetCategory();
            Console.WriteLine(res.GetType());
            System.Console.WriteLine(string.Join(Environment.NewLine, res));
            Console.ReadKey();
        }
    }
}
