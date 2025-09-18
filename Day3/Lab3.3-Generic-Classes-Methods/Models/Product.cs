namespace Lab3._3_Generic_Classes_Methods.Models;

public sealed class Product : Entity, IComparable<Product>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int CompareTo(Product? other) =>
        other is null ? 1 : Price.CompareTo(other.Price);

    public override string ToString() => $"{Name} (${Price:F2})";
}