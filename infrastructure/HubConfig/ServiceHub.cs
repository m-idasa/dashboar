using Microsoft.AspNetCore.SignalR;


namespace infrastructure.HubConfig;


public class ServiceHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
