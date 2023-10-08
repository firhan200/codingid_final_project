using WebApi.Constants;
using WebApi.Dto;
using WebApi.Models;
using WebApi.Repositories.Users;
using WebApi.Services.Password;

namespace WebApi.Services.Users;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;

    public UserService(IUserRepository userRepository, IPasswordService passwordService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public LoginResponse Login(string email, string password)
    {
        LoginResponse model = new LoginResponse();

        _userRepository.GetByEmailAndPassword(email, password);

        model.Token = "thisisgeneratedtoken";

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

        return model;
    }
}