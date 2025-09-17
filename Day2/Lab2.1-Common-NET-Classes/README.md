# Lab 2.1: Common .NET Classes and Types

## Objective
Explore the most frequently used .NET classes and understand their capabilities for everyday programming tasks.

## Duration: 45 minutes

## Theory
The .NET Base Class Library (BCL) provides a rich set of classes for common programming tasks:
- **System.String**: Immutable text manipulation
- **System.DateTime**: Date and time operations
- **System.Math**: Mathematical operations
- **System.Random**: Random number generation
- **System.Guid**: Globally unique identifiers
- **System.Convert**: Type conversions

## Exercise

### Part A: String Operations (15 minutes)
Master string manipulation techniques and best practices.

### Part B: DateTime and Math Operations (15 minutes)
Work with dates, times, and mathematical calculations.

### Part C: Utility Classes (15 minutes)
Explore Random, Guid, and conversion utilities.

## Hands-On Tasks

### Task 1: String Manipulation
Create `StringOperations.cs`:
```csharp
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
            
            // String interpolation (preferred)
            string interpolated = $"Name: {name}, Age: {age}";
            
            // String concatenation
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

            string[] testStrings = { "", "   ", null, "Valid String", "123", "user@email.com" };

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

        private static bool IsNumeric(string input)
        {
            return double.TryParse(input, out _);
        }

        private static bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
```

### Task 2: DateTime Operations
Create `DateTimeOperations.cs`:
```csharp
namespace Lab2_1
{
    public static class DateTimeOperations
    {
        public static void DemonstrateDateTimeBasics()
        {
            Console.WriteLine("=== DateTime Basics Demo ===\n");

            // Current date and time
            DateTime now = DateTime.Now;
            DateTime utcNow = DateTime.UtcNow;
            DateTime today = DateTime.Today;

            Console.WriteLine($"Current Local Time: {now}");
            Console.WriteLine($"Current UTC Time: {utcNow}");
            Console.WriteLine($"Today (Date only): {today}");

            // Creating specific dates
            DateTime specificDate = new DateTime(2024, 12, 25, 10, 30, 0);
            DateTime parsedDate = DateTime.Parse("2024-06-15 14:30:00");
            
            Console.WriteLine($"Christmas 2024: {specificDate}");
            Console.WriteLine($"Parsed Date: {parsedDate}");

            // Date arithmetic
            DateTime futureDate = now.AddDays(30);
            DateTime pastDate = now.AddMonths(-6);
            TimeSpan difference = futureDate - now;

            Console.WriteLine($"30 days from now: {futureDate}");
            Console.WriteLine($"6 months ago: {pastDate}");
            Console.WriteLine($"Difference: {difference.Days} days");
        }

        public static void DemonstrateDateTimeFormatting()
        {
            Console.WriteLine("\n=== DateTime Formatting Demo ===");

            DateTime date = new DateTime(2024, 3, 15, 14, 30, 45);

            // Standard format strings
            Console.WriteLine($"Short Date: {date:d}");
            Console.WriteLine($"Long Date: {date:D}");
            Console.WriteLine($"Short Time: {date:t}");
            Console.WriteLine($"Long Time: {date:T}");
            Console.WriteLine($"Full DateTime: {date:F}");
            Console.WriteLine($"ISO 8601: {date:yyyy-MM-ddTHH:mm:ss}");

            // Custom format strings
            Console.WriteLine($"Custom 1: {date:MMM dd, yyyy}");
            Console.WriteLine($"Custom 2: {date:dddd, MMMM dd}");
            Console.WriteLine($"Custom 3: {date:HH:mm:ss}");
            Console.WriteLine($"Custom 4: {date:yyyy/MM/dd hh:mm tt}");
        }

        public static void DemonstrateTimeSpan()
        {
            Console.WriteLine("\n=== TimeSpan Demo ===");

            // Creating TimeSpan objects
            TimeSpan span1 = new TimeSpan(2, 30, 45); // 2 hours, 30 minutes, 45 seconds
            TimeSpan span2 = TimeSpan.FromDays(7);
            TimeSpan span3 = TimeSpan.FromMinutes(90);

            Console.WriteLine($"Span 1: {span1}");
            Console.WriteLine($"Span 2: {span2}");
            Console.WriteLine($"Span 3: {span3}");

            // TimeSpan arithmetic
            TimeSpan total = span1 + span3;
            Console.WriteLine($"Span1 + Span3: {total}");

            // TimeSpan properties
            Console.WriteLine($"Total hours in span3: {span3.TotalHours}");
            Console.WriteLine($"Days in span2: {span2.Days}");
        }

        public static void DemonstrateAgeCalculation()
        {
            Console.WriteLine("\n=== Age Calculation Demo ===");

            DateTime[] birthDates = {
                new DateTime(1990, 5, 15),
                new DateTime(2000, 12, 3),
                new DateTime(1985, 8, 22),
                new DateTime(2010, 1, 10)
            };

            foreach (var birthDate in birthDates)
            {
                int age = CalculateAge(birthDate);
                Console.WriteLine($"Born: {birthDate:yyyy-MM-dd}, Age: {age} years");
            }
        }

        private static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            
            // Adjust if birthday hasn't occurred this year
            if (birthDate.Date > today.AddYears(-age))
                age--;
                
            return age;
        }
    }
}
```

