# Lab 1.6: Enums and Methods

## Objective
Master the use of enumerations for type-safe constants and understand method design, parameters, and return types.

## Duration: 45 minutes

## Theory
- **Enums**: Type-safe named constants that improve code readability and maintainability
- **Methods**: Functions that encapsulate behavior and can accept parameters and return values
- **Method Signatures**: The combination of method name, parameters, and return type
- **Method Overloading**: Multiple methods with the same name but different parameters

## Exercise

### Part A: Working with Enums (15 minutes)
Create and use enums for better type safety and code clarity.

### Part B: Method Design and Implementation (20 minutes)
Design methods with various parameter types and return values.

### Part C: Method Overloading (10 minutes)
Implement method overloading for flexible APIs.

## Hands-On Tasks

### Task 1: Create Enums
Create `Enums/OrderStatus.cs`:
```csharp
namespace Lab1_6.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4,
        Returned = 5
    }

    public enum Priority
    {
        Low = 1,
        Normal = 2,
        High = 3,
        Critical = 4
    }

    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        PayPal,
        BankTransfer,
        Cash,
        Cryptocurrency
    }

    // Flags enum for multiple selections
    [Flags]
    public enum DeliveryOptions
    {
        None = 0,
        StandardShipping = 1,
        ExpressShipping = 2,
        OvernightShipping = 4,
        SignatureRequired = 8,
        InsuranceIncluded = 16,
        TrackingIncluded = 32
    }
}
```

