using MySql.Data.MySqlClient;
using WebApi.Constants;
using WebApi.Models;

namespace WebApi.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;

    public UserRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString(Configs.CONNECTION_STRING) ?? "";
    }

    public User Create(User user)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using(MySqlCommand command = new MySqlCommand{
                Connection = connection
            }){
                command.CommandText = "INSERT INTO users(name, email, password, role) VALUES (@name, @email, @password, @role)";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@role", user.Role);

                try{
                    command.ExecuteNonQuery();
                }catch(Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }

            connection.Close();
        }

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
        Console.WriteLine("GetByEmailAndPassword: " + email + " and " + password);

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