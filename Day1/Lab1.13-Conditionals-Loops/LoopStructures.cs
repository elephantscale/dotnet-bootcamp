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
