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
            Console.WriteLine($"Division (a / b): {a / b}");           // Integer division
            Console.WriteLine($"Division (a / (double)b): {a / (double)b}"); // Floating-point division
            Console.WriteLine($"Modulus (a % b): {a % b}");           // Remainder

            // Unary operators
            Console.WriteLine($"\nUnary plus (+a): {+a}");
            Console.WriteLine($"Unary minus (-a): {-a}");
            Console.WriteLine($"Pre-increment (++a): {++a}");         // a becomes 16
            Console.WriteLine($"Post-increment (a++): {a++}");        // Returns 16, then a becomes 17
            Console.WriteLine($"Current value of a: {a}");
            Console.WriteLine($"Pre-decrement (--a): {--a}");         // a becomes 16
            Console.WriteLine($"Post-decrement (a--): {a--}");        // Returns 16, then a becomes 15
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

            // Null-coalescing assignment (C# 8.0+)
            string? text = null;
            text ??= "Default Value";  // Assign if null
            Console.WriteLine($"After text ??= 'Default Value': {text}");

            text ??= "Another Value";  // Won't assign because text is not null
            Console.WriteLine($"After second ??= assignment: {text}");
        }

        public static void DemonstrateStringOperators()
        {
            Console.WriteLine("\n=== String Operators ===\n");

            string first = "Hello";
            string second = "World";
            
            // String concatenation
            string result = first + " " + second;
            Console.WriteLine($"Concatenation: {result}");

            // String interpolation (preferred)
            string interpolated = $"{first} {second}!";
            Console.WriteLine($"Interpolation: {interpolated}");

            // String comparison
            Console.WriteLine($"first == second: {first == second}");
            Console.WriteLine($"first != second: {first != second}");

            // String with numbers
            string numberStr = "Value: " + 42;
            Console.WriteLine($"String + number: {numberStr}");
        }
    }
}
```

### Task 2: Comparison and Logical Operators
Create `ComparisonLogicalOperators.cs`:
```csharp
namespace Lab1_12
{
    public static class ComparisonLogicalOperators
    {
        public static void DemonstrateComparisonOperators()
        {
            Console.WriteLine("=== Comparison Operators ===\n");

            int a = 10, b = 20, c = 10;
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");

            Console.WriteLine($"a == b: {a == b}");     // Equal to
            Console.WriteLine($"a == c: {a == c}");
            Console.WriteLine($"a != b: {a != b}");     // Not equal to
            Console.WriteLine($"a < b: {a < b}");       // Less than
            Console.WriteLine($"a > b: {a > b}");       // Greater than
            Console.WriteLine($"a <= c: {a <= c}");     // Less than or equal to
            Console.WriteLine($"b >= a: {b >= a}");     // Greater than or equal to

            // String comparisons
            string str1 = "apple", str2 = "banana", str3 = "apple";
            Console.WriteLine($"\nString comparisons:");
            Console.WriteLine($"str1 = '{str1}', str2 = '{str2}', str3 = '{str3}'");
            Console.WriteLine($"str1 == str2: {str1 == str2}");
            Console.WriteLine($"str1 == str3: {str1 == str3}");
            Console.WriteLine($"str1.CompareTo(str2): {str1.CompareTo(str2)}"); // Lexicographic comparison
        }

