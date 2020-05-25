using System.Collections.Generic;
using System.Linq;

namespace TelegrammBotApi.SQL
{
    /// <summary>Класс, запросов к БД </summary>
    public class RequestBd
    {

        /// <summary>
        /// кол-во продуктов
        /// </summary>
        /// <returns></returns>
        public string CountProducts()
        {

            //подключаемся к БД - kinopoisk
            using (ApplicationContext db = new ApplicationContext())
            {
                //Формируем БД в виде объектов
                List<StructureBdProducts> sql = db.products.ToList();

                var res = from n in sql
                          select sql.Count();
                return res.Count().ToString();
            }
        }



        public IEnumerable<string> GetCategory()
        {

            //подключаемся к БД - kinopoisk
            using (ApplicationContext db = new ApplicationContext())
            {
                //Формируем БД в виде объектов
                List<StructureBdCategorys> sql = db.categorys.ToList();
                var res = sql.Select(x => x.catName);

                return res;

            }

        }


        /// <summary>
        /// Получаем название продуктов по категории
        /// </summary>
        /// <param name="Category">название категории</param>
        /// <returns></returns>
        public List<string> GetProductsFromCategory(string Category)
        {
            /*
            SELECT  name
            FROM products
            INNER JOIN categorys ON products.CategorysId = categorys.id
            WHERE categorys.catName='Каши'
            */

            //подключаемся к БД - kinopoisk
            using (ApplicationContext db = new ApplicationContext())
            {
                //Формируем БД в виде объектов
                List<StructureBdCategorys> Categorys = db.categorys.ToList();
                List<StructureBdProducts> Products = db.products.ToList();

                #region Способ-1
                /*
                //Метод Join() принимает четыре параметра:
                return Products.Join(
                    Categorys,                          //второй список, который соединяем с текущим
                    products => products.CategorysId,   //свойство объекта из текущего списка, по которому идет соединение
                    categorys => categorys.id,          //свойство объекта из второго списка, по которому идет соединение
                    (products, categorys)              //новый объект, который получается в результате соединения
                    => products.name.ToList();                  // результат
                */
                #endregion

                var res =
                        from products in Products
                        join categorys in Categorys
                        on products.CategorysId equals categorys.id
                        where categorys.catName == Category
                        select products.name;
                return res.ToList();

            }

        }
    }//class RequestBd
}
