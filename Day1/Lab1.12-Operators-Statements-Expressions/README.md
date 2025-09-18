# Lab 1.12: Operators, Statements, and Expressions

## Objective
Master C# operators, understand the difference between statements and expressions, and learn operator precedence.

## Duration: 45 minutes

## Theory
- **Operators**: Symbols that perform operations on operands
- **Expressions**: Combinations of operands and operators that evaluate to a value
- **Statements**: Complete instructions that perform actions
- **Operator Precedence**: Order in which operators are evaluated

## Exercise

### Part A: Arithmetic and Assignment Operators (15 minutes)
Explore basic mathematical and assignment operations.

### Part B: Comparison and Logical Operators (15 minutes)
Work with boolean logic and comparisons.

### Part C: Advanced Operators and Precedence (15 minutes)
Learn bitwise, null-coalescing, and other specialized operators.

## Hands-On Tasks

### Task 1: Arithmetic Operators
Create `ArithmeticOperators.cs`:
```csharp
using System;

namespace Lab1_12
{
    public static class ArithmeticOperators
    {
        public static void DemonstrateBasicArithmetic()
        {
            Console.WriteLine("=== Basic Arithmetic Operators ===\n");

            int a = 15, b = 4;
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"Addition (a + b): {a + b}");
            Console.WriteLine($"Subtraction (a - b): {a - b}");
            Console.WriteLine($"Multiplication (a * b): {a * b}");
            Console.WriteLine($"Division (a / b): {a / b}");
            Console.WriteLine($"Division (a / (double)b): {a / (double)b}");
            Console.WriteLine($"Modulus (a % b): {a % b}");

            // Unary operators
            Console.WriteLine($"\nUnary plus (+a): {+a}");
            Console.WriteLine($"Unary minus (-a): {-a}");
            Console.WriteLine($"Pre-increment (++a): {++a}");
            Console.WriteLine($"Post-increment (a++): {a++}");
            Console.WriteLine($"Current value of a: {a}");
            Console.WriteLine($"Pre-decrement (--a): {--a}");
            Console.WriteLine($"Post-decrement (a--): {a--}");
            Console.WriteLine($"Final value of a: {a}");
        }

        public static void DemonstrateAssignmentOperators()
        {
            Console.WriteLine("\n=== Assignment Operators ===\n");

            int x = 10;
            Console.WriteLine($"Initial x: {x}");

            x += 5;  // x = x + 5
            Console.WriteLine($"After x += 5: {x}");

            x -= 3;  // x = x - 3
            Console.WriteLine($"After x -= 3: {x}");

            x *= 2;  // x = x * 2
            Console.WriteLine($"After x *= 2: {x}");

            x /= 4;  // x = x / 4
            Console.WriteLine($"After x /= 4: {x}");

            x %= 3;  // x = x % 3
            Console.WriteLine($"After x %= 3: {x}");

            // Null-coalescing assignment (C# 8+)
            string? text = null;
            text ??= "Default Value";
            Console.WriteLine($"After text ??= 'Default Value': {text}");

            text ??= "Another Value";
            Console.WriteLine($"After second ??= assignment: {text}");
        }

        public static void DemonstrateStringOperators()
        {
            Console.WriteLine("\n=== String Operators ===\n");

            string first = "Hello";
            string second = "World";

            // Concatenation
            string result = first + " " + second;
            Console.WriteLine($"Concatenation: {result}");

            // Interpolation
            string interpolated = $"{first} {second}!";
            Console.WriteLine($"Interpolation: {interpolated}");

            // Comparison
            Console.WriteLine($"first == second: {first == second}");
            Console.WriteLine($"first != second: {first != second}");

            // With numbers
            string numberStr = "Value: " + 42;
            Console.WriteLine($"String + number: {numberStr}");
        }
    }
}

```

