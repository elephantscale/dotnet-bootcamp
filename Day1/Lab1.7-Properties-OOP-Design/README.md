# Lab 1.7: Properties and OOP Design Concepts

## Objective
Master properties as the interface to object data and understand fundamental OOP design principles.

## Duration: 30 minutes

## Theory
- **Properties**: Provide controlled access to private fields with get/set accessors
- **Encapsulation**: Hide internal implementation details
- **Abstraction**: Expose only necessary functionality
- **Auto-Properties**: Simplified property syntax for common scenarios
- **Computed Properties**: Properties that calculate values on-the-fly

## Exercise

### Part A: Property Types (15 minutes)
Explore different property implementations and access patterns.

### Part B: OOP Design Principles (15 minutes)
Apply encapsulation and abstraction in practical examples.

## Hands-On Tasks

### Task 1: Property Variations
Create `Models/Employee.cs`:
```csharp
using System;

namespace Lab1_7.Models
{
    public class Employee
    {
        // Private fields
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private decimal _salary;
        private DateTime _hireDate;

        // Full property with validation
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty");
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name cannot be empty");
                _lastName = value.Trim();
            }
        }

        // Property with business logic
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative");
                if (value > 1_000_000)
                    throw new ArgumentException("Salary exceeds maximum allowed");
                _salary = value;
            }
        }

        // Read-only property
        public DateTime HireDate
        {
            get => _hireDate;
            private set => _hireDate = value;
        }

        // Auto-implemented properties
        public int EmployeeId { get; set; }
        public string Department { get; set; } = "General";
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Computed properties
        public string FullName => $"{FirstName} {LastName}";
        public int YearsOfService => DateTime.Now.Year - HireDate.Year;
        public decimal AnnualSalary => Salary * 12;
        public string DisplayName => $"{FullName} ({EmployeeId})";

        public string SalaryGrade =>
            AnnualSalary switch
            {
                < 30000  => "Entry Level",
                < 50000  => "Junior",
                < 75000  => "Mid Level",
                < 100000 => "Senior",
                < 150000 => "Lead",
                _        => "Executive"
            };

        // Constructor
        public Employee(int employeeId, string firstName, string lastName, decimal monthlySalary)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Salary = monthlySalary;
            HireDate = DateTime.Now;
        }

        // Methods that use properties
        public void GiveRaise(decimal percentage)
        {
            if (percentage < 0)
                throw new ArgumentException("Raise percentage cannot be negative");

            var oldSalary = Salary;
            Salary += Salary * (percentage / 100m);

            Console.WriteLine($"{FullName} received a {percentage}% raise");
            Console.WriteLine($"Salary increased from {oldSalary:C} to {Salary:C} per month");
        }

        public void UpdateDepartment(string newDepartment)
        {
            if (string.IsNullOrWhiteSpace(newDepartment))
                throw new ArgumentException("Department cannot be empty");

            var old = Department;
            Department = newDepartment;
            Console.WriteLine($"{FullName} transferred from {old} to {Department}");
        }

        public void PrintEmployeeInfo()
        {
            Console.WriteLine($"\n=== Employee Information ===");
            Console.WriteLine($"ID: {EmployeeId}");
            Console.WriteLine($"Name: {FullName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Hire Date: {HireDate:yyyy-MM-dd}");
            Console.WriteLine($"Years of Service: {YearsOfService}");
            Console.WriteLine($"Monthly Salary: {Salary:C}");
            Console.WriteLine($"Annual Salary: {AnnualSalary:C}");
            Console.WriteLine($"Salary Grade: {SalaryGrade}");
            Console.WriteLine($"Status: {(IsActive ? "Active" : "Inactive")}");
            Console.WriteLine("============================\n");
        }
    }
}
```

