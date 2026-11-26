using KitchenLib.Interfaces;
using KitchenLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KitchenLib.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private string _connectionString = "Server=tcp:smartkitchenserver.database.windows.net,1433;Initial Catalog=smartkitchen-db;Persist Security Info=False;User ID=smartkitchen;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            List<Recipe> recipes = new List<Recipe>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Recipe", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Recipe recipe = MapReaderToRecipe(reader);
                    recipes.Add(recipe);
                }
            }
            return recipes;
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SELECT * FROM Recipe WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    return MapReaderToRecipe(reader);
                }
            }
            return null;
        }

        private Recipe MapReaderToRecipe(SqlDataReader reader)
        {
            List<string> ingredientStrings = new List<string>();
            List<string> measures = new List<string>();
            for (int i = 1; i <= 20; i++)
            {
                string ingredientColumnName = $"strIngredient{i}";
                string measureColumnName = $"strMeasure{i}";

                if (!reader.IsDBNull(reader.GetOrdinal(ingredientColumnName)))
                {
                    string ingredient = reader.GetString(ingredientColumnName);
                    ingredientStrings.Add(ingredient);
                }

                if (!reader.IsDBNull(reader.GetOrdinal(measureColumnName)))
                {
                    string measure = reader.GetString(measureColumnName);
                    measures.Add(measure);
                }
            }

            return new Recipe
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                AlternateName = reader.IsDBNull(reader.GetOrdinal("AlternateName")) ? null : reader.GetString("AlternateName"),
                Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? null : reader.GetString("Category"),
                Area = reader.IsDBNull(reader.GetOrdinal("Area")) ? null : reader.GetString("Area"),
                Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : reader.GetString("Country"),
                Instructions = reader.IsDBNull(reader.GetOrdinal("Instructions")) ? null : reader.GetString("Instructions"),
                ThumbnailUrl = reader.IsDBNull(reader.GetOrdinal("ThumbUrl")) ? null : reader.GetString("ThumbUrl"),
                Tags = reader.IsDBNull(reader.GetOrdinal("Tags")) ? null : reader.GetString("Tags"),
                YoutubeUrl = reader.IsDBNull(reader.GetOrdinal("YoutubeUrl")) ? null : reader.GetString("YoutubeUrl"),
                IngredientStrings = ingredientStrings,
                Measures = measures
            };
        }
    }
}
