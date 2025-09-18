
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
