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
            {
                Console.WriteLine($"\n😞 Game over! The number was {secretNumber}.");
            }
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
