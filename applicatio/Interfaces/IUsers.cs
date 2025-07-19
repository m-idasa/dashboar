using domain.Dto;
using domain.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces;

public interface IUsers
{
    public List<UserDto> GetAllUsers();
    public Task<UserDto> GetUserAsync(int UserId);

    public List<LoginDto> GetLogedInUsers(int period);
    public List<LoginDto> GetNotLogedInUsers(int period);
}
