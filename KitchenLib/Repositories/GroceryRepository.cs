using KitchenLib.Interfaces;
using KitchenLib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KitchenLib.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {
        private string _connectionString;

        public GroceryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Always call inside a try-catch
        public async Task<Grocery> AddAsync(Grocery grocery)
        {
            ArgumentNullException.ThrowIfNull(grocery);
            if (grocery.Name == null) throw new ArgumentException("Name can't be null");
            if (grocery.Quantity < 1) throw new ArgumentOutOfRangeException("Quantity must be at least 1");

            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(@"INSERT INTO Grocery (Barcode, Name, Quantity, Ingredient, Category)
                    VALUES (@Barcode, @Name, @Quantity, @Ingredient, @Category)
                    SELECT CAST(SCOPE_IDENTITY() AS INT)", connection);
                command.Parameters.AddWithValue("@Barcode", (string.IsNullOrWhiteSpace(grocery.Barcode) ? DBNull.Value: grocery.Barcode));
                command.Parameters.AddWithValue("@Name", grocery.Name);
                command.Parameters.AddWithValue("@Quantity", grocery.Quantity);
                command.Parameters.AddWithValue("@Ingredient", (string.IsNullOrWhiteSpace(grocery.Ingredient) ? DBNull.Value : grocery.Ingredient));
                command.Parameters.AddWithValue("@Category", (string.IsNullOrWhiteSpace(grocery.Category) ? DBNull.Value : grocery.Category));

                var result = await command.ExecuteScalarAsync();
                grocery.Id = Convert.ToInt32(result);

                return grocery;
            }
        }

        public Task<Grocery?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Grocery>> GetAllAsync()
        {
            List<Grocery> groceries = new List<Grocery>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(@"SELECT * FROM Grocery", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    groceries.Add(GroceryReader(reader));
                }

            }
            return groceries;
        }

        public Task<Grocery?> GetByBarcodeAsync(string barcode)
        {
            throw new NotImplementedException();
        }

        public Task<Grocery?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Grocery?> UpdateAsync(int id, Grocery grocery)
        {
            throw new NotImplementedException();
        }

        private Grocery GroceryReader(SqlDataReader reader)
        {
            Grocery grocery = new Grocery
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Barcode = reader.IsDBNull("Barcode") ? null : reader.GetString("Barcode"),
                Quantity = reader.GetInt32("Quantity"),
                Ingredient = reader.IsDBNull("Ingredient") ? null : reader.GetString("Ingredient"),
                Category = reader.IsDBNull("Category") ? null : reader.GetString("Category")
            };
            return grocery;
        }
    }
}
