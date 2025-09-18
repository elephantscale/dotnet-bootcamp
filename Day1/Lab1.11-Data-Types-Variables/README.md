# Lab 1.11: Data Types, Variables, and Scope

## Objective
Master .NET data types, variable declarations, the 'this' keyword, and understand scope rules.

## Duration: 45 minutes

## Theory
- **Value Types**: Stored on stack, contain actual data (int, double, bool, struct)
- **Reference Types**: Stored on heap, contain references (string, class, array)
- **Variable Scope**: Determines where variables can be accessed
- **'this' Keyword**: References the current instance of a class

## Exercise

### Part A: Data Types and Variables (20 minutes)
Explore different data types and their characteristics.

### Part B: Scope and Lifetime (15 minutes)
Understand variable scope rules and lifetime.

### Part C: 'this' Keyword Usage (10 minutes)
Learn proper usage of the 'this' keyword.

## Hands-On Tasks

### Task 1: Data Types Exploration
Create `DataTypesDemo.cs`:
```csharp
using System;

namespace Lab1_11
{
    public class DataTypesDemo
    {
        // Class-level variables (fields)
        private int classField = 100;
        private static int staticField = 200;

        public void DemonstrateValueTypes()
        {
            Console.WriteLine("=== Value Types Demo ===\n");

            // Integer types
            byte  byteValue  = 255;                  // 0 to 255
            sbyte sbyteValue = -128;                 // -128 to 127
            short shortValue = -32768;               // -32,768 to 32,767
            ushort ushortValue = 65535;              // 0 to 65,535
            int   intValue   = int.MinValue;         // use constant to avoid literal overflow
            uint  uintValue  = 4294967295;           // 0 to 4,294,967,295
            long  longValue  = long.MinValue;        // use constant to avoid literal overflow
            ulong ulongValue = 18446744073709551615UL;

            Console.WriteLine($"byte: {byteValue} (size: {sizeof(byte)} bytes)");
            Console.WriteLine($"sbyte: {sbyteValue} (size: {sizeof(sbyte)} bytes)");
            Console.WriteLine($"short: {shortValue} (size: {sizeof(short)} bytes)");
            Console.WriteLine($"ushort: {ushortValue} (size: {sizeof(ushort)} bytes)");
            Console.WriteLine($"int: {intValue} (size: {sizeof(int)} bytes)");
            Console.WriteLine($"uint: {uintValue} (size: {sizeof(uint)} bytes)");
            Console.WriteLine($"long: {longValue} (size: {sizeof(long)} bytes)");
            Console.WriteLine($"ulong: {ulongValue} (size: {sizeof(ulong)} bytes)");

            // Floating-point types
            float   floatValue   = 3.14159f;             // ~7 digits precision
            double  doubleValue  = 3.141592653589793;    // ~15-17 digits precision
            decimal decimalValue = 3.141592653589793238462643383279m; // ~28-29 digits

            Console.WriteLine($"\nfloat: {floatValue} (size: {sizeof(float)} bytes)");
            Console.WriteLine($"double: {doubleValue} (size: {sizeof(double)} bytes)");
            Console.WriteLine($"decimal: {decimalValue} (size: {sizeof(decimal)} bytes)");

            // Other value types
            bool     boolValue = true;
            char     charValue = 'A';
            DateTime dateValue = DateTime.Now;

            Console.WriteLine($"\nbool: {boolValue} (size: {sizeof(bool)} bytes)");
            Console.WriteLine($"char: '{charValue}' (size: {sizeof(char)} bytes)");
            Console.WriteLine($"DateTime: {dateValue}");

            // Nullable value types
            int?    nullableInt    = null;
            double? nullableDouble = 3.14;

            Console.WriteLine($"\nNullable int (null): {nullableInt?.ToString() ?? "NULL"}");
            Console.WriteLine($"Nullable double: {nullableDouble}");
            Console.WriteLine($"Has value: {nullableDouble.HasValue}");
            Console.WriteLine($"Value: {nullableDouble.Value}");
        }

        public void DemonstrateReferenceTypes()
        {
            Console.WriteLine("\n=== Reference Types Demo ===\n");

            // String (reference type but immutable)
            string  stringValue = "Hello, World!";
            string? nullString  = null;

            Console.WriteLine($"String: '{stringValue}'");
            Console.WriteLine($"Null string: {nullString ?? "NULL"}");

            // Arrays (reference types)
            int[]    intArray    = { 1, 2, 3, 4, 5 };
            string[] stringArray = new string[3] { "A", "B", "C" };

            Console.WriteLine($"Int array: [{string.Join(", ", intArray)}]");
            Console.WriteLine($"String array: [{string.Join(", ", stringArray)}]");

            // Object type (base of all types)
            object objectValue = 42;
            object objectString = "This is a string in object";
            object objectArray = new int[] { 1, 2, 3 };

            Console.WriteLine($"Object (int): {objectValue} (actual type: {objectValue.GetType().Name})");
            Console.WriteLine($"Object (string): {objectString} (actual type: {objectString.GetType().Name})");
            Console.WriteLine($"Object (array): {objectArray.GetType().Name}");
        }

        public void DemonstrateVariableDeclarations()
        {
            Console.WriteLine("\n=== Variable Declarations Demo ===\n");

            // Explicit type declaration
            int    explicitInt    = 42;
            string explicitString = "Explicit";

            // Implicit type declaration (var keyword)
            var implicitInt   = 42;              // Compiler infers int
            var implicitString = "Implicit";     // Compiler infers string
            var implicitArray  = new[] { 1, 2, 3 }; // Compiler infers int[]

            Console.WriteLine($"Explicit int: {explicitInt} (type: {explicitInt.GetType().Name})");
            Console.WriteLine($"Implicit int: {implicitInt} (type: {implicitInt.GetType().Name})");
            Console.WriteLine($"Explicit string: {explicitString} (type: {explicitString.GetType().Name})");
            Console.WriteLine($"Implicit string: {implicitString} (type: {implicitString.GetType().Name})");
            Console.WriteLine($"Implicit array: [{string.Join(", ", implicitArray)}] (type: {implicitArray.GetType().Name})");

            // Constants
            const double PI = 3.14159;
            const string COMPANY_NAME = "My Company";

            Console.WriteLine($"Constant PI: {PI}");
            Console.WriteLine($"Constant Company: {COMPANY_NAME}");

            // Default values
            int      defaultInt    = default; // 0
            bool     defaultBool   = default; // false
            string?  defaultString = default; // null
            DateTime defaultDate   = default; // 1/1/0001 12:00:00 AM

            Console.WriteLine($"Default int: {defaultInt}");
            Console.WriteLine($"Default bool: {defaultBool}");
            Console.WriteLine($"Default string: {defaultString ?? "NULL"}");
            Console.WriteLine($"Default DateTime: {defaultDate}");
        }

        public void DemonstrateScopeRules()
        {
            Console.WriteLine("\n=== Scope Rules Demo ===\n");

            // Method-level variable
            int methodVariable = 10;
            Console.WriteLine($"Method variable: {methodVariable}");
            Console.WriteLine($"Class field: {classField}");
            Console.WriteLine($"Static field: {staticField}");

            // Block scope
            {
                int blockVariable = 20;
                Console.WriteLine($"Inside block - Block variable: {blockVariable}");
                Console.WriteLine($"Inside block - Method variable: {methodVariable}");

                // No illegal shadowing: use a different name
                int innerMethodVariable = 30;
                Console.WriteLine($"Inside block - Inner method variable: {innerMethodVariable}");
            }
            Console.WriteLine($"Outside block - Method variable: {methodVariable}");

            // Loop scope
            for (int i = 0; i < 3; i++)
            {
                int loopVariable = i * 10;
                Console.WriteLine($"Loop iteration {i}: loop variable = {loopVariable}");
            }

            // Conditional scope
            if (methodVariable > 5)
            {
                int conditionalVariable = 40;
                Console.WriteLine($"Inside if - Conditional variable: {conditionalVariable}");
            }
        }

        public void DemonstrateThisKeyword(int classField)
        {
            Console.WriteLine("\n=== 'this' Keyword Demo ===\n");

            // Parameter shadows class field
            Console.WriteLine($"Parameter classField: {classField}");
            Console.WriteLine($"Class field (this.classField): {this.classField}");

            // Using 'this' to call other methods
            this.PrintInstanceInfo();
            PrintInstanceInfo(); // Same as this.PrintInstanceInfo()
        }

        private void PrintInstanceInfo()
        {
            Console.WriteLine($"Instance method called. Class field value: {classField}");
        }

        // Static method cannot use 'this'
        public static void StaticMethodDemo()
        {
            Console.WriteLine($"Static method. Static field value: {staticField}");
        }
    }

    // Demonstrate struct (value type)
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
        public override string ToString() => $"({X}, {Y})";
    }

    // Demonstrate class (reference type)
    public class Circle
    {
        private double radius;

        public double Radius
        {
            get => radius;
            set => radius = value > 0 ? value : throw new ArgumentException("Radius must be positive");
        }

        public Circle(double radius)
        {
            this.Radius = radius; // 'this' clarifies we're setting the property
        }

        public double Area => Math.PI * radius * radius;
        public double Circumference => 2 * Math.PI * radius;

        public void PrintInfo()
        {
            Console.WriteLine($"Circle - Radius: {this.Radius}, Area: {this.Area:F2}, Circumference: {this.Circumference:F2}");
        }
    }
}
```