### Task 2: Advanced Property Patterns
Create `Models/BankAccount.cs`:
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_7.Models
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly List<Transaction> _transactions;

        // Properties with different access levels
        public string AccountNumber { get; }
        public string AccountHolder { get; }
        public DateTime CreatedDate { get; }

        // Property with private setter
        public decimal Balance
        {
            get => _balance;
            private set => _balance = value;
        }

        // Read-only collection property
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        // Computed properties
        public decimal TotalDeposits => _transactions
            .Where(t => t.Type == TransactionType.Deposit)
            .Sum(t => t.Amount);

        public decimal TotalWithdrawals => _transactions
            .Where(t => t.Type == TransactionType.Withdrawal)
            .Sum(t => t.Amount);

        public int TransactionCount => _transactions.Count;

        public Transaction? LastTransaction => _transactions.LastOrDefault();

        // Property with validation and side effects
        public bool IsActive { get; set; } = true;

        // Property that depends on other properties
        public string AccountStatus
        {
            get
            {
                if (!IsActive) return "Closed";
                if (Balance < 0) return "Overdrawn";
                if (Balance < 100) return "Low Balance";
                return "Active";
            }
        }

        public string AccountSummary =>
            $"{AccountNumber} - {AccountHolder} - {Balance:C} ({AccountStatus})";

        // Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number is required");
            if (string.IsNullOrWhiteSpace(accountHolder))
                throw new ArgumentException("Account holder name is required");
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");

            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            CreatedDate = DateTime.Now;
            _transactions = new List<Transaction>();

            if (initialBalance > 0)
            {
                Balance = initialBalance;
                _transactions.Add(new Transaction(TransactionType.Deposit, initialBalance, "Initial deposit"));
            }
        }

        // Methods that modify properties
        public bool Deposit(decimal amount, string description = "Deposit")
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return false;
            }

            if (!IsActive)
            {
                Console.WriteLine("Cannot deposit to inactive account");
                return false;
            }

            Balance += amount;
            _transactions.Add(new Transaction(TransactionType.Deposit, amount, description));

            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public bool Withdraw(decimal amount, string description = "Withdrawal")
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive");
                return false;
            }

            if (!IsActive)
            {
                Console.WriteLine("Cannot withdraw from inactive account");
                return false;
            }

            if (amount > Balance)
            {
                Console.WriteLine($"Insufficient funds. Available: {Balance:C}");
                return false;
            }

            Balance -= amount;
            _transactions.Add(new Transaction(TransactionType.Withdrawal, amount, description));

            Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public void CloseAccount()
        {
            IsActive = false;
            Console.WriteLine($"Account {AccountNumber} has been closed");
        }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }

    public class Transaction
    {
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Timestamp { get; }

        public Transaction(TransactionType type, decimal amount, string description)
        {
            Type = type;
            Amount = amount;
            Description = description;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            var sign = Type == TransactionType.Deposit ? "+" : "-";
            return $"{Timestamp:yyyy-MM-dd HH:mm} | {Type} | {sign}{Amount:C} | {Description}";
        }
    }
}
```

### Task 3: Property-Based Design Pattern
Create `Models/Configuration.cs`:
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_7.Models
{
    public class ApplicationConfiguration
    {
        private readonly Dictionary<string, object> _settings;

        // Indexer property
        public object this[string key]
        {
            get => _settings.TryGetValue(key, out var value) ? value : null!;
            set => _settings[key] = value!;
        }

        // Strongly-typed properties for common settings
        public string ApplicationName
        {
            get => GetSetting<string>("ApplicationName") ?? "My .NET Application";
            set => SetSetting("ApplicationName", value);
        }

        public int MaxUsers
        {
            get => GetSetting<int>("MaxUsers");
            set
            {
                if (value < 1)
                    throw new ArgumentException("Max users must be at least 1");
                SetSetting("MaxUsers", value);
            }
        }

        public bool EnableLogging
        {
            get => GetSetting<bool>("EnableLogging");
            set => SetSetting("EnableLogging", value);
        }

        public TimeSpan SessionTimeout
        {
            get => TimeSpan.FromMinutes(GetSetting<int>("SessionTimeoutMinutes"));
            set => SetSetting("SessionTimeoutMinutes", (int)value.TotalMinutes);
        }

        // Computed properties
        public int SettingsCount => _settings.Count;
        public IEnumerable<string> SettingKeys => _settings.Keys;

        public ApplicationConfiguration()
        {
            _settings = new Dictionary<string, object>();
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            ApplicationName = "My .NET Application";
            MaxUsers = 100;
            EnableLogging = true;
            SessionTimeout = TimeSpan.FromMinutes(30);
        }

        private T GetSetting<T>(string key)
        {
            if (_settings.TryGetValue(key, out var value) && value is T typed)
                return typed;
            return default!;
        }

        private void SetSetting(string key, object value)
        {
            _settings[key] = value;
            Console.WriteLine($"Setting updated: {key} = {value}");
        }

        public void PrintConfiguration()
        {
            Console.WriteLine("\n=== Application Configuration ===");
            foreach (var setting in _settings.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{setting.Key}: {setting.Value}");
            }
            Console.WriteLine($"Total Settings: {SettingsCount}");
            Console.WriteLine("================================\n");
        }
    }
}
```

