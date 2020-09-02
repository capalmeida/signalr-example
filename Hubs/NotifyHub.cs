using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

public class NotifyHub : Hub
{
    // Going to be called from the client side (vue)
    public async Task AddTask(object taskItem)
    {
        // Kinda like a callback or event
        await Clients.All.SendAsync("AddedTask", taskItem);
    }
}