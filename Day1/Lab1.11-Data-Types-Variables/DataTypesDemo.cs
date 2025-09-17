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
            byte byteValue = 255;                    // 0 to 255
            sbyte sbyteValue = -128;                 // -128 to 127
            short shortValue = -32768;               // -32,768 to 32,767
            ushort ushortValue = 65535;              // 0 to 65,535
            int intValue = int.MinValue;             // use constant
            uint uintValue = 4294967295;             // 0 to 4,294,967,295
            long longValue = long.MinValue;          // use constant
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
            float floatValue = 3.14159f;
            double doubleValue = 3.141592653589793;
            decimal decimalValue = 3.141592653589793238462643383279m;

            Console.WriteLine($"\nfloat: {floatValue} (size: {sizeof(float)} bytes)");
            Console.WriteLine($"double: {doubleValue} (size: {sizeof(double)} bytes)");
            Console.WriteLine($"decimal: {decimalValue} (size: {sizeof(decimal)} bytes)");

            // Other value types
            bool boolValue = true;
            char charValue = 'A';
            DateTime dateValue = DateTime.Now;

            Console.WriteLine($"\nbool: {boolValue} (size: {sizeof(bool)} bytes)");
            Console.WriteLine($"char: '{charValue}' (size: {sizeof(char)} bytes)");
            Console.WriteLine($"DateTime: {dateValue}");

            // Nullable value types
            int? nullableInt = null;
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
            string stringValue = "Hello, World!";
            string? nullString = null;

            Console.WriteLine($"String: '{stringValue}'");
            Console.WriteLine($"Null string: {nullString ?? "NULL"}");

            // Arrays (reference types)
            int[] intArray = { 1, 2, 3, 4, 5 };
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
            int explicitInt = 42;
            string explicitString = "Explicit";

            // Implicit type declaration (var keyword)
            var implicitInt = 42;
            var implicitString = "Implicit";
            var implicitArray = new[] { 1, 2, 3 };

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
            int defaultInt = default;                 // 0
            bool defaultBool = default;               // false
            string? defaultString = default;          // null
            DateTime defaultDate = default;           // 1/1/0001 12:00:00 AM

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

                int innerMethodVariable = 30; // new name; no shadowing error
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

            Console.WriteLine($"Parameter classField: {classField}");
            Console.WriteLine($"Class field (this.classField): {this.classField}");

            this.PrintInstanceInfo();
            PrintInstanceInfo();
        }

        private void PrintInstanceInfo()
        {
            Console.WriteLine($"Instance method called. Class field value: {classField}");
        }

        public static void StaticMethodDemo()
        {
            Console.WriteLine($"Static method. Static field value: {staticField}");
        }
    }

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
            this.Radius = radius;
        }

        public double Area => Math.PI * radius * radius;
        public double Circumference => 2 * Math.PI * radius;

        public void PrintInfo()
        {
            Console.WriteLine($"Circle - Radius: {this.Radius}, Area: {this.Area:F2}, Circumference: {this.Circumference:F2}");
        }
    }
}
