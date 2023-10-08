namespace WebApi.Services.Image;

public interface IImageService {
    string SaveImage(IFormFile? image); //return path
}