using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Exceptions;
using System.Threading;
using Kurs_Bot_UsedCar.Model.Filter;
using Newtonsoft.Json;
using Kurs_Api_UsedCar.Model;
using Kurs_Api_UsedCar.Model.SearchCarByID;

namespace Kurs_Bot_UsedCar
{

    public class UsedCarSearch_bot
    {

        static TelegramBotClient botClient = new TelegramBotClient("5434610471:AAGj9zE2-xpbShUwMZslqhOI_JVkVu-qb-k");
        CancellationToken cancellationToken = new CancellationToken();
        ReceiverOptions receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
        public string mark { get; set; }
        public string price_ot { get; set; }
        public string price_do { get; set; }
        public string TypeOfCar { get; set; }
        public string model { get; set; }
        public string bodystyle { get; set; }
        public string fuel { get; set; }
        public string gear { get; set; }
        public string s_years { get; set; }
        public string po_years { get; set; }
        public string engineVolumeFrom { get; set; }
        public string engineVolumeTo { get; set; }
        public const string ria_adress = "https://auto.ria.com/uk";
        public int i { get; set; }
        List<Root> advertisement { get; set; }


        public async Task Start()
        {
            botClient.StartReceiving(HandlerUpdateAsync, HandlerError, receiverOptions, cancellationToken);
            var botMe = await botClient.GetMeAsync();
            Console.WriteLine($"Бот {botMe.Username} почав працювати");
            Console.ReadKey();
        }

