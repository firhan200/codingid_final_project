namespace WebApi.Dto;

public record UploadImageRequest
{
    public IFormFile? Image { get; set; }
}