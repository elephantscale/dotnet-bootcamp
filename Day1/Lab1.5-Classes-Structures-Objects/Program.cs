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