### Task 2: Main Program
Create `Program.cs`:
```csharp
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
object boxedValue = valueType;        // Boxing: value type -> reference type
int unboxedValue = (int)boxedValue;   // Unboxing: reference type -> value type

Console.WriteLine($"Original value: {valueType}");
Console.WriteLine($"Boxed value: {boxedValue}");
Console.WriteLine($"Unboxed value: {unboxedValue}");
Console.WriteLine($"Are they equal: {valueType == unboxedValue}");

// Type checking
Console.WriteLine($"valueType runtime type: {valueType.GetType().Name}");
Console.WriteLine($"boxedValue is int: {boxedValue is int}");
Console.WriteLine($"boxedValue is object: {boxedValue is object}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

## Key Concepts Summary

### Data Types
| Category | Types | Storage | Default |
|----------|-------|---------|---------|
| Integer | byte, short, int, long | Stack | 0 |
| Floating | float, double, decimal | Stack | 0.0 |
| Boolean | bool | Stack | false |
| Character | char | Stack | '\0' |
| Reference | string, class, array | Heap | null |

### Variable Scope Rules
1. **Class Level**: Accessible throughout the class
2. **Method Level**: Accessible within the method
3. **Block Level**: Accessible within the block {}
4. **Loop Level**: Accessible within the loop
5. **Parameter Level**: Accessible within the method

### 'this' Keyword Usage
- Reference current instance
- Resolve naming conflicts
- Call other constructors
- Pass current instance as parameter

## Expected Output
```
=== Data Types, Variables, and Scope Demo ===

=== Value Types Demo ===

byte: 255 (size: 1 bytes)
sbyte: -128 (size: 1 bytes)
short: -32768 (size: 2 bytes)
ushort: 65535 (size: 2 bytes)
int: -2147483648 (size: 4 bytes)
uint: 4294967295 (size: 4 bytes)
long: -9223372036854775808 (size: 8 bytes)
ulong: 18446744073709551615 (size: 8 bytes)
```

## Key Takeaways
- Value types store data directly, reference types store references
- Variable scope determines accessibility and lifetime
- 'this' keyword references the current instance
- Nullable types allow value types to be null
- Boxing/unboxing converts between value and reference types
- Use appropriate data types for memory efficiency

## Challenge Exercise
Create a `Temperature` struct that can store temperature in Celsius and provide properties for Fahrenheit and Kelvin conversions. Demonstrate value type behavior vs a `TemperatureLogger` class that tracks temperature readings.

## Next Lab
Lab 1.12 will explore operators, statements, and expressions.
