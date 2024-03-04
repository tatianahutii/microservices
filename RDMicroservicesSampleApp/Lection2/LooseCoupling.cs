namespace RDMicroservicesSampleApp.Lection2.LooseCoupling
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            // Логіка відправлення електронного листа
            Console.WriteLine("Sending Email...");
        }
    }

    public class OrderProcessor
    {
        private IEmailService _emailService;

        // Constructor injection
        public OrderProcessor(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void ProcessOrder(Order order)
        {
            // Обробка замовлення
            Console.WriteLine("Processing Order...");

            // Відправлення електронного листа через інтерфейс
            _emailService.SendEmail(order.Email, "Order Processed", "Your order has been processed.");
        }
    }

    public class Order
    {
        public string Email { get; set; }
    }
}
