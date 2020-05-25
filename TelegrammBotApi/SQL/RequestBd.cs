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


    }//class RequestBd
}
