// using Lab3._3_Generic_Classes_Methods.Models;
// using Lab3._3_Generic_Classes_Methods.Services;
// using Lab3._3_Generic_Classes_Methods.Collections;
// using Lab3._3_Generic_Classes_Methods.Interfaces;
// using Lab3._3_Generic_Classes_Methods.Utilities;

// Console.WriteLine("🎯 Day 3 - Lab 3.3: Generic Classes and Methods");
// Console.WriteLine("============================================================\n");

// Console.WriteLine("=== Generic Class Demonstrations ===\n");

// // 1) Generic Repository Pattern
// var productRepo = new ProductRepository();
// productRepo.Add(new Product { Name = "Laptop", Price = 999.99m });
// productRepo.Add(new Product { Name = "Mouse", Price = 29.99m });
// productRepo.Add(new Product { Name = "Keyboard", Price = 79.99m });

// var customerRepo = new CustomerRepository();
// customerRepo.Add(new Customer { FirstName = "John", LastName = "Doe", Email = "john@email.com" });
// customerRepo.Add(new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@email.com" });

// Console.WriteLine("1. Generic Repository Pattern:");
// Console.WriteLine("   📚 Product Repository:");
// foreach (var p in productRepo.GetAll())
//     Console.WriteLine($"   - Added: {p.Name} (${p.Price:F2})");
// Console.WriteLine($"   - Total Products: {productRepo.Count}");
// var found = productRepo.GetById(1);
// Console.WriteLine($"   - Found by ID 1: {found?.Name} (${found?.Price:F2})\n");

// Console.WriteLine("   👥 Customer Repository:");
// foreach (var c in customerRepo.GetAll())
//     Console.WriteLine($"   - Added: {c.FullName} ({c.Email})");
// Console.WriteLine($"   - Total Customers: {customerRepo.Count}");
// var foundJane = customerRepo.Find(c => c.Email.Contains("jane")).FirstOrDefault();
// Console.WriteLine($"   - Search by email: {foundJane?.FullName} ({foundJane?.Email})\n");

// // 2) Generic Collections
// Console.WriteLine("2. Generic Collections:");
// var glist = new GenericList<string>();
// glist.Add("Apple");
// glist.Add("Banana");
// glist.Add("Cherry");
// Console.WriteLine("   📦 Custom Generic List<string>:");
// Console.WriteLine($"   - Items: [{string.Join(", ", glist)}]");
// Console.WriteLine($"   - Count: {glist.Count}, Capacity: {glist.Capacity}");
// Console.WriteLine($"   - Contains 'Banana': {glist.Contains("Banana")}\n");

// var gstack = new GenericStack<int>();
// gstack.Push(10); gstack.Push(20); gstack.Push(30);
// int popped = gstack.Pop();
// Console.WriteLine("   📚 Generic Stack<int>:");
// Console.WriteLine($"   - Pushed: 10, 20, 30");
// Console.WriteLine($"   - Popped: {popped} (remaining: {gstack.Count} items)");
// Console.WriteLine($"   - Peek: {gstack.Peek()}\n");

// Console.WriteLine("=== Generic Method Demonstrations ===\n");

// // 3) Generic Utility Methods
// Console.WriteLine("3. Generic Utility Methods:");
// Console.WriteLine("   🔢 Generic Math Operations:");
// Console.WriteLine($"   - Max(10, 20): {GenericMath.Max(10, 20)}");
// Console.WriteLine($"   - Min(3.14, 2.71): {GenericMath.Min(3.14, 2.71)}");
// Console.WriteLine($"   - Add(5, 7): {GenericMath.Add(5, 7)}\n");

// Console.WriteLine("   🔄 Generic Conversion:");
// IConverter<string, int> strToInt = new Converters.StringToIntConverter();
// IConverter<int, string> intToStr = new Converters.IntToStringConverter();
// IConverter<bool, string> boolToStr = new Converters.BoolToStringConverter();
// Console.WriteLine($"   - String to Int: \"123\" → {strToInt.Convert("123")}");
// Console.WriteLine($"   - Int to String: 456 → \"{intToStr.Convert(456)}\"");
// Console.WriteLine($"   - Bool to String: True → \"{boolToStr.Convert(true)}\"\n");

// // 4) Generic Comparison/Sorting
// Console.WriteLine("4. Generic Comparison:");
// var nums = new List<int> { 7, 1, 9, 5, 3 };
// GenericComparer.Sort(nums);
// Console.WriteLine($"   📊 Numbers: [{string.Join(", ", nums)}]");
// var fruits = new List<string> { "Banana", "Apple", "Cherry" };
// GenericComparer.Sort(fruits);
// Console.WriteLine($"   📊 Strings: [{string.Join(", ", fruits)}]");
// var prods = productRepo.GetAll().ToList();
// GenericComparer.Sort(prods, (a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
// Console.WriteLine($"   📊 Custom Objects: [{string.Join(", ", prods.Select(p => p.Name))}]\n");

// Console.WriteLine("=== Advanced Generic Patterns ===\n");

// // 5) Multiple Type Parameters: KeyValueStore
// Console.WriteLine("5. Multiple Type Parameters:");
// var kv = new KeyValueStore<string, Product>();
// kv.Set("laptop", productRepo.Find(p => p.Name == "Laptop").First());
// kv.Set("mouse", productRepo.Find(p => p.Name == "Mouse").First());
// Console.WriteLine("   🗃️ Generic Key-Value Store<string, Product>:");
// Console.WriteLine($"   - Stored: \"laptop\" → {kv.Get("laptop")}");
// Console.WriteLine($"   - Stored: \"mouse\" → {kv.Get("mouse")}");
// Console.WriteLine($"   - Retrieved: \"laptop\" → {kv.Get("laptop")}\n");

// // 6) Generic Delegates and Events
// Console.WriteLine("6. Generic Delegates and Events:");
// var bus = new EventBus<Product>();
// int notifications = 0;
// bus.Subscribe(p => { notifications++; Console.WriteLine($"   - Handler A: Product Added => {p.Name} (${p.Price:F2})"); });
// bus.Subscribe(p => { notifications++; Console.WriteLine($"   - Handler B: Product Added => {p.Name} (${p.Price:F2})"); });
// bus.Publish(new Product { Name = "Headphones", Price = 199.99m });
// Console.WriteLine("   📢 Generic Event System:");
// Console.WriteLine("   - Event Published: ProductAdded<Product>");
// Console.WriteLine($"   - Subscribers Notified: {notifications} handlers\n");

// // 7) Generic Inheritance
// Console.WriteLine("7. Generic Inheritance:");
// Console.WriteLine("   🏪 Specialized Repositories:");
// Console.WriteLine("   - ProductRepository extends Repository<Product>");
// Console.WriteLine("   - CustomerRepository extends Repository<Customer>");
// Console.WriteLine("   - OrderRepository extends Repository<Order>");

// Console.WriteLine("\n🎉 Lab 3.3 completed successfully!");

using Lab3._3_Generic_Classes_Methods.Services;

Console.WriteLine("🎯 Day 3 - Lab 3.3: Generic Classes and Methods");
Console.WriteLine("============================================================\n");

DataProcessor.RunAllDemos();

Console.WriteLine("\n🎉 Lab 3.3 completed successfully!");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();