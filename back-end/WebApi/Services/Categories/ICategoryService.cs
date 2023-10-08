using WebApi.Models;

namespace WebApi.Services.Categories;

public interface ICategoryService {
    List<Category> GetAll();
    bool Create(string name, string imagePath, string description);
    bool Update(int Id, string name, string imagePath, string description, bool status);
    bool Delete(int Id);
}