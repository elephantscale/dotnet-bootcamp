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

            x += 5;
            Console.WriteLine($"After x += 5: {x}");

            x -= 3;
            Console.WriteLine($"After x -= 3: {x}");

            x *= 2;
            Console.WriteLine($"After x *= 2: {x}");

            x /= 4;
            Console.WriteLine($"After x /= 4: {x}");

            x %= 3;
            Console.WriteLine($"After x %= 3: {x}");

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

            string result = first + " " + second;
            Console.WriteLine($"Concatenation: {result}");

            string interpolated = $"{first} {second}!";
            Console.WriteLine($"Interpolation: {interpolated}");

            Console.WriteLine($"first == second: {first == second}");
            Console.WriteLine($"first != second: {first != second}");

            string numberStr = "Value: " + 42;
            Console.WriteLine($"String + number: {numberStr}");
        }
    }
}
