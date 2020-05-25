using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using TelegrammBotApi.SQL;
using static TelegrammBotApi.Buttons;

namespace TelegrammBotApi
{
    public class Menu
    {
        #region Кнопочное меню
        List<List<string>> CreateMenu()
        {

            //Создаем ВСЮ клавиатуру
            List<List<string>> keybord = new List<List<string>>()
            {
                 new List<string>(){"Первый ряд - кн1", "Первый ряд - кн2"},
                 new List<string>(){"Второй ряд - кн3"},
                 new List<string>(){"Третий ряд - кн4", "Третий ряд - кн5", "Третий ряд - кн6"},
            };
            return keybord;

        }

        /// <summary>
        /// Меню кнопок
        /// </summary>
        /// <param name="ChatId"></param>
        public string MyMenu()
        {

            ButtonMenu btn = new ButtonMenu(CreateMenu());
            //необходимо сериализовать класс в JSON
            string replyMarkup = JsonConvert.SerializeObject(btn);

            return replyMarkup;

        }
        #endregion

        #region Создаем Inline Меню
        /// <summary>
        /// Создаем Inline меню
        /// </summary>
        /// <param name="ChatId"></param>
        public string InlineMenu()
        {


            //Создаем все кнопки
            List<List<InlineKeyboardButton>> keybort = new List<List<InlineKeyboardButton>>()
            {

                //1 линия состоящая из кнопок
                new List<InlineKeyboardButton>()
                {
                    new InlineKeyboardButton("кнопка1", "линия 2 - кнопка1"),
                    new InlineKeyboardButton("кнопка2", "линия 2 - кнопка2"),
                    new InlineKeyboardButton("кнопка3", "линия 2 - кнопка3"),
                },
                //2 линия состоящая из кнопок
                new List<InlineKeyboardButton>()
                {
                    new InlineKeyboardButton("кнопка4", "линия 3 - кнопка4"),
      
                }
            };

            InlineKeyboardMarkup allBtn = new InlineKeyboardMarkup(keybort);


            //необходимо сериализовать класс в JSON
            string replyMarkup = JsonConvert.SerializeObject(allBtn);
            return replyMarkup;
        }
        #endregion

        #region Добавление Inline кнопок в меню
        /// <summary>
        /// Добавляем кнопку в InlineMenu
        /// </summary>
        /// <param name="ChatId"></param>
        /// <param name="nameButton"> имя кнопки</param>
        /// <param name="lineBtn">линия кнопки</param>
        /// <returns></returns>
        public string InlineMenuAddButton (string ChatId, string nameButton, string callback_data, int lineBtn)
        {

            Buttons.InlineKeyboardMarkup allBtn = new Buttons.InlineKeyboardMarkup();

            allBtn.AddButton
                (new InlineKeyboardButton(nameButton, callback_data));

            //необходимо сериализовать класс в JSON
            string replyMarkup = JsonConvert.SerializeObject(allBtn);
            return replyMarkup;


            
        }
        #endregion

        #region Создаем Inline Меню из БД (наименование категории)
        /// <summary>
        /// Меню из БД
        /// </summary>
        /// <param name="ChatId"></param>
        /// <returns></returns>
        public string InlineMenuFromBd(out string replyMarkup)
        {
            Buttons.InlineKeyboardMarkup allBtn = new Buttons.InlineKeyboardMarkup();
            IEnumerable<string> res = new RequestBd().GetCategory();

            //string query = "SELECT catName FROM categorys";
            //var res = new Bd().SelectBD(query);
            //res.Split(new String[] { "\r\n" }, StringSplitOptions.None)

            int a = 0;
            foreach (string el in res)
            {
                if (el == "") continue;
                //Добавляем кнопку в следующий столбец
                allBtn.AddButton(new InlineKeyboardButton($"{el}", $"{el}"), ++a / 4);
               
            }

            ButtonHeaderMenu(allBtn);
             replyMarkup =  JsonConvert.SerializeObject(allBtn);
            return "Категории продуктов";
        }
        #endregion

        #region Метод для добавления Главных Inline кнопок в Меню
        /// <summary>
        /// Метод, добавляет главные кнопки в меню
        /// </summary>
        /// <param name="keybort"></param>
        public void ButtonHeaderMenu(InlineKeyboardMarkup keybort)
        {
            List<InlineKeyboardButton> line = new List<InlineKeyboardButton>()
            {
                 new InlineKeyboardButton("Есть вопросы?","help"),
                 new InlineKeyboardButton("О нас?","about"),
            };
            keybort.AddLineButton(line);
        }
        #endregion


        public string InlineMenuProductsFromCategory(string Category,out string replyMarkup)
        {
            IEnumerable<string> res = new RequestBd().GetProductsFromCategory(Category);
            Buttons.InlineKeyboardMarkup allBtn = new Buttons.InlineKeyboardMarkup();
            //string query = $"SELECT name FROM products INNER JOIN categorys ON products.CategorysId = categorys.id WHERE categorys.catName='{Category.ToLower()}';";
            //var res =  new Bd().SelectBD(query);
            int a = 0;
            foreach (string el in res)
            {
                if (el == "") continue;
                //Добавляем кнопку в следующий столбец
                allBtn.AddButton(new InlineKeyboardButton($"{el}", $"{el}"), ++a / 4);
            }
            ButtonHeaderMenu(allBtn);
            replyMarkup = JsonConvert.SerializeObject(allBtn);
            return Category;
        }

    }//class Menu
}//namespace TelegrammBotApi
