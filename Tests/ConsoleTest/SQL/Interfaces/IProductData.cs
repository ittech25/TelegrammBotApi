using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest.SQL.Interfaces
{
    public interface IProductData
    {
        /// <summary>Получить все категории</summary>
        /// <returns>Перечисление секций каталога</returns>
        IEnumerable<StructureBdCategorys> GetAllCategory();
    }
}
