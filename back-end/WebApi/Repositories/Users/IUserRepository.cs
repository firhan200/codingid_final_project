using WebApi.Models;

namespace WebApi.Repositories.Users;

public interface IUserRepository {
    List<User> GetAll();
    User? GetByEmailAndPassword(string email, string password);
    User? GetById(int Id);
    User Create(User user);
    User Update(User user);
    bool Delete(int Id);
}