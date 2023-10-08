using WebApi.Models;
using WebApi.Repositories.Categories;

namespace WebApi.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public bool Create(string name, string imagePath, string description)
    {
        var resp = _categoryRepository.Create(new Category{
            Name = name,
            Image = imagePath,
            Description = description
        });

        bool isSuccess = resp.Id > 0;

        return isSuccess;
    }

    public bool Delete(int Id)
    {
        return _categoryRepository.Delete(Id);
    }

    public List<Category> GetAll()
    {
        return _categoryRepository.GetAll();
    }

    public bool Update(int Id, string name, string imagePath, string description, bool status)
    {
        Category? category = _categoryRepository.GetById(Id);
        if(category == null){
            return false;
        }

        category.Name = name;
        category.Image = imagePath;
        category.Description = description;
        category.Status = status;
        var resp = _categoryRepository.Update(category);

        bool isSuccess = resp.Id > 0;

        return isSuccess;
    }
}