using Microsoft.Data.SqlClient;

namespace RDMicroservicesSampleApp.Lection2.ResourceCoupling
{
    public class OrderService
    {
        public void CreateOrder(int productId, int quantity)
        {
            // Логіка створення нового замовлення
            // Перевірка наявності товару в InventoryService не показана для спрощення
            using var connection = new SqlConnection("connectionString");
            string sql = "INSERT INTO Orders (ProductId, Quantity, Status) " +
                         "VALUES (@ProductId, @Quantity, 'New')";

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@Quantity", quantity);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public class InventoryService
    {
        public void UpdateInventory(int productId, int quantity)
        {
            // Логіка оновлення запасів
            using var connection = new SqlConnection("connectionString");
            string sql = "UPDATE Inventory " +
                         "SET AvailableQuantity = AvailableQuantity - @Quantity " +
                         "WHERE ProductId = @ProductId";

            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@Quantity", quantity);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
