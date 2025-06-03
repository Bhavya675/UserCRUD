using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Internal.Postgres;
using UserManagement.Common.Validators;
using UserManagement.Entities;
using UserManagement.Interfaces;
using UserManagement.Models.DTO.Request;
// using UserManagement.Models;

namespace UserManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService _userService, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    // [Authorize(Roles = "admin")]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _userService.GetAllUsersAsync();
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("{id}")]
    // [Authorize(Roles = "admin")]

    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user != null ? Ok(user) : NotFound();
    }

    [HttpPost("add-user")]
    // [Authorize(Roles = "admin")]
    public async Task<IActionResult> AddUser(UserDTO requestObject)
    {
        var validator = new UserValidator();
        var validationResult = validator.Validate(requestObject);
        if (validationResult.IsValid)
        {
            var user = _mapper.Map<User>(requestObject);
            var result = await _userService.AddUserAsync(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        else
        {
            return new BadRequestObjectResult(validationResult.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            }));
        }
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "user,admin")]

    public async Task<IActionResult> UpdateUser(int id, UserDTO requestObject)
    {
        var validator = new UserValidator();
        var validationResult = validator.Validate(requestObject);
        if (validationResult.IsValid)
        {
            var user = _mapper.Map<User>(requestObject);
            var result = await _userService.UpdateUserAsync(id, user);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }
        else
        {
            return new BadRequestObjectResult(validationResult.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            }));
        }
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await _userService.DeleteUserAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO requestObject)
    {
        var validator = new LoginValidator();
        var validationResult = validator.Validate(requestObject);
        if (validationResult.IsValid)
        {
            var result = await _userService.Login(requestObject);
            return result != null ? Ok(result) : Unauthorized();
        }
        else
        {
            return new BadRequestObjectResult(validationResult.Errors.Select(e => new
            {
                Field = e.PropertyName,
                Error = e.ErrorMessage
            }));
        }
    }
}