### Task 2: Create Order Class with Methods
Create `Models/Order.cs`:
```csharp
using Lab1_6.Enums;

namespace Lab1_6.Models
{
    public class Order
    {
        private static int _nextOrderId = 1000;
        private List<OrderItem> _items;

        public int OrderId { get; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; }
        public OrderStatus Status { get; private set; }
        public Priority Priority { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

        // Constructor
        public Order(string customerName, PaymentMethod paymentMethod)
        {
            OrderId = _nextOrderId++;
            CustomerName = customerName ?? throw new ArgumentNullException(nameof(customerName));
            PaymentMethod = paymentMethod;
            OrderDate = DateTime.Now;
            Status = OrderStatus.Pending;
            Priority = Priority.Normal;
            DeliveryOptions = DeliveryOptions.StandardShipping | DeliveryOptions.TrackingIncluded;
            _items = new List<OrderItem>();
        }

        // Method: Add item (overloaded)
        public void AddItem(string productName, decimal price)
        {
            AddItem(productName, price, 1);
        }

        public void AddItem(string productName, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(productName))
                throw new ArgumentException("Product name cannot be empty");
            
            if (price < 0)
                throw new ArgumentException("Price cannot be negative");
            
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            var item = new OrderItem(productName, price, quantity);
            _items.Add(item);
            
            Console.WriteLine($"Added {quantity}x {productName} at ${price:C} each to order {OrderId}");
        }

        // Method: Remove item
        public bool RemoveItem(string productName)
        {
            var item = _items.FirstOrDefault(i => i.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                _items.Remove(item);
                Console.WriteLine($"Removed {productName} from order {OrderId}");
                return true;
            }
            
            Console.WriteLine($"Product {productName} not found in order {OrderId}");
            return false;
        }

        // Method: Calculate total
        public decimal GetTotal()
        {
            return _items.Sum(item => item.GetSubtotal());
        }

        // Method: Calculate total with tax
        public decimal GetTotal(decimal taxRate)
        {
            var subtotal = GetTotal();
            return subtotal + (subtotal * taxRate);
        }

        // Method: Calculate total with tax and shipping
        public decimal GetTotal(decimal taxRate, decimal shippingCost)
        {
            return GetTotal(taxRate) + shippingCost;
        }

        // Method: Update status
        public void UpdateStatus(OrderStatus newStatus)
        {
            var oldStatus = Status;
            Status = newStatus;
            
            Console.WriteLine($"Order {OrderId} status changed from {oldStatus} to {newStatus}");
            
            // Business logic based on status
            switch (newStatus)
            {
                case OrderStatus.Processing:
                    Console.WriteLine("Order is being prepared for shipment");
                    break;
                case OrderStatus.Shipped:
                    Console.WriteLine("Order has been shipped and is on its way");
                    break;
                case OrderStatus.Delivered:
                    Console.WriteLine("Order has been successfully delivered");
                    break;
                case OrderStatus.Cancelled:
                    Console.WriteLine("Order has been cancelled");
                    break;
            }
        }

        // Method: Check if express delivery
        public bool HasExpressDelivery()
        {
            return DeliveryOptions.HasFlag(DeliveryOptions.ExpressShipping) || 
                   DeliveryOptions.HasFlag(DeliveryOptions.OvernightShipping);
        }

        // Method: Get delivery description
        public string GetDeliveryDescription()
        {
            var descriptions = new List<string>();
            
            if (DeliveryOptions.HasFlag(DeliveryOptions.StandardShipping))
                descriptions.Add("Standard Shipping");
            if (DeliveryOptions.HasFlag(DeliveryOptions.ExpressShipping))
                descriptions.Add("Express Shipping");
            if (DeliveryOptions.HasFlag(DeliveryOptions.OvernightShipping))
                descriptions.Add("Overnight Shipping");
            if (DeliveryOptions.HasFlag(DeliveryOptions.SignatureRequired))
                descriptions.Add("Signature Required");
            if (DeliveryOptions.HasFlag(DeliveryOptions.InsuranceIncluded))
                descriptions.Add("Insurance Included");
            if (DeliveryOptions.HasFlag(DeliveryOptions.TrackingIncluded))
                descriptions.Add("Tracking Included");
            
            return string.Join(", ", descriptions);
        }

        // Method: Get priority color (for UI)
        public string GetPriorityColor()
        {
            return Priority switch
            {
                Priority.Low => "Green",
                Priority.Normal => "Blue",
                Priority.High => "Orange",
                Priority.Critical => "Red",
                _ => "Gray"
            };
        }

        // Method: Print order summary
        public void PrintOrderSummary()
        {
            Console.WriteLine($"\n=== Order Summary ===");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Order Date: {OrderDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Priority: {Priority} ({GetPriorityColor()})");
            Console.WriteLine($"Payment Method: {PaymentMethod}");
            Console.WriteLine($"Delivery Options: {GetDeliveryDescription()}");
            Console.WriteLine($"Express Delivery: {(HasExpressDelivery() ? "Yes" : "No")}");
            
            Console.WriteLine("\nItems:");
            foreach (var item in _items)
            {
                Console.WriteLine($"  {item}");
            }
            
            Console.WriteLine($"\nSubtotal: ${GetTotal():C}");
            Console.WriteLine($"Total with Tax (8.5%): ${GetTotal(0.085m):C}");
            Console.WriteLine($"Total with Tax and Shipping ($15): ${GetTotal(0.085m, 15m):C}");
            Console.WriteLine("=====================\n");
        }

        // Static method: Create sample order
        public static Order CreateSampleOrder()
        {
            var order = new Order("John Doe", PaymentMethod.CreditCard);
            order.Priority = Priority.High;
            order.DeliveryOptions = DeliveryOptions.ExpressShipping | 
                                   DeliveryOptions.SignatureRequired | 
                                   DeliveryOptions.InsuranceIncluded | 
                                   DeliveryOptions.TrackingIncluded;
            
            order.AddItem("Laptop", 999.99m);
            order.AddItem("Mouse", 29.99m, 2);
            order.AddItem("Keyboard", 79.99m);
            
            return order;
        }
    }

    public class OrderItem
    {
        public string ProductName { get; }
        public decimal Price { get; }
        public int Quantity { get; }

        public OrderItem(string productName, decimal price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetSubtotal()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return $"{Quantity}x {ProductName} @ ${Price:C} = ${GetSubtotal():C}";
        }
    }
}
```

