# Lab 3.4: Generic Constraints and Variance

## 🎯 Objectives

By the end of this lab, you will understand and be able to implement:

- **Generic Constraints**: Restrict type parameters with where clauses
- **Class Constraints**: Ensure type parameters are reference types
- **Struct Constraints**: Ensure type parameters are value types
- **Interface Constraints**: Require implementation of specific interfaces
- **Constructor Constraints**: Require parameterless constructors
- **Covariance**: Use `out` keyword for output type parameters
- **Contravariance**: Use `in` keyword for input type parameters
- **Invariance**: Understand when generics are invariant
- **Variance in Delegates**: Apply variance to delegate types
- **Variance in Interfaces**: Design variant generic interfaces

## 📚 Theory

### Generic Constraints

Generic constraints allow you to specify requirements for type parameters:

```csharp
// Class constraint - T must be a reference type
public class Repository<T> where T : class
{
    // Implementation
}

// Struct constraint - T must be a value type
public class Calculator<T> where T : struct
{
    // Implementation
}

// Interface constraint - T must implement IComparable
public class SortedList<T> where T : IComparable<T>
{
    // Implementation
}

// Constructor constraint - T must have parameterless constructor
public class Factory<T> where T : new()
{
    public T Create() => new T();
}
```

### Multiple Constraints

You can combine multiple constraints:

```csharp
public class EntityRepository<T> where T : class, IEntity, new()
{
    // T must be a reference type, implement IEntity, and have a parameterless constructor
}
```

### Covariance (out)

Covariance allows you to use a more derived type than originally specified:

```csharp
public interface IProducer<out T>
{
    T Produce(); // T only appears in output positions
}

// This is valid due to covariance
IProducer<object> producer = new Producer<string>();
```

### Contravariance (in)

Contravariance allows you to use a more generic type than originally specified:

```csharp
public interface IConsumer<in T>
{
    void Consume(T item); // T only appears in input positions
}

// This is valid due to contravariance
IConsumer<string> consumer = new Consumer<object>();
```

### Invariance

When a generic type parameter is used in both input and output positions, it's invariant:

```csharp
public interface IRepository<T>
{
    T Get(int id);     // Output position
    void Add(T item);  // Input position
    // T is invariant - no variance allowed
}
```

## 🏗️ Project Structure

```
Lab3.4-Generic-Constraints-Variance/
├── Models/
│   ├── IEntity.cs              # Base entity interface
│   ├── BaseEntity.cs           # Base entity implementation
│   ├── Product.cs              # Product entity with constraints
│   ├── Customer.cs             # Customer entity with constraints
│   └── Order.cs                # Order entity with constraints
├── Constraints/
│   ├── NumericOperations.cs    # Numeric constraint examples
│   ├── ComparableOperations.cs # IComparable constraint examples
│   ├── EntityOperations.cs     # Entity constraint examples
│   └── CollectionOperations.cs # Collection constraint examples
├── Variance/
│   ├── CovariantInterfaces.cs  # Covariance examples
│   ├── ContravariantInterfaces.cs # Contravariance examples
│   ├── VariantDelegates.cs     # Delegate variance examples
│   └── VarianceExamples.cs     # Practical variance scenarios
├── Services/
│   ├── ConstrainedRepository.cs # Repository with constraints
│   ├── VariantEventSystem.cs   # Event system with variance
│   ├── TypeSafeOperations.cs   # Type-safe operations
│   └── AdvancedConstraints.cs  # Advanced constraint patterns
├── Utilities/
│   ├── ConstraintHelpers.cs    # Constraint utility methods
│   ├── VarianceHelpers.cs      # Variance utility methods
│   └── TypeCheckers.cs         # Runtime type checking
├── Program.cs                  # Main application
├── Lab3.4-Generic-Constraints-Variance.csproj
└── README.md
```

## 🔧 Key Classes

