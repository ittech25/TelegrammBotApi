using ConsoleTest.SQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.SQL
{
    public class SqlProductData //: IProductData
    {
        private readonly ApplicationContext _db;

        public SqlProductData(ApplicationContext db) => _db = db;

        //public IEnumerable<StructureBdCategorys> GetAllCategory() => _db.categorys
        //   .Select(categorys => categorys.catName)
        //   .AsEnumerable();


        public StructureBdProducts GetProductById(string name) => _db.products
       .Include(p => p.CategorysId)
       .Include(p => p.id)
       .FirstOrDefault(p => p. == 5);
    }
}
