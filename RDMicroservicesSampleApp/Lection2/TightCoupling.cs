namespace RDMicroservicesSampleApp.Lection2.TightCoupling
{
    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Логіка відправлення електронного листа
            Console.WriteLine("Sending Email...");
        }
    }

    public class OrderProcessor
    {
        private EmailService _emailService = new EmailService();

        public void ProcessOrder(Order order)
        {
            // Обробка замовлення
            Console.WriteLine("Processing Order...");
            // Відправлення електронного листа
            _emailService.SendEmail(order.Email, "Order Processed", "Your order has been processed.");
        }
    }

    public class Order
    {
        public string Email { get; set; }
    }
}
