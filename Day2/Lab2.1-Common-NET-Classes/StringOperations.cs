using System.Text;

namespace Lab2_1
{
    public static class StringOperations
    {
        public static void DemonstrateStringMethods()
        {
            Console.WriteLine("=== String Operations Demo ===\n");

            string sample = "  Hello, .NET World!  ";
            Console.WriteLine($"Original: '{sample}'");
            Console.WriteLine($"Length: {sample.Length}");
            Console.WriteLine($"Trimmed: '{sample.Trim()}'");
            Console.WriteLine($"Upper: '{sample.ToUpper()}'");
            Console.WriteLine($"Lower: '{sample.ToLower()}'");
            Console.WriteLine($"Contains 'NET': {sample.Contains("NET")}");
            Console.WriteLine($"Starts with '  Hello': {sample.StartsWith("  Hello")}");
            Console.WriteLine($"Ends with '!  ': {sample.EndsWith("!  ")}");

            // String manipulation
            string replaced = sample.Replace("World", "Universe");
            Console.WriteLine($"Replaced: '{replaced}'");

            string[] words = sample.Trim().Split(' ');
            Console.WriteLine($"Split into {words.Length} words:");
            foreach (var word in words)
            {
                Console.WriteLine($"  '{word}'");
            }

            // String interpolation vs concatenation
            string name = "Alice";
            int age = 30;

            // Interpolation (preferred)
            string interpolated = $"Name: {name}, Age: {age}";

            // Concatenation
            string concatenated = "Name: " + name + ", Age: " + age;

            // String.Format
            string formatted = string.Format("Name: {0}, Age: {1}", name, age);

            Console.WriteLine($"Interpolated: {interpolated}");
            Console.WriteLine($"Concatenated: {concatenated}");
            Console.WriteLine($"Formatted: {formatted}");

            // StringBuilder for multiple operations
            var sb = new StringBuilder();
            sb.AppendLine("Building a multi-line string:");
            sb.AppendLine($"- Current time: {DateTime.Now}");
            sb.AppendLine($"- Random number: {new Random().Next(1, 100)}");
            sb.Append("- End of string");

            Console.WriteLine(sb.ToString());
        }

        public static void DemonstrateStringComparison()
        {
            Console.WriteLine("\n=== String Comparison Demo ===");

            string str1 = "Hello";
            string str2 = "hello";
            string str3 = "Hello";

            Console.WriteLine($"str1 == str2: {str1 == str2}");
            Console.WriteLine($"str1 == str3: {str1 == str3}");
            Console.WriteLine($"str1.Equals(str2): {str1.Equals(str2)}");
            Console.WriteLine($"str1.Equals(str2, StringComparison.OrdinalIgnoreCase): {str1.Equals(str2, StringComparison.OrdinalIgnoreCase)}");

            // String comparison methods
            Console.WriteLine($"Compare(str1, str2): {string.Compare(str1, str2)}");
            Console.WriteLine($"Compare(str1, str2, ignoreCase): {string.Compare(str1, str2, true)}");
        }

        public static void DemonstrateStringValidation()
        {
            Console.WriteLine("\n=== String Validation Demo ===");

            string?[] testStrings = { "", "   ", null, "Valid String", "123", "user@email.com" };

            foreach (var test in testStrings)
            {
                Console.WriteLine($"Testing: '{test ?? "null"}'");
                Console.WriteLine($"  IsNullOrEmpty: {string.IsNullOrEmpty(test)}");
                Console.WriteLine($"  IsNullOrWhiteSpace: {string.IsNullOrWhiteSpace(test)}");

                if (!string.IsNullOrEmpty(test))
                {
                    Console.WriteLine($"  IsNumeric: {IsNumeric(test)}");
                    Console.WriteLine($"  IsEmail: {IsValidEmail(test)}");
                }
                Console.WriteLine();
            }
        }

        private static bool IsNumeric(string? input) => double.TryParse(input, out _);

        private static bool IsValidEmail(string? email) =>
            !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");
    }
}