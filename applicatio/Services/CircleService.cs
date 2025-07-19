using application.Interfaces;
using Azure.Core;
using domain.Dto;
using infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace application.Services;


public class CircleService : ICircle
{
    //private readonly IServiceScopeFactory _serviceScopeFactory;

    private readonly AppDBContext _dbContext;
    
    public CircleService(AppDBContext dbContext)
    {
    
        _dbContext = dbContext;
    }

    public CircleResponseDto CircleCalculate(RequestDto request)
    {
        CircleResponseDto response = new();

        var from = new SqlParameter("@from", request.From);
        var to = new SqlParameter("@to", request.To);
        if ((request.Services.Count > 1 && request.Clients.Count == 1) || request.Services.Contains("-1"))
        {
            var client = new SqlParameter("@client", String.Join(",", request.Clients));
            var services = new SqlParameter("@services", String.Join(",", request.Services));
            try
            {
                response.Data = (List<CircleResultDto>)_dbContext.Database.SqlQuery<CircleResultDto>($"dbo.ServicePercent {client}, {services}, {from}, {to}").ToList();
                response.Client = request.Clients[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        else if ((request.Clients.Count > 1 && request.Services.Count == 1) || request.Clients.Contains("-1"))
        {
            var service = new SqlParameter("@service", String.Join(",", request.Services));
            var clients = new SqlParameter("@clients", String.Join(",", request.Clients));
            response.Data = (List<CircleResultDto>)_dbContext.Database.SqlQuery<CircleResultDto>($"dbo.ClientPercent {service}, {clients}, {from}, {to}").ToList();

            response.Service = request.Services[0];
        }
        else
            return null;

        return response;
    }

    public CircleResponseDto LoginCircleDailyCalculate()
    {
        //var scope = _serviceScopeFactory.CreateScope();

        //var _dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();

        CircleResponseDto response = new();

        var current = DateTime.Now;
        var from = new SqlParameter("@from", current.AddHours(-24).ToString("yyyy-MM-dd HH:mm:ss"));
        try
        {
            response.Data = (List<CircleResultDto>)_dbContext.Database.SqlQuery<CircleResultDto>($"dbo.LoginPercent {from}").ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return null;
        }
        response.Service = "AccountLogin";

        return response;
    }
}
