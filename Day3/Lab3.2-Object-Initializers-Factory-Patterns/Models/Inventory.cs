namespace Lab3._2_Object_Initializers_Factory_Patterns.Models;

public class Inventory
{
    private readonly Dictionary<int, InventoryItem> _items = new();
    
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateTime LastUpdated { get; private set; }
    
    public int TotalItems => _items.Count;
    public int TotalQuantity => _items.Values.Sum(item => item.Quantity);
    public decimal TotalValue => _items.Values.Sum(item => item.TotalValue);
    
    public Inventory()
    {
        LastUpdated = DateTime.Now;
    }
    
    public Inventory(string name, string location) : this()
    {
        Name = name;
        Location = location;
    }
    
    public void AddProduct(Product product, int quantity, decimal? costPrice = null)
    {
        if (_items.ContainsKey(product.Id))
        {
            _items[product.Id].Quantity += quantity;
        }
        else
        {
            _items[product.Id] = new InventoryItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Category = product.Category,
                Quantity = quantity,
                UnitCost = costPrice ?? product.Price * 0.7m, // Default 30% markup
                RetailPrice = product.Price,
                LastRestocked = DateTime.Now
            };
        }
        LastUpdated = DateTime.Now;
    }
    
    public bool RemoveProduct(int productId, int quantity)
    {
        if (_items.ContainsKey(productId) && _items[productId].Quantity >= quantity)
        {
            _items[productId].Quantity -= quantity;
            if (_items[productId].Quantity == 0)
            {
                _items.Remove(productId);
            }
            LastUpdated = DateTime.Now;
            return true;
        }
        return false;
    }
    
    public InventoryItem? GetItem(int productId)
    {
        return _items.TryGetValue(productId, out var item) ? item : null;
    }
    
    public List<InventoryItem> GetAllItems()
    {
        return _items.Values.ToList();
    }
    
    // Anonymous type examples for reporting
    public object GetInventorySummary()
    {
        return new
        {
            InventoryName = Name,
            Location = Location,
            TotalItems = TotalItems,
            TotalQuantity = TotalQuantity,
            TotalValue = TotalValue,
            LastUpdated = LastUpdated,
            Categories = _items.Values
                .GroupBy(item => item.Category)
                .Select(g => new { Category = g.Key, Count = g.Count(), Value = g.Sum(i => i.TotalValue) })
                .ToList()
        };
    }
    
    public List<object> GetLowStockReport(int threshold = 10)
    {
        return _items.Values
            .Where(item => item.Quantity <= threshold)
            .Select(item => new
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                CurrentStock = item.Quantity,
                ReorderLevel = threshold,
                Category = item.Category,
                DaysOutOfStock = item.Quantity == 0 ? (DateTime.Now - item.LastRestocked).Days : 0
            })
            .ToList<object>();
    }
    
    public List<object> GetTopValueItems(int count = 5)
    {
        return _items.Values
            .OrderByDescending(item => item.TotalValue)
            .Take(count)
            .Select(item => new
            {
                Rank = _items.Values.OrderByDescending(i => i.TotalValue).ToList().IndexOf(item) + 1,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                UnitValue = item.RetailPrice,
                TotalValue = item.TotalValue,
                ProfitMargin = ((item.RetailPrice - item.UnitCost) / item.RetailPrice * 100).ToString("F1") + "%"
            })
            .ToList<object>();
    }
}

public class InventoryItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal RetailPrice { get; set; }
    public DateTime LastRestocked { get; set; }
    
    public decimal TotalValue => Quantity * RetailPrice;
    public decimal ProfitPerUnit => RetailPrice - UnitCost;
    public decimal TotalProfit => Quantity * ProfitPerUnit;
    
    public override string ToString()
    {
        return $"{ProductName}: {Quantity} units @ ${RetailPrice:F2} (Total: ${TotalValue:F2})";
    }
}
