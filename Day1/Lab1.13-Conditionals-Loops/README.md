# Lab 1.13: Conditionals and Loops

## Objective
Master control flow structures including if-else statements, switch expressions, and various loop types.

## Duration: 45 minutes

## Theory
- **Conditionals**: Control program flow based on boolean conditions
- **Loops**: Repeat code blocks based on conditions or iterations
- **Switch Expressions**: Pattern matching for multiple conditions
- **Break/Continue**: Control loop execution flow

## Exercise

### Part A: Conditional Statements (15 minutes)
Explore if-else and switch constructs.

### Part B: Loop Types (20 minutes)
Master for, while, do-while, and foreach loops.

### Part C: Advanced Control Flow (10 minutes)
Learn break, continue, and nested structures.

## Hands-On Tasks

### Task 1: Conditional Statements
Create `ConditionalStatements.cs`:
```csharp
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
                int i    => $"Integer: {i}",
                string s => $"String: '{s}'",
                bool b   => $"Boolean: {b}",
                double d => $"Double: {d:F2}",
                null     => "Null value",
                _        => $"Unknown type: {value.GetType().Name}"
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

```

### Task 2: Loop Structures
Create `LoopStructures.cs`:
```csharp
using System;
using System.Collections.Generic;

namespace Lab1_13
{
    public static class LoopStructures
    {
        public static void DemonstrateForLoop()
        {
            Console.WriteLine("=== For Loops ===\n");

            Console.WriteLine("Counting from 1 to 5:");
            for (int i = 1; i <= 5; i++)
                Console.WriteLine($"  Count: {i}");

            Console.WriteLine("\nCounting by 2s from 0 to 10:");
            for (int i = 0; i <= 10; i += 2)
                Console.WriteLine($"  Even number: {i}");

            Console.WriteLine("\nCountdown from 5 to 1:");
            for (int i = 5; i >= 1; i--)
                Console.WriteLine($"  Countdown: {i}");

            Console.WriteLine("\nMultiple variables in for loop:");
            for (int i = 0, j = 10; i < 5; i++, j--)
                Console.WriteLine($"  i = {i}, j = {j}");

            Console.WriteLine("\nMultiplication table (3x3):");
            for (int row = 1; row <= 3; row++)
            {
                for (int col = 1; col <= 3; col++)
                    Console.Write($"{row * col,4}");
                Console.WriteLine();
            }
        }

        public static void DemonstrateWhileLoop()
        {
            Console.WriteLine("\n=== While Loops ===\n");

            Console.WriteLine("While loop counting to 5:");
            int count = 1;
            while (count <= 5)
            {
                Console.WriteLine($"  Count: {count}");
                count++;
            }

            Console.WriteLine("\nGuessing game simulation:");
            Random random = new Random();
            int target = random.Next(1, 11);
            int guess = 0;
            int attempts = 0;

            while (guess != target)
            {
                guess = random.Next(1, 11);
                attempts++;
                Console.WriteLine($"  Attempt {attempts}: Guessed {guess}");

                if (attempts > 10) // safety break
                {
                    Console.WriteLine("  Too many attempts, giving up!");
                    break;
                }
            }

            if (guess == target)
                Console.WriteLine($"  Found target {target} in {attempts} attempts!");
        }

        public static void DemonstrateDoWhileLoop()
        {
            Console.WriteLine("\n=== Do-While Loops ===\n");

            Console.WriteLine("Do-while loop (executes at least once):");
            int value = 10;
            do
            {
                Console.WriteLine($"  Value: {value}");
                value--;
            } while (value > 5);

            Console.WriteLine("\nCompare with while loop:");
            value = 0;
            while (value > 5)
            {
                Console.WriteLine($"  This won't print: {value}");
                value--;
            }

            do
            {
                Console.WriteLine($"  This will print once: {value}");
                value--;
            } while (value > 5);
        }

        public static void DemonstrateForeachLoop()
        {
            Console.WriteLine("\n=== Foreach Loops ===\n");

            int[] numbers = { 10, 20, 30, 40, 50 };
            Console.WriteLine("Iterating through array:");
            foreach (int number in numbers)
                Console.WriteLine($"  Number: {number}");

            List<string> fruits = new() { "Apple", "Banana", "Orange", "Grape" };
            Console.WriteLine("\nIterating through List:");
            foreach (string fruit in fruits)
                Console.WriteLine($"  Fruit: {fruit}");

            string text = "Hello";
            Console.WriteLine($"\nIterating through string '{text}':");
            foreach (char c in text)
                Console.WriteLine($"  Character: '{c}'");

            Dictionary<string, int> ages = new()
            {
                ["Alice"] = 25,
                ["Bob"] = 30,
                ["Charlie"] = 35
            };

            Console.WriteLine("\nIterating through Dictionary:");
            foreach (KeyValuePair<string, int> kvp in ages)
                Console.WriteLine($"  {kvp.Key} is {kvp.Value} years old");

            Console.WriteLine("\nUsing var in foreach:");
            foreach (var person in ages)
                Console.WriteLine($"  {person.Key}: {person.Value}");
        }

        public static void DemonstrateAdvancedLoopControl()
        {
            Console.WriteLine("\n=== Advanced Loop Control ===\n");

            Console.WriteLine("Using break to exit loop early:");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 6)
                {
                    Console.WriteLine($"  Breaking at {i}");
                    break;
                }
                Console.WriteLine($"  Processing: {i}");
            }

            Console.WriteLine("\nUsing continue to skip iterations:");
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0) continue; // skip even
                Console.WriteLine($"  Odd number: {i}");
            }

            Console.WriteLine("\nNested loops with early exit:");
            bool found = false;
            for (int i = 1; i <= 3 && !found; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine($"  Checking ({i}, {j})");
                    if (i == 2 && j == 2)
                    {
                        Console.WriteLine("  Found target position!");
                        found = true;
                        break;
                    }
                }
            }

            Console.WriteLine("\nDemonstrating early method return:");
            FindFirstEven(new int[] { 1, 3, 5, 8, 9, 12 });
        }

        private static void FindFirstEven(int[] numbers)
        {
            Console.WriteLine("Searching for first even number:");
            foreach (int number in numbers)
            {
                Console.WriteLine($"  Checking: {number}");
                if (number % 2 == 0)
                {
                    Console.WriteLine($"  Found first even number: {number}");
                    return; // exit method
                }
            }
            Console.WriteLine("  No even numbers found");
        }
    }
}

```

