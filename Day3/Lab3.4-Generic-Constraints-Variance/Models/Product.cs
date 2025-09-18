// namespace Lab3._4_Generic_Constraints_Variance.Models;

// public class Product : BaseEntity<int>, IComparable<Product>, ICloneable
// {
//     private static int _nextId = 1;

//     public string Name { get; set; } = string.Empty;
//     public decimal Price { get; set; }
//     public string Category { get; set; } = string.Empty;
//     public string? Description { get; set; }
//     public bool InStock { get; set; } = true;
//     public int StockQuantity { get; set; }
//     public decimal Weight { get; set; }
//     public ProductStatus Status { get; set; } = ProductStatus.Active;

//     public Product() : base(_nextId++)
//     {
//     }

//     public Product(string name, decimal price, string category) : this()
//     {
//         Name = name;
//         Price = price;
//         Category = category;
//     }

//     public Product(string name, decimal price, string category, string description, int stockQuantity) 
//         : this(name, price, category)
//     {
//         Description = description;
//         StockQuantity = stockQuantity;
//         InStock = stockQuantity > 0;
//     }

//     public void UpdatePrice(decimal newPrice)
//     {
//         Price = newPrice;
//         MarkAsUpdated();
//     }

//     public void UpdateStock(int quantity)
//     {
//         StockQuantity = quantity;
//         InStock = quantity > 0;
//         MarkAsUpdated();
//     }

//     public void AddStock(int quantity)
//     {
//         StockQuantity += quantity;
//         InStock = StockQuantity > 0;
//         MarkAsUpdated();
//     }

//     public bool RemoveStock(int quantity)
//     {
//         if (StockQuantity >= quantity)
//         {
//             StockQuantity -= quantity;
//             InStock = StockQuantity > 0;
//             MarkAsUpdated();
//             return true;
//         }
//         return false;
//     }

//     // IComparable<Product> implementation - enables sorting constraints
//     public int CompareTo(Product? other)
//     {
//         if (other == null) return 1;

//         // Primary sort by price, secondary by name
//         int priceComparison = Price.CompareTo(other.Price);
//         return priceComparison != 0 ? priceComparison : string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
//     }

//     // ICloneable implementation - enables cloning constraints
//     public object Clone()
//     {
//         return new Product
//         {
//             Id = this.Id,
//             Name = this.Name,
//             Price = this.Price,
//             Category = this.Category,
//             Description = this.Description,
//             InStock = this.InStock,
//             StockQuantity = this.StockQuantity,
//             Weight = this.Weight,
//             Status = this.Status,
//             CreatedBy = this.CreatedBy,
//             UpdatedBy = this.UpdatedBy
//         };
//     }

//     public Product DeepClone()
//     {
//         return (Product)Clone();
//     }

//     public override string ToString()
//     {
//         return $"{Name}: ${Price:F2} ({Category}) - Stock: {StockQuantity}";
//     }
// }

// public enum ProductStatus
// {
//     Active,
//     Inactive,
//     Discontinued,
//     OutOfStock,
//     Backordered
// }

namespace Lab3._4_Generic_Constraints_Variance.Models;

public sealed class Product : BaseEntity, IComparable<Product>
{
    public string Name { get; set; } = "Product";
    public decimal Price { get; set; }

    // parameterless ctor required for new() constraint demos
    public Product() { }

    public override string DisplayName => $"{Name}: ${Price:F2}";

    public int CompareTo(Product? other)
        => Price.CompareTo(other?.Price ?? 0m);
}