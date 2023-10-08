using WebApi.Models;

namespace WebApi.Repositories.Categories;

public interface ICategoryRepository {
    List<Category> GetAll();
    Category? GetById(int Id);
    Category Create(Category category);
    Category Update(Category category);
    bool Delete(int Id);
}