### Task 3: Math and Utility Classes
Create `MathAndUtilities.cs`:
```csharp
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
```

### Task 4: Main Program
Create `Program.cs`:
```csharp
using Lab2_1;

Console.WriteLine("=== Common .NET Classes and Types Demo ===\n");

// String operations
StringOperations.DemonstrateStringMethods();
StringOperations.DemonstrateStringComparison();
StringOperations.DemonstrateStringValidation();

// DateTime operations
DateTimeOperations.DemonstrateDateTimeBasics();
DateTimeOperations.DemonstrateDateTimeFormatting();
DateTimeOperations.DemonstrateTimeSpan();
DateTimeOperations.DemonstrateAgeCalculation();

// Math and utilities
MathAndUtilities.DemonstrateMathClass();
MathAndUtilities.DemonstrateRandomClass();
MathAndUtilities.DemonstrateGuidClass();
MathAndUtilities.DemonstrateConvertClass();
MathAndUtilities.DemonstrateTypeChecking();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

## Key .NET Classes Summary

| Class | Purpose | Common Methods |
|-------|---------|----------------|
| String | Text manipulation | Trim(), Split(), Replace(), Contains() |
| DateTime | Date/time operations | Now, Parse(), AddDays(), ToString() |
| Math | Mathematical operations | Abs(), Round(), Sqrt(), Min(), Max() |
| Random | Random number generation | Next(), NextDouble(), NextBytes() |
| Guid | Unique identifiers | NewGuid(), Parse(), ToString() |
| Convert | Type conversions | ToInt32(), ToDouble(), ToString() |

## Expected Output
```
=== Common .NET Classes and Types Demo ===

=== String Operations Demo ===

Original: '  Hello, .NET World!  '
Length: 21
Trimmed: 'Hello, .NET World!'
Upper: '  HELLO, .NET WORLD!  '
Lower: '  hello, .net world!  '
Contains 'NET': True
Starts with '  Hello': True
Ends with '!  ': True
```

## Key Takeaways
- String is immutable; use StringBuilder for multiple operations
- DateTime provides comprehensive date/time functionality
- Math class offers essential mathematical operations
- Random generates pseudo-random numbers
- Guid creates globally unique identifiers
- Convert handles type conversions safely
- Always handle potential exceptions in conversions

## Challenge Exercise
Create a utility class that combines these concepts: generate random employee data including names, hire dates, salaries, and employee IDs (GUIDs), then format the output nicely.

## Next Lab
Lab 2.2 will dive deeper into string manipulation and DateTime advanced features.
