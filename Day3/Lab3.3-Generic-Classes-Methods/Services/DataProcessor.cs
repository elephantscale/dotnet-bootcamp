// using Lab3._3_Generic_Classes_Methods.Interfaces;

// namespace Lab3._3_Generic_Classes_Methods.Services;

// public class DataProcessor<T> : IProcessor<T>
// {
//     private readonly List<Func<T, T>> _processors = new();

//     public void AddProcessor(Func<T, T> processor)
//     {
//         _processors.Add(processor);
//     }

//     public T Process(T input)
//     {
//         var result = input;
//         foreach (var processor in _processors)
//         {
//             result = processor(result);
//         }
//         return result;
//     }

//     public IEnumerable<T> ProcessBatch(IEnumerable<T> inputs)
//     {
//         return inputs.Select(Process);
//     }

//     public async Task<T> ProcessAsync(T input)
//     {
//         return await Task.Run(() => Process(input));
//     }

//     public async Task<IEnumerable<T>> ProcessBatchAsync(IEnumerable<T> inputs)
//     {
//         var tasks = inputs.Select(ProcessAsync);
//         return await Task.WhenAll(tasks);
//     }
// }

// public class ValidationProcessor<T> : IValidationProcessor<T>
// {
//     private readonly List<Func<T, bool>> _validators = new();
//     private readonly List<Func<T, string>> _errorProviders = new();
//     private readonly List<Func<T, T>> _processors = new();

//     public void AddValidator(Func<T, bool> validator, Func<T, string> errorProvider)
//     {
//         _validators.Add(validator);
//         _errorProviders.Add(errorProvider);
//     }

//     public void AddProcessor(Func<T, T> processor)
//     {
//         _processors.Add(processor);
//     }

//     public bool IsValid(T input)
//     {
//         return _validators.All(validator => validator(input));
//     }

//     public IEnumerable<string> GetValidationErrors(T input)
//     {
//         var errors = new List<string>();
//         for (int i = 0; i < _validators.Count; i++)
//         {
//             if (!_validators[i](input))
//             {
//                 errors.Add(_errorProviders[i](input));
//             }
//         }
//         return errors;
//     }

//     public T ProcessWithValidation(T input)
//     {
//         var errors = GetValidationErrors(input).ToList();
//         if (errors.Any())
//         {
//             throw new ValidationException($"Validation failed: {string.Join(", ", errors)}");
//         }

//         return Process(input);
//     }

//     public T Process(T input)
//     {
//         var result = input;
//         foreach (var processor in _processors)
//         {
//             result = processor(result);
//         }
//         return result;
//     }

//     public IEnumerable<T> ProcessBatch(IEnumerable<T> inputs)
//     {
//         return inputs.Select(Process);
//     }

//     public async Task<T> ProcessAsync(T input)
//     {
//         return await Task.Run(() => Process(input));
//     }

//     public async Task<IEnumerable<T>> ProcessBatchAsync(IEnumerable<T> inputs)
//     {
//         var tasks = inputs.Select(ProcessAsync);
//         return await Task.WhenAll(tasks);
//     }
// }

// public class ValidationException : Exception
// {
//     public ValidationException(string message) : base(message) { }
//     public ValidationException(string message, Exception innerException) : base(message, innerException) { }
// }

using Lab3._3_Generic_Classes_Methods.Collections;
using Lab3._3_Generic_Classes_Methods.Models;
using Lab3._3_Generic_Classes_Methods.Services;
using Lab3._3_Generic_Classes_Methods.Utilities;

namespace Lab3._3_Generic_Classes_Methods.Services;

