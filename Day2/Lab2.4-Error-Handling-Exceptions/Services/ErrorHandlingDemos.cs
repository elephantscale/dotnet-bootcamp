using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lab2_4.Exceptions;
using Lab2_4.Models;

namespace Lab2_4.Services
{
    public static class ErrorHandlingDemos
    {
        public static void BasicExceptions()
        {
            Console.WriteLine(">>> Basic try/catch/finally");

            try
            {
                int a = 10, b = 0;
                _ = a / b;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"  Caught: {ex.GetType().Name} -> {ex.Message}");
            }
            finally
            {
                Console.WriteLine("  Finally block executed");
            }

            try
            {
                int[] arr = { 1, 2, 3 };
                _ = arr[5];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"  Caught: {ex.GetType().Name}");
            }
        }

        public static void CustomExceptions()
        {
            Console.WriteLine("\n>>> Custom exceptions");

            // ValidationException via dictionary ctor (2nd param is the dictionary)
            var errors = new Dictionary<string, string[]>
            {
                ["Email"] = new[] { "Email is required.", "Email format invalid." }
            };
            try
            {
                throw new ValidationException("Bad input", errors);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"  Validation failed with {ex.Errors.Count} field(s).");
            }

            // NetworkException with Uri as 2nd arg
            try
            {
                throw new NetworkException("Timeout contacting service", new Uri("https://api.example.com/status"));
            }
            catch (NetworkException ex)
            {
                Console.WriteLine($"  Network to {ex.Endpoint} failed.");
            }
        }

        public static void BankingScenario()
        {
            Console.WriteLine("\n>>> Banking scenario");

            var a = new BankAccount("A-001", "Alice", 100m);
            var b = new BankAccount("B-001", "Bob", 50m);

            try
            {
                a.TransferTo(b, 250m);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"  Insufficient funds: have {ex.CurrentBalance:C}, need {ex.AttemptedAmount:C}");
            }
            catch (BusinessLogicException ex)
            {
                Console.WriteLine($"  Business error [{ex.ErrorCode}]: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"    Inner: {ex.InnerException.GetType().Name}");
            }
        }

        public static void FileDemo()
        {
            Console.WriteLine("\n>>> File processing demo");
            var fp = new FileProcessor();

            try
            {
                _ = fp.ReadAllText(""); // triggers ValidationException
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"  File validation failed: {string.Join(", ", ex.Errors.Keys)}");
            }

            // Demonstrate wrapping of IO exception (path likely invalid)
            try
            {
                _ = fp.ReadAllText("/root/definitely-not-allowed.txt");
            }
            catch (FileProcessingException ex)
            {
                Console.WriteLine($"  File error: {ex.Message} | Path: {ex.FilePath}");
            }
        }

        public static async Task AsyncDemo()
        {
            Console.WriteLine("\n>>> Async exception handling");

            using var http = new HttpClient
            {
                Timeout = TimeSpan.FromMilliseconds(10) // force timeout
            };

            try
            {
                await http.GetStringAsync("https://example.com/");
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("  Request timed out (TaskCanceledException).");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"  HTTP error: {ex.Message}");
            }
        }

        public static void AggregateDemo()
        {
            Console.WriteLine("\n>>> AggregateException demo");

            var tasks = new[]
            {
                Task.Run(() => throw new InvalidOperationException("Invalid op")),
                Task.Run(() => throw new IOException("I/O fail"))
            };

            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException agg)
            {
                foreach (var e in agg.Flatten().InnerExceptions)
                    Console.WriteLine($"  Inner: {e.GetType().Name} -> {e.Message}");
            }
        }
    }
}