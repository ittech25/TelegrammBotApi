using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.SQL
{
    /// <summary>
    /// Структура из БД
    /// </summary>
    public class StructureBdProducts
    {
        //id, catId, name, description, price
        public int id { get; set; }
        public int CategorysId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public virtual StructureBdCategorys Categorys { get; set; }
    }

    public class StructureBdCategorys
    {
        public int id { get; set; }
        public string catName { get; set; }

        public virtual ICollection<StructureBdProducts> Products { get; set; }
    }
}
