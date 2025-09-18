# Lab 3.3: Generic Classes and Methods

## 🎯 Objectives

By the end of this lab, you will understand and be able to implement:

- **Generic Classes**: Create reusable classes with type parameters
- **Generic Methods**: Write methods that work with multiple types
- **Generic Interfaces**: Define contracts with type parameters
- **Type Parameters**: Use single and multiple type parameters effectively
- **Generic Collections**: Create custom generic collection classes
- **Generic Delegates**: Define type-safe function pointers
- **Default Values**: Handle default values for generic types
- **Type Inference**: Leverage compiler type inference
- **Generic Inheritance**: Inherit from generic base classes

## 📚 Theory

### Generic Classes

Generic classes allow you to create reusable code that works with different types:

```csharp
public class Repository<T> where T : class
{
    private readonly List<T> _items = new();
    
    public void Add(T item) => _items.Add(item);
    public T? GetById(int id) => _items.ElementAtOrDefault(id);
    public IEnumerable<T> GetAll() => _items.AsReadOnly();
}
```

### Generic Methods

Generic methods can be defined in both generic and non-generic classes:

```csharp
public static T Max<T>(T first, T second) where T : IComparable<T>
{
    return first.CompareTo(second) >= 0 ? first : second;
}
```

### Multiple Type Parameters

You can use multiple type parameters for complex scenarios:

```csharp
public class KeyValueStore<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _store = new();
    
    public void Set(TKey key, TValue value) => _store[key] = value;
    public TValue? Get(TKey key) => _store.TryGetValue(key, out var value) ? value : default;
}
```

### Generic Interfaces

Define contracts that work with multiple types:

```csharp
public interface IConverter<TInput, TOutput>
{
    TOutput Convert(TInput input);
    bool CanConvert(TInput input);
}
```

### Generic Delegates

Create type-safe function pointers:

```csharp
public delegate TResult Processor<TInput, TResult>(TInput input);
public delegate void EventHandler<T>(T eventArgs);
```

## 🏗️ Project Structure

```
Lab3.3-Generic-Classes-Methods/
├── Models/
│   ├── Entity.cs               # Base entity class
│   ├── Product.cs              # Product entity
│   ├── Customer.cs             # Customer entity
│   └── Order.cs                # Order entity
├── Collections/
│   ├── GenericList.cs          # Custom generic list implementation
│   ├── GenericStack.cs         # Custom generic stack
│   ├── GenericQueue.cs         # Custom generic queue
│   └── GenericDictionary.cs    # Custom generic dictionary
├── Services/
│   ├── Repository.cs           # Generic repository pattern
│   ├── DataProcessor.cs        # Generic data processing
│   ├── Converter.cs            # Generic type conversion
│   └── Cache.cs                # Generic caching service
├── Interfaces/
│   ├── IRepository.cs          # Generic repository interface
│   ├── IConverter.cs           # Generic converter interface
│   └── IProcessor.cs           # Generic processor interface
├── Utilities/
│   ├── GenericMath.cs          # Generic mathematical operations
│   ├── GenericComparer.cs      # Generic comparison utilities
│   └── GenericValidator.cs     # Generic validation methods
├── Program.cs                  # Main application
├── Lab3.3-Generic-Classes-Methods.csproj
└── README.md
```

## 🔧 Key Classes

### Generic Repository
- **Type Safety**: Strongly typed data access
- **CRUD Operations**: Create, Read, Update, Delete with generics
- **Query Methods**: Generic search and filtering
- **Batch Operations**: Process multiple items efficiently
- **Event Handling**: Generic event notifications

### Generic Collections
- **Custom List**: Generic list with additional functionality
- **Generic Stack**: LIFO collection with type safety
- **Generic Queue**: FIFO collection implementation
- **Generic Dictionary**: Key-value storage with type parameters
- **Performance**: Optimized generic collection operations

### Generic Utilities
- **Mathematical Operations**: Generic math functions
- **Comparison Utilities**: Generic sorting and comparison
- **Validation Methods**: Type-safe validation logic
- **Conversion Services**: Generic type conversion
- **Caching System**: Generic memory caching

## 🚀 Running the Lab

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022, VS Code, or any C# IDE

### Build and Run
```bash
# Navigate to the lab directory
cd "Day3/Lab3.3-Generic-Classes-Methods"

# Build the project
dotnet build

# Run the application
dotnet run
```

### Expected Output
The program will demonstrate:
1. Generic class creation and usage
2. Generic method implementations
3. Multiple type parameter scenarios
4. Generic interface implementations
5. Custom generic collection classes
6. Generic delegate usage
7. Type inference examples
8. Generic inheritance patterns

## 💡 Exercises

### Exercise 1: Generic Data Structure
Create a `BinaryTree<T>` class with:
- Generic node structure
- Insert, search, and delete operations
- In-order, pre-order, and post-order traversal methods
- Generic comparison for ordering
- Balance checking methods

### Exercise 2: Generic Service Layer
Implement a `ServiceManager<T>` with:
- Generic service registration
- Dependency injection for generic services
- Service lifecycle management
- Generic service resolution
- Service health monitoring

