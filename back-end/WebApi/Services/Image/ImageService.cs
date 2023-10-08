namespace WebApi.Services.Image;

public class ImageService : IImageService
{
    public string SaveImage(IFormFile? image)
    {
        if(image == null){
            return string.Empty;
        }

        //set path
        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        string imagePath = "images";
        string fullUploadPath = Path.Combine(uploadPath, imagePath);

        //check if dir already exist
        if(!Directory.Exists(fullUploadPath)){
            Directory.CreateDirectory(fullUploadPath);
        }

        //set filename
        string fileName = DateTime.UtcNow.ToString("HH:mm:ss_dd-MM-yyyy");
        string ext = ".png";

        string fullPath = Path.Combine(fullUploadPath, fileName + ext);

        using (Stream fileStream = new FileStream(fullPath, FileMode.Create))
        {
            image.CopyToAsync(fileStream);
        }

        return Path.Combine(imagePath, fileName + ext);
    }
}