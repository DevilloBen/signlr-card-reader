using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Chatty.Api.Hubs;
using Chatty.Api.Hubs.Clients;
using Chatty.Api.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Timers;
using ThaiNationalIDCard.NET;
namespace WebSocketsTutorial
{
    public class Program
    {
        private static int lineId = 0;
        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            try
            {

                var thaiNationalIDCardReader = new ThaiNationalIDCardReader();
                var thaiNationalIDCard = thaiNationalIDCardReader.GetPersonal();


                Console.WriteLine($" {lineId} : Thai National ID Card Number ==> {thaiNationalIDCard.CitizenID}");
                Console.WriteLine($" {lineId} : Thai National ID EnglishPersonalInfo ==> {thaiNationalIDCard.EnglishPersonalInfo}");

                var jsonString = JsonSerializer.Serialize(thaiNationalIDCard);
                //var objectCard = JsonSerializer.SerializeToUtf8Bytes

                Console.WriteLine($" {lineId} : Thai National ID Card Name ==> {jsonString}");

            }
            catch (Exception ex)
            {

                Console.WriteLine($" {lineId} Error ==> {DateTime.Now:dd MMM yyyy hh:mm:ss}");
                Console.WriteLine($" {lineId} Error Message ==> ");
                Console.WriteLine($" {ex.Message}");

            }
            lineId++;
        }

        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            var timer = new System.Timers.Timer();

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 3 * 1000;
            timer.Enabled = true;

            var keyInfo = Console.ReadKey();
            while (keyInfo.Key != ConsoleKey.Escape)
            {
                keyInfo = Console.ReadKey();
            }

            Console.WriteLine("**************************");
            Console.WriteLine("Pass Card System");
            Console.WriteLine("**************************");
            Console.WriteLine($"Exit Program ===> {DateTime.Now:dd MMM yyyy hh:mm:ss}");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
