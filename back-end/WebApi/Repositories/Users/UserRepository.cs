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

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "INSERT INTO users(name, email, password, role) VALUES (@name, @email, @password, @role)";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@role", user.Role);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            connection.Close();
        }

        return user;
    }

    public bool Delete(int Id)
    {
        bool isSuccess = false;

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "UPDATE users SET status=0 WHERE id=@id";
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    command.ExecuteNonQuery();
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            connection.Close();
        }

        return isSuccess;
    }

    public List<User> GetAll()
    {
        List<User> users = new List<User>();

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "SELECT id, name, email, status FROM users";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString() ?? string.Empty,
                        Email = reader[2].ToString() ?? string.Empty,
                        Status = Convert.ToBoolean(reader[3]),
                    });
                }
            }

            connection.Close();
        }

        return users;
    }

    public User? GetByEmail(string email)
    {
        User? user = null;

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "SELECT id, name, email, role FROM users WHERE email=@email";
                command.Parameters.AddWithValue("@email", email);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString() ?? string.Empty,
                        Email = reader[2].ToString() ?? string.Empty,
                        Role = reader[3].ToString() ?? string.Empty,
                    };

                    break;
                }
            }

            connection.Close();
        }

        return user;
    }

    public User? GetByEmailAndPassword(string email, string password)
    {
        User? user = null;

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "SELECT id, name, email, role FROM users WHERE email=@email AND password=@password";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString() ?? string.Empty,
                        Email = reader[2].ToString() ?? string.Empty,
                        Role = reader[3].ToString() ?? string.Empty,
                    };

                    break;
                }
            }

            connection.Close();
        }

        return user;
    }

    public User? GetById(int Id)
    {
        User? user = null;

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "SELECT id, name, email, role, status FROM users WHERE id=@id";
                command.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString() ?? string.Empty,
                        Email = reader[2].ToString() ?? string.Empty,
                        Role = reader[3].ToString() ?? string.Empty,
                    };

                    break;
                }
            }

            connection.Close();
        }

        return user;
    }

    public User Update(User user)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "UPDATE users SET name=@name, status=@status WHERE id=@id";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@role", user.Status);
                command.Parameters.AddWithValue("@id", user.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            connection.Close();
        }

        return user;
    }
}