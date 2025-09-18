# Lab 1.5: Classes, Structures, and Objects

## Objective
Understand the fundamental building blocks of object-oriented programming in .NET: classes, structures, and objects.

## Duration: 45 minutes

## Theory
- **Classes**: Reference types that define blueprints for objects
- **Structures**: Value types that are typically used for simple data
- **Objects**: Instances of classes created in memory
- **OOP Design**: Encapsulation, inheritance, polymorphism, and abstraction

## Exercise

### Part A: Classes vs Structures (15 minutes)
Create and compare classes and structures to understand their differences.

### Part B: Object Creation and Management (20 minutes)
Work with object instantiation, initialization, and lifecycle.

### Part C: OOP Design Principles (10 minutes)
Apply basic OOP principles in practical examples.

## Hands-On Tasks

### Task 1: Create a Class
Create `Models/Vehicle.cs`:
```csharp
using System;

namespace Lab1_5.Models
{
    public class Vehicle
    {
        // Fields (private data)
        private string _make = "";
        private string _model = "";
        private int _year;
        private decimal _price;

        // Properties (public interface)
        public string Make
        {
            get => _make;
            set => _make = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Year
        {
            get => _year;
            set => _year = value > 1885 ? value : throw new ArgumentException("Year must be after 1885");
        }

        public decimal Price
        {
            get => _price;
            set => _price = value >= 0 ? value : throw new ArgumentException("Price cannot be negative");
        }

        // Auto-implemented properties
        public string Color { get; set; } = "White";
        public bool IsRunning { get; private set; }

        // Constructor
        public Vehicle(string make, string model, int year, decimal price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            IsRunning = false;
        }

        // Methods
        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine($"{Make} {Model} is now running.");
            }
            else
            {
                Console.WriteLine($"{Make} {Model} is already running.");
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Console.WriteLine($"{Make} {Model} has stopped.");
            }
            else
            {
                Console.WriteLine($"{Make} {Model} is already stopped.");
            }
        }

        public string GetVehicleInfo()
        {
            // {Price:C} already includes the currency symbol for the current culture
            return $"{Year} {Make} {Model} - {Price:C} ({Color})";
        }

        public void Honk() => Console.WriteLine($"{Make} {Model}: Beep! Beep!");

        public override string ToString() => GetVehicleInfo();
    }
}
```

### Task 2: Create a Structure
Create `Models/Point.cs`:
```csharp
using System;

namespace Lab1_5.Models
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);

        public double DistanceTo(Point other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public Point MoveBy(double deltaX, double deltaY) => new Point(X + deltaX, Y + deltaY);

        public override string ToString() => $"({X}, {Y})";

        public override bool Equals(object? obj) => obj is Point p && X == p.X && Y == p.Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static Point Origin => new Point(0, 0);
        public static double Distance(Point p1, Point p2) => p1.DistanceTo(p2);
    }
}
```

### Task 3: Demonstrate Classes vs Structures
Create `Program.cs`:
```csharp
using Lab1_5.Models;

Console.WriteLine("=== Classes vs Structures Demo ===\n");

// ----- Classes (Reference Types)
Console.WriteLine("--- Classes (Reference Types) ---");
Vehicle car1 = new Vehicle("Toyota", "Camry", 2023, 25000);
Vehicle car2 = car1; // both variables reference the same object

Console.WriteLine($"Car1: {car1}");
Console.WriteLine($"Car2: {car2}");

car1.Color = "Red";
Console.WriteLine($"\nAfter changing car1.Color to Red:");
Console.WriteLine($"Car1: {car1}");
Console.WriteLine($"Car2: {car2}"); // also shows Red (same object)

// ----- Structures (Value Types)
Console.WriteLine("\n--- Structures (Value Types) ---");
Point point1 = new Point(3, 4);
Point point2 = point1; // copied values

Console.WriteLine($"Point1: {point1}");
Console.WriteLine($"Point2: {point2}");

point1.X = 10;
Console.WriteLine($"\nAfter changing point1.X to 10:");
Console.WriteLine($"Point1: {point1}");
Console.WriteLine($"Point2: {point2}"); // unchanged copy

// ----- Object lifecycle & methods
Console.WriteLine("\n--- Object Methods and Lifecycle ---");
Vehicle[] vehicles =
{
    new Vehicle("Honda", "Civic",   2022, 22000) { Color = "Blue"  },
    new Vehicle("Ford",  "Mustang", 2023, 35000) { Color = "Black" },
    new Vehicle("Tesla", "Model 3", 2023, 40000) { Color = "White" }
};

foreach (var v in vehicles)
{
    Console.WriteLine($"\nVehicle: {v}");
    v.Start();
    v.Honk();
    v.Stop();
}

// ----- Point calculations
Console.WriteLine("\n--- Point Calculations ---");
Point origin = Point.Origin;
Point p1 = new Point(3, 4);
Point p2 = new Point(6, 8);

Console.WriteLine($"Origin: {origin}");
Console.WriteLine($"P1: {p1}");
Console.WriteLine($"P2: {p2}");
Console.WriteLine($"Distance from P1 to origin: {p1.DistanceFromOrigin():F2}");
Console.WriteLine($"Distance from P1 to P2: {p1.DistanceTo(p2):F2}");
Console.WriteLine($"Distance using static method: {Point.Distance(p1, p2):F2}");

Point p3 = p1.MoveBy(2, 3);
Console.WriteLine($"P1 moved by (2,3): {p3}");

// ----- Encapsulation (with exceptions)
Console.WriteLine("\n--- Encapsulation Demo ---");
try
{
    Vehicle invalid = new Vehicle("", "Test", 1800, -5000);
}
catch (Exception ex)
{
    Console.WriteLine($"Error creating invalid vehicle: {ex.Message}");
}

// Optional: quick BankAccount demo
var acct = new BankAccount("Ada Lovelace", "ACCT-001", 1000);
acct.Deposit(250);
acct.Withdraw(90);
acct.PrintStatement();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

### Task 4: Advanced Object Concepts
Create `Models/BankAccount.cs` to demonstrate encapsulation:
```csharp
using System;
using System.Collections.Generic;

