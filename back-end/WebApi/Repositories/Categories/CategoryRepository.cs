using MySql.Data.MySqlClient;
using WebApi.Constants;
using WebApi.Models;

namespace WebApi.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;

    public CategoryRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString(Configs.CONNECTION_STRING) ?? "";
    }

    public Category Create(Category category)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "INSERT INTO categories(name, description, image) VALUES (@name, @description, @image)";
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.AddWithValue("@description", category.Description);
                command.Parameters.AddWithValue("@image", category.Image);

                try
                {
                    command.ExecuteNonQuery();
                    category.Id = Convert.ToInt32(command.LastInsertedId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            connection.Close();
        }

        return category;
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
                command.CommandText = "UPDATE categories SET status=0 WHERE id=@id";
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

    public List<Category> GetAll()
    {
        List<Category> categories = new List<Category>();

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "SELECT id, name, image, description, status FROM categories";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString() ?? string.Empty,
                        Image = reader[2].ToString() ?? string.Empty,
                        Description = reader[3].ToString() ?? string.Empty,
                        Status = Convert.ToBoolean(reader[4]),
                    });
                }
            }

            connection.Close();
        }

        return categories;
    }

    public Category? GetById(int Id)
    {
        Category? category = null;

        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "SELECT id, name, image, description, status FROM users WHERE id=@id";
                command.Parameters.AddWithValue("@id", Id);

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString() ?? string.Empty,
                        Image = reader[2].ToString() ?? string.Empty,
                        Description = reader[3].ToString() ?? string.Empty,
                        Status = Convert.ToBoolean(reader[4]),
                    };

                    break;
                }
            }

            connection.Close();
        }

        return category;
    }

    public Category Update(Category category)
    {
        using (MySqlConnection connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (MySqlCommand command = new MySqlCommand
            {
                Connection = connection
            })
            {
                command.CommandText = "UPDATE categories SET name=@name, image=@image, description=@description, status=@status WHERE id=@id";
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.AddWithValue("@image", category.Image);
                command.Parameters.AddWithValue("@description", category.Description);
                command.Parameters.AddWithValue("@status", category.Status);
                command.Parameters.AddWithValue("@id", category.Id);

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

        return category;
    }
}