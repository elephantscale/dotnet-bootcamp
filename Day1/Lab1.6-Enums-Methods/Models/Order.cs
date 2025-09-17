using Lab1_6.Enums;

namespace Lab1_6.Models
{
    public class Order
    {
        private static int _nextOrderId = 1000;
        private readonly List<OrderItem> _items;

        public int OrderId { get; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; }
        public OrderStatus Status { get; private set; }
        public Priority Priority { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

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

        // Add item (overloads)
        public void AddItem(string productName, decimal price) => AddItem(productName, price, 1);

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

            Console.WriteLine($"Added {quantity}x {productName} at {price:C} each to order {OrderId}");
        }

        // Remove item
        public bool RemoveItem(string productName)
        {
            var item = _items.FirstOrDefault(i =>
                i.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (item is null)
            {
                Console.WriteLine($"Product {productName} not found in order {OrderId}");
                return false;
            }

            _items.Remove(item);
            Console.WriteLine($"Removed {productName} from order {OrderId}");
            return true;
        }

        // Totals (overloads)
        public decimal GetTotal() => _items.Sum(i => i.GetSubtotal());

        public decimal GetTotal(decimal taxRate)
        {
            var subtotal = GetTotal();
            return subtotal + (subtotal * taxRate);
        }

        public decimal GetTotal(decimal taxRate, decimal shippingCost) => GetTotal(taxRate) + shippingCost;

        // Status
        public void UpdateStatus(OrderStatus newStatus)
        {
            var old = Status;
            Status = newStatus;
            Console.WriteLine($"Order {OrderId} status changed from {old} to {newStatus}");

            switch (newStatus)
            {
                case OrderStatus.Processing: Console.WriteLine("Order is being prepared for shipment"); break;
                case OrderStatus.Shipped: Console.WriteLine("Order has been shipped and is on its way"); break;
                case OrderStatus.Delivered: Console.WriteLine("Order has been successfully delivered"); break;
                case OrderStatus.Cancelled: Console.WriteLine("Order has been cancelled"); break;
            }
        }

        public bool HasExpressDelivery() =>
            DeliveryOptions.HasFlag(DeliveryOptions.ExpressShipping) ||
            DeliveryOptions.HasFlag(DeliveryOptions.OvernightShipping);

        public string GetDeliveryDescription()
        {
            var parts = new List<string>();
            if (DeliveryOptions.HasFlag(DeliveryOptions.StandardShipping)) parts.Add("Standard Shipping");
            if (DeliveryOptions.HasFlag(DeliveryOptions.ExpressShipping)) parts.Add("Express Shipping");
            if (DeliveryOptions.HasFlag(DeliveryOptions.OvernightShipping)) parts.Add("Overnight Shipping");
            if (DeliveryOptions.HasFlag(DeliveryOptions.SignatureRequired)) parts.Add("Signature Required");
            if (DeliveryOptions.HasFlag(DeliveryOptions.InsuranceIncluded)) parts.Add("Insurance Included");
            if (DeliveryOptions.HasFlag(DeliveryOptions.TrackingIncluded)) parts.Add("Tracking Included");
            return string.Join(", ", parts);
        }

        public string GetPriorityColor() => Priority switch
        {
            Priority.Low => "Green",
            Priority.Normal => "Blue",
            Priority.High => "Orange",
            Priority.Critical => "Red",
            _ => "Gray"
        };

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
            foreach (var item in _items) Console.WriteLine($"  {item}");

            Console.WriteLine($"\nSubtotal: {GetTotal():C}");
            Console.WriteLine($"Total with Tax (8.5%): {GetTotal(0.085m):C}");
            Console.WriteLine($"Total with Tax and Shipping (15): {GetTotal(0.085m, 15m):C}");
            Console.WriteLine("=====================\n");
        }

        // Sample factory
        public static Order CreateSampleOrder()
        {
            var order = new Order("John Doe", PaymentMethod.CreditCard)
            {
                Priority = Priority.High,
                DeliveryOptions = DeliveryOptions.ExpressShipping |
                                  DeliveryOptions.SignatureRequired |
                                  DeliveryOptions.InsuranceIncluded |
                                  DeliveryOptions.TrackingIncluded
            };

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

        public decimal GetSubtotal() => Price * Quantity;

        public override string ToString() => $"{Quantity}x {ProductName} @ {Price:C} = {GetSubtotal():C}";
    }
}