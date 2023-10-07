using WebApi.Models;

namespace WebApi.Repositories.Users;

public class UserRepository : IUserRepository
{
    public User Create(User user)
    {
        Console.WriteLine("Create: "+user.Email);

        return user;
    }

    public bool Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User? GetByEmailAndPassword(string email, string password)
    {
        Console.WriteLine("GetByEmailAndPassword: "+email+" and "+password);

        return null;
    }

    public User? GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }
}