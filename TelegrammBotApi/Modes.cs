using System;
using System.Collections.Generic;
using System.Text;

namespace TelegrammBotApi
{
    internal class Modes
    {
        public Modes(string token)
        {
            string baseUrl = "https://api.telegram.org/bot";
            string url = baseUrl + token + "/";

        }
    }
}
