using Microsoft.AspNetCore.SignalR;
using PointOfSale.Api.Models;

namespace PointOfSale.Api.SignalR
{
    public class OrderHub : Hub
    {
        public async Task SendMessage(M_MessageOrder message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
