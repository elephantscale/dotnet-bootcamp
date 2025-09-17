namespace Lab2_1
{
    public static class MathAndUtilities
    {
        public static void DemonstrateMathClass()
        {
            Console.WriteLine("=== Math Class Demo ===\n");

            double[] numbers = { 16.7, -5.3, 0, 25, 100.5 };

            foreach (var num in numbers)
            {
                Console.WriteLine($"Number: {num}");
                Console.WriteLine($"  Absolute: {Math.Abs(num)}");
                Console.WriteLine($"  Ceiling: {Math.Ceiling(num)}");
                Console.WriteLine($"  Floor: {Math.Floor(num)}");
                Console.WriteLine($"  Round: {Math.Round(num)}");
                Console.WriteLine($"  Square Root: {Math.Sqrt(Math.Abs(num)):F2}");
                Console.WriteLine();
            }

            // Math constants and functions
            Console.WriteLine($"Pi: {Math.PI}");
            Console.WriteLine($"E: {Math.E}");
            Console.WriteLine($"Sin(π/2): {Math.Sin(Math.PI / 2)}");
            Console.WriteLine($"Cos(0): {Math.Cos(0)}");
            Console.WriteLine($"Log(e): {Math.Log(Math.E)}");
            Console.WriteLine($"Log10(100): {Math.Log10(100)}");
            Console.WriteLine($"2^8: {Math.Pow(2, 8)}");

            // Min/Max operations
            Console.WriteLine($"Max(10, 20): {Math.Max(10, 20)}");
            Console.WriteLine($"Min(-5, 3): {Math.Min(-5, 3)}");
        }

        public static void DemonstrateRandomClass()
        {
            Console.WriteLine("\n=== Random Class Demo ===");

            Random random = new Random();

            Console.WriteLine("Random integers (0-99):");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"  {random.Next(100)}");
            }

            Console.WriteLine("\nRandom integers (10-50):");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"  {random.Next(10, 51)}");
            }

            Console.WriteLine("\nRandom doubles (0.0-1.0):");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"  {random.NextDouble():F4}");
            }

            // Random bytes
            byte[] buffer = new byte[10];
            random.NextBytes(buffer);
            Console.WriteLine($"\nRandom bytes: {string.Join(", ", buffer)}");

            // Seeded random for reproducible results
            Random seededRandom = new Random(12345);
            Console.WriteLine("\nSeeded random (same seed = same sequence):");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"  {seededRandom.Next(100)}");
            }
        }

        public static void DemonstrateGuidClass()
        {
            Console.WriteLine("\n=== Guid Class Demo ===");

            // Generate new GUIDs
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid emptyGuid = Guid.Empty;

            Console.WriteLine($"GUID 1: {guid1}");
            Console.WriteLine($"GUID 2: {guid2}");
            Console.WriteLine($"Empty GUID: {emptyGuid}");

            // GUID formats
            Console.WriteLine($"\nGUID Formats:");
            Console.WriteLine($"  Default: {guid1}");
            Console.WriteLine($"  No hyphens: {guid1:N}");
            Console.WriteLine($"  With braces: {guid1:B}");
            Console.WriteLine($"  With parentheses: {guid1:P}");

            // Parse GUID from string
            string guidString = guid1.ToString();
            Guid parsedGuid = Guid.Parse(guidString);
            Console.WriteLine($"\nParsed GUID matches original: {parsedGuid == guid1}");
        }

        public static void DemonstrateConvertClass()
        {
            Console.WriteLine("\n=== Convert Class Demo ===");

            // Type conversions
            string numberString = "123";
            string doubleString = "45.67";
            string boolString = "true";

            try
            {
                int intValue = Convert.ToInt32(numberString);
                double doubleValue = Convert.ToDouble(doubleString);
                bool boolValue = Convert.ToBoolean(boolString);
                DateTime dateValue = Convert.ToDateTime("2024-03-15");

                Console.WriteLine($"String to int: '{numberString}' -> {intValue}");
                Console.WriteLine($"String to double: '{doubleString}' -> {doubleValue}");
                Console.WriteLine($"String to bool: '{boolString}' -> {boolValue}");
                Console.WriteLine($"String to DateTime: '2024-03-15' -> {dateValue:yyyy-MM-dd}");

                // Base conversions
                int number = 255;
                Console.WriteLine($"\nBase conversions for {number}:");
                Console.WriteLine($"  Binary: {Convert.ToString(number, 2)}");
                Console.WriteLine($"  Octal: {Convert.ToString(number, 8)}");
                Console.WriteLine($"  Hexadecimal: {Convert.ToString(number, 16)}");

                // Convert back from hex
                string hexString = "FF";
                int fromHex = Convert.ToInt32(hexString, 16);
                Console.WriteLine($"  Hex '{hexString}' to int: {fromHex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion error: {ex.Message}");
            }
        }

        public static void DemonstrateTypeChecking()
        {
            Console.WriteLine("\n=== Type Checking Demo ===");

            object[] values = { 42, "Hello", 3.14, true, DateTime.Now, new List<int>() };

            foreach (var value in values)
            {
                Console.WriteLine($"Value: {value}");
                Console.WriteLine($"  Type: {value.GetType().Name}");
                Console.WriteLine($"  Is int: {value is int}");
                Console.WriteLine($"  Is string: {value is string}");
                Console.WriteLine($"  Is IEnumerable: {value is System.Collections.IEnumerable}");
                Console.WriteLine();
            }
        }
    }
}