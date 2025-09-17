using Lab1_6.Enums;
using Lab1_6.Models;

namespace Lab1_6.Utilities
{
    public static class OrderUtilities
    {
        public static OrderStatus ParseOrderStatus(string text)
        {
            if (Enum.TryParse<OrderStatus>(text, true, out var status)) return status;
            throw new ArgumentException($"Invalid order status: {text}");
        }

        public static OrderStatus[] GetAllOrderStatuses() => Enum.GetValues<OrderStatus>();

        public static string GetStatusDescription(OrderStatus status) => status switch
        {
            OrderStatus.Pending => "Order received and awaiting processing",
            OrderStatus.Processing => "Order is being prepared",
            OrderStatus.Shipped => "Order has been shipped",
            OrderStatus.Delivered => "Order has been delivered to customer",
            OrderStatus.Cancelled => "Order has been cancelled",
            OrderStatus.Returned => "Order has been returned by customer",
            _ => "Unknown status"
        };

        public static int GetEstimatedDeliveryDays(DeliveryOptions options, Priority priority)
        {
            int baseDays = 5;
            if (options.HasFlag(DeliveryOptions.ExpressShipping)) baseDays = 2;
            else if (options.HasFlag(DeliveryOptions.OvernightShipping)) baseDays = 1;

            return priority switch
            {
                Priority.Critical => Math.Max(1, baseDays - 1),
                Priority.High => baseDays,
                Priority.Normal => baseDays + 1,
                Priority.Low => baseDays + 2,
                _ => baseDays
            };
        }

        public static string FormatPaymentMethod(PaymentMethod m) => m switch
        {
            PaymentMethod.CreditCard => "Credit Card",
            PaymentMethod.DebitCard => "Debit Card",
            PaymentMethod.PayPal => "PayPal",
            PaymentMethod.BankTransfer => "Bank Transfer",
            PaymentMethod.Cash => "Cash",
            PaymentMethod.Cryptocurrency => "Cryptocurrency",
            _ => m.ToString()
        };

        public static (bool IsValid, string[] Errors) ValidateOrder(Order order)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(order.CustomerName)) errors.Add("Customer name is required");
            if (!order.Items.Any()) errors.Add("Order must contain at least one item");
            if (order.GetTotal() <= 0) errors.Add("Order total must be greater than zero");
            return (errors.Count == 0, errors.ToArray());
        }

        public static void GenerateOrderReport(IEnumerable<Order> orders)
        {
            Console.WriteLine("\n=== Order Report ===");
            var list = orders.ToList();
            Console.WriteLine($"Total Orders: {list.Count}");
            if (list.Any())
            {
                Console.WriteLine($"Total Revenue: {list.Sum(o => o.GetTotal()):C}");
                Console.WriteLine($"Average Order Value: {list.Average(o => o.GetTotal()):C}");

                Console.WriteLine("\nOrders by Status:");
                foreach (var g in list.GroupBy(o => o.Status))
                    Console.WriteLine($"  {g.Key}: {g.Count()} orders");

                Console.WriteLine("\nOrders by Priority:");
                foreach (var g in list.GroupBy(o => o.Priority))
                    Console.WriteLine($"  {g.Key}: {g.Count()} orders");
            }
            Console.WriteLine("===================\n");
        }
    }
}