// using Lab3._4_Generic_Constraints_Variance.Models;
// using Lab3._4_Generic_Constraints_Variance.Constraints;
// using Lab3._4_Generic_Constraints_Variance.Variance;
// using System.Numerics;

// namespace Lab3._4_Generic_Constraints_Variance;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("=== Lab 3.4: Generic Constraints and Variance ===\n");

//         // Demonstrate numeric constraints
//         DemonstrateNumericConstraints();

//         // Demonstrate comparable constraints
//         DemonstrateComparableConstraints();

//         // Demonstrate entity constraints
//         DemonstrateEntityConstraints();

//         // Demonstrate collection constraints
//         DemonstrateCollectionConstraints();

//         // Demonstrate covariance
//         DemonstrateCovariance();

//         // Demonstrate contravariance
//         DemonstrateContravariance();

//         // Demonstrate delegate variance
//         DemonstrateDelegateVariance();

//         Console.WriteLine("\n=== Lab 3.4 Complete ===");
//         Console.WriteLine("Press any key to exit...");
//         Console.ReadKey();
//     }

//     static void DemonstrateNumericConstraints()
//     {
//         Console.WriteLine("=== Numeric Constraints (INumber<T>) ===");

//         var calculator = new Calculator<int>();
//         Console.WriteLine($"Add: {calculator.Add(10, 20)}");
//         Console.WriteLine($"Multiply: {calculator.Multiply(5, 6)}");
//         Console.WriteLine($"Power: {calculator.Power(2, 8)}");

//         var doubleCalculator = new Calculator<double>();
//         Console.WriteLine($"Add (double): {doubleCalculator.Add(3.14, 2.86)}");
//         Console.WriteLine($"Divide: {doubleCalculator.Divide(10.0, 3.0)}");

//         var statistics = new Statistics<decimal>();
//         var numbers = new decimal[] { 1.5m, 2.5m, 3.5m, 4.5m, 5.5m };
//         Console.WriteLine($"Sum: {statistics.Sum(numbers)}");
//         Console.WriteLine($"Average: {statistics.Average(numbers)}");
//         Console.WriteLine($"Min: {statistics.Min(numbers)}");
//         Console.WriteLine($"Max: {statistics.Max(numbers)}");
//         Console.WriteLine();
//     }

//     static void DemonstrateComparableConstraints()
//     {
//         Console.WriteLine("=== Comparable Constraints (IComparable<T>) ===");

//         var products = new List<Product>
//         {
//             new Product("Laptop", 999.99m, "Electronics"),
//             new Product("Mouse", 29.99m, "Electronics"),
//             new Product("Keyboard", 79.99m, "Electronics")
//         };

//         var sortableCollection = new SortableCollection<Product>();
//         foreach (var product in products)
//         {
//             sortableCollection.Add(product);
//         }

//         Console.WriteLine("Products sorted by name:");
//         var sorted = sortableCollection.GetSorted();
//         foreach (var product in sorted)
//         {
//             Console.WriteLine($"  {product.Name}: ${product.Price}");
//         }

//         var rangeChecker = new RangeChecker<Product>();
//         var minProduct = new Product("A", 0m, "Test");
//         var maxProduct = new Product("Z", 2000m, "Test");

//         foreach (var product in products)
//         {
//             bool inRange = rangeChecker.IsInRange(product, minProduct, maxProduct);
//             Console.WriteLine($"  {product.Name} in range: {inRange}");
//         }

//         // Binary Search Tree
//         var bst = new BinarySearchTree<int>();
//         var numbers = new[] { 50, 30, 70, 20, 40, 60, 80 };
//         foreach (var num in numbers)
//         {
//             bst.Insert(num);
//         }

//         Console.WriteLine("BST In-Order Traversal:");
//         Console.WriteLine($"  {string.Join(", ", bst.InOrderTraversal())}");
//         Console.WriteLine($"Contains 40: {bst.Contains(40)}");
//         Console.WriteLine($"Contains 90: {bst.Contains(90)}");
//         Console.WriteLine();
//     }

