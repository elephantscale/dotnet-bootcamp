// namespace Lab3._3_Generic_Classes_Methods.Models;

// public class Order : Entity<int>
// {
//     private static int _nextId = 1001;

//     public int CustomerId { get; set; }
//     public DateTime OrderDate { get; set; }
//     public OrderStatus Status { get; set; } = OrderStatus.Pending;
//     public List<OrderItem> Items { get; set; } = new();
//     public decimal ShippingCost { get; set; }
//     public decimal TaxAmount { get; set; }
//     public string? Notes { get; set; }

//     public decimal SubTotal => Items.Sum(item => item.TotalPrice);
//     public decimal TotalAmount => SubTotal + ShippingCost + TaxAmount;
//     public int ItemCount => Items.Sum(item => item.Quantity);

//     public Order() : base(_nextId++)
//     {
//         OrderDate = DateTime.UtcNow;
//     }

//     public Order(int customerId) : this()
//     {
//         CustomerId = customerId;
//     }

//     public void AddItem(int productId, string productName, decimal unitPrice, int quantity = 1)
//     {
//         var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
//         if (existingItem != null)
//         {
//             existingItem.Quantity += quantity;
//         }
//         else
//         {
//             Items.Add(new OrderItem
//             {
//                 ProductId = productId,
//                 ProductName = productName,
//                 UnitPrice = unitPrice,
//                 Quantity = quantity
//             });
//         }
//         MarkAsUpdated();
//     }

//     public void RemoveItem(int productId)
//     {
//         var item = Items.FirstOrDefault(i => i.ProductId == productId);
//         if (item != null)
//         {
//             Items.Remove(item);
//             MarkAsUpdated();
//         }
//     }

//     public void UpdateStatus(OrderStatus newStatus)
//     {
//         Status = newStatus;
//         MarkAsUpdated();
//     }

//     public void CalculateTax(decimal taxRate = 0.08m)
//     {
//         TaxAmount = SubTotal * taxRate;
//         MarkAsUpdated();
//     }

//     public override string ToString()
//     {
//         return $"Order #{Id}: {ItemCount} items, ${TotalAmount:F2} ({Status})";
//     }
// }

// public class OrderItem
// {
//     public int ProductId { get; set; }
//     public string ProductName { get; set; } = string.Empty;
//     public decimal UnitPrice { get; set; }
//     public int Quantity { get; set; }

//     public decimal TotalPrice => UnitPrice * Quantity;

//     public override string ToString()
//     {
//         return $"{ProductName} x{Quantity} @ ${UnitPrice:F2} = ${TotalPrice:F2}";
//     }
// }

// public enum OrderStatus
// {
//     Pending,
//     Processing,
//     Shipped,
//     Delivered,
//     Cancelled,
//     Returned
// }

namespace Lab3._3_Generic_Classes_Methods.Models;

public sealed class Order : Entity
{
    public int CustomerId { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public List<OrderItem> Items { get; } = new();

    public int TotalItems => Items.Sum(i => i.Quantity);
    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);

    public void Add(Product p, int qty = 1) =>
        Items.Add(new OrderItem { ProductId = p.Id, ProductName = p.Name, UnitPrice = p.Price, Quantity = qty });

    public override string ToString() => $"Order #{Id}: {TotalItems} items, Total: ${Total:F2}";
}

public sealed class OrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public override string ToString() => $"{ProductName} x{Quantity} @ {UnitPrice:C}";
}