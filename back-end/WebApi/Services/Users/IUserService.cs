using WebApi.Dto;

namespace WebApi.Services.Users;

public interface IUserService {
    LoginResponse Login(string email, string password);
    RegisterResponse Register(string name, string email, string password);
}