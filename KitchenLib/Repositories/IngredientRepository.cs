using KitchenLib.Interfaces;
using KitchenLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KitchenLib.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private string _connectionString = "Server=tcp:smartkitchenserver.database.windows.net,1433;Initial Catalog=smartkitchen-db;Persist Security Info=False;User ID=smartkitchen;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Ingredient", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Ingredient ingredient = MapReaderToIngredient(reader);
                    ingredients.Add(ingredient);
                }
            }

            return ingredients;
        }

        public async Task<Ingredient?> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Ingredient WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return MapReaderToIngredient(reader);
                }
            }

            return null;
        }

        private static Ingredient MapReaderToIngredient(SqlDataReader reader)
        {
            return new Ingredient
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString("Description"),
                ThumbnailUrl = reader.IsDBNull(reader.GetOrdinal("ThumbUrl")) ? null : reader.GetString("ThumbUrl"),
                Type = reader.IsDBNull(reader.GetOrdinal("Type")) ? null : reader.GetString("Type")
            };
        }
    }
}
