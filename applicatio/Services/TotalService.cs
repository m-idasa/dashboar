using application.Interfaces;
using domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tsetmc.Base.Extention;
using domain.Table;

namespace application.Services;

public class TotalService : ITotal
{
    private readonly AppDBContext _dbContext;
    public TotalService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public TotalResponseDto TotalCalculate(RequestDto request) {
        
        var totalRequest = new SqlParameter()
        {
            ParameterName = "total",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Output
        };
        var totalResponse = new SqlParameter()
        {
            ParameterName = "total",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Output
        };

        var averageWaitingTime = new SqlParameter()
        {
            ParameterName = "total",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Output
        };

        var clients = new SqlParameter("@clients", String.Join(",", request.Clients));
        var services = new SqlParameter("@services", String.Join(",", request.Services));
        var from = new SqlParameter("@from", request.From);
        var to = new SqlParameter("@to", request.To);
        try
        {
            _dbContext.Database.ExecuteSqlRaw("dbo.Total_Request @clients, @services, @from, @to, @total OUTPUT",
            clients, services, from, to, totalRequest);

            _dbContext.Database.ExecuteSqlRaw("dbo.Total_Response @clients, @services, @from, @to, @total OUTPUT",
            clients, services, from, to, totalResponse);

            _dbContext.Database.ExecuteSqlRaw("dbo.AverageWaitingTime @clients, @services, @from, @to, @total OUTPUT",
            clients, services, from, to, averageWaitingTime);
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
            
            return null;

        }

        if (averageWaitingTime.Value is System.DBNull)
            averageWaitingTime.Value = 0;
        TotalResponseDto response = new TotalResponseDto();
        response.TotalRequest = (int)totalRequest.Value;
        response.TotalResponse = (int)totalResponse.Value;
        response.AverageWaitingTime = TimeSpan.FromMilliseconds((int)averageWaitingTime.Value).ToString(@"hh\:mm\:ss\.fff");
        return response;
    }

    public List<CircleResultDto> TotalPerHourCalculate()
    {
        try
        {

            List<CircleResultDto> result = (List<CircleResultDto>)_dbContext.Database.SqlQuery<CircleResultDto>($"dbo.Total_Request_Hour").ToList();

            return result;

        } catch ( Exception e)
        {
            Console.WriteLine(e.Message);

            return null;
        }
    }
}