### Task 3: Practical Examples
Create `PracticalExamples.cs`:
```csharp
using System;

namespace Lab1_13
{
    public static class PracticalExamples
    {
        public static void NumberGuessingGame()
        {
            Console.WriteLine("=== Number Guessing Game ===\n");

            Random random = new();
            int secretNumber = random.Next(1, 101);
            int attempts = 0;
            int maxAttempts = 7;
            bool hasWon = false;

            Console.WriteLine("I'm thinking of a number between 1 and 100.");
            Console.WriteLine($"You have {maxAttempts} attempts to guess it!");

            // Simulated guesses (to keep the demo non-interactive)
            int[] simulatedGuesses = { 50, 75, 88, 94, 91, 89, 90 };

            for (int i = 0; i < maxAttempts && !hasWon; i++)
            {
                attempts++;
                int guess = simulatedGuesses[Math.Min(i, simulatedGuesses.Length - 1)];

                Console.WriteLine($"\nAttempt {attempts}: Guessing {guess}");

                if (guess == secretNumber)
                {
                    hasWon = true;
                    Console.WriteLine($"🎉 Congratulations! You guessed it in {attempts} attempts!");
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("Too low! Try a higher number.");
                }
                else
                {
                    Console.WriteLine("Too high! Try a lower number.");
                }
            }

            if (!hasWon)
                Console.WriteLine($"\n😞 Game over! The number was {secretNumber}.");
        }

        public static void CalculateFactorial()
        {
            Console.WriteLine("\n=== Factorial Calculator ===\n");

            int[] testNumbers = { 0, 1, 5, 10 };

            foreach (int number in testNumbers)
            {
                if (number < 0)
                {
                    Console.WriteLine($"Factorial of {number}: Undefined (negative number)");
                    continue;
                }

                long factorial = 1;
                Console.Write($"Factorial of {number}: ");

                if (number is 0 or 1)
                {
                    Console.WriteLine($"{number}! = 1");
                }
                else
                {
                    Console.Write($"{number}! = ");
                    for (int i = number; i >= 1; i--)
                    {
                        factorial *= i;
                        Console.Write(i);
                        if (i > 1) Console.Write(" × ");
                    }
                    Console.WriteLine($" = {factorial}");
                }
            }
        }

        public static void FibonacciSequence()
        {
            Console.WriteLine("\n=== Fibonacci Sequence ===\n");

            int count = 15;
            Console.WriteLine($"First {count} Fibonacci numbers:");

            long first = 0, second = 1;

            if (count >= 1) Console.Write($"{first}");
            if (count >= 2) Console.Write($", {second}");

            for (int i = 3; i <= count; i++)
            {
                long next = first + second;
                Console.Write($", {next}");
                first = second;
                second = next;
            }
            Console.WriteLine();
        }

        public static void PrimeNumberFinder()
        {
            Console.WriteLine("\n=== Prime Number Finder ===\n");

            int limit = 50;
            Console.WriteLine($"Prime numbers up to {limit}:");

            for (int number = 2; number <= limit; number++)
            {
                bool isPrime = true;

                for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
                {
                    if (number % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        public static void MultiplicationTable()
        {
            Console.WriteLine("\n=== Multiplication Table ===\n");

            int size = 10;
            Console.WriteLine($"{size}x{size} Multiplication Table:");

            // Header
            Console.Write("    ");
            for (int col = 1; col <= size; col++)
                Console.Write($"{col,4}");
            Console.WriteLine();

            // Separator
            Console.Write("    ");
            for (int col = 1; col <= size; col++)
                Console.Write("----");
            Console.WriteLine();

            // Body
            for (int row = 1; row <= size; row++)
            {
                Console.Write($"{row,2}: ");
                for (int col = 1; col <= size; col++)
                    Console.Write($"{row * col,4}");
                Console.WriteLine();
            }
        }
    }
}

```