### Constrained Repository
- **Entity Constraints**: Ensure entities implement required interfaces
- **Constructor Constraints**: Enable generic object creation
- **Type Safety**: Compile-time type checking with constraints
- **Performance**: Optimized operations with known type capabilities
- **Flexibility**: Support multiple constraint combinations

### Variance Examples
- **Covariant Producers**: Interfaces that only output values
- **Contravariant Consumers**: Interfaces that only accept inputs
- **Variant Delegates**: Function and action delegates with variance
- **Real-world Scenarios**: Practical applications of variance
- **Type Relationships**: Understanding inheritance and variance

### Advanced Constraints
- **Nested Constraints**: Complex constraint combinations
- **Conditional Constraints**: Runtime constraint validation
- **Performance Constraints**: Optimizations enabled by constraints
- **Design Patterns**: Constraint-based design patterns
- **Error Prevention**: Compile-time error prevention

## 🚀 Running the Lab

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022, VS Code, or any C# IDE

### Build and Run
```bash
# Navigate to the lab directory
cd "Day3/Lab3.4-Generic-Constraints-Variance"

# Build the project
dotnet build

# Run the application
dotnet run
```

### Expected Output
The program will demonstrate:
1. Various generic constraint types and combinations
2. Covariance examples with interfaces and delegates
3. Contravariance examples with consumers and handlers
4. Invariance scenarios and limitations
5. Real-world applications of constraints and variance
6. Performance benefits of constrained generics
7. Type safety improvements with constraints
8. Advanced variance patterns and use cases

## 💡 Exercises

### Exercise 1: Advanced Constraints
Create a `DataProcessor<T>` class with:
- Multiple interface constraints (IComparable, ICloneable, IDisposable)
- Constructor constraint for object creation
- Class constraint for reference type operations
- Custom constraint validation methods
- Performance optimizations using constraints

### Exercise 2: Covariant Collections
Implement a `ReadOnlyCollection<T>` with:
- Covariant interface design
- Safe type conversions
- Enumeration support with variance
- LINQ compatibility with covariance
- Performance considerations for variant collections

### Exercise 3: Contravariant Handlers
Design an `EventHandler<T>` system with:
- Contravariant event handling
- Type-safe event subscription
- Hierarchical event handling
- Event filtering with contravariance
- Performance optimizations

### Exercise 4: Constraint-Based Factory
Build a `GenericFactory<T>` with:
- Constructor constraints for instantiation
- Interface constraints for capabilities
- Conditional constraint checking
- Factory method patterns with constraints
- Dependency injection with constraints

## 🏆 Challenges

### Challenge 1: Self-Referencing Constraints
Implement a system with:
- Recursive generic constraints
- Self-referencing type parameters
- Fluent interface with constraints
- Builder pattern with type safety
- Complex inheritance hierarchies

### Challenge 2: Variance in Collections
Create a collection framework that:
- Supports full variance capabilities
- Maintains type safety across operations
- Provides optimal performance
- Handles edge cases gracefully
- Integrates with existing .NET collections

### Challenge 3: Dynamic Constraint Validation
Build a system that:
- Validates constraints at runtime
- Provides detailed constraint violation messages
- Supports custom constraint definitions
- Handles constraint inheritance
- Optimizes constraint checking performance

### Challenge 4: Advanced Variance Patterns
Implement patterns that:
- Combine covariance and contravariance
- Support complex type relationships
- Maintain type safety in all scenarios
- Provide intuitive APIs
- Handle performance-critical operations

## 📋 Expected Output

