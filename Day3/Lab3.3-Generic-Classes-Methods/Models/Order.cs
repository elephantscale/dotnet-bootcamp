

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
