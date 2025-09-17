using System;

namespace Lab1_13
{
    public static class ConditionalStatements
    {
        public static void DemonstrateIfElse()
        {
            Console.WriteLine("=== If-Else Statements ===\n");

            int temperature = 75;
            Console.WriteLine($"Temperature: {temperature}°F");

            // Simple if
            if (temperature > 80)
            {
                Console.WriteLine("It's hot outside!");
            }

            // If-else
            if (temperature > 80)
            {
                Console.WriteLine("It's hot outside!");
            }
            else
            {
                Console.WriteLine("It's not too hot.");
            }

            // If-else if-else chain
            if (temperature >= 90)
                Console.WriteLine("Weather: Very Hot");
            else if (temperature >= 80)
                Console.WriteLine("Weather: Hot");
            else if (temperature >= 70)
                Console.WriteLine("Weather: Warm");
            else if (temperature >= 60)
                Console.WriteLine("Weather: Cool");
            else
                Console.WriteLine("Weather: Cold");

            // Nested ifs
            bool isWeekend = true;
            if (temperature > 70)
            {
                if (isWeekend) Console.WriteLine("Perfect day for outdoor activities!");
                else Console.WriteLine("Nice weather for work day.");
            }

            // Ternary
            string activity = temperature > 80 ? "Swimming" : "Walking";
            Console.WriteLine($"Recommended activity: {activity}");

            // Multiple conditions
            int humidity = 60;
            if (temperature > 80 && humidity > 70)
                Console.WriteLine("It's hot and humid!");
            else if (temperature > 80 || humidity > 70)
                Console.WriteLine("Either hot or humid.");
        }

        public static void DemonstrateSwitchStatement()
        {
            Console.WriteLine("\n=== Switch Statements ===\n");

            // Switch on int
            int dayOfWeek = 3;
            Console.WriteLine($"Day number: {dayOfWeek}");

            switch (dayOfWeek)
            {
                case 1: Console.WriteLine("Monday - Start of work week"); break;
                case 2: Console.WriteLine("Tuesday - Getting into the groove"); break;
                case 3: Console.WriteLine("Wednesday - Hump day!"); break;
                case 4: Console.WriteLine("Thursday - Almost there"); break;
                case 5: Console.WriteLine("Friday - TGIF!"); break;
                case 6:
                case 7: Console.WriteLine("Weekend - Time to relax!"); break;
                default: Console.WriteLine("Invalid day number"); break;
            }

            // Switch with string
            string grade = "B";
            switch (grade.ToUpper())
            {
                case "A": Console.WriteLine("Excellent work!"); break;
                case "B": Console.WriteLine("Good job!"); break;
                case "C": Console.WriteLine("Satisfactory"); break;
                case "D": Console.WriteLine("Needs improvement"); break;
                case "F": Console.WriteLine("Failed"); break;
                default: Console.WriteLine("Invalid grade"); break;
            }
        }

        public static void DemonstrateSwitchExpressions()
        {
            Console.WriteLine("\n=== Switch Expressions (C# 8+) ===\n");

            // Simple values
            int month = 6;
            string season = month switch
            {
                12 or 1 or 2 => "Winter",
                3 or 4 or 5 => "Spring",
                6 or 7 or 8 => "Summer",
                9 or 10 or 11 => "Fall",
                _ => "Invalid month"
            };
            Console.WriteLine($"Month {month} is in {season}");

            // Ranges
            int score = 85;
            string letterGrade = score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
            Console.WriteLine($"Score {score} = Grade {letterGrade}");

            // Type patterns
            object value = "Hello";
            string description = value switch
            {
                int i => $"Integer: {i}",
                string s => $"String: '{s}'",
                bool b => $"Boolean: {b}",
                double d => $"Double: {d:F2}",
                null => "Null value",
                _ => $"Unknown type: {value.GetType().Name}"
            };
            Console.WriteLine(description);

            // Property patterns (anonymous type)
            var person = new { Name = "Alice", Age = 25 };
            string category = person switch
            {
                { Age: < 13 } => "Child",
                { Age: < 20 } => "Teenager",
                { Age: < 65 } => "Adult",
                _ => "Senior"
            };
            Console.WriteLine($"{person.Name} (age {person.Age}) is a {category}");
        }
    }
}
