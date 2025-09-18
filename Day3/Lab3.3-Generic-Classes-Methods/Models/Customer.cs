
namespace Lab3._3_Generic_Classes_Methods.Models;

public sealed class Customer : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString() => $"{FullName} ({Email})";
}
