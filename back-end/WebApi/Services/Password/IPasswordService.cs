namespace WebApi.Services.Password;

public interface IPasswordService {
    string HashPassword(string rawPassword);
}