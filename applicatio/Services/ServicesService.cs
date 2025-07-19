using application.Interfaces;
using domain.Dto;
using infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Services;

public class ServicesService: IServices
{
    private readonly AppDBContext _dbContext;
    public ServicesService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<AServiceDto> GetAllServices()
    {
        
        try
        {
            var AServicesList = _dbContext.AServices.ToList();

            List<AServiceDto> Services = AServicesList.Select(t => new AServiceDto { ServiceName = t.ServiceName, ServiceDesc = t.ServiceDesc }).ToList();

            return Services;

        } catch
        {
            return null;
        }

    }

    public async Task<AServiceDto> GetServiceAsync(string ServiceName)
    {
        var user = await _dbContext.AServices.FindAsync(ServiceName);

        if (user is null)
        {
            return null;
        }

        var serviceDto = new AServiceDto
        {
            ServiceName = user.ServiceDesc,
            ServiceDesc = user.ServiceDesc
        };

        return serviceDto;
    }

}
