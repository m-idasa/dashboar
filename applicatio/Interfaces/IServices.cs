using domain.Dto;

namespace application.Interfaces;

public interface IServices
{
    public List<AServiceDto> GetAllServices();
    public Task<AServiceDto> GetServiceAsync(string ServiceName);
}