### Task 4: Main Program
Create `Program.cs`:
```csharp
using Lab1_7.Models;

Console.WriteLine("=== Properties and OOP Design Demo ===\n");

// Employee property demonstrations
Console.WriteLine("--- Employee Properties Demo ---");
var employee = new Employee(1001, "John", "Doe", 5000);
employee.Email = "john.doe@company.com";
employee.Department = "Engineering";

employee.PrintEmployeeInfo();

// Demonstrate property validation
try
{
    employee.FirstName = ""; // This will throw an exception
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation error: {ex.Message}");
}

// Demonstrate computed properties
Console.WriteLine($"Employee display name: {employee.DisplayName}");
Console.WriteLine($"Salary grade: {employee.SalaryGrade}");

// Give a raise and see property changes
employee.GiveRaise(10);
Console.WriteLine($"New salary grade: {employee.SalaryGrade}");

// Bank account property demonstrations
Console.WriteLine("\n--- Bank Account Properties Demo ---");
var account = new BankAccount("ACC-001", "Alice Johnson", 1000);

Console.WriteLine($"Account Summary: {account.AccountSummary}");
Console.WriteLine($"Account Status: {account.AccountStatus}");

// Perform transactions and observe property changes
account.Deposit(500, "Salary deposit");
account.Withdraw(200, "ATM withdrawal");
account.Withdraw(50, "Online purchase");

Console.WriteLine($"\nAccount after transactions:");
Console.WriteLine($"Balance: {account.Balance:C}");
Console.WriteLine($"Total Deposits: {account.TotalDeposits:C}");
Console.WriteLine($"Total Withdrawals: {account.TotalWithdrawals:C}");
Console.WriteLine($"Transaction Count: {account.TransactionCount}");

if (account.LastTransaction != null)
{
    Console.WriteLine($"Last Transaction: {account.LastTransaction}");
}

// Show all transactions
Console.WriteLine("\nTransaction History:");
foreach (var transaction in account.Transactions)
{
    Console.WriteLine($"  {transaction}");
}

// Configuration properties demo
Console.WriteLine("\n--- Configuration Properties Demo ---");
var config = new ApplicationConfiguration();
config.PrintConfiguration();

// Modify settings using properties
config.ApplicationName = "Advanced .NET Lab";
config.MaxUsers = 500;
config.EnableLogging = false;
config.SessionTimeout = TimeSpan.FromHours(2);

// Use indexer property
config["DatabaseConnectionString"] = "Server=localhost;Database=LabDB";
config["ApiKey"] = "abc123xyz789";

Console.WriteLine("After modifications:");
config.PrintConfiguration();

// Demonstrate property access patterns
Console.WriteLine("--- Property Access Patterns ---");
Console.WriteLine($"Direct property access: {config.ApplicationName}");
Console.WriteLine($"Indexer access: {config["DatabaseConnectionString"]}");
Console.WriteLine($"Computed property: {config.SettingsCount} settings configured");

// Show encapsulation benefits
Console.WriteLine("\n--- Encapsulation Benefits ---");
Console.WriteLine("✓ Data validation in property setters");
Console.WriteLine("✓ Computed values without storage overhead");
Console.WriteLine("✓ Controlled access to internal state");
Console.WriteLine("✓ Side effects (logging, notifications) in setters");
Console.WriteLine("✓ Read-only properties for immutable data");

// Demonstrate abstraction
Console.WriteLine("\n--- Abstraction Benefits ---");
Console.WriteLine("✓ Hide implementation details (private fields)");
Console.WriteLine("✓ Provide clean public interface (properties)");
Console.WriteLine("✓ Allow internal changes without breaking clients");
Console.WriteLine("✓ Express business rules through property logic");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

## Property Types Summary

| Property Type | Example | Use Case |
|---------------|---------|----------|
| Auto-Property | `public string Name { get; set; }` | Simple data storage |
| Read-Only | `public DateTime Created { get; }` | Immutable data |
| Computed | `public string FullName => $"{First} {Last}"` | Calculated values |
| Validated | `get/set with validation logic` | Data integrity |
| Private Setter | `public decimal Balance { get; private set; }` | Controlled modification |
| Indexer | `public object this[string key] { get; set; }` | Dictionary-like access |

## Expected Output
```
=== Properties and OOP Design Demo ===

--- Employee Properties Demo ---

=== Employee Information ===
ID: 1001
Name: John Doe
Email: john.doe@company.com
Department: Engineering
Hire Date: 2024-01-15
Years of Service: 0
Monthly Salary: $5,000.00
Annual Salary: $60,000.00
Salary Grade: Mid Level
Status: Active
============================

Validation error: First name cannot be empty
Employee display name: John Doe (1001)
Salary grade: Mid Level
John Doe received a 10% raise
Salary increased from $5,000.00 to $5,500.00 per month
New salary grade: Mid Level
```

## Key Takeaways
- Properties provide controlled access to object data
- Validation in setters ensures data integrity
- Computed properties eliminate redundant storage
- Read-only properties protect immutable data
- Encapsulation hides implementation details
- Abstraction provides clean public interfaces

## Challenge Exercise
Create a `ShoppingCart` class with properties for items, total cost, tax rate, and shipping cost. Include computed properties for subtotal, tax amount, and final total.

## Next Lab
Lab 1.8 will explore linting and code analysis tools.
