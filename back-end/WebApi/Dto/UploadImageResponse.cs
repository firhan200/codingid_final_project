namespace WebApi.Dto;

public record UploadImageResponse
{
    public string? Error { get; set; }
    public string? ImagePath { get; set; }
}