### Task 2: Comparison and Logical Operators
Create `ComparisonLogicalOperators.cs`:
```csharp
using System;

namespace Lab1_12
{
    public static class ComparisonLogicalOperators
    {
        public static void DemonstrateComparisonOperators()
        {
            Console.WriteLine("=== Comparison Operators ===\n");

            int a = 10, b = 20, c = 10;
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            Console.WriteLine($"a == b: {a == b}");
            Console.WriteLine($"a == c: {a == c}");
            Console.WriteLine($"a != b: {a != b}");
            Console.WriteLine($"a < b: {a < b}");
            Console.WriteLine($"a > b: {a > b}");
            Console.WriteLine($"a <= c: {a <= c}");
            Console.WriteLine($"b >= a: {b >= a}");

            // Strings
            string str1 = "apple", str2 = "banana", str3 = "apple";
            Console.WriteLine($"\nString comparisons:");
            Console.WriteLine($"str1 = '{str1}', str2 = '{str2}', str3 = '{str3}'");
            Console.WriteLine($"str1 == str2: {str1 == str2}");
            Console.WriteLine($"str1 == str3: {str1 == str3}");
            Console.WriteLine($"str1.CompareTo(str2): {str1.CompareTo(str2)}"); // <0 since apple < banana
        }

        public static void DemonstrateLogicalOperators()
        {
            Console.WriteLine("\n=== Logical Operators ===\n");

            bool p = true, q = false;
            Console.WriteLine($"p = {p}, q = {q}");

            // Short-circuiting logical
            Console.WriteLine($"p && q: {p && q}");
            Console.WriteLine($"p && true: {p && true}");
            Console.WriteLine($"p || q: {p || q}");
            Console.WriteLine($"q || false: {q || false}");
            Console.WriteLine($"!p: {!p}");
            Console.WriteLine($"!q: {!q}");

            Console.WriteLine("\nShort-circuit evaluation:");
            Console.WriteLine($"false && SomeMethod(): {false && SomeExpensiveMethod()}"); // RHS not evaluated
            Console.WriteLine($"true || SomeMethod(): {true || SomeExpensiveMethod()}");   // RHS not evaluated

            // Non-short-circuit bitwise logical on bools
            Console.WriteLine($"\nBitwise logical (no short-circuit):");
            Console.WriteLine($"p & q: {p & q}");
            Console.WriteLine($"p | q: {p | q}");
            Console.WriteLine($"p ^ q: {p ^ q}"); // XOR
        }

        private static bool SomeExpensiveMethod()
        {
            Console.WriteLine("  SomeExpensiveMethod() was called!");
            return true;
        }

        public static void DemonstrateConditionalOperator()
        {
            Console.WriteLine("\n=== Conditional (Ternary) Operator ===\n");

            int age = 18;
            string status = age >= 18 ? "Adult" : "Minor";
            Console.WriteLine($"Age: {age}, Status: {status}");

            int score = 85;
            string grade = score >= 90 ? "A" :
                           score >= 80 ? "B" :
                           score >= 70 ? "C" :
                           score >= 60 ? "D" : "F";
            Console.WriteLine($"Score: {score}, Grade: {grade}");

            // Null-conditional
            string? nullableString = null;
            int? length = nullableString?.Length;
            Console.WriteLine($"Nullable string length: {length?.ToString() ?? "null"}");

            nullableString = "Hello";
            length = nullableString?.Length;
            Console.WriteLine($"String '{nullableString}' length: {length}");
        }
    }
}

```

