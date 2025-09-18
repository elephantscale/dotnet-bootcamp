namespace Lab3._2_Object_Initializers_Factory_Patterns.Models;

public class Product
{
    private static int _nextId = 1;
    private string _name = string.Empty;
    private decimal _price;

    public int Id { get; } = _nextId++;

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value)
            ? throw new ArgumentException("Name required")
            : value.Trim();
    }

    public decimal Price
    {
        get => _price;
        set => _price = value < 0
            ? throw new ArgumentException("Price cannot be negative")
            : value;
    }

    public string Category { get; set; } = "General";
    public List<string> Tags { get; } = new();
    public DateTime Created { get; } = DateTime.Now;

    public override string ToString() => $"{Name} - {Price:C} ({Category}) - In Stock: True";

    // ----- Factory helpers -----
    public static Product CreateElectronics(string name, decimal price) =>
        new() { Name = name, Price = price, Category = "Electronics" };

    public static Product CreateBook(string title, decimal price, string author)
    {
        var p = new Product { Name = title, Price = price, Category = "Books" };
        p.Tags.Add($"Author:{author}");
        return p;
    }

    // ----- Fluent Builder -----
    public static BuilderClass Builder() => new();

    public sealed class BuilderClass
    {
        private readonly Product _p = new();
        public BuilderClass WithName(string name) { _p.Name = name; return this; }
        public BuilderClass WithPrice(decimal price) { _p.Price = price; return this; }
        public BuilderClass InCategory(string category) { _p.Category = category; return this; }
        public BuilderClass AddTag(string tag) { _p.Tags.Add(tag); return this; }

        public Product Build()
        {
            if (string.IsNullOrWhiteSpace(_p.Name))
                throw new InvalidOperationException("Name is required");
            return _p;
        }
    }
}