        public static void DemonstrateLogicalOperators()
        {
            Console.WriteLine("\n=== Logical Operators ===\n");

            bool p = true, q = false;
            Console.WriteLine($"p = {p}, q = {q}");

            // Logical AND
            Console.WriteLine($"p && q: {p && q}");     // Both must be true
            Console.WriteLine($"p && true: {p && true}");

            // Logical OR
            Console.WriteLine($"p || q: {p || q}");     // At least one must be true
            Console.WriteLine($"q || false: {q || false}");

            // Logical NOT
            Console.WriteLine($"!p: {!p}");             // Negation
            Console.WriteLine($"!q: {!q}");

            // Short-circuit evaluation
            Console.WriteLine("\nShort-circuit evaluation:");
            Console.WriteLine($"false && SomeMethod(): {false && SomeExpensiveMethod()}"); // SomeExpensiveMethod() not called
            Console.WriteLine($"true || SomeMethod(): {true || SomeExpensiveMethod()}");   // SomeExpensiveMethod() not called

            // Bitwise logical operators (no short-circuit)
            Console.WriteLine($"\nBitwise logical (no short-circuit):");
            Console.WriteLine($"p & q: {p & q}");
            Console.WriteLine($"p | q: {p | q}");
            Console.WriteLine($"p ^ q: {p ^ q}");       // XOR (exclusive or)
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

            // Nested conditional operators
            int score = 85;
            string grade = score >= 90 ? "A" : 
                          score >= 80 ? "B" : 
                          score >= 70 ? "C" : 
                          score >= 60 ? "D" : "F";
            Console.WriteLine($"Score: {score}, Grade: {grade}");

            // Null-conditional operator
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
namespace Lab1_12
{
    public static class AdvancedOperators
    {
        public static void DemonstrateBitwiseOperators()
        {
            Console.WriteLine("=== Bitwise Operators ===\n");

            int a = 12;  // Binary: 1100
            int b = 10;  // Binary: 1010
            
            Console.WriteLine($"a = {a} (binary: {Convert.ToString(a, 2).PadLeft(8, '0')})");
            Console.WriteLine($"b = {b} (binary: {Convert.ToString(b, 2).PadLeft(8, '0')})");

            int andResult = a & b;    // Bitwise AND
            int orResult = a | b;     // Bitwise OR
            int xorResult = a ^ b;    // Bitwise XOR
            int notResult = ~a;       // Bitwise NOT (complement)

            Console.WriteLine($"a & b = {andResult} (binary: {Convert.ToString(andResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a | b = {orResult} (binary: {Convert.ToString(orResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a ^ b = {xorResult} (binary: {Convert.ToString(xorResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"~a = {notResult} (binary: {Convert.ToString(notResult, 2)})");

            // Bit shift operators
            int leftShift = a << 2;   // Left shift by 2 positions
            int rightShift = a >> 1;  // Right shift by 1 position

            Console.WriteLine($"a << 2 = {leftShift} (binary: {Convert.ToString(leftShift, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a >> 1 = {rightShift} (binary: {Convert.ToString(rightShift, 2).PadLeft(8, '0')})");
        }

        public static void DemonstrateNullOperators()
        {
            Console.WriteLine("\n=== Null-Related Operators ===\n");

            string? nullableString = null;
            string nonNullString = "Hello";

            // Null-coalescing operator (??)
            string result1 = nullableString ?? "Default";
            string result2 = nonNullString ?? "Default";
            Console.WriteLine($"null ?? 'Default': {result1}");
            Console.WriteLine($"'Hello' ?? 'Default': {result2}");

            // Null-coalescing assignment (??=)
            nullableString ??= "Assigned Default";
            Console.WriteLine($"After ??= assignment: {nullableString}");

            // Null-conditional operator (?.)
            string? testString = null;
            int? length1 = testString?.Length;
            Console.WriteLine($"null?.Length: {length1?.ToString() ?? "null"}");

            testString = "Test";
            int? length2 = testString?.Length;
            Console.WriteLine($"'Test'?.Length: {length2}");

            // Null-conditional with arrays/collections
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
                
                // 'is' operator for type checking
                Console.WriteLine($"  is int: {obj is int}");
                Console.WriteLine($"  is string: {obj is string}");
                Console.WriteLine($"  is double: {obj is double}");

                // 'as' operator for safe casting
                string? asString = obj as string;
                Console.WriteLine($"  as string: {asString ?? "null"}");

                // 'typeof' operator
                Console.WriteLine($"  typeof: {obj.GetType().Name}");

                // Pattern matching with 'is'
                if (obj is int intValue)
                {
                    Console.WriteLine($"  Integer value: {intValue}");
                }
                else if (obj is string stringValue)
                {
                    Console.WriteLine($"  String value: '{stringValue}'");
                }

                Console.WriteLine();
            }
        }

        public static void DemonstrateOperatorPrecedence()
        {
            Console.WriteLine("=== Operator Precedence ===\n");

            // Without parentheses - follows precedence rules
            int result1 = 2 + 3 * 4;        // Multiplication first: 2 + 12 = 14
            int result2 = 10 - 4 / 2;       // Division first: 10 - 2 = 8
            bool result3 = 5 > 3 && 2 < 4;  // Comparison first, then logical AND

            Console.WriteLine($"2 + 3 * 4 = {result1} (multiplication first)");
            Console.WriteLine($"10 - 4 / 2 = {result2} (division first)");
            Console.WriteLine($"5 > 3 && 2 < 4 = {result3} (comparison first)");

            // With parentheses - overrides precedence
            int result4 = (2 + 3) * 4;      // Addition first: 5 * 4 = 20
            int result5 = (10 - 4) / 2;     // Subtraction first: 6 / 2 = 3
            bool result6 = (5 > 3) && (2 < 4); // Explicit grouping

            Console.WriteLine($"(2 + 3) * 4 = {result4} (addition first)");
            Console.WriteLine($"(10 - 4) / 2 = {result5} (subtraction first)");
            Console.WriteLine($"(5 > 3) && (2 < 4) = {result6} (explicit grouping)");

            // Complex expression
            int a = 5, b = 3, c = 2;
            int complex = a + b * c - a / b + c;
            Console.WriteLine($"Complex: {a} + {b} * {c} - {a} / {b} + {c} = {complex}");
            Console.WriteLine("Order: 3*2=6, 5/3=1, then 5+6-1+2=12");
        }
    }
}
```

### Task 4: Main Program
Create `Program.cs`:
```csharp
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

// Demonstrate statements vs expressions
Console.WriteLine("\n=== Statements vs Expressions ===\n");

// Statements (perform actions, don't return values)
int x = 10;                    // Assignment statement
Console.WriteLine("Hello");   // Method call statement
if (x > 5) x++;               // Conditional statement

// Expressions (evaluate to values)
int sum = 5 + 3;              // Arithmetic expression
bool isPositive = x > 0;      // Comparison expression
string message = x > 10 ? "Large" : "Small"; // Conditional expression

Console.WriteLine($"Sum expression result: {sum}");
Console.WriteLine($"Comparison expression result: {isPositive}");
Console.WriteLine($"Conditional expression result: {message}");

// Expression-bodied members (expressions used as method bodies)
static int Square(int n) => n * n;  // Expression-bodied method
static string GetStatus(int value) => value switch
{
    > 0 => "Positive",
    < 0 => "Negative",
    _ => "Zero"
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
