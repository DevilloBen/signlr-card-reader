using System.Threading.Tasks;
using Chatty.Api.Hubs;
using Chatty.Api.Hubs.Clients;
using Chatty.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
// using System;
// using System.Collections.Generic;
// using System.Text;
// using System.Text.Json;
// using System.Timers;
// using ThaiNationalIDCard.NET;

namespace Chatty.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub, IChatClient> _chatHub;
        public readonly ILogger<ChatController> _logger;

        private static int lineId = 0;

        public ChatController(IHubContext<ChatHub, IChatClient> chatHub, ILogger<ChatController> logger)
        {
            _chatHub = chatHub;
            _logger = logger;
        }


        // public static void OnTimedEvent(object source, ElapsedEventArgs e)
        // {

        //     try
        //     {

        //         var thaiNationalIDCardReader = new ThaiNationalIDCardReader();
        //         var thaiNationalIDCard = thaiNationalIDCardReader.GetPersonal();


        //         Console.WriteLine($" {lineId} : Thai National ID Card Number ==> {thaiNationalIDCard.CitizenID}");
        //         Console.WriteLine($" {lineId} : Thai National ID EnglishPersonalInfo ==> {thaiNationalIDCard.EnglishPersonalInfo}");

        //         var jsonString = JsonSerializer.Serialize(thaiNationalIDCard);
        //         //var objectCard = JsonSerializer.SerializeToUtf8Bytes

        //         Console.WriteLine($" {lineId} : Thai National ID Card Name ==> {jsonString}");

        //     }
        //     catch (Exception ex)
        //     {

        //         Console.WriteLine($" {lineId} Error ==> {DateTime.Now:dd MMM yyyy hh:mm:ss}");
        //         Console.WriteLine($" {lineId} Error Message ==> ");
        //         Console.WriteLine($" {ex.Message}");

        //     }
        //     lineId++;
        // }


        [HttpPost("messages")]
        public async Task Post(ChatMessage message)
        {
            // run some logic...
            _logger.Log(LogLevel.Information, "Starting...");



            await _chatHub.Clients.All.ReceiveMessage(message);
        }
    }
}
