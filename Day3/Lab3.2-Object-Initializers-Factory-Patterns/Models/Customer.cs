namespace Lab3._2_Object_Initializers_Factory_Patterns.Models;

public enum CustomerType { Standard, Premium, VIP }

public class Customer
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string FirstName { get; set; } = "First";
    public string LastName { get; set; } = "Last";
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public CustomerType Type { get; set; } = CustomerType.Standard;

    public Address? Address { get; set; }
    public List<Order> Orders { get; } = new();

    public string FullName => $"{FirstName} {LastName}";

    public void AddOrder(Order order) => Orders.Add(order);

    // Factory helpers
    public static Customer CreatePremiumCustomer(string first, string last, string email)
        => new() { FirstName = first, LastName = last, Email = email, Type = CustomerType.Premium };

    public static Customer CreateVipCustomer(string first, string last, string email, string? phone = null)
        => new() { FirstName = first, LastName = last, Email = email, Phone = phone, Type = CustomerType.VIP };
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;

    public override string ToString() => $"{Street}, {City}, {State} {ZipCode}";
}