using System;
using System.Threading.Tasks;
using Lab2_4.Services;

Console.WriteLine("=== Error Handling & Exceptions Demo ===\n");

ErrorHandlingDemos.BasicExceptions();
ErrorHandlingDemos.CustomExceptions();
ErrorHandlingDemos.BankingScenario();
ErrorHandlingDemos.FileDemo();
await ErrorHandlingDemos.AsyncDemo();
ErrorHandlingDemos.AggregateDemo();

Console.WriteLine("\nDone. Press any key to exit...");
Console.ReadKey();