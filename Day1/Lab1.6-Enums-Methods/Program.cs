using Lab1_6.Enums;
using Lab1_6.Models;
using Lab1_6.Utilities;

Console.WriteLine("=== Enums and Methods Demo ===\n");

var orders = new List<Order>();

// Create order step-by-step
Console.WriteLine("--- Creating Order Step by Step ---");
var order1 = new Order("Alice Johnson", PaymentMethod.PayPal)
{
    Priority = Priority.High
};
order1.AddItem("Smartphone", 699.99m);
order1.AddItem("Phone Case", 19.99m, 2);
order1.AddItem("Screen Protector", 9.99m, 3);
orders.Add(order1);

// Sample order
Console.WriteLine("\n--- Creating Sample Order ---");
var order2 = Order.CreateSampleOrder();
orders.Add(order2);

// Custom delivery
Console.WriteLine("\n--- Creating Order with Custom Delivery ---");
var order3 = new Order("Bob Smith", PaymentMethod.CreditCard)
{
    Priority = Priority.Critical,
    DeliveryOptions = DeliveryOptions.OvernightShipping |
                      DeliveryOptions.SignatureRequired |
                      DeliveryOptions.InsuranceIncluded
};
order3.AddItem("Gaming Console", 499.99m);
order3.AddItem("Controller", 59.99m, 2);
orders.Add(order3);

// Overloading demo
Console.WriteLine("\n--- Method Overloading Demo ---");
Console.WriteLine($"Order 1 Subtotal: {order1.GetTotal():C}");
Console.WriteLine($"Order 1 with Tax (8.5%): {order1.GetTotal(0.085m):C}");
Console.WriteLine($"Order 1 with Tax and Shipping: {order1.GetTotal(0.085m, 12.99m):C}");

// Enums
Console.WriteLine("\n--- Working with Enums ---");
Console.WriteLine("Available Order Statuses:");
foreach (var status in OrderUtilities.GetAllOrderStatuses())
    Console.WriteLine($"  {status} ({(int)status}): {OrderUtilities.GetStatusDescription(status)}");

Console.WriteLine("\nAvailable Payment Methods:");
foreach (PaymentMethod method in Enum.GetValues<PaymentMethod>())
    Console.WriteLine($"  {OrderUtilities.FormatPaymentMethod(method)}");

// Flags demo
Console.WriteLine("\n--- Flags Enum Demo ---");
var opts = DeliveryOptions.ExpressShipping | DeliveryOptions.SignatureRequired;
Console.WriteLine($"Selected options: {opts}");
Console.WriteLine($"Has Express Shipping: {opts.HasFlag(DeliveryOptions.ExpressShipping)}");
Console.WriteLine($"Has Insurance: {opts.HasFlag(DeliveryOptions.InsuranceIncluded)}");

// Process & report
Console.WriteLine("\n--- Order Processing Demo ---");
foreach (var o in orders)
{
    o.PrintOrderSummary();

    var (isValid, errors) = OrderUtilities.ValidateOrder(o);
    if (isValid)
    {
        Console.WriteLine("✓ Order validation passed");
        o.UpdateStatus(OrderStatus.Processing);
        var eta = OrderUtilities.GetEstimatedDeliveryDays(o.DeliveryOptions, o.Priority);
        Console.WriteLine($"Estimated delivery: {eta} days");
        o.UpdateStatus(OrderStatus.Shipped);
        o.UpdateStatus(OrderStatus.Delivered);
    }
    else
    {
        Console.WriteLine("✗ Order validation failed:");
        foreach (var e in errors) Console.WriteLine($"  - {e}");
    }

    Console.WriteLine(new string('-', 50));
}

OrderUtilities.GenerateOrderReport(orders);

// Enum parsing
Console.WriteLine("--- Enum Parsing Demo ---");
try
{
    var ok = OrderUtilities.ParseOrderStatus("Shipped");
    Console.WriteLine($"Parsed status: {ok}");
    var _ = OrderUtilities.ParseOrderStatus("InvalidStatus");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Parse error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();