```
🎯 Day 3 - Lab 3.4: Generic Constraints and Variance
============================================================

=== Generic Constraint Demonstrations ===

1. Class and Struct Constraints:
   📚 Reference Type Repository<Customer>:
   - Customer repository created (reference type constraint)
   - Added customer: John Doe (ID: 1)
   - Repository count: 1

   🔢 Value Type Calculator<int>:
   - Calculator created (value type constraint)
   - Add operation: 10 + 20 = 30
   - Multiply operation: 5 * 6 = 30

2. Interface Constraints:
   📊 Sortable Collection<Product> (IComparable constraint):
   - Products added: [Laptop: $999.99, Mouse: $29.99, Keyboard: $79.99]
   - Sorted by price: [Mouse: $29.99, Keyboard: $79.99, Laptop: $999.99]
   - Sort operation successful due to IComparable<Product>

3. Constructor Constraints:
   🏭 Generic Factory<Product> (new() constraint):
   - Factory created with constructor constraint
   - Product instance created: Product (ID: 1)
   - Factory can create any type with parameterless constructor

=== Variance Demonstrations ===

4. Covariance (out keyword):
   📤 Covariant Producer<string> → Producer<object>:
   - String producer: "Hello, World!"
   - Assigned to object producer (covariance)
   - Retrieved value: "Hello, World!" (as object)
   - Covariance allows more derived → less derived assignment

5. Contravariance (in keyword):
   📥 Contravariant Consumer<object> → Consumer<string>:
   - Object consumer created
   - Assigned to string consumer (contravariance)
   - Consumed string: "Test String"
   - Contravariance allows less derived → more derived assignment

6. Delegate Variance:
   🎯 Function and Action Delegates:
   - Func<string, object> → Func<string, string> (covariant return)
   - Action<object> → Action<string> (contravariant parameter)
   - Delegate variance enables flexible method assignments

=== Advanced Constraint Patterns ===

7. Multiple Constraints:
   🔗 EntityRepository<T> where T : class, IEntity, IComparable<T>, new():
   - Product entity: implements IEntity, IComparable<Product>
   - Repository operations: Add, Sort, Create
   - All constraints satisfied: ✓ class ✓ IEntity ✓ IComparable ✓ new()

8. Conditional Constraints:
   ⚡ Performance-Optimized Operations:
   - Numeric operations with INumber<T> constraint
   - Collection operations with ICollection<T> constraint
   - Comparison operations with IComparable<T> constraint
   - Constraints enable compile-time optimizations

9. Variance in Real Scenarios:
   📋 Event System with Variance:
   - BaseEvent → SpecificEvent hierarchy
   - Covariant event producers: IEventProducer<out T>
   - Contravariant event handlers: IEventHandler<in T>
   - Type-safe event routing with variance

🎉 Lab 3.4 completed successfully!
```

## 🎓 Key Learning Points

1. **Type Safety**: Constraints provide compile-time type checking
2. **Performance**: Constraints enable compiler optimizations
3. **API Design**: Constraints create more intuitive and safe APIs
4. **Covariance**: Enables assignment compatibility for output scenarios
5. **Contravariance**: Enables assignment compatibility for input scenarios
6. **Invariance**: Default behavior when variance isn't applicable
7. **Constraint Combinations**: Multiple constraints for precise type requirements
8. **Real-world Applications**: Practical uses of constraints and variance

## 🔗 Related Concepts

- **Type Theory**: Mathematical foundations of type systems
- **Compiler Optimizations**: How constraints enable better code generation
- **API Design**: Creating intuitive and type-safe interfaces
- **Performance**: Runtime performance benefits of constrained generics
- **SOLID Principles**: How constraints support good design principles
- **Design Patterns**: Constraint-enabled pattern implementations
- **Functional Programming**: Variance in functional programming concepts

## 📖 Additional Resources

- [Microsoft Docs: Generic Constraints](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters)
- [Covariance and Contravariance](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/)
- [Generic Interfaces with Variance](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces)
- [Delegate Variance](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates)
- [Performance Considerations](https://docs.microsoft.com/en-us/dotnet/standard/generics/performance)

---

**Next Lab**: Lab 3.5 - Collection Data Structures
**Previous Lab**: Lab 3.3 - Generic Classes and Methods
