using Lab3._2_Object_Initializers_Factory_Patterns.Models;
using Lab3._2_Object_Initializers_Factory_Patterns.Services;

Console.WriteLine("=== Object Initializers & Factory Patterns ===\n");

// Products via factories / builder
var laptop = Product.CreateElectronics("Laptop", 999.99m);
var book = Product.CreateBook("C# Programming", 59.99m, "Jon Skeet");
var mouse = Product.Builder()
    .WithName("Gaming Mouse")
    .WithPrice(79.99m)
    .InCategory("Electronics")
    .AddTag("Gaming")
    .AddTag("Peripheral")
    .Build();

// Customer with nested object initializer
var customer = new Customer
{
    FirstName = "John",
    LastName = "Doe",
    Email = "john@example.com",
    Phone = "555-0123",
    Address = new Address
    {
        Street = "123 Main St",
        City = "Anytown",
        State = "CA",
        ZipCode = "12345"
    }
};

// Orders (OrderNumber is assigned by constructor; do not set it manually)
var orderA = new Order(customer.Id);
orderA.AddItem(laptop, 1);
orderA.AddItem(mouse, 2);
orderA.CalculateTax();

var orderB = Order.CreateExpressOrder(customer.Id);
orderB.AddItem(book, 1);
orderB.CalculateTax();

// Add orders using the existing list (read-only property)
customer.Orders.AddRange(new[] { orderA, orderB });

Console.WriteLine($"Customer: {customer.FullName}");
foreach (var o in customer.Orders)
{
    Console.WriteLine($"- {o}");
}

// Inventory demo
var inventory = new Inventory("Main Warehouse", "Building A");
inventory.AddProduct(laptop, 5);
inventory.AddProduct(mouse, 10);
inventory.AddProduct(book, 7);

Console.WriteLine($"\nInventory '{inventory.Name}' items: {inventory.TotalItems}, value: {inventory.TotalValue:C}");

// Data processing demo (uses ConfigurationManager singleton internally)
new DataProcessor().ProcessOrderData();

// Fluent report builder demo
new ReportGenerator()
    .WithTitle("Monthly Sales Report")
    .WithFormat(ReportFormat.Pdf)
    .WithDateRange(DateTime.Today.AddDays(-30), DateTime.Today)
    .AddFilter("Region", "North")
    .SortBy("Date", descending: true)
    .SortBy("Amount", descending: true)
    .Build();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();