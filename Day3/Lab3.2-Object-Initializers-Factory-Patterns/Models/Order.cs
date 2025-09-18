namespace Lab3._2_Object_Initializers_Factory_Patterns.Models;

public class Order
{
    private static int _nextOrderNumber = 1001;
    
    public int OrderNumber { get; private set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public List<OrderItem> Items { get; set; } = new();
    public decimal ShippingCost { get; set; }
    public decimal TaxAmount { get; set; }
    public string? Notes { get; set; }
    
    public decimal SubTotal => Items.Sum(item => item.TotalPrice);
    public decimal TotalAmount => SubTotal + ShippingCost + TaxAmount;
    public int ItemCount => Items.Sum(item => item.Quantity);
    
    public Order()
    {
        OrderNumber = _nextOrderNumber++;
        OrderDate = DateTime.Now;
    }
    
    public Order(int customerId) : this()
    {
        CustomerId = customerId;
    }
    
    // Factory methods for different order types
    public static Order CreateExpressOrder(int customerId, decimal expressShipping = 15.99m)
    {
        return new Order
        {
            CustomerId = customerId,
            ShippingCost = expressShipping,
            Status = OrderStatus.Processing,
            Notes = "Express shipping requested"
        };
    }
    
    public static Order CreateBulkOrder(int customerId, decimal bulkDiscount = 0.1m)
    {
        return new Order
        {
            CustomerId = customerId,
            ShippingCost = 0, // Free shipping for bulk orders
            Notes = $"Bulk order with {bulkDiscount:P0} discount applied"
        };
    }
    
    public void AddItem(Product product, int quantity = 1)
    {
        var existingItem = Items.FirstOrDefault(i => i.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            Items.Add(new OrderItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = quantity
            });
        }
    }
    
    public void CalculateTax(decimal taxRate = 0.08m)
    {
        TaxAmount = SubTotal * taxRate;
    }
    
    public override string ToString()
    {
        return $"Order #{OrderNumber}: {ItemCount} items, Total: ${TotalAmount:F2}";
    }
}

public class OrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    
    public decimal TotalPrice => UnitPrice * Quantity;
    
    public override string ToString()
    {
        return $"{ProductName} x{Quantity} @ ${UnitPrice:F2} = ${TotalPrice:F2}";
    }
}

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled,
    Returned
}