### Task 3: Utility Methods Class
Create `Utilities/OrderUtilities.cs`:
```csharp
using Lab1_6.Enums;
using Lab1_6.Models;

namespace Lab1_6.Utilities
{
    public static class OrderUtilities
    {
        // Method: Parse order status from string
        public static OrderStatus ParseOrderStatus(string statusText)
        {
            if (Enum.TryParse<OrderStatus>(statusText, true, out var status))
            {
                return status;
            }
            throw new ArgumentException($"Invalid order status: {statusText}");
        }

        // Method: Get all order statuses
        public static OrderStatus[] GetAllOrderStatuses()
        {
            return Enum.GetValues<OrderStatus>();
        }

        // Method: Get status description
        public static string GetStatusDescription(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Order received and awaiting processing",
                OrderStatus.Processing => "Order is being prepared",
                OrderStatus.Shipped => "Order has been shipped",
                OrderStatus.Delivered => "Order has been delivered to customer",
                OrderStatus.Cancelled => "Order has been cancelled",
                OrderStatus.Returned => "Order has been returned by customer",
                _ => "Unknown status"
            };
        }

        // Method: Calculate estimated delivery days
        public static int GetEstimatedDeliveryDays(DeliveryOptions options, Priority priority)
        {
            int baseDays = 5; // Standard shipping

            if (options.HasFlag(DeliveryOptions.ExpressShipping))
                baseDays = 2;
            else if (options.HasFlag(DeliveryOptions.OvernightShipping))
                baseDays = 1;

            // Priority adjustment
            return priority switch
            {
                Priority.Critical => Math.Max(1, baseDays - 1),
                Priority.High => baseDays,
                Priority.Normal => baseDays + 1,
                Priority.Low => baseDays + 2,
                _ => baseDays
            };
        }

        // Method: Format payment method for display
        public static string FormatPaymentMethod(PaymentMethod method)
        {
            return method switch
            {
                PaymentMethod.CreditCard => "Credit Card",
                PaymentMethod.DebitCard => "Debit Card",
                PaymentMethod.PayPal => "PayPal",
                PaymentMethod.BankTransfer => "Bank Transfer",
                PaymentMethod.Cash => "Cash",
                PaymentMethod.Cryptocurrency => "Cryptocurrency",
                _ => method.ToString()
            };
        }

        // Method: Validate order for processing
        public static (bool IsValid, string[] Errors) ValidateOrder(Order order)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(order.CustomerName))
                errors.Add("Customer name is required");

            if (!order.Items.Any())
                errors.Add("Order must contain at least one item");

            if (order.GetTotal() <= 0)
                errors.Add("Order total must be greater than zero");

            return (errors.Count == 0, errors.ToArray());
        }

        // Method: Generate order report
        public static void GenerateOrderReport(IEnumerable<Order> orders)
        {
            Console.WriteLine("\n=== Order Report ===");
            
            var orderList = orders.ToList();
            Console.WriteLine($"Total Orders: {orderList.Count}");
            
            if (orderList.Any())
            {
                Console.WriteLine($"Total Revenue: ${orderList.Sum(o => o.GetTotal()):C}");
                Console.WriteLine($"Average Order Value: ${orderList.Average(o => o.GetTotal()):C}");
                
                Console.WriteLine("\nOrders by Status:");
                var statusGroups = orderList.GroupBy(o => o.Status);
                foreach (var group in statusGroups)
                {
                    Console.WriteLine($"  {group.Key}: {group.Count()} orders");
                }
                
                Console.WriteLine("\nOrders by Priority:");
                var priorityGroups = orderList.GroupBy(o => o.Priority);
                foreach (var group in priorityGroups)
                {
                    Console.WriteLine($"  {group.Key}: {group.Count()} orders");
                }
            }
            Console.WriteLine("===================\n");
        }
    }
}
```

