using System;


namespace Kurs_Bot_UsedCar
{
    class Program
    {
        static void Main(string[] args)
        {
            UsedCarSearch_bot UsedCarSearch_bot = new UsedCarSearch_bot();
            UsedCarSearch_bot.Start();
            Console.ReadKey();
        }
    }
}
