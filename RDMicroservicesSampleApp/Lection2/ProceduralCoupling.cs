namespace RDMicroservicesSampleApp.Lection2.ProceduralCoupling
{
    public class Order
    {
        public int Id { get; set; }
        public required string ProductId { get; set; }
    }

    public class OrderService
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing order {order.Id} for {order.ProductId}");
            // Виклик InventoryService для перевірки наявності товару на складі
            // Припускаємо, що ми викликаємо InventoryService через HTTP
            InventoryService.ShipProduct(order.ProductId);
        }
    }

    public class InventoryService
    {
        public static void ShipProduct(string productId)
        {
            Console.WriteLine($"Checking inventory for product {productId}");
            // Логіка перевірки наявності товару на складі
            // Припустимо, товар доступний, відповідно ми викликаємо ShippingService
            ShippingService.ScheduleDelivery(productId);
        }
    }

    public class ShippingService
    {
        public static void ScheduleDelivery(string productId)
        {
            Console.WriteLine($"Scheduling delivery for product {productId}");
            // Логіка організації доставки
        }
    }
}
