using System;
using System.Collections.Generic;
using System.Text;

namespace TelegrammBotApi.SQL
{
    public class StructureBd
    {
        //id, name, description, price
        public int id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }

    }
}