### Task 3: Advanced Operators
Create `AdvancedOperators.cs`:
```csharp
using System;
using System.Collections.Generic;

namespace Lab1_12
{
    public static class AdvancedOperators
    {
        public static void DemonstrateBitwiseOperators()
        {
            Console.WriteLine("=== Bitwise Operators ===\n");

            int a = 12;  // 1100
            int b = 10;  // 1010

            Console.WriteLine($"a = {a} (binary: {Convert.ToString(a, 2).PadLeft(8, '0')})");
            Console.WriteLine($"b = {b} (binary: {Convert.ToString(b, 2).PadLeft(8, '0')})");

            int andResult = a & b;
            int orResult  = a | b;
            int xorResult = a ^ b;
            int notResult = ~a;

            Console.WriteLine($"a & b = {andResult} (binary: {Convert.ToString(andResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a | b = {orResult}  (binary: {Convert.ToString(orResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a ^ b = {xorResult} (binary: {Convert.ToString(xorResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"~a    = {notResult} (binary: {Convert.ToString(notResult, 2)})");

            int leftShift  = a << 2;
            int rightShift = a >> 1;

            Console.WriteLine($"a << 2 = {leftShift}  (binary: {Convert.ToString(leftShift, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a >> 1 = {rightShift} (binary: {Convert.ToString(rightShift, 2).PadLeft(8, '0')})");
        }

        public static void DemonstrateNullOperators()
        {
            Console.WriteLine("\n=== Null-Related Operators ===\n");

            string? nullableString = null;
            string nonNullString = "Hello";

            // ?? and ??=
            string result1 = nullableString ?? "Default";
            string result2 = nonNullString ?? "Default";
            Console.WriteLine($"null ?? 'Default': {result1}");
            Console.WriteLine($"'Hello' ?? 'Default': {result2}");

            nullableString ??= "Assigned Default";
            Console.WriteLine($"After ??= assignment: {nullableString}");

            // ?.
            string? testString = null;
            int? length1 = testString?.Length;
            Console.WriteLine($"null?.Length: {length1?.ToString() ?? "null"}");

            testString = "Test";
            int? length2 = testString?.Length;
            Console.WriteLine($"'Test'?.Length: {length2}");

            // With arrays
            int[]? numbers = null;
            int? firstElement = numbers?[0];
            Console.WriteLine($"null array?[0]: {firstElement?.ToString() ?? "null"}");

            numbers = new int[] { 1, 2, 3 };
            firstElement = numbers?[0];
            Console.WriteLine($"array?[0]: {firstElement}");
        }

        public static void DemonstrateTypeOperators()
        {
            Console.WriteLine("\n=== Type Operators ===\n");

            object[] objects = { 42, "Hello", 3.14, true, new List<int>() };

            foreach (var obj in objects)
            {
                Console.WriteLine($"Object: {obj}");

                // is / as
                Console.WriteLine($"  is int: {obj is int}");
                Console.WriteLine($"  is string: {obj is string}");
                Console.WriteLine($"  is double: {obj is double}");

                string? asString = obj as string;
                Console.WriteLine($"  as string: {asString ?? "null"}");

                // typeof via runtime type
                Console.WriteLine($"  typeof: {obj.GetType().Name}");

                // Pattern matching
                if (obj is int intValue)
                    Console.WriteLine($"  Integer value: {intValue}");
                else if (obj is string stringValue)
                    Console.WriteLine($"  String value: '{stringValue}'");

                Console.WriteLine();
            }
        }

        public static void DemonstrateOperatorPrecedence()
        {
            Console.WriteLine("=== Operator Precedence ===\n");

            // Default precedence
            int  result1 = 2 + 3 * 4;       // 14
            int  result2 = 10 - 4 / 2;      // 8
            bool result3 = 5 > 3 && 2 < 4;  // true

            Console.WriteLine($"2 + 3 * 4 = {result1} (multiplication first)");
            Console.WriteLine($"10 - 4 / 2 = {result2} (division first)");
            Console.WriteLine($"5 > 3 && 2 < 4 = {result3} (comparison first)");

            // Overriding with parentheses
            int  result4 = (2 + 3) * 4;     // 20
            int  result5 = (10 - 4) / 2;    // 3
            bool result6 = (5 > 3) && (2 < 4);

            Console.WriteLine($"(2 + 3) * 4 = {result4} (addition first)");
            Console.WriteLine($"(10 - 4) / 2 = {result5} (subtraction first)");
            Console.WriteLine($"(5 > 3) && (2 < 4) = {result6} (explicit grouping)");

            int a = 5, b = 3, c = 2;
            int complex = a + b * c - a / b + c; // 12
            Console.WriteLine($"Complex: {a} + {b} * {c} - {a} / {b} + {c} = {complex}");
            Console.WriteLine("Order: 3*2=6, 5/3=1, then 5+6-1+2=12");
        }
    }
}

```

