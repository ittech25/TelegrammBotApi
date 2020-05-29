using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelegrammBotApi.SQL
{
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
        /// Получаем продукты в указанной категории из БД
        /// </summary>
        /// <param name="Category">Укажите категорию</param>
        /// <param name="SkipNomer">Укажите сколько продуктов пропустить(по умл. = 0)</param>
        /// <param name="TakeNomer">Укажите сколько продуктов показать, выдать(по умл. = 0 - все)</param>
        /// <returns></returns>
        public IEnumerable<string> GetProductsFromCategory(string Category, int SkipNomer = 0, int TakeNomer = 0)
        {

            //подключаемся к БД - kinopoisk
            using (ApplicationContext db = new ApplicationContext())
            {
                //Формируем БД в виде объектов
                List<StructureBdCategorys> Categorys = db.categorys.ToList();
                List<StructureBdProducts> Products = db.products.ToList();


                //Получаем продукты из категории
                var res =
                        from products in Products
                        join categorys in Categorys
                        on products.CategorysId equals categorys.id
                        where categorys.catName == Category
                        select products.name;

                //Если значение равно 0 - то получаем весь список товара
                if (TakeNomer == 0) TakeNomer = res.Count();

                //Обрезаем длинные заголовки, в телеге мах длина заголовка 64 байта (33символа-кирилица, 64 - латиница)
                //берем продукты по сортировки, мах в телеге можно создать 100 кнопок (продуктов)
                return res.ToList().Skip(SkipNomer).Select(p => p = GetString(p, 62)).Take(TakeNomer);

            }

        }




        /// <summary>
        /// Получаем данные о товаре(описание)
        /// </summary>
        /// <param name="NameProduct">Наименование товара</param>
        /// <param name="catName">возвращает Категорию данного товара</param>
        /// <returns>вернет Описание товара и категорию</returns>
        public string GetProducts(string NameProduct, out string catName)
        {
            string categoryName = String.Empty;
            //подключаемся к БД
            using (ApplicationContext db = new ApplicationContext())
            {
                //SELECT id, name, description, price FROM products WHERE NAME = 'Рисовая'
                //Формируем БД в виде объектов
                List<StructureBdCategorys> Categorys = db.categorys.ToList();
                List<StructureBdProducts> Products = db.products.ToList();

                //Метод Join() принимает четыре параметра:
                var res = Products.Where(p => p.name == NameProduct).Join(
                    Categorys,                          //второй список, который соединяем с текущим
                    products => products.CategorysId,   //свойство объекта из текущего списка, по которому идет соединение
                    categorys => categorys.id,          //свойство объекта из второго списка, по которому идет соединение
                    (products, categorys)               //новый объект, который получается в результате соединения
                    => $"Категория товара: {categoryName = categorys.catName}\r\nПродукт:{products.name}\n\n" +
                       $"Описание:\n\t{products.description}\n\n\t\tЦена: {products.price}.00 руб.").FirstOrDefault();                  // результат

                catName = categoryName;
                return res;
            }
        }

        /// <summary>
        /// Получаем текст с заданной длиной байтов.
        /// В теллеграмме ограничение в 64 байта для заголовков
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="sizeArrMax">максимальный размер байтов(по умл. = 62)</param>
        /// <returns></returns>
        string GetString(string text, int sizeArrMax = 62)
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







        public IEnumerable<string> GetProductsToCart(string UserName)
        {
            string categoryName = String.Empty;
            //подключаемся к БД
            using (ApplicationContext db = new ApplicationContext())
            {
                //SELECT id, name, description, price FROM products WHERE NAME = 'Рисовая'
                //Формируем БД в виде объектов
                List<StructureBdCategorys> Categorys = db.categorys.ToList();
                List<StructureBdProducts> Products = db.products.ToList();
                List<StructureBdCart> Cart = db.cart.ToList();


                //SELECT id, user_name, productId FROM cart WHERE user_name = 123

                //Метод Join() принимает четыре параметра:
                var res = Cart.Where(c => c.user_name == UserName).Select(c => c.productId.ToString());  // результат
                return res;
            }
        }






    }//class RequestBd
}//namespace ConsoleTest.SQL
