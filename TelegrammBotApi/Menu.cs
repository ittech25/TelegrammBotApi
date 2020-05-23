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
            InlineKeyboardButton key2 = new InlineKeyboardButton("кнопка 2", "Отобразится данное сообщение");

            //Создаем 1 линию(строку) из кнопок
            List<InlineKeyboardButton> keyBtn = new List<InlineKeyboardButton>()
            {
                key1,
                key2
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
    }
}
