using application.Interfaces;
using domain.Dto;
using infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace application.Services;

public class LineService: ILine
{
    private readonly AppDBContext _dbContext;
    public LineService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public LineResponseDto LineCalculate(RequestDto request)
    {
    
        LineResponseDto response = new();

        var from = new SqlParameter("@from", request.From);
        var to = new SqlParameter("@to", request.To);
        var period = new SqlParameter("@period", request.TimePeriod);
        List<string> names = new List<string>();
        List<LineResultDto> lineResults = new List<LineResultDto>();
        if ((request.Services.Count > 1 || request.Services.Contains("-1")) && request.Clients.Count == 1)
        {
            var client = new SqlParameter("@client", String.Join(",", request.Clients));
            var services = new SqlParameter("@services", String.Join(",", request.Services));
            try
            {
                lineResults = (List<LineResultDto>)_dbContext.Database.SqlQuery<LineResultDto>($"dbo.ClientLine {client}, {services}, {from}, {to}, {period}").ToList();
                response.Client = request.Clients[0];
                names = request.Services;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        else if ((request.Clients.Count > 1 || request.Clients.Contains("-1")) && request.Services.Count == 1)
        {
            var service = new SqlParameter("@service", String.Join(",", request.Services));
            var clients = new SqlParameter("@clients", String.Join(",", request.Clients));
            try { 
                lineResults = (List<LineResultDto>)_dbContext.Database.SqlQuery<LineResultDto>($"dbo.ServiceLine {service}, {clients}, {from}, {to}, {period}").ToList();
                response.Service = request.Services[0];
                names = request.Clients;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        else
            return null;

        //List<DateTime> Dates = [];
        //List<LineResultDto> Results = [];
        //foreach (LineResultDto result in lineResults)
        //{
        //    if (!Dates.Contains(result.DFrom))
        //        Dates.Add(result.DFrom);

        //    if (result.RName is not null)
        //    {
        //        Results.Add(new LineResultDto
        //        {
        //            RName = result.RName,
        //            DFrom = result.DFrom
        //        });
        //    }

        //}
        //LineResultDto tmp = new();
        //foreach (DateTime date in Dates)
        //{
        //    foreach (string n in names)
        //    {
        //        tmp.RName = n;
        //        tmp.DFrom = date;
        //        if (!Results.Contains(tmp))
        //        {
        //            tmp.RCount = 0;
        //            lineResults.Add(tmp);
        //            tmp = new();
        //        }
        //    }
        //}
        //response.Results = [];

        //foreach (LineResultDto lineResultDto in lineResults)
        //{
        //    if (lineResultDto.RName is not null)    
        //        response.Results.Add(lineResultDto);
        //}
        response.Results = lineResults;
        return response;
    }
}