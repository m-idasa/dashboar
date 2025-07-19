using application.Interfaces;
using infrastructure.HubConfig;
using Microsoft.AspNetCore.SignalR;
using Quartz;

namespace application.Services;

public class MessageService: IMessage, IJob
{
    private readonly ITotal _total;
    private readonly ICircle _circle;
    private readonly IHubContext<ServiceHub> _hubContext;

    public MessageService(ITotal total, ICircle circle, IHubContext<ServiceHub> hubContext)
    {
        _total = total;
        _circle = circle;
        _hubContext = hubContext;
    }

    public async void SendMessage()
    {

        var message = _circle.LoginCircleDailyCalculate();

        await _hubContext.Clients.All.SendAsync("ReceiveMessage", "logincircle", message);

        var result = _total.TotalPerHourCalculate();

        await _hubContext.Clients.All.SendAsync("ReceiveMessage", "totalperhour", result);

    }

    public Task Execute(IJobExecutionContext context)
    {
        SendMessage();

        Console.WriteLine("this job is working  with cron schedule");
        return Task.CompletedTask;
    }
}
