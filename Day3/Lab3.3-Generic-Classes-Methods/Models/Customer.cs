// namespace Lab3._3_Generic_Classes_Methods.Models;

// public class Customer : Entity<int>
// {
//     private static int _nextId = 1;

//     public string FirstName { get; set; } = string.Empty;
//     public string LastName { get; set; } = string.Empty;
//     public string Email { get; set; } = string.Empty;
//     public string? Phone { get; set; }
//     public DateTime? DateOfBirth { get; set; }
//     public CustomerType Type { get; set; } = CustomerType.Regular;
//     public List<int> OrderIds { get; set; } = new();

//     public string FullName => $"{FirstName} {LastName}";
//     public int Age => DateOfBirth?.Date != null ? 
//         DateTime.Today.Year - DateOfBirth.Value.Year - 
//         (DateTime.Today.DayOfYear < DateOfBirth.Value.DayOfYear ? 1 : 0) : 0;

//     public Customer() : base(_nextId++)
//     {
//     }

//     public Customer(string firstName, string lastName, string email) : this()
//     {
//         FirstName = firstName;
//         LastName = lastName;
//         Email = email;
//     }

//     public Customer(string firstName, string lastName, string email, DateTime dateOfBirth) 
//         : this(firstName, lastName, email)
//     {
//         DateOfBirth = dateOfBirth;
//     }

//     public void UpdateContactInfo(string email, string? phone = null)
//     {
//         Email = email;
//         Phone = phone;
//         MarkAsUpdated();
//     }

//     public void UpgradeToType(CustomerType newType)
//     {
//         if (newType > Type)
//         {
//             Type = newType;
//             MarkAsUpdated();
//         }
//     }

//     public void AddOrder(int orderId)
//     {
//         if (!OrderIds.Contains(orderId))
//         {
//             OrderIds.Add(orderId);
//             MarkAsUpdated();
//         }
//     }

//     public override string ToString()
//     {
//         return $"{FullName} ({Email}) - {Type} Customer";
//     }
// }

// public enum CustomerType
// {
//     Regular = 1,
//     Premium = 2,
//     VIP = 3,
//     Enterprise = 4
// }
namespace Lab3._3_Generic_Classes_Methods.Models;

public sealed class Customer : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString() => $"{FullName} ({Email})";
}