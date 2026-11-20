using KitchenLib.Repositories;
using Microsoft.Data.SqlClient;

namespace KitchenLibTests
{
    [TestClass]
    public sealed class GroceryRepositoryDBUnitTests
    {
        private IGroceryRepository _groceryRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            string connectionString = "testDbConnectionString";

            _groceryRepository = new GroceryRepositoryDB(connectionString);

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand(
                "DELETE FROM Grocery", connection);

            command.ExecuteNonQuery();
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
