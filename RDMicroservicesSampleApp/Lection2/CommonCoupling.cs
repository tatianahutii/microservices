namespace RDMicroservicesSampleApp.Lection2.CommonCoupling
{
    public class OrderService
    {
        public void CreateOrder(Order order)
        {
            // Збереження замовлення в таблицю Orders
            SaveOrderToDatabase(order);

            // Пряме зменшення запасів в Inventory
            ReduceInventory(order.ProductId, order.Quantity); 
        }

        public void SaveOrderToDatabase(Order order)
        { }

        public void ReduceInventory(int productId, int quantity)
        { }
    }

    public class InventoryService
    {
        public void UpdateInventory(int productId, int quantity)
        {
            // Логіка оновлення складу
        }
    }

    public class Order
    { 
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
