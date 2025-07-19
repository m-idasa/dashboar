using application.Interfaces;
using Azure.Core;
using domain.Dto;
using domain.Table;
using infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace application.Services;

public class UsersService: IUsers
{
    private readonly AppDBContext _dbContext;
    public UsersService(AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<UserDto> GetAllUsers()
    {
        var AspNetUsersList = _dbContext.AspNetUsers.ToList();

        List<UserDto> UserDtos = AspNetUsersList.Select(t => new UserDto { Id = t.Id, CompanyName = t.CompanyName }).ToList();

        return UserDtos;

    }
    public async Task<UserDto> GetUserAsync(int UserId)
    {
        var user = await _dbContext.AspNetUsers.FindAsync(UserId);

        if (user is null)
        {
            return null;
        }

        var userDto = new UserDto
        {
            Id = user.Id,
            CompanyName = user.CompanyName
        };

        return userDto;
    }
    public List<LoginDto> GetLogedInUsers(int period)
    {
        
        var periodParam = new SqlParameter("@to", period);

        List<LoginDto> users = _dbContext.Database.SqlQuery<LoginDto>($"dbo.LogedInUsers {periodParam}").ToList();

        if (users is null)
        {
            return null;
        }

        return users;
    }

    public List<LoginDto> GetNotLogedInUsers(int period)
    {
        var periodParam = new SqlParameter("@to", period);

        List<LoginDto> users = _dbContext.Database.SqlQuery<LoginDto>($"dbo.NotLogedInUsers {periodParam}").ToList();

        if (users is null)
        {
            return null;
        }

        return users;
    }
}
