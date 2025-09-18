// namespace Lab3._4_Generic_Constraints_Variance.Models;

// public class Customer : BaseEntity<int>, IComparable<Customer>, ICloneable
// {
//     private static int _nextId = 1;

//     public string FirstName { get; set; } = string.Empty;
//     public string LastName { get; set; } = string.Empty;
//     public string Email { get; set; } = string.Empty;
//     public string? Phone { get; set; }
//     public DateTime? DateOfBirth { get; set; }
//     public CustomerType Type { get; set; } = CustomerType.Regular;
//     public CustomerStatus Status { get; set; } = CustomerStatus.Active;
//     public List<int> OrderIds { get; set; } = new();
//     public decimal CreditLimit { get; set; }
//     public decimal CurrentBalance { get; set; }

//     public string FullName => $"{FirstName} {LastName}";
//     public int Age => DateOfBirth?.Date != null ? 
//         DateTime.Today.Year - DateOfBirth.Value.Year - 
//         (DateTime.Today.DayOfYear < DateOfBirth.Value.DayOfYear ? 1 : 0) : 0;

//     public decimal AvailableCredit => CreditLimit - CurrentBalance;

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
//             // Increase credit limit based on customer type
//             CreditLimit = newType switch
//             {
//                 CustomerType.Premium => 5000m,
//                 CustomerType.VIP => 10000m,
//                 CustomerType.Enterprise => 50000m,
//                 _ => CreditLimit
//             };
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

//     public bool CanPurchase(decimal amount)
//     {
//         return Status == CustomerStatus.Active && AvailableCredit >= amount;
//     }

//     public void AddToBalance(decimal amount)
//     {
//         CurrentBalance += amount;
//         MarkAsUpdated();
//     }

//     public void PayBalance(decimal amount)
//     {
//         CurrentBalance = Math.Max(0, CurrentBalance - amount);
//         MarkAsUpdated();
//     }

//     // IComparable<Customer> implementation - enables sorting constraints
//     public int CompareTo(Customer? other)
//     {
//         if (other == null) return 1;

//         // Primary sort by type (descending), secondary by last name, tertiary by first name
//         int typeComparison = other.Type.CompareTo(Type); // Descending
//         if (typeComparison != 0) return typeComparison;

//         int lastNameComparison = string.Compare(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
//         if (lastNameComparison != 0) return lastNameComparison;

//         return string.Compare(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase);
//     }

//     // ICloneable implementation - enables cloning constraints
//     public object Clone()
//     {
//         return new Customer
//         {
//             Id = this.Id,
//             FirstName = this.FirstName,
//             LastName = this.LastName,
//             Email = this.Email,
//             Phone = this.Phone,
//             DateOfBirth = this.DateOfBirth,
//             Type = this.Type,
//             Status = this.Status,
//             OrderIds = new List<int>(this.OrderIds),
//             CreditLimit = this.CreditLimit,
//             CurrentBalance = this.CurrentBalance,
//             CreatedBy = this.CreatedBy,
//             UpdatedBy = this.UpdatedBy
//         };
//     }

//     public Customer DeepClone()
//     {
//         return (Customer)Clone();
//     }

//     public override string ToString()
//     {
//         return $"{FullName} ({Type}) - {Email} - Balance: ${CurrentBalance:F2}";
//     }
// }

// public enum CustomerType
// {
//     Regular = 1,
//     Premium = 2,
//     VIP = 3,
//     Enterprise = 4
// }

// public enum CustomerStatus
// {
//     Active,
//     Inactive,
//     Suspended,
//     Closed
// }

namespace Lab3._4_Generic_Constraints_Variance.Models;

public sealed class Customer : BaseEntity
{
    public string FirstName { get; set; } = "John";
    public string LastName { get; set; } = "Doe";
    public string Email { get; set; } = "unknown@email.com";

    public override string DisplayName => $"{FirstName} {LastName}";
}