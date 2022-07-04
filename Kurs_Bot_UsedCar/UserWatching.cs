using System;
using System.Collections.Generic;
using System.Text;
using Kurs_Api_UsedCar.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Kurs_Bot_UsedCar.Model.Filter;

namespace Kurs_Bot_UsedCar
{
    class UserWatching
    {


        public static async Task AddRequestAsync(string Requestt, string UserIdt)
        {
            Request request = new Request
            {
                id = 0,
                request = Requestt,
                UserId = UserIdt
            };

            var json = JsonConvert.SerializeObject(request);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            BotClient clients = new BotClient();

            var post = await clients.Client.PostAsync("/PostRequest", data);

            post.EnsureSuccessStatusCode();

            var postcontent = post.Content.ReadAsStringAsync().Result;
            Console.WriteLine(postcontent);

        }
        public static async Task AddFiltersAsync(string UserId)
        {
            Filter228 filter228 = new Filter228
            {
                UserId = UserId,
                mark = " ",
                price_do = " ",
                price_ot = " ",
                TypeOfCar = " ",
                model = " ",
                bodystyle = " ",
                fuel = " ",
                gear = " ",
                s_years = " ",
                po_years = " ",
                engineVolumeFrom = " ",
                engineVolumeTo = " "
            };
            BotClient clients = new BotClient();
            var json = JsonConvert.SerializeObject(filter228);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var post = await clients.Client.PostAsync("/PostFilter", data);

            post.EnsureSuccessStatusCode();

            var postcontent = post.Content.ReadAsStringAsync().Result;
            Console.WriteLine(postcontent);
        }
        public static async Task PostLikeAsync(string Advertisement_Id, string UserId)
        {
            Advertisement advert = new Advertisement
            {
                id = "0",
                Advertisement_Id = Advertisement_Id,
                UserId = UserId
            };

            var json = JsonConvert.SerializeObject(advert);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            BotClient clients = new BotClient();

            var post = await clients.Client.PostAsync($"PostFav?auto_id={Advertisement_Id}&UserId={UserId}", data);

            post.EnsureSuccessStatusCode();

            var postcontent = post.Content.ReadAsStringAsync().Result;
            Console.WriteLine(postcontent);

        }

    }
}
