using System.Collections.Generic;

namespace TelegrammBotApi
{
    /// <summary>
    /// Класс для создания кнопок
    /// </summary>
    public class Buttons
    {
        #region Процесс создания Inline кнопок
        /// <summary>
        /// Этот класс представляет встроенную клавиатуру, которая появляется под соответствующим сообщением.
        /// </summary>
        public class InlineKeyboardMarkup
        {
            /// <summary>Массив строк, каждая из которых является массивом объектов InlineKeyboardButton</summary>
            public List<List<InlineKeyboardButton>> inline_keyboard { get; set; }


            /// <summary>
            /// Конструктор, Массив массивов с InlineKeyboardButton
            /// </summary>
            /// <param name="inline_keyboard"> Массив кнопок</param>
            public InlineKeyboardMarkup(List<List<InlineKeyboardButton>> inline_keyboard)
            {
                this.inline_keyboard = inline_keyboard;
            }

            public InlineKeyboardMarkup()
            {
                this.inline_keyboard = new List<List<InlineKeyboardButton>>();
            }

            /// <summary>
            /// Метод, добавление кнопки в Меню
            /// </summary>
            /// <param name="Button">Массив кнопки</param>
            public void AddButton(InlineKeyboardButton Button)
            {
                this.inline_keyboard.Add(new List<InlineKeyboardButton> { Button });
            }

            /// <summary>
            /// Метод, добавление кнопки в указанную строку
            /// </summary>
            /// <param name="Button"></param>
            /// <param name="NumberLine">номер строки для добавления кнопки</param>
            public void AddButton(InlineKeyboardButton Button, int NumberLine)
            {
                while (this.inline_keyboard.Count <= NumberLine)
                {
                    this.inline_keyboard.Add(new List<InlineKeyboardButton>());
                }
                this.inline_keyboard[NumberLine].Add(Button);
            }



            /// <summary>
            /// Метод, добавление линий у кнопок
            /// </summary>
            /// <param name="LineList">массив линий из кнопок</param>
            public void AddLineButton(List<InlineKeyboardButton> LineList)
            {
                this.inline_keyboard.Add(LineList);
            }


        }

        /// <summary>
        /// Этот объект представляет одну кнопку встроенной клавиатуры
        /// </summary>
        public class InlineKeyboardButton
        {
            /// <summary>Текст на кнопке</summary>
            public string text { get; set; }
            /// <summary>URL, который откроется при нажатии на кнопку</summary>
            public string url { get; set; }
            /// <summary>Данные, которые будут отправлены в callback_query при нажатии на кнопку</summary>
            public string callback_data { get; set; }




            /// <summary>
            /// Создаем кнопки
            /// </summary>
            /// <param name="text">Текст кнопки</param>
            /// <param name="url">URL адрес кнопки</param>
            /// <param name="callback_data">Данные, которые будут отправлены в callback_query при нажатии на кнопку</param>
            public InlineKeyboardButton(string text, string url, string callback_data)

            {
                this.text = text;
                this.url = url;
                this.callback_data = callback_data;
                
                
                if (this.callback_data == "")
                {
                    this.callback_data = url;
                    if (url == "")
                        this.callback_data = text;
                }


            }

            /// <summary>
            /// Создаем кнопки
            /// </summary>
            /// <param name="text">Текст кнопки</param>
            /// <param name="callback_data">Данные, которые будут отправлены в callback_query при нажатии на кнопку</param>
            public InlineKeyboardButton(string text, string callback_data)
            {
                url = "";
                this.text = text;
                this.callback_data = callback_data;
                if (callback_data == "") this.callback_data = text;

            }

        }
        #endregion


        #region Кнопочное меню
        /// <summary>Класс создания кнопочного меню </summary>
        public class ButtonMenu
        {
            /// <summary>
            ///Набор кнопок
            /// </summary>
            public List<List<string>> keyboard { get; set; }
            /// <summary>
            /// скрывать клавиатуру
            /// </summary>
            public bool one_time_keyboard { get; set; }

            /// <summary>
            /// Конструктор, Создаем список кнопок
            /// </summary>
            /// <param name="keyboard">Лист с наборами кнопок</param>
            /// <param name="one_time_keyboard">Скрывать клавиатуру?</param>
            public ButtonMenu(List<List<string>> keyboard, bool one_time_keyboard = true)
            {

                this.keyboard = keyboard;
                this.one_time_keyboard = one_time_keyboard;

            }

        }
        #endregion

    }//class Buttons
}//namespace TelegrammBotApi
