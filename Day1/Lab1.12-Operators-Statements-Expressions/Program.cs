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

// Expression-bodied members (local functions)
static int Square(int n) => n * n;
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