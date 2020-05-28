using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest.SQL
{
    [System.Runtime.InteropServices.Guid("5297F4DD-C3AF-46F9-82A7-A2BB30E1A161")]
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





        public IEnumerable<string> GetProductsFromCategory(string Category,int SkipNomer =0, int TakeNomer=0)
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
                    (products, categorys)               //новый объект, который получается в результате соединения
                    => products.name);                  // результат
                */
                #endregion

                var res =
                        from products in Products
                        join categorys in Categorys
                        on products.CategorysId equals categorys.id
                        where categorys.catName == Category
                        select products.name;

                if (TakeNomer == 0) TakeNomer = res.Count();

                return res.ToList().Skip(SkipNomer).Select(p => p = GetString(p, 62)).Take(TakeNomer);

            }

        }


        /// <summary>
        ///Получаем данные о товаре
        /// </summary>
        /// <param name="NameProduct">имя товара</param>
        /// <returns></returns>
        public IEnumerable<string> GetProducts(string NameProduct)
        {
            //подключаемся к БД - kinopoisk
            using (ApplicationContext db = new ApplicationContext())
            {
                //SELECT id, name, description, price FROM products WHERE NAME = 'Рисовая'
                //Формируем БД в виде объектов
                List<StructureBdCategorys> Categorys = db.categorys.ToList();
                List<StructureBdProducts> Products = db.products.ToList();

                //Метод Join() принимает четыре параметра:
                return Products.Where(p => p.name == "Рисовая").Join(
                    Categorys,                          //второй список, который соединяем с текущим
                    products => products.CategorysId,   //свойство объекта из текущего списка, по которому идет соединение
                    categorys => categorys.id,          //свойство объекта из второго списка, по которому идет соединение
                    (products, categorys)               //новый объект, который получается в результате соединения
                    => $"Категория товара: {categorys.catName}\r\nПродукт:{products.name}\n\n" +
                       $"Описание:\n\t{products.description}\n\n\t\tЦена: {products.price}.00 руб.");                  // результат


            }
        }

        /// <summary>
        /// Получаем текст с заданной длиной байтов.
        /// В теллеграмме ограничение в 64 байта для заголовков
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="sizeArrMax">максимальный размер байтов(по умл. = 62)</param>
        /// <returns></returns>
        public string GetString(string text, int sizeArrMax = 62)
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

    }//class RequestBd
}//namespace ConsoleTest.SQL
