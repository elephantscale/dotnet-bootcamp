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
            int orResult = a | b;
            int xorResult = a ^ b;
            int notResult = ~a;

            Console.WriteLine($"a & b = {andResult} (binary: {Convert.ToString(andResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a | b = {orResult}  (binary: {Convert.ToString(orResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a ^ b = {xorResult} (binary: {Convert.ToString(xorResult, 2).PadLeft(8, '0')})");
            Console.WriteLine($"~a    = {notResult} (binary: {Convert.ToString(notResult, 2)})");

            int leftShift = a << 2;
            int rightShift = a >> 1;

            Console.WriteLine($"a << 2 = {leftShift}  (binary: {Convert.ToString(leftShift, 2).PadLeft(8, '0')})");
            Console.WriteLine($"a >> 1 = {rightShift} (binary: {Convert.ToString(rightShift, 2).PadLeft(8, '0')})");
        }

        public static void DemonstrateNullOperators()
        {
            Console.WriteLine("\n=== Null-Related Operators ===\n");

            string? nullableString = null;
            string nonNullString = "Hello";

            string result1 = nullableString ?? "Default";
            string result2 = nonNullString ?? "Default";
            Console.WriteLine($"null ?? 'Default': {result1}");
            Console.WriteLine($"'Hello' ?? 'Default': {result2}");

            nullableString ??= "Assigned Default";
            Console.WriteLine($"After ??= assignment: {nullableString}");

            string? testString = null;
            int? length1 = testString?.Length;
            Console.WriteLine($"null?.Length: {length1?.ToString() ?? "null"}");

            testString = "Test";
            int? length2 = testString?.Length;
            Console.WriteLine($"'Test'?.Length: {length2}");

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
                Console.WriteLine($"  is int: {obj is int}");
                Console.WriteLine($"  is string: {obj is string}");
                Console.WriteLine($"  is double: {obj is double}");

                string? asString = obj as string;
                Console.WriteLine($"  as string: {asString ?? "null"}");

                Console.WriteLine($"  typeof: {obj.GetType().Name}");

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

            int result1 = 2 + 3 * 4;       // 14
            int result2 = 10 - 4 / 2;      // 8
            bool result3 = 5 > 3 && 2 < 4;  // true

            Console.WriteLine($"2 + 3 * 4 = {result1} (multiplication first)");
            Console.WriteLine($"10 - 4 / 2 = {result2} (division first)");
            Console.WriteLine($"5 > 3 && 2 < 4 = {result3} (comparison first)");

            int result4 = (2 + 3) * 4;     // 20
            int result5 = (10 - 4) / 2;    // 3
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