### Exercise 3: Generic Pipeline
Design a `Pipeline<T>` class with:
- Generic stage processing
- Fluent interface for pipeline building
- Error handling at each stage
- Parallel processing support
- Pipeline result aggregation

### Exercise 4: Generic Event System
Create an `EventBus<T>` with:
- Generic event publishing
- Type-safe event subscription
- Event filtering and routing
- Asynchronous event handling
- Event history and replay

## 🏆 Challenges

### Challenge 1: Generic Expression Builder
Implement a system that:
- Builds LINQ expressions generically
- Supports dynamic property access
- Provides type-safe query building
- Includes expression caching
- Supports complex query scenarios

### Challenge 2: Generic Serialization Framework
Create a framework that:
- Serializes any generic type
- Supports multiple output formats
- Handles circular references
- Provides custom serialization hooks
- Includes performance optimization

### Challenge 3: Generic State Machine
Build a state machine that:
- Works with any state and event types
- Provides type-safe transitions
- Supports conditional transitions
- Includes state entry/exit actions
- Provides state history tracking

### Challenge 4: Generic Caching System
Implement a caching system with:
- Multiple cache providers
- Generic key and value types
- Cache expiration strategies
- Cache statistics and monitoring
- Distributed caching support

## 📋 Expected Output

```
🎯 Day 3 - Lab 3.3: Generic Classes and Methods
============================================================

=== Generic Class Demonstrations ===

1. Generic Repository Pattern:
   📚 Product Repository:
   - Added: Laptop ($999.99)
   - Added: Mouse ($29.99)
   - Added: Keyboard ($79.99)
   - Total Products: 3
   - Found by ID 1: Laptop ($999.99)

   👥 Customer Repository:
   - Added: John Doe (john@email.com)
   - Added: Jane Smith (jane@email.com)
   - Total Customers: 2
   - Search by email: Jane Smith (jane@email.com)

2. Generic Collections:
   📦 Custom Generic List<string>:
   - Items: [Apple, Banana, Cherry]
   - Count: 3, Capacity: 4
   - Contains 'Banana': True

   📚 Generic Stack<int>:
   - Pushed: 10, 20, 30
   - Popped: 30 (remaining: 2 items)
   - Peek: 20

=== Generic Method Demonstrations ===

3. Generic Utility Methods:
   🔢 Generic Math Operations:
   - Max(10, 20): 20
   - Min(3.14, 2.71): 2.71
   - Add(5, 7): 12

   🔄 Generic Conversion:
   - String to Int: "123" → 123
   - Int to String: 456 → "456"
   - Bool to String: True → "True"

4. Generic Comparison:
   📊 Generic Sorting:
   - Numbers: [1, 3, 5, 7, 9]
   - Strings: [Apple, Banana, Cherry]
   - Custom Objects: [Product1, Product2, Product3]

=== Advanced Generic Patterns ===

5. Multiple Type Parameters:
   🗃️ Generic Key-Value Store<string, Product>:
   - Stored: "laptop" → Laptop ($999.99)
   - Stored: "mouse" → Mouse ($29.99)
   - Retrieved: "laptop" → Laptop ($999.99)

6. Generic Delegates and Events:
   📢 Generic Event System:
   - Event Published: ProductAdded<Product>
   - Subscribers Notified: 2 handlers
   - Event Data: Laptop ($999.99)

7. Generic Inheritance:
   🏪 Specialized Repositories:
   - ProductRepository extends Repository<Product>
   - CustomerRepository extends Repository<Customer>
   - OrderRepository extends Repository<Order>

🎉 Lab 3.3 completed successfully!
```

## 🎓 Key Learning Points

1. **Type Safety**: Generics provide compile-time type checking
2. **Code Reusability**: Write once, use with multiple types
3. **Performance**: Avoid boxing/unboxing with value types
4. **IntelliSense**: Better IDE support with generic types
5. **Constraints**: Use where clauses to limit type parameters
6. **Type Inference**: Compiler can often infer generic types
7. **Covariance/Contravariance**: Understand generic type relationships
8. **Default Values**: Handle default(T) appropriately

## 🔗 Related Concepts

- **Collections**: Generic collections in .NET Framework
- **LINQ**: Language Integrated Query with generics
- **Reflection**: Working with generic types at runtime
- **Performance**: Generic performance considerations
- **Design Patterns**: Generic implementations of common patterns
- **Constraints**: Generic type constraints and their uses
- **Variance**: Covariance and contravariance in generics

## 📖 Additional Resources

- [Microsoft Docs: Generics](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/)
- [Generic Constraints](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
- [Generic Methods](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-methods)
- [Generic Collections](https://docs.microsoft.com/en-us/dotnet/standard/collections/commonly-used-collection-types)
- [Covariance and Contravariance](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/)

---

**Next Lab**: Lab 3.4 - Generic Constraints and Variance
**Previous Lab**: Lab 3.2 - Object Initializers and Factory Patterns
