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
    employee.FirstName = ""; // will throw
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Validation error: {ex.Message}");
}

// Computed properties
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

// Encapsulation & Abstraction notes
Console.WriteLine("\n--- Encapsulation Benefits ---");
Console.WriteLine("✓ Data validation in property setters");
Console.WriteLine("✓ Computed values without storage overhead");
Console.WriteLine("✓ Controlled access to internal state");
Console.WriteLine("✓ Side effects (logging, notifications) in setters");
Console.WriteLine("✓ Read-only properties for immutable data");

Console.WriteLine("\n--- Abstraction Benefits ---");
Console.WriteLine("✓ Hide implementation details (private fields)");
Console.WriteLine("✓ Provide clean public interface (properties)");
Console.WriteLine("✓ Allow internal changes without breaking clients");
Console.WriteLine("✓ Express business rules through property logic");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();