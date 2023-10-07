using WebApi.Dto;
using WebApi.Repositories.Users;

namespace WebApi.Services.Users;

public class UserService : IUserService {
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        _userRepository.Create(new Models.User{
            Name = name,
            Email = email,
            Password = password
        });

        return model;
    }
}