//     static void DemonstrateEntityConstraints()
//     {
//         Console.WriteLine("=== Entity Constraints (IEntity) ===");

//         var entityRepo = new EntityRepository<Product>();

//         var product1 = new Product("Gaming Laptop", 1299.99m, "Electronics");
//         var product2 = new Product("Wireless Mouse", 49.99m, "Electronics");

//         entityRepo.Add(product1);
//         entityRepo.Add(product2);

//         Console.WriteLine("All entities:");
//         foreach (var entity in entityRepo.GetAll())
//         {
//             Console.WriteLine($"  ID: {entity.Id}, Name: {entity.Name}, Created: {entity.CreatedAt:yyyy-MM-dd HH:mm:ss}");
//         }

//         // Demonstrate soft delete
//         entityRepo.SoftDelete(product1.Id);
//         Console.WriteLine($"\nAfter soft delete of {product1.Name}:");
//         Console.WriteLine($"Active entities: {entityRepo.GetActive().Count()}");
//         Console.WriteLine($"Deleted entities: {entityRepo.GetDeleted().Count()}");

//         // Entity factory
//         var factory = new EntityFactory<Customer>();
//         var customer = factory.Create();
//         customer.FirstName = "John";
//         customer.LastName = "Doe";
//         customer.Email = "john.doe@example.com";

//         Console.WriteLine($"\nCreated customer: {customer.FirstName} {customer.LastName} (ID: {customer.Id})");

//         // Cloneable operations
//         var cloneableOps = new CloneableOperations<Product>();
//         var clonedProduct = cloneableOps.DeepClone(product2);
//         Console.WriteLine($"Original: {product2.Name} (ID: {product2.Id})");
//         Console.WriteLine($"Cloned: {clonedProduct.Name} (ID: {clonedProduct.Id})");
//         Console.WriteLine();
//     }

//     static void DemonstrateCollectionConstraints()
//     {
//         Console.WriteLine("=== Collection Constraints ===");

//         // ICollection<T> constraint
//         var collectionOps = new CollectionOperations<string>();
//         var stringList = new List<string> { "apple", "banana", "cherry" };

//         collectionOps.AddRange(stringList, new[] { "date", "elderberry" });
//         Console.WriteLine($"Collection count after AddRange: {stringList.Count}");
//         Console.WriteLine($"Contains 'banana': {collectionOps.Contains(stringList, "banana")}");

//         var filtered = collectionOps.Filter(stringList, s => s.StartsWith('a'));
//         Console.WriteLine($"Items starting with 'a': {string.Join(", ", filtered)}");

//         // IDictionary<TKey, TValue> constraint
//         var dictOps = new DictionaryOperations<string, int>();
//         var dictionary = new Dictionary<string, int>
//         {
//             { "apple", 5 },
//             { "banana", 3 },
//             { "cherry", 8 }
//         };

//         dictOps.AddOrUpdate(dictionary, "date", 2);
//         dictOps.AddOrUpdate(dictionary, "apple", 7); // Update existing

//         Console.WriteLine("Dictionary contents:");
//         foreach (var kvp in dictionary)
//         {
//             Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
//         }

//         var merged = dictOps.Merge(dictionary, new Dictionary<string, int> { { "fig", 4 }, { "grape", 6 } });
//         Console.WriteLine($"Merged dictionary count: {merged.Count}");

//         // Thread-safe collection
//         var threadSafeCollection = new ThreadSafeCollection<int>();

//         // Simulate concurrent operations
//         var tasks = new List<Task>();
//         for (int i = 0; i < 5; i++)
//         {
//             int taskId = i;
//             tasks.Add(Task.Run(() =>
//             {
//                 for (int j = 0; j < 10; j++)
//                 {
//                     threadSafeCollection.Add(taskId * 10 + j);
//                 }
//             }));
//         }