### Task 4: Main Program
Create `Program.cs`:
```csharp
using System;
using Lab1_12;

Console.WriteLine("=== Operators, Statements, and Expressions Demo ===\n");

// Arithmetic operators
ArithmeticOperators.DemonstrateBasicArithmetic();
ArithmeticOperators.DemonstrateAssignmentOperators();
ArithmeticOperators.DemonstrateStringOperators();

// Comparison and logical operators
ComparisonLogicalOperators.DemonstrateComparisonOperators();
ComparisonLogicalOperators.DemonstrateLogicalOperators();
ComparisonLogicalOperators.DemonstrateConditionalOperator();

// Advanced operators
AdvancedOperators.DemonstrateBitwiseOperators();
AdvancedOperators.DemonstrateNullOperators();
AdvancedOperators.DemonstrateTypeOperators();
AdvancedOperators.DemonstrateOperatorPrecedence();

// Statements vs Expressions
Console.WriteLine("\n=== Statements vs Expressions ===\n");

// Statements
int x = 10;
Console.WriteLine("Hello");
if (x > 5) x++;

// Expressions
int sum = 5 + 3;
bool isPositive = x > 0;
string message = x > 10 ? "Large" : "Small";

Console.WriteLine($"Sum expression result: {sum}");
Console.WriteLine($"Comparison expression result: {isPositive}");
Console.WriteLine($"Conditional expression result: {message}");

// Expression-bodied local functions
static int Square(int n) => n * n;
static string GetStatus(int value) => value switch
{
    > 0 => "Positive",
    < 0 => "Negative",
    _   => "Zero"
};

Console.WriteLine($"Square(4) = {Square(4)}");
Console.WriteLine($"Status of -5: {GetStatus(-5)}");

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

## Operator Precedence Table (High to Low)

| Precedence | Operators | Description |
|------------|-----------|-------------|
| 1 | `()` `[]` `.` `?.` | Primary |
| 2 | `!` `~` `++` `--` `+` `-` | Unary |
| 3 | `*` `/` `%` | Multiplicative |
| 4 | `+` `-` | Additive |
| 5 | `<<` `>>` | Shift |
| 6 | `<` `>` `<=` `>=` `is` `as` | Relational |
| 7 | `==` `!=` | Equality |
| 8 | `&` | Logical AND |
| 9 | `^` | Logical XOR |
| 10 | `|` | Logical OR |
| 11 | `&&` | Conditional AND |
| 12 | `||` | Conditional OR |
| 13 | `??` | Null-coalescing |
| 14 | `?:` | Conditional |
| 15 | `=` `+=` `-=` etc. | Assignment |

## Expected Output
```
=== Operators, Statements, and Expressions Demo ===

=== Basic Arithmetic Operators ===

a = 15, b = 4
Addition (a + b): 19
Subtraction (a - b): 11
Multiplication (a * b): 60
Division (a / b): 3
Division (a / (double)b): 3.75
Modulus (a % b): 3
```

## Key Takeaways
- Operators perform operations on operands
- Expressions evaluate to values; statements perform actions
- Operator precedence determines evaluation order
- Use parentheses to override precedence
- Null-conditional operators provide safe navigation
- Bitwise operators work at the bit level
- Short-circuit evaluation improves performance

## Challenge Exercise
Create a calculator class that uses all operator types to perform complex mathematical expressions while handling null values and type conversions safely.

## Next Lab
Lab 1.13 will explore conditionals and loops for program flow control.