namespace Lab1_5.Models
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly string _accountNumber;
        private readonly List<string> _transactionHistory;

        public string AccountNumber => _accountNumber;
        public decimal Balance => _balance;
        public string AccountHolder { get; }
        public DateTime CreatedDate { get; }

        public BankAccount(string accountHolder, string accountNumber, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accountHolder))
                throw new ArgumentException("Account holder name is required");
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number is required");
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");

            AccountHolder = accountHolder;
            _accountNumber = accountNumber;
            _balance = initialBalance;
            CreatedDate = DateTime.Now;
            _transactionHistory = new List<string>();

            if (initialBalance > 0)
                _transactionHistory.Add($"{DateTime.Now}: Initial deposit of {initialBalance:C}");
        }

        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return false;
            }

            _balance += amount;
            _transactionHistory.Add($"{DateTime.Now}: Deposit of {amount:C}. New balance: {Balance:C}");
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive");
                return false;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }

            _balance -= amount;
            _transactionHistory.Add($"{DateTime.Now}: Withdrawal of {amount:C}. New balance: {Balance:C}");
            Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public void PrintStatement()
        {
            Console.WriteLine($"\n=== Account Statement ===");
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Current Balance: {Balance:C}");
            Console.WriteLine($"Account Created: {CreatedDate:yyyy-MM-dd}");
            Console.WriteLine("\nTransaction History:");
            foreach (var t in _transactionHistory)
                Console.WriteLine($"  {t}");
            Console.WriteLine("========================\n");
        }
    }
}
```

## Key Differences: Classes vs Structures

| Aspect | Classes | Structures |
|--------|---------|------------|
| Type | Reference Type | Value Type |
| Memory | Heap | Stack (usually) |
| Assignment | Reference copy | Value copy |
| Inheritance | Supports inheritance | No inheritance |
| Default constructor | Can define custom | Always has default |
| Null values | Can be null | Cannot be null |
| Performance | Slower allocation | Faster allocation |
| Use case | Complex objects | Simple data containers |

## Expected Output
```
=== Classes vs Structures Demo ===

--- Classes (Reference Types) ---
Car1: 2023 Toyota Camry - $25,000.00 (White)
Car2: 2023 Toyota Camry - $25,000.00 (White)

After changing car1.Color to Red:
Car1: 2023 Toyota Camry - $25,000.00 (Red)
Car2: 2023 Toyota Camry - $25,000.00 (Red)

--- Structures (Value Types) ---
Point1: (3, 4)
Point2: (3, 4)

After changing point1.X to 10:
Point1: (10, 4)
Point2: (3, 4)
```

## Key Takeaways
- Classes are reference types; structures are value types
- Objects encapsulate data and behavior
- Properties provide controlled access to private fields
- Constructors initialize object state
- Methods define object behavior
- Encapsulation protects object integrity

## Challenge Exercise
Create a `Rectangle` class and a `Size` structure. The Rectangle should use Size for its dimensions and provide methods for calculating area and perimeter.

## Next Lab
Lab 1.6 will explore enums and methods in detail.
