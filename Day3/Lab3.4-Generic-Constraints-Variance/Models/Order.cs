// namespace Lab3._4_Generic_Constraints_Variance.Models;

// public class Order : BaseEntity<int>, IComparable<Order>, ICloneable
// {
//     private static int _nextId = 1001;

//     public int CustomerId { get; set; }
//     public DateTime OrderDate { get; set; }
//     public OrderStatus Status { get; set; } = OrderStatus.Pending;
//     public List<OrderItem> Items { get; set; } = new();
//     public decimal ShippingCost { get; set; }
//     public decimal TaxAmount { get; set; }
//     public decimal DiscountAmount { get; set; }
//     public string? Notes { get; set; }
//     public string? ShippingAddress { get; set; }
//     public DateTime? ShippedDate { get; set; }
//     public DateTime? DeliveredDate { get; set; }
//     public string? TrackingNumber { get; set; }

//     public decimal SubTotal => Items.Sum(item => item.TotalPrice);
//     public decimal TotalAmount => SubTotal + ShippingCost + TaxAmount - DiscountAmount;
//     public int ItemCount => Items.Sum(item => item.Quantity);
//     public decimal TotalWeight => Items.Sum(item => item.Weight * item.Quantity);

//     public Order() : base(_nextId++)
//     {
//         OrderDate = DateTime.UtcNow;
//     }

//     public Order(int customerId) : this()
//     {
//         CustomerId = customerId;
//     }

//     public Order(int customerId, string shippingAddress) : this(customerId)
//     {
//         ShippingAddress = shippingAddress;
//     }

//     public void AddItem(int productId, string productName, decimal unitPrice, int quantity = 1, decimal weight = 0)
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
//                 Quantity = quantity,
//                 Weight = weight
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

//         switch (newStatus)
//         {
//             case OrderStatus.Shipped:
//                 ShippedDate = DateTime.UtcNow;
//                 break;
//             case OrderStatus.Delivered:
//                 DeliveredDate = DateTime.UtcNow;
//                 break;
//         }

//         MarkAsUpdated();
//     }

//     public void CalculateTax(decimal taxRate = 0.08m)
//     {
//         TaxAmount = SubTotal * taxRate;
//         MarkAsUpdated();
//     }

//     public void ApplyDiscount(decimal discountAmount)
//     {
//         DiscountAmount = Math.Max(0, Math.Min(discountAmount, SubTotal));
//         MarkAsUpdated();
//     }

//     public void SetTrackingNumber(string trackingNumber)
//     {
//         TrackingNumber = trackingNumber;
//         MarkAsUpdated();
//     }

//     // IComparable<Order> implementation - enables sorting constraints
//     public int CompareTo(Order? other)
//     {
//         if (other == null) return 1;

//         // Primary sort by order date (descending), secondary by total amount (descending)
//         int dateComparison = other.OrderDate.CompareTo(OrderDate); // Descending
//         if (dateComparison != 0) return dateComparison;

//         return other.TotalAmount.CompareTo(TotalAmount); // Descending
//     }

//     // ICloneable implementation - enables cloning constraints
//     public object Clone()
//     {
//         return new Order
//         {
//             Id = this.Id,
//             CustomerId = this.CustomerId,
//             OrderDate = this.OrderDate,
//             Status = this.Status,
//             Items = this.Items.Select(item => new OrderItem
//             {
//                 ProductId = item.ProductId,
//                 ProductName = item.ProductName,
//                 UnitPrice = item.UnitPrice,
//                 Quantity = item.Quantity,
//                 Weight = item.Weight
//             }).ToList(),
//             ShippingCost = this.ShippingCost,
//             TaxAmount = this.TaxAmount,
//             DiscountAmount = this.DiscountAmount,
//             Notes = this.Notes,
//             ShippingAddress = this.ShippingAddress,
//             ShippedDate = this.ShippedDate,
//             DeliveredDate = this.DeliveredDate,
//             TrackingNumber = this.TrackingNumber,
//             CreatedBy = this.CreatedBy,
//             UpdatedBy = this.UpdatedBy
//         };
//     }

//     public Order DeepClone()
//     {
//         return (Order)Clone();
//     }

//     public override string ToString()
//     {
//         return $"Order #{Id}: {ItemCount} items, ${TotalAmount:F2} ({Status})";
//     }
// }

// public class OrderItem : ICloneable
// {
//     public int ProductId { get; set; }
//     public string ProductName { get; set; } = string.Empty;
//     public decimal UnitPrice { get; set; }
//     public int Quantity { get; set; }
//     public decimal Weight { get; set; }

//     public decimal TotalPrice => UnitPrice * Quantity;

//     public object Clone()
//     {
//         return new OrderItem
//         {
//             ProductId = this.ProductId,
//             ProductName = this.ProductName,
//             UnitPrice = this.UnitPrice,
//             Quantity = this.Quantity,
//             Weight = this.Weight
//         };
//     }

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
//     Returned,
//     Refunded
// }

namespace Lab3._4_Generic_Constraints_Variance.Models;

public sealed class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public DateTime Created { get; } = DateTime.Now;
    public override string DisplayName => $"Order #{Id}";
}