### Task 4: Main Program
Create `Program.cs`:
```csharp
using System;
using Lab1_13;

Console.WriteLine("=== Conditionals and Loops Demo ===\n");

// Conditional statements
ConditionalStatements.DemonstrateIfElse();
ConditionalStatements.DemonstrateSwitchStatement();
ConditionalStatements.DemonstrateSwitchExpressions();

// Loop structures
LoopStructures.DemonstrateForLoop();
LoopStructures.DemonstrateWhileLoop();
LoopStructures.DemonstrateDoWhileLoop();
LoopStructures.DemonstrateForeachLoop();
LoopStructures.DemonstrateAdvancedLoopControl();

// Practical examples
PracticalExamples.NumberGuessingGame();
PracticalExamples.CalculateFactorial();
PracticalExamples.FibonacciSequence();
PracticalExamples.PrimeNumberFinder();
PracticalExamples.MultiplicationTable();

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();

```

## Control Flow Summary

| Structure | Use Case | Key Points |
|-----------|----------|------------|
| `if-else` | Simple conditions | Use for binary decisions |
| `switch` | Multiple discrete values | Good for enums and constants |
| `switch expression` | Pattern matching | More concise, returns values |
| `for` | Known iteration count | Best for counting loops |
| `while` | Condition-based repetition | May not execute at all |
| `do-while` | Execute at least once | Condition checked after |
| `foreach` | Collection iteration | Simplest for arrays/collections |

## Expected Output
```
=== Conditionals and Loops Demo ===

=== If-Else Statements ===

Temperature: 75°F
It's not too hot.
Weather: Warm
Perfect day for outdoor activities!
Recommended activity: Walking
```

## Key Takeaways
- Use appropriate conditional structures for different scenarios
- Switch expressions provide cleaner pattern matching
- Choose the right loop type based on your needs
- Break and continue control loop execution
- Nested structures increase complexity but provide flexibility
- Always consider edge cases and infinite loop prevention

## Challenge Exercise
Create a text-based menu system that uses all conditional and loop types to implement a simple calculator with multiple operations and input validation.

## Next Lab
Lab 1.14 will explore arrays and iterators for data collection management.