//         Task.WaitAll(tasks.ToArray());
//         Console.WriteLine($"Thread-safe collection count: {threadSafeCollection.Count}");
//         Console.WriteLine();
//     }

//     static void DemonstrateCovariance()
//     {
//         Console.WriteLine("=== Covariance Examples ===");

//         CovarianceExamples.DemonstrateProducerCovariance();
//         CovarianceExamples.DemonstrateRepositoryCovariance();
//         CovarianceExamples.DemonstrateEventSourceCovariance();
//         CovarianceExamples.DemonstrateCollectionCovariance();
//         CovarianceExamples.DemonstrateFuncCovariance();
//         Console.WriteLine();
//     }

//     static void DemonstrateContravariance()
//     {
//         Console.WriteLine("=== Contravariance Examples ===");

//         ContravarianceExamples.DemonstrateConsumerContravariance();
//         ContravarianceExamples.DemonstrateComparerContravariance();
//         ContravarianceExamples.DemonstrateValidatorContravariance();
//         ContravarianceExamples.DemonstrateEventHandlerContravariance();
//         ContravarianceExamples.DemonstrateActionContravariance();
//         ContravarianceExamples.DemonstratePredicateContravariance();

//         // Mixed variance
//         MixedVarianceExamples.DemonstrateProcessorVariance();
//         MixedVarianceExamples.DemonstrateFuncActionVariance();
//         Console.WriteLine();
//     }

//     static void DemonstrateDelegateVariance()
//     {
//         Console.WriteLine("=== Delegate Variance ===");

//         VariantDelegates.DemonstrateProducerDelegateCovariance();
//         VariantDelegates.DemonstrateConsumerDelegateContravariance();
//         VariantDelegates.DemonstrateConverterDelegateMixedVariance();
//         VariantDelegates.DemonstrateBuiltInDelegateVariance();
//         VariantDelegates.DemonstrateEventHandlerVariance();
//         VariantDelegates.DemonstrateComplexDelegateVariance();

//         // Event system demonstration
//         var eventSystem = new VariantEventSystem<string>();

//         // Object consumer can handle string events (contravariance)
//         Consumer<object> objectConsumer = obj => Console.WriteLine($"Object handler: {obj}");
//         Consumer<string> stringConsumer = objectConsumer;

//         eventSystem.Subscribe(stringConsumer);
//         eventSystem.Subscribe(str => Console.WriteLine($"String handler: {str}"));

//         Console.WriteLine("Publishing events:");
//         eventSystem.Publish("First Event");
//         eventSystem.Publish("Second Event");
//         Console.WriteLine();
//     }
// }

using Lab3._4_Generic_Constraints_Variance.Models;
using Lab3._4_Generic_Constraints_Variance.Constraints;
using Lab3._4_Generic_Constraints_Variance.Variance;

Console.WriteLine("🎯 Day 3 - Lab 3.4: Generic Constraints and Variance");
Console.WriteLine("============================================================\n");

Console.WriteLine("=== Generic Constraint Demonstrations ===\n");

// 1. Class & struct constraints
Console.WriteLine("1. Class and Struct Constraints:");
var customers = new List<Customer>();
int nextId = 1;
var added = EntityOperations.AddWithAutoId(customers, new Customer { FirstName = "John", LastName = "Doe" }, ref nextId);
Console.WriteLine("  📚 Reference Type Repository<Customer>:");
Console.WriteLine("  - Customer repository created (reference type constraint)");
Console.WriteLine($"  - Added customer: {added.DisplayName} (ID: {added.Id})");
Console.WriteLine($"  - Repository count: {customers.Count}\n");

Console.WriteLine("  🔢 Value Type Calculator<int>:");
Console.WriteLine($"  - Calculator created (value type constraint)");
Console.WriteLine($"  - Add operation: 10 + 20 = {NumericOperations.Add(10, 20)}");
Console.WriteLine($"  - Multiply operation: 5 * 6 = {NumericOperations.Multiply(5, 6)}\n");

