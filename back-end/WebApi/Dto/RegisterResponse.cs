namespace WebApi.Dto;

public record RegisterResponse
{
    public string? Error { get; set; }
    public UserInformation? User { get; set; }
}