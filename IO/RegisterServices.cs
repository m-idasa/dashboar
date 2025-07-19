using Microsoft.Extensions.DependencyInjection;
using application.Interfaces;
using application.Services;

namespace IOC;

public static class RegisterServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<ITotal, TotalService>();
        services.AddScoped<ICircle, CircleService>();
        services.AddScoped<ILine, LineService>();
        services.AddScoped<IUsers, UsersService>();
        services.AddScoped<IServices, ServicesService>();
        services.AddScoped<IMessage, MessageService>();
    }
}