### Task 4: Main Program
Create `Program.cs`:
```csharp
using Lab1_6.Enums;
using Lab1_6.Models;
using Lab1_6.Utilities;

Console.WriteLine("=== Enums and Methods Demo ===\n");

// Create orders using different methods
var orders = new List<Order>();

// Method 1: Create order step by step
Console.WriteLine("--- Creating Order Step by Step ---");
var order1 = new Order("Alice Johnson", PaymentMethod.PayPal);
order1.Priority = Priority.High;
order1.AddItem("Smartphone", 699.99m);
order1.AddItem("Phone Case", 19.99m, 2);
order1.AddItem("Screen Protector", 9.99m, 3);
orders.Add(order1);

// Method 2: Create sample order
Console.WriteLine("\n--- Creating Sample Order ---");
var order2 = Order.CreateSampleOrder();
orders.Add(order2);

// Method 3: Create order with different delivery options
Console.WriteLine("\n--- Creating Order with Custom Delivery ---");
var order3 = new Order("Bob Smith", PaymentMethod.CreditCard);
order3.Priority = Priority.Critical;
order3.DeliveryOptions = DeliveryOptions.OvernightShipping | 
                        DeliveryOptions.SignatureRequired | 
                        DeliveryOptions.InsuranceIncluded;
order3.AddItem("Gaming Console", 499.99m);
order3.AddItem("Controller", 59.99m, 2);
orders.Add(order3);

// Demonstrate method overloading
Console.WriteLine("\n--- Method Overloading Demo ---");
Console.WriteLine($"Order 1 Subtotal: ${order1.GetTotal():C}");
Console.WriteLine($"Order 1 with Tax (8.5%): ${order1.GetTotal(0.085m):C}");
Console.WriteLine($"Order 1 with Tax and Shipping: ${order1.GetTotal(0.085m, 12.99m):C}");

// Work with enums
Console.WriteLine("\n--- Working with Enums ---");
Console.WriteLine("Available Order Statuses:");
foreach (var status in OrderUtilities.GetAllOrderStatuses())
{
    Console.WriteLine($"  {status} ({(int)status}): {OrderUtilities.GetStatusDescription(status)}");
}

Console.WriteLine("\nAvailable Payment Methods:");
foreach (PaymentMethod method in Enum.GetValues<PaymentMethod>())
{
    Console.WriteLine($"  {OrderUtilities.FormatPaymentMethod(method)}");
}

// Demonstrate flags enum
Console.WriteLine("\n--- Flags Enum Demo ---");
var deliveryOptions = DeliveryOptions.ExpressShipping | DeliveryOptions.SignatureRequired;
Console.WriteLine($"Selected options: {deliveryOptions}");
Console.WriteLine($"Has Express Shipping: {deliveryOptions.HasFlag(DeliveryOptions.ExpressShipping)}");
Console.WriteLine($"Has Insurance: {deliveryOptions.HasFlag(DeliveryOptions.InsuranceIncluded)}");

// Process orders through different statuses
Console.WriteLine("\n--- Order Processing Demo ---");
foreach (var order in orders)
{
    order.PrintOrderSummary();
    
    // Validate order
    var (isValid, errors) = OrderUtilities.ValidateOrder(order);
    if (isValid)
    {
        Console.WriteLine("✓ Order validation passed");
        
        // Process through statuses
        order.UpdateStatus(OrderStatus.Processing);
        
        var estimatedDays = OrderUtilities.GetEstimatedDeliveryDays(order.DeliveryOptions, order.Priority);
        Console.WriteLine($"Estimated delivery: {estimatedDays} days");
        
        order.UpdateStatus(OrderStatus.Shipped);
        order.UpdateStatus(OrderStatus.Delivered);
    }
    else
    {
        Console.WriteLine("✗ Order validation failed:");
        foreach (var error in errors)
        {
            Console.WriteLine($"  - {error}");
        }
    }
    
    Console.WriteLine(new string('-', 50));
}

// Generate report
OrderUtilities.GenerateOrderReport(orders);

// Demonstrate enum parsing
Console.WriteLine("--- Enum Parsing Demo ---");
try
{
    var status = OrderUtilities.ParseOrderStatus("Shipped");
    Console.WriteLine($"Parsed status: {status}");
    
    var invalidStatus = OrderUtilities.ParseOrderStatus("InvalidStatus");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Parse error: {ex.Message}");
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

## Key Concepts Demonstrated

### Enums
- **Simple Enums**: Named constants with automatic numbering
- **Explicit Values**: Assigning specific numeric values
- **Flags Enums**: Using `[Flags]` attribute for bitwise operations
- **Enum Methods**: `Enum.GetValues()`, `Enum.TryParse()`, `HasFlag()`

### Methods
- **Method Overloading**: Same name, different parameters
- **Return Types**: void, value types, reference types
- **Parameters**: by value, optional parameters
- **Static Methods**: Class-level methods
- **Instance Methods**: Object-level methods

## Expected Output
```
=== Enums and Methods Demo ===

--- Creating Order Step by Step ---
Added 1x Smartphone at $699.99 each to order 1000
Added 2x Phone Case at $19.99 each to order 1000
Added 3x Screen Protector at $9.99 each to order 1000

--- Method Overloading Demo ---
Order 1 Subtotal: $769.96
Order 1 with Tax (8.5%): $835.41
Order 1 with Tax and Shipping: $848.40
```

## Key Takeaways
- Enums provide type-safe constants and improve code readability
- Flags enums enable bitwise operations for multiple selections
- Method overloading provides flexible APIs with the same logical operation
- Static methods belong to the type, instance methods belong to objects
- Proper method design includes validation and clear return values

## Challenge Exercise
Create a `ProductCategory` enum and a `Product` class with methods for calculating discounts based on category and quantity. Implement method overloading for different discount scenarios.

## Next Lab
Lab 1.7 will explore properties and advanced OOP design concepts.