// 2. Interface constraints (IComparable)
Console.WriteLine("2. Interface Constraints:");
var products = new List<Product>
{
    new() { Name = "Laptop",   Price = 999.99m },
    new() { Name = "Mouse",    Price = 29.99m },
    new() { Name = "Keyboard", Price = 79.99m }
};
Console.WriteLine("  📊 Sortable Collection<Product> (IComparable constraint):");
Console.WriteLine($"  - Products added: [{string.Join(", ", products.Select(p => p.DisplayName))}]");
var sortedByPrice = ComparableOperations.Sorted(products);
Console.WriteLine($"  - Sorted by price: [{string.Join(", ", sortedByPrice.Select(p => p.DisplayName))}]");
Console.WriteLine("  - Sort operation successful due to IComparable<Product>\n");

// 3. Constructor constraint
Console.WriteLine("3. Constructor Constraints:");
var factoryCreated = EntityOperations.CreateDefault<Product>();
factoryCreated.Id = 1;
Console.WriteLine("  🏭 Generic Factory<Product> (new() constraint):");
Console.WriteLine("  - Factory created with constructor constraint");
Console.WriteLine($"  - Product instance created: {factoryCreated.DisplayName} (ID: {factoryCreated.Id})");
Console.WriteLine("  - Factory can create any type with parameterless constructor\n");

Console.WriteLine("=== Variance Demonstrations ===\n");

// 4. Covariance
Console.WriteLine("4. Covariance (out keyword):");
var (asString, asObject) = CovariantDemo.Run();
Console.WriteLine("  📤 Covariant Producer<string> → Producer<object>:");
Console.WriteLine($"  - String producer: \"{asString}\"");
Console.WriteLine("  - Assigned to object producer (covariance)");
Console.WriteLine($"  - Retrieved value: \"{asObject}\" (as object)");
Console.WriteLine("  - Covariance allows more derived → less derived assignment\n");

// 5. Contravariance
Console.WriteLine("5. Contravariance (in keyword):");
var (before, after, log) = ContravariantDemo.Run();
Console.WriteLine("  📥 Contravariant Consumer<object> → Consumer<string>:");
Console.WriteLine("  - Object consumer created");
Console.WriteLine("  - Assigned to string consumer (contravariance)");
Console.WriteLine($"  - Consumed string: \"Test String\"");
Console.WriteLine($"  - Log entries before: {before}, after: {after}");
Console.WriteLine("  - Contravariance allows less derived → more derived assignment\n");

// 6. Delegate variance
Console.WriteLine("6. Delegate Variance:");
var (funcRes, actionRes) = VariantDelegates.Run();
Console.WriteLine("  🎯 Function and Action Delegates:");
Console.WriteLine($"  - Func<string, object> → Func<string, string> (covariant return) -> {funcRes}");
Console.WriteLine($"  - Action<object> → Action<string> (contravariant parameter) -> {actionRes}\n");

// 7. Multiple constraints demo (informational)
Console.WriteLine("=== Advanced Constraint Patterns ===\n");
Console.WriteLine("7. Multiple Constraints:");
Console.WriteLine("  🔗 Example: EntityRepository<T> where T : class, IEntity, IComparable<T>, new()");
Console.WriteLine("  - (Demonstrated above with Product implementing IEntity + IComparable and using new())\n");

// 8. Conditional / performance style constraints
Console.WriteLine("8. Conditional Constraints:");
Console.WriteLine("  ⚡ Numeric operations with INumber<T> constraint demonstrated earlier");
Console.WriteLine("  - Constraints enable compile-time optimizations\n");

// 9. Real variance scenario (short summary)
Console.WriteLine("9. Variance in Real Scenarios:");
Console.WriteLine("  📋 Event-style producers/handlers are classic cases for covariance/contravariance\n");

Console.WriteLine("🎉 Lab 3.4 completed successfully!");
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();