using System.Threading.Tasks;
using Chatty.Api.Models;

namespace Chatty.Api.Hubs.Clients
{
    public interface IChatClient
    {
        //Task InvokeAsync(string v);
        Task ReceiveMessage(ChatMessage message);
    }

}