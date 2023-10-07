namespace WebApi.Dto;

public record LoginResponse
{
    public string? Error { get; set; }
    public string? Token { get; set; } = null;
    public string? Role { get; set; }
}