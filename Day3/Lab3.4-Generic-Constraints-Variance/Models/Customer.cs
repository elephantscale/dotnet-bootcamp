

namespace Lab3._4_Generic_Constraints_Variance.Models;

public sealed class Customer : BaseEntity
{
    public string FirstName { get; set; } = "John";
    public string LastName { get; set; } = "Doe";
    public string Email { get; set; } = "unknown@email.com";

    public override string DisplayName => $"{FirstName} {LastName}";
}
