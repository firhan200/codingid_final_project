using WebApi.Constants;
using WebApi.Dto;
using WebApi.Models;
using WebApi.Repositories.Users;
using WebApi.Services.Password;
using WebApi.Services.Token;

namespace WebApi.Services.Users;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, IPasswordService passwordService, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }

    public LoginResponse Login(string email, string password)
    {
        LoginResponse model = new LoginResponse();

        //validate
        if(string.IsNullOrEmpty(email)){
            model.Error = "Email cannot be empty";
            return model;
        }
        if(string.IsNullOrEmpty(password)){
            model.Error = "Password cannot be empty";
            return model;
        }

        //encrypt password
        password = _passwordService.HashPassword(password);

        User? user = _userRepository.GetByEmailAndPassword(email, password);
        if(user == null){
            model.Error = "User not found";
            return model;
        }

        model.User = new UserInformation{
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Role = user.Role
        };

        model.Token = _tokenService.GenerateJWT(user.Id, user.Role);
        return model;
    }

    public RegisterResponse Register(string name, string email, string password)
    {
        RegisterResponse model = new RegisterResponse();

        //validate
        if(string.IsNullOrEmpty(name)){
            model.Error = "Name cannot be empty";
            return model;
        }
        if(string.IsNullOrEmpty(email)){
            model.Error = "Email cannot be empty";
            return model;
        }
        if(string.IsNullOrEmpty(password)){
            model.Error = "Password cannot be empty";
            return model;
        }

        //check if email already taken
        User? existedUser = _userRepository.GetByEmail(email);
        if(existedUser != null){
            model.Error = "Email already taken";
            return model;
        }

        //encrypt password
        password = _passwordService.HashPassword(password);

        User? user = _userRepository.Create(new Models.User{
            Name = name,
            Email = email,
            Password = password,
            Role = Roles.USER
        });

        if(user == null){
            model.Error = "failed to create user";
            return model;
        }

        model.User = new UserInformation{
            Id = user.Id,
            Email = user.Email,
            Name = user.Name,
            Role = user.Role
        };
        return model;
    }
}