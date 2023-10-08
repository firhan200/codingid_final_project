using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Services.Token;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJWT(int userId, string role)
    {
        //get secret jwt key
        var jwtSecretObj = _configuration.GetSection("JWT:Key");
        string secretKey = jwtSecretObj.Value ?? "";

        //init claims payload
        List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Sid, userId.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

        //set jwt config
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha512)
        );

        string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return jwtToken;
    }
}