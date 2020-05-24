using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
                List<StructureBd> sql = db.product.ToList();

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
                List<StructureBd> sql = db.product.ToList();

                return sql.Select(x => x.category).Distinct();
                
            }
        }


    }
}
