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

            string str1 = "apple", str2 = "banana", str3 = "apple";
            Console.WriteLine($"\nString comparisons:");
            Console.WriteLine($"str1 = '{str1}', str2 = '{str2}', str3 = '{str3}'");
            Console.WriteLine($"str1 == str2: {str1 == str2}");
            Console.WriteLine($"str1 == str3: {str1 == str3}");
            Console.WriteLine($"str1.CompareTo(str2): {str1.CompareTo(str2)}");
        }

        public static void DemonstrateLogicalOperators()
        {
            Console.WriteLine("\n=== Logical Operators ===\n");

            bool p = true, q = false;
            Console.WriteLine($"p = {p}, q = {q}");

            Console.WriteLine($"p && q: {p && q}");
            Console.WriteLine($"p && true: {p && true}");

            Console.WriteLine($"p || q: {p || q}");
            Console.WriteLine($"q || false: {q || false}");

            Console.WriteLine($"!p: {!p}");
            Console.WriteLine($"!q: {!q}");

            Console.WriteLine("\nShort-circuit evaluation:");
            Console.WriteLine($"false && SomeMethod(): {false && SomeExpensiveMethod()}");
            Console.WriteLine($"true || SomeMethod(): {true || SomeExpensiveMethod()}");

            Console.WriteLine($"\nBitwise logical (no short-circuit):");
            Console.WriteLine($"p & q: {p & q}");
            Console.WriteLine($"p | q: {p | q}");
            Console.WriteLine($"p ^ q: {p ^ q}");
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

            string? nullableString = null;
            int? length = nullableString?.Length;
            Console.WriteLine($"Nullable string length: {length?.ToString() ?? "null"}");

            nullableString = "Hello";
            length = nullableString?.Length;
            Console.WriteLine($"String '{nullableString}' length: {length}");
        }
    }
}