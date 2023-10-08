using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Services.Image;

namespace WebApi.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class ImageController : ControllerBase {
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost(Name = "Upload Image")]
    public IResult Upload([FromForm] UploadImageRequest uploadImageRequest){
        UploadImageResponse res = new UploadImageResponse();

        string imagePath = _imageService.SaveImage(uploadImageRequest.Image);
        if(string.IsNullOrEmpty(imagePath)){
            res.Error = "Failed to upload image";
            return Results.BadRequest(res);
        }
        
        res.ImagePath = imagePath;
        return Results.Ok(res);
    }
}