using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Kurs_Bot_UsedCar
{
    class BotClient
    {
        public HttpClient Client = new HttpClient();

        public BotClient()
        {
            //Client.BaseAddress = new Uri(@"https://localhost:5001/");
            Client.BaseAddress = new Uri(@"https://api-usedcar.herokuapp.com/");

            // https://localhost:5001/index.html
        }
    }
}
