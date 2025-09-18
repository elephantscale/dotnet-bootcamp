using Lab3._2_Object_Initializers_Factory_Patterns.Models;

namespace Lab3._2_Object_Initializers_Factory_Patterns.Services;

public class DataProcessor
{
    private readonly ConfigurationManager _config;

    public DataProcessor()
    {
        _config = ConfigurationManager.Instance;
    }

    public void ProcessOrderData()
    {
        Console.WriteLine("=== Processing Order Data with Multiple Patterns ===");

        // Object initializers with collection initializers
        var customers = new List<Customer>
        {
            new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                Phone = "555-0123",
                Address = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    ZipCode = "12345"
                }
            },
            Customer.CreatePremiumCustomer("Jane", "Smith", "jane.smith@email.com"),
            Customer.CreateVipCustomer("Bob", "Johnson", "bob.johnson@email.com", "555-0456")
        };

        // Create products using different patterns
        var products = new List<Product>
        {
            Product.CreateElectronics("Laptop", 999.99m),
            Product.CreateBook("C# Programming", 59.99m, "John Skeet"),
            Product.Builder()
                .WithName("Gaming Mouse")
                .WithPrice(79.99m)
                .InCategory("Electronics")
                .AddTag("Gaming")
                .AddTag("Peripheral")
                .Build()
        };

        // Create orders using factory methods and object initializers
        foreach (var customer in customers)
        {
            var order = customer.Type switch
            {
                CustomerType.VIP => Order.CreateExpressOrder(customer.Id),
                CustomerType.Premium => Order.CreateBulkOrder(customer.Id),
                _ => new Order(customer.Id)
            };

            // Add random products to order
            var random = new Random();
            var productCount = random.Next(1, 4);
            for (int i = 0; i < productCount; i++)
            {
                var product = products[random.Next(products.Count)];
                var quantity = random.Next(1, 3);
                order.AddItem(product, quantity);
            }

            order.CalculateTax();
            customer.AddOrder(order);
        }

        // Display results using anonymous types for reporting
        var orderSummary = customers.SelectMany(c => c.Orders)
            .Select(o => new
            {
                OrderNumber = o.OrderNumber,
                CustomerName = customers.First(c => c.Id == o.CustomerId).FullName,
                ItemCount = o.ItemCount,
                Total = o.TotalAmount,
                Status = o.Status
            })
            .ToList();

        Console.WriteLine("\nOrder Summary:");
        foreach (var summary in orderSummary)
        {
            Console.WriteLine($"  Order #{summary.OrderNumber}: {summary.CustomerName} - {summary.ItemCount} items, ${summary.Total:F2}");
        }
    }
}
