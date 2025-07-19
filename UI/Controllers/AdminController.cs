using domain.Dto;
using Microsoft.AspNetCore.Mvc;
using application.Interfaces;
using Microsoft.AspNetCore.Cors;
using IOC;
using application.Services;


namespace UI.Controllers;

[ApiController]
[EnableCors("policy")]
[Route("api/[controller]")]
public class AdminController : Controller
{
    private readonly ITotal _total;
    private readonly ICircle _circle;
    private readonly ILine _line;
    private readonly IUsers _users;
    private readonly IServices _services;
    private readonly IMessage _message;
    private readonly Timer _timer;
    


    public AdminController(IMessage message, ITotal total, ICircle circle, ILine line, IUsers users, IServices services)
    {
        _total = total;
        _circle = circle;
        _line = line;
        _users = users;
        _services = services;
        _message = message;
        
    }


    [HttpGet]
    [EnableCors("Policy")]
    public string HelloWorld()
    {
        return _message.GetHashCode().ToString();
    }

    [HttpPost]
    [Route("Total")]
    [EnableCors("Policy")]
    public IActionResult TotalApi(RequestDto request)
    {
        TotalResponseDto response = _total.TotalCalculate(request);
        return Ok(response);
    }
    
    [HttpGet]
    [Route("TotalPerHour")]
    [EnableCors("Policy")]
    public List<CircleResultDto> TotalPerHourApi()
    {
        List<CircleResultDto> response = _total.TotalPerHourCalculate();
        return response;
    }
    
    [HttpPost]
    [Route("Circle")]
    [EnableCors("Policy")]
    public IActionResult CircleApi(RequestDto request)
    {
        CircleResponseDto response = _circle.CircleCalculate(request);
        return Ok(response);
    }

    [HttpPost]
    [Route("Line")]
    [EnableCors("Policy")]
    public IActionResult LineApi(RequestDto request)
    {
        LineResponseDto response = _line.LineCalculate(request);
        
        return Ok(response);
    }

    [HttpGet]
    [Route("Clients")]
    [EnableCors("Policy")]
    public IActionResult GetUsers()
    {
        return Ok(_users.GetAllUsers());
    }

    [HttpGet]
    [Route("Services")]
    [EnableCors("Policy")]
    public IActionResult GetServices()
    {
        return Ok(_services.GetAllServices());
    }
    
    [HttpGet]
    [Route("DailyLogin")]
    [EnableCors("Policy")]
    public CircleResponseDto GetLogins()
    {
        return _circle.LoginCircleDailyCalculate();
    }
    
    [HttpGet]
    [Route("LogedInUsers")]
    [EnableCors("Policy")]
    public IActionResult GetLogedInUsers(int period)
    {
        return Ok(_users.GetLogedInUsers(period));
    }

    [HttpGet]
    [Route("NotLogedInUsers")]
    [EnableCors("Policy")]
    public IActionResult GetNotLogedInUsers(int period)
    {
        return Ok(_users.GetNotLogedInUsers(period));
    }

    [HttpGet]
    [Route("SendMessage")]
    public void SendMessage()
    {
        _message.SendMessage();
    }
}
