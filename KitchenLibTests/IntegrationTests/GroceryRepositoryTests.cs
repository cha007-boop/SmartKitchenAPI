using KitchenLib.Interfaces;
using KitchenLib.Models;
using KitchenLib.Repositories;
using Microsoft.Data.SqlClient;

namespace KitchenLibTests.IntegrationTests
{
    [DoNotParallelize]
    [TestClass]
    public sealed class GroceryRepositoryTests
    {
        private IGroceryRepository _groceryRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            string connectionString = "Server=tcp:smartkitchenserver.database.windows.net,1433;Initial Catalog=test-db;Persist Security Info=False;User ID=smartkitchen;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            _groceryRepository = new GroceryRepository(connectionString);

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand(
                "DELETE FROM Grocery", connection);

            command.ExecuteNonQuery();
        }
        [TestMethod]
        public async Task Add_ValidGrocery_SuccessfullyAddsGroceryToDatabaseAsync()
        {
            // Arrange 
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = "Arla Milk 1l",
                Barcode = "123444211",
                Quantity = 1,
                Ingredient = "Milk",
                Category = "Dairy"
            };

            int countBefore = (await _groceryRepository.GetAllAsync()).Count();

            // Act
            grocery.Id = (await _groceryRepository.AddAsync(grocery)).Id;

            // Assert
            Grocery groceryFromDb = (await _groceryRepository.GetAllAsync()).FirstOrDefault();

            Assert.AreEqual(grocery.Barcode, groceryFromDb.Barcode);
            Assert.AreEqual(grocery.Name, groceryFromDb.Name);
            Assert.AreEqual(grocery.Quantity, groceryFromDb.Quantity);
            Assert.AreEqual(grocery.Ingredient, groceryFromDb.Ingredient);
            Assert.AreEqual(grocery.Category, groceryFromDb.Category);
        }

        [TestMethod]
        public async Task Add_ValidGroceryWithIngredientOrCategoryNull_SuccessfullyAddsGroceryToDatabaseAsync()
        {
            // Arrange 
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = "Arla Milk 1l",
                Barcode = "123444211",
                Quantity = 1,
                Ingredient = null,
                Category = null
            };

            int countBefore = (await _groceryRepository.GetAllAsync()).Count();

            // Act
            grocery.Id = (await _groceryRepository.AddAsync(grocery)).Id;

            // Assert
            Grocery groceryFromDb = (await _groceryRepository.GetAllAsync()).FirstOrDefault();

            Assert.AreEqual(grocery.Barcode, groceryFromDb.Barcode);
            Assert.AreEqual(grocery.Name, groceryFromDb.Name);
            Assert.AreEqual(grocery.Quantity, groceryFromDb.Quantity);
            Assert.IsNull(groceryFromDb.Ingredient);
            Assert.IsNull(groceryFromDb.Category);
        }

        [TestMethod]
        public async Task Add_NameNull_ThrowsArgumentException()
        {
            // Arrange 
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = null,
                Barcode = "123444211",
                Quantity = 1,
                Ingredient = "Milk",
                Category = "Dairy"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await _groceryRepository.AddAsync(grocery));

            
        }

        [TestMethod]
        public async Task Add_GroceryNull_ThrowsArgumentNullException()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _groceryRepository.AddAsync(null));
        }

        [TestMethod]
        public async Task Add_QuantityLessThan1_ThrowsException()
        {
            // Arrange 
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = "Milk",
                Barcode = "123444211",
                Quantity = -1,
                Ingredient = "Milk",
                Category = "Dairy"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await _groceryRepository.AddAsync(grocery));
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsEmptyCollectionWhenNoGroceryInDatabase()
        {
            // Arrange
            int expectedCount = 0;

            // Act
            var groceries = await _groceryRepository.GetAllAsync();

            // Assert
            Assert.HasCount(expectedCount, groceries);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsAddedGroceries()
        {
            // Arrange
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = "Milk",
                Barcode = "123444211",
                Quantity = 1,
                Ingredient = "Milk",
                Category = "Dairy"
            };
            int countBefore = (await _groceryRepository.GetAllAsync()).ToList().Count;

            await _groceryRepository.AddAsync(grocery);
            
            // Act
            var groceries = await _groceryRepository.GetAllAsync();

            // Assert
            Assert.HasCount(countBefore + 1, groceries);
        }
        [TestMethod]
        public async Task GetByIdAsync_ExistingId_GetsSuccessfully()
        {
            // Arrange
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = "Milk",
                Barcode = "123444211",
                Quantity = 1,
                Ingredient = "Milk",
                Category = "Dairy"
            };

            grocery.Id = (await _groceryRepository.AddAsync(grocery)).Id;

            // Act
            Grocery? foundGrocery = await _groceryRepository.GetByIdAsync(grocery.Id);

            // Assert
            Assert.IsNotNull(foundGrocery);
            Assert.AreEqual(grocery.Barcode, foundGrocery.Barcode);
            Assert.AreEqual(grocery.Name, foundGrocery.Name);
            Assert.AreEqual(grocery.Quantity, foundGrocery.Quantity);
            Assert.AreEqual(grocery.Ingredient, foundGrocery.Ingredient);
            Assert.AreEqual(grocery.Category, foundGrocery.Category);

        }

        [TestMethod]
        public async Task GetByIdAsync_NonExistentId_ReturnsNull()
        {
            // Act
            Grocery? foundGrocery = await _groceryRepository.GetByIdAsync(0);

            // Assert
            Assert.IsNull(foundGrocery);
        }
        [TestMethod]
        public async Task GetByBarcode_ExistingBarcode_GetsSuccessfully()
        {
            // Arrange
            Grocery grocery = new Grocery
            {
                Id = 1,
                Name = "Milk",
                Barcode = "123444211",
                Quantity = 1,
                Ingredient = "Milk",
                Category = "Dairy"
            };

            _groceryRepository.AddAsync(grocery);

            // Act
            Grocery? foundGrocery = await _groceryRepository.GetByBarcodeAsync(grocery.Barcode);

            // Assert
            Assert.IsNotNull(foundGrocery);
            Assert.AreEqual(grocery.Barcode, foundGrocery.Barcode);
            Assert.AreEqual(grocery.Name, foundGrocery.Name);
            Assert.AreEqual(grocery.Quantity, foundGrocery.Quantity);
            Assert.AreEqual(grocery.Ingredient, foundGrocery.Ingredient);
            Assert.AreEqual(grocery.Category, foundGrocery.Category);

        }
        [TestMethod]
        public async Task GetByBarcodeAsync_NonExistentBarcode_ReturnsNull()
        {
            // Act
            Grocery? foundGrocery = await _groceryRepository.GetByBarcodeAsync("0");

            // Assert
            Assert.IsNull(foundGrocery);
        }




    }
}
