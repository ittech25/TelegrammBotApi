using Newtonsoft.Json;
using System.Collections.Generic;
using static TelegrammBotApi.Buttons;

namespace TelegrammBotApi
{
    public class Menu
    {
        #region Создаем Inline Меню
        /// <summary>
        /// Создаем Inline меню
        /// </summary>
        /// <param name="ChatId"></param>
        public string InlineMenu(string ChatId)
        {
            //создаем кнопку 1
            InlineKeyboardButton key1 = new InlineKeyboardButton("кнопка 1", "ya.ru", "адрес перенаправления");
            //создаем кнопку 2
            InlineKeyboardButton key2 = new InlineKeyboardButton("Меню", "Кнопочное меню");

            //Создаем 1 линию(строку) из кнопок
            List<InlineKeyboardButton> keyBtn = new List<InlineKeyboardButton>()
            {
                key1,
                key2,
            };


            //Создаем все кнопки
            List<List<InlineKeyboardButton>> keybort = new List<List<InlineKeyboardButton>>()
            {
                keyBtn,
            };

            InlineKeyboardMarkup allBtn = new InlineKeyboardMarkup(keybort);


            //необходимо сериализовать класс в JSON
            string replyMarkup = JsonConvert.SerializeObject(allBtn);
            return replyMarkup;
        }
        #endregion



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
    }//class Menu
}//namespace TelegrammBotApi
