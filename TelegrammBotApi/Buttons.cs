using System.Collections.Generic;

namespace TelegrammBotApi
{
    /// <summary>
    /// Класс для создания кнопок
    /// </summary>
    class Buttons
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


    }//class Buttons
}//namespace TelegrammBotApi
