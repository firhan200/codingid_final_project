using System.Security.Cryptography;
using System.Text;

namespace WebApi.Services.Password;

public class PasswordService : IPasswordService
{
    public string HashPassword(string rawPassword)
    {
        using var sha1 = SHA1.Create();
        return Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(rawPassword)));
    }
}