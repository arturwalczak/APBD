using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using Task04.Models;
using System.Linq;
using System.Configuration.Abstractions;

namespace Task04.Services
{
    public class DBService : IDBService
    {
        private IConfiguration _configuration;
        public DBService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ChangeAnimal(int idAnimal, Animal animal)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Animal SET Name = @name, Description = @description, Category = @category, Area = @area WHERE idAnimal = @idAnimal";
                    command.Parameters.AddWithValue("name", animal.Name);
                    command.Parameters.AddWithValue("description", animal.Description);
                    command.Parameters.AddWithValue("category", animal.Category);
                    command.Parameters.AddWithValue("area", animal.Area);
                    command.Parameters.AddWithValue("idAnimal", idAnimal);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void CreateAnimal(Animal animal)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO Animal(Name, Description, Category, Area) VALUES(@name, @description, @category, @area)";
                    command.Parameters.AddWithValue("name", animal.Name);
                    command.Parameters.AddWithValue("description", animal.Description);
                    command.Parameters.AddWithValue("category", animal.Category);
                    command.Parameters.AddWithValue("area", animal.Area);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void DeleteAnimal(int idAnimal)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"DELETE FROM Animal WHERE IdAnimal = {idAnimal}";                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Animal> GetAnimals(string orderBy)
        {
            List<Animal> animals = new List<Animal>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;                    
                    string[] columnNames = { "name", "description", "category", "area" };
                    if (columnNames.Contains(orderBy)){
                        command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";
                    }
                    else if(orderBy == null)
                    {
                        command.CommandText = "SELECT * FROM Animal ORDER BY Name ASC";
                    }else
                    {
                        throw new System.Exception("provided column name does not match existing columns");
                    }
                    connection.Open();

                    using (var dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            animals.Add(new Animal
                            {
                                IdAnimal = int.Parse(dr["IdAnimal"].ToString()),
                                Name = dr["Name"].ToString(),
                                Description = dr["Description"].ToString(),
                                Category = dr["Category"].ToString(),
                                Area = dr["Area"].ToString()
                            });
                        }
                    }                                        
                }
                
            }
            return animals;
        }
    }
}