        private Task HandlerError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Помилка в телеграм бот АПІ:\n {apiRequestException.ErrorCode}" +
                $"\n{apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        private async Task HandlerUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                await HandlerMessageAsync(botClient, update.Message);
            }
            //add
            //
            if (update?.Type == UpdateType.CallbackQuery)
            {
                await HandlerCallbackQuery(botClient, update.CallbackQuery);
            }
            //
        }
        //add
        //
        private async Task HandlerCallbackQuery(ITelegramBotClient botClient, CallbackQuery? callbackQuery)
        {
            switch (callbackQuery.Data)
            {
                case "Марка автомобiля":
                    await UserWatching.AddRequestAsync("#Car mark", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть марку автомобіля");
                    return;
                case "Вид машини":
                    await UserWatching.AddRequestAsync("#Type of car", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть тип машини");
                    return;
                case "Модель автомобiля":
                    await UserWatching.AddRequestAsync("#Car model", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть модель машини");
                    return;
                case "Цiна вiд":
                    await UserWatching.AddRequestAsync("#Price from", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть від якої ціни шукати машини");
                    return;
                case "Цiна до":
                    await UserWatching.AddRequestAsync("#Price to", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть до якої ціни шукати машини");
                    return;
                case "Тип кузову машини":
                    await UserWatching.AddRequestAsync("#Car bodystyle", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть тип кузова машини");
                    return;
                case "Вид коробки передач":
                    await UserWatching.AddRequestAsync("#Car gearbox", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть тип коробки передач машини");
                    return;
                case "Рік виробництва від":
                    await UserWatching.AddRequestAsync("#Car year from", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть від якого року шукати машини");
                    return;
                case "Рік виробництва до":
                    await UserWatching.AddRequestAsync("#Car year to", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть до якого року шукати машини");
                    return;
                case "Тип пального":
                    await UserWatching.AddRequestAsync("#Car fuel type", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть тип палива машини");
                    return;
                case "Об'єм двигуна від":
                    await UserWatching.AddRequestAsync("#Car engine from", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть від якого об'єму двигуна шукати машини");
                    return;
                case "Об'єм двигуна до":
                    await UserWatching.AddRequestAsync("#Car engine to", callbackQuery.From.Id.ToString());
                    await botClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, text: $"Введіть до якого об'єму двигуна шукати машини");
                    return;
                case "0":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[0].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "1":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[1].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "2":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[2].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "3":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[3].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "4":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[4].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "5":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[5].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "6":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[6].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "7":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[7].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
                case "8":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[8].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    
                    return;
                case "9":
                    if (advertisement != null)
                    {
                        await UserWatching.PostLikeAsync($"{ria_adress}{advertisement[9].linkToView}", callbackQuery.From.Id.ToString());
                    }
                    return;
            } //await UserWatching.PostLikeAsync(advertisement[8].autoData.autoId.ToString(), callbackQuery.From.Id.ToString());
        }
        private async Task HandlerMessageAsync(ITelegramBotClient botClient, Message message)
        {
            BotClient client = new BotClient();
            switch (message.Text)
            {
                case "/start":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть команду /keyboard");
                    return;
                case "Фільтри пошуку":
                    InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(new[]
                        {
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Марка автомобiля", "Марка автомобiля"),
                            InlineKeyboardButton.WithCallbackData("Цiна вiд", $"Цiна вiд"),
                            InlineKeyboardButton.WithCallbackData("Цiна до", $"Цiна до")
                         },
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Вид машини", $"Вид машини"),
                            InlineKeyboardButton.WithCallbackData("Модель автомобiля", $"Модель автомобiля"),
                            InlineKeyboardButton.WithCallbackData("Тип кузову машини", $"Тип кузову машини")
                         },
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Вид коробки передач", $"Вид коробки передач"),
                            InlineKeyboardButton.WithCallbackData("Рік виробництва від", $"Рік виробництва від"),
                            InlineKeyboardButton.WithCallbackData("Рік виробництва до", $"Рік виробництва до")
                         },
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Тип пального", $"Тип пального"),
                            InlineKeyboardButton.WithCallbackData("Об'єм двигуна від", $"Об'єм двигуна від"),
                            InlineKeyboardButton.WithCallbackData("Об'єм двигуна до", $"Об'єм двигуна до")
                         }
                        });
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть фільтр пошуку:", replyMarkup: keyboardMarkup);
                    return;
                case "/keyboard":
                    ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup
                    (
                    new[]
                        {
                            new KeyboardButton [] { "Шукати автомобіль", "Улюблені об'яви", "Як шукати автомобіль"},
                            new KeyboardButton [] { "Фільтри пошуку", "Скинути фільтри пошуку"},
                        }
                    )
                    {
                        ResizeKeyboard = true
                    };
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Виберіть пункт меню:", replyMarkup: replyKeyboardMarkup);
                    return;
                case "Шукати автомобіль":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Розпочався пошук автомобіля");
                    var http = client.Client.GetAsync($"/GetTypeOfFuel?fuel={fuel}");
                    var temp = JsonConvert.DeserializeObject<string>(http.Result.Content.ReadAsStringAsync().Result);
                    fuel = temp;

                    
                    http = client.Client.GetAsync($"/GetTypeOfCar?TypeOfCar={TypeOfCar}");
                    temp = JsonConvert.DeserializeObject<string>(http.Result.Content.ReadAsStringAsync().Result);
                    TypeOfCar = temp;


                    http = client.Client.GetAsync($"/GetMarkOfCar?mark={mark}&category_id={TypeOfCar}");
                    temp = JsonConvert.DeserializeObject<string>(http.Result.Content.ReadAsStringAsync().Result);
                    mark = temp;


                    http = client.Client.GetAsync($"/GetBodystyleOfCar?Bodystyle={bodystyle}&category_id={TypeOfCar}");
                    temp = JsonConvert.DeserializeObject<string>(http.Result.Content.ReadAsStringAsync().Result);
                    bodystyle = temp;


                    http = client.Client.GetAsync($"/GetGearboxOfCar?gear={gear}&category_id={TypeOfCar}");
                    temp = JsonConvert.DeserializeObject<string>(http.Result.Content.ReadAsStringAsync().Result);
                    gear = temp;


                    http = client.Client.GetAsync($"/GetModelOfCar?model={model}&marka_id={mark}&category_id={TypeOfCar}");
                    temp = JsonConvert.DeserializeObject<string>(http.Result.Content.ReadAsStringAsync().Result);
                    model = temp;


                    var result = client.Client.GetAsync($"/SearchUsedCar?marka_id={mark}&price_ot={price_ot}&price_do={price_do}&category_id={TypeOfCar}&model_id={model}&bodystyle={bodystyle}&type={fuel}&gearbox={gear}&s_years={s_years}&po_years={po_years}&engineVolumeFrom={engineVolumeFrom}&engineVolumeTo={engineVolumeTo}");

                    advertisement = JsonConvert.DeserializeObject<List<Kurs_Api_UsedCar.Model.SearchCarByID.Root>>(result.Result.Content.ReadAsStringAsync().Result);
                    
                    if (advertisement.Count == 0)
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Error");
                    }
                    else
                    {
                        for (int i = 0; i <= advertisement.Count - 1; i++)
                        {
                            InlineKeyboardMarkup keyboardMarkupa = new InlineKeyboardMarkup(new[]
                                    {
                                        new[]
                                        {
                                            InlineKeyboardButton.WithCallbackData("Додати до улюблених", $"{i}")
                                        }
                                    });
                            await botClient.SendTextMessageAsync(message.Chat.Id, $"-Автомобіль знаходиться в: {advertisement[i].locationCityName}\n\n-Дата створення об`яви: {advertisement[i].addDate}\n\n-Ціна у USD: {advertisement[i].USD}, ціна у UAH: {advertisement[i].UAH}\n\n-Назва марки: {advertisement[i].markName}, Модель машини: {advertisement[i].modelName}\n\n-Рік виготовлення машини {advertisement[i].autoData.year}\n\n-Пробіг авто {advertisement[i].autoData.race}\n\n-Паливо {advertisement[i].autoData.fuelName}\n\n-Тип коробки передач{advertisement[i].autoData.gearboxName}\n\n-Опис продавця {advertisement[i].autoData.description}\n\n-Лінк на об'яву {ria_adress + advertisement[i].linkToView}", replyMarkup: keyboardMarkupa);
                        }
                    }
                    return;
                case "Улюблені об'яви":
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Улюблені об'яви:");
                    http = client.Client.GetAsync($"GetFav?UserId={message.From.Id}");

                    var LikedAdvertisements = JsonConvert.DeserializeObject<IEnumerable<Advertisement>>(http.Result.Content.ReadAsStringAsync().Result);
                    for(int a = 0; a<LikedAdvertisements.Count(); a++)
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, $"{a+1}: {LikedAdvertisements.ElementAt(a).Advertisement_Id}");
                    }
                    return;
                case "Як шукати автомобіль":
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Введіть до фільтрів пошуку деякі дані, далі натисніть на кнопку *Шукати автомобіль* ");
                    return;
                case "Скинути фільтри пошуку":
                    mark = "0";
                    price_ot = "0";
                    price_do = "0";
                    TypeOfCar = "1";
                    model = "0";
                    bodystyle = "0";
                    fuel = "0";
                    gear = "0";
                    s_years = "0";
                    po_years = "0";
                    engineVolumeFrom = "0";
                    engineVolumeTo = "0";
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"Фільтри скинуто");
                    return;
            }
            var result1 = await client.Client.GetAsync($"/GetRequest?UserId={message.From.Id}");
            Request Mode = JsonConvert.DeserializeObject<Request>(result1.Content.ReadAsStringAsync().Result);
            var result2 = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
            if (result2.Content.ToString().Length == 0)
            {
                // проверка на наличие таблицы для UserId
                UserWatching.AddFiltersAsync(message.From.Id.ToString()); // добавляем пустой фильтр
            }
            switch (Mode.request)
            {
                case "#Car mark":
                    var CarMarkResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    mark = message.Text.ToString();
                    return;
                case "#Type of car":
                    var TypeOfCarResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    TypeOfCar = message.Text.ToString();
                    return;
                case "#Car model":
                    var CarModelResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    model = message.Text.ToString();
                    return;
                case "#Price from":
                    var PriceFromResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    price_ot = message.Text.ToString();
                    return;
                case "#Price to":
                    var PriceToResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    price_do = message.Text.ToString();
                    return;
                case "#Car bodystyle":
                    var BodystyleResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    bodystyle = message.Text.ToString();
                    return;
                case "#Car gearbox":
                    var GearboxResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    gear = message.Text.ToString();
                    return;
                case "Car year from":
                    var YearFromResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    s_years = message.Text.ToString();
                    return;
                case "#Car year to":
                    var YearToResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    po_years = message.Text.ToString();
                    return;
                case "#Car fuel type":
                    var FuelTypeResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    fuel = message.Text.ToString();
                    return;
                case "#Car engine from":
                    var EngineFromResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    engineVolumeFrom = message.Text.ToString();
                    return;
                case "#Car engine to":
                    var EngineToResult = await client.Client.GetAsync($"/GetFilter?UserId={message.From.Id}");
                    engineVolumeTo = message.Text.ToString();
                    return;
                case "test":
                    InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(new[]
                        {
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Додати до улюблених", "1"),
                            InlineKeyboardButton.WithCallbackData("Цiна вiд", $"Цiна вiд"),
                            InlineKeyboardButton.WithCallbackData("Цiна до", $"Цiна до")
                         },
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Вид машини", $"Вид машини"),
                            InlineKeyboardButton.WithCallbackData("Модель автомобiля", $"Модель автомобiля"),
                            InlineKeyboardButton.WithCallbackData("Тип кузову машини", $"Тип кузову машини")
                         },
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Вид коробки передач", $"Вид коробки передач"),
                            InlineKeyboardButton.WithCallbackData("Рік виробництва від", $"Рік виробництва від"),
                            InlineKeyboardButton.WithCallbackData("Рік виробництва до", $"Рік виробництва до")
                         },
                         new[]
                         {
                            InlineKeyboardButton.WithCallbackData("Тип пального", $"Тип пального"),
                            InlineKeyboardButton.WithCallbackData("Об'єм двигуна від", $"Об'єм двигуна від"),
                            InlineKeyboardButton.WithCallbackData("Об'єм двигуна до", $"Об'єм двигуна до")
                         }
                        });
                    return;
            }
        }
    }
}