public static class DataProcessor
{
    public static void RunAllDemos()
    {
        Console.WriteLine("=== Generic Class Demonstrations ===\n");

        // 1) Generic Repository
        Console.WriteLine("1. Generic Repository Pattern:");
        var prodRepo = new Repository<Product>();
        prodRepo.Add(new Product { Name = "Laptop", Price = 999.99m });
        prodRepo.Add(new Product { Name = "Mouse", Price = 29.99m });
        prodRepo.Add(new Product { Name = "Keyboard", Price = 79.99m });

        Console.WriteLine("   📚 Product Repository:");
        foreach (var p in prodRepo.GetAll()) Console.WriteLine($"   - Added: {p}");
        Console.WriteLine($"   - Total Products: {prodRepo.Count}");
        Console.WriteLine($"   - Found by ID 1: {prodRepo.GetById(1)}\n");

        var custRepo = new Repository<Customer>();
        custRepo.Add(new Customer { FirstName = "John", LastName = "Doe", Email = "john@email.com" });
        custRepo.Add(new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@email.com" });

        Console.WriteLine("   👥 Customer Repository:");
        foreach (var c in custRepo.GetAll()) Console.WriteLine($"   - Added: {c}");
        Console.WriteLine($"   - Total Customers: {custRepo.Count}");
        var byEmail = custRepo.Find(c => c.Email.Contains("jane", StringComparison.OrdinalIgnoreCase)).First();
        Console.WriteLine($"   - Search by email: {byEmail}\n");

        // 2) Generic Collections
        Console.WriteLine("2. Generic Collections:");
        var glist = new GenericList<string>();
        glist.Add("Apple"); glist.Add("Banana"); glist.Add("Cherry");
        Console.WriteLine("   📦 Custom Generic List<string>:");
        Console.WriteLine($"   - Items: {glist}");
        Console.WriteLine($"   - Count: {glist.Count}, Capacity: {glist.Capacity}");
        Console.WriteLine($"   - Contains 'Banana': {glist.Contains("Banana")}\n");

        var gstack = new GenericStack<int>();
        gstack.Push(10); gstack.Push(20); gstack.Push(30);
        var popped = gstack.Pop();
        Console.WriteLine("   📚 Generic Stack<int>:");
        Console.WriteLine($"   - Pushed: 10, 20, 30");
        Console.WriteLine($"   - Popped: {popped} (remaining: {gstack.Count} items)");
        Console.WriteLine($"   - Peek: {gstack.Peek()}\n");

        Console.WriteLine("=== Generic Method Demonstrations ===\n");

        // 3) Generic Utility Methods (Math)
        Console.WriteLine("3. Generic Utility Methods:");
        Console.WriteLine("   🔢 Generic Math Operations:");
        Console.WriteLine($"   - Max(10, 20): {GenericMath.Max(10, 20)}");
        Console.WriteLine($"   - Min(3.14, 2.71): {GenericMath.Min(3.14, 2.71)}");
        Console.WriteLine($"   - Add(5, 7): {GenericMath.Add<int>(5, 7)}\n");

        // 4) Generic Conversion
        Console.WriteLine("   🔄 Generic Conversion:");
        Console.WriteLine($"   - String to Int: \"123\" → {Converter.StringToInt.Convert("123")}");
        Console.WriteLine($"   - Int to String: 456 → \"{Converter.IntToString.Convert(456)}\"");
        Console.WriteLine($"   - Bool to String: True → \"{Converter.BoolToString.Convert(true)}\"\n");

        Console.WriteLine("4. Generic Comparison:");
        var nums = new List<int> { 7, 1, 9, 3, 5 };
        var strs = new List<string> { "Banana", "Apple", "Cherry" };
        var prods = prodRepo.GetAll().ToList(); // already comparable by price

        nums = Utilities.GenericComparer.SortedCopy(nums);
        strs = Utilities.GenericComparer.SortedCopy(strs);
        prods = Utilities.GenericComparer.SortedCopy(prods);

        Console.WriteLine($"   📊 Generic Sorting:");
        Console.WriteLine($"   - Numbers: [{string.Join(", ", nums)}]");
        Console.WriteLine($"   - Strings: [{string.Join(", ", strs)}]");
        Console.WriteLine($"   - Custom Objects: [{string.Join(", ", prods.Select(p => p.Name))}]\n");

        Console.WriteLine("=== Advanced Generic Patterns ===\n");

        // 5) Multiple Type Parameters – KeyValueStore
        Console.WriteLine("5. Multiple Type Parameters:");
        var store = new Utilities.KeyValueStore<string, Product>();
        store.Set("laptop", prodRepo.GetById(1)!);
        store.Set("mouse", prodRepo.GetById(2)!);
        Console.WriteLine("   🗃️ Generic Key-Value Store<string, Product>:");
        Console.WriteLine($"   - Stored: \"laptop\" → {store.Get("laptop")}");
        Console.WriteLine($"   - Stored: \"mouse\" → {store.Get("mouse")}");
        Console.WriteLine($"   - Retrieved: \"laptop\" → {store.Get("laptop")}\n");

        // 6) Generic Delegates / Events
        Console.WriteLine("6. Generic Delegates and Events:");
        var bus = new Utilities.EventBus<Product>();
        int notified = 0;
        bus.Subscribe(p => { notified++; /* handler 1 */ });
        bus.Subscribe(p => { notified++; /* handler 2 */ });
        bus.Publish(prodRepo.GetById(1)!);
        Console.WriteLine("   📢 Generic Event System:");
        Console.WriteLine("   - Event Published: ProductAdded<Product>");
        Console.WriteLine($"   - Subscribers Notified: {notified} handlers");
        Console.WriteLine($"   - Event Data: {prodRepo.GetById(1)!}\n");

        // 7) Generic inheritance is implied via Repository<T> usage; also show specialized class
        Console.WriteLine("7. Generic Inheritance:");
        Console.WriteLine("   🏪 Specialized Repositories:");
        Console.WriteLine("   - ProductRepository extends Repository<Product>");
        Console.WriteLine("   - CustomerRepository extends Repository<Customer>");
        Console.WriteLine("   - OrderRepository extends Repository<Order>");
    }
}