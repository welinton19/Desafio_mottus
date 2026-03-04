using Microsoft.AspNetCore.Mvc;
using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;
using MottuDesafio.Domain.Entities;

namespace Desafio_Back_End.Net.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public UserController(ILogger<UserController> logger, IUserService userService, ITokenService tokenService)
    {
        _logger = logger;
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDTO userRegisterDto)
    {
        var result = await _userService.CreateUserAsync(userRegisterDto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO user) 
    {
        var authenticatedUser = await _userService.ValidateUserLogin(user.Name!, user.Password);
        if (authenticatedUser == null)
            return BadRequest("Invalid username or password.");
        var token = _tokenService.GenereteUserToken(authenticatedUser);
        return Ok(token);
    }
}

public class LoginDTO
{
  public string? Name { get; set; }
  public string? Password { get; set; }
}

