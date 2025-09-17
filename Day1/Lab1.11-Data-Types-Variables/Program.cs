using Lab1_11;

Console.WriteLine("=== Data Types, Variables, and Scope Demo ===\n");

var demo = new DataTypesDemo();

// Demonstrate different data types
demo.DemonstrateValueTypes();
demo.DemonstrateReferenceTypes();
demo.DemonstrateVariableDeclarations();
demo.DemonstrateScopeRules();
demo.DemonstrateThisKeyword(999);

// Static method call
DataTypesDemo.StaticMethodDemo();

// Value type vs Reference type behavior
Console.WriteLine("\n=== Value vs Reference Type Behavior ===\n");

// Value types
Point point1 = new Point(3, 4);
Point point2 = point1; // Copy of values
point2.X = 10;

Console.WriteLine($"Point1: {point1}"); // (3, 4) - unchanged
Console.WriteLine($"Point2: {point2}"); // (10, 4) - changed

// Reference types
Circle circle1 = new Circle(5);
Circle circle2 = circle1; // Copy of reference
circle2.Radius = 10;

Console.WriteLine("Circle1:");
circle1.PrintInfo(); // Radius: 10 - changed because both variables reference the same object
Console.WriteLine("Circle2:");
circle2.PrintInfo(); // Radius: 10 - same object

// Demonstrate boxing and unboxing
Console.WriteLine("\n=== Boxing and Unboxing Demo ===");

int valueType = 42;
object boxedValue = valueType;    // Boxing: value type -> reference type
int unboxedValue = (int)boxedValue; // Unboxing: reference type -> value type

Console.WriteLine($"Original value: {valueType}");
Console.WriteLine($"Boxed value: {boxedValue}");
Console.WriteLine($"Unboxed value: {unboxedValue}");
Console.WriteLine($"Are they equal: {valueType == unboxedValue}");

// Type checking
// Console.WriteLine($"valueType is int: {valueType is int}");
Console.WriteLine($"valueType runtime type: {valueType.GetType().Name}");
Console.WriteLine($"boxedValue is int: {boxedValue is int}");
Console.WriteLine($"boxedValue is object: {boxedValue is object}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();