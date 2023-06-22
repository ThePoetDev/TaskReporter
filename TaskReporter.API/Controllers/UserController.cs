using Microsoft.AspNetCore.Mvc;
using TaskReporter.Business.DTO;
using TaskReporter.Business.Interfaces;
using TaskReporter.Domain.Entities;

namespace TaskReporter.Controllers;

[ApiController]
public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("UserGetById")]
    public UserDTO GetById(int id)
    {
        return _userService.GetById(id);
    }
    
    [HttpPost("UserInsert")]
    public void Insert(UserCreateDTO user)
    {
        _userService.Insert(user);
    }

    [HttpDelete("UserDelete")]
    public void Delete(int id)
    {
        _userService.Delete(id);
    }

    [HttpPut("UserUpdate")]
    public void Update(UserDTO user)
    {
        _userService.Update(user);
    }

    [HttpGet("UserGetAll")]
    public List<User> GetAll()
    {
        return _userService.GetAll();
    }
    
    
}