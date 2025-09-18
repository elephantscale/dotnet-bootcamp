

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
