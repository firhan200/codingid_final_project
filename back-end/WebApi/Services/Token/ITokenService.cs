namespace WebApi.Services.Token;

public interface ITokenService {
    string GenerateJWT(int userId, string role);
}