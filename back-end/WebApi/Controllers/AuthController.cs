using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Services.Users;

namespace WebApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Login")]
    public IResult Login([FromBody] LoginRequest loginRequest)
    {
        LoginResponse resp = _userService.Login(loginRequest.Email, loginRequest.Password);

        return Results.Ok(resp);
    }

    [HttpPost("Register")]
    public IResult Register([FromBody] RegisterRequest registerRequest)
    {
        RegisterResponse resp = _userService.Register(registerRequest.Name, registerRequest.Email, registerRequest.Password);

        return Results.Ok(resp);
    }
}