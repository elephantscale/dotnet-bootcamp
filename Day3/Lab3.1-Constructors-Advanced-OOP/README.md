# Lab 3.1: Constructors and Advanced OOP

## 🎯 Objectives

By the end of this lab, you will understand and be able to implement:

- **Constructor Patterns**: Default, parameterized, copy, and static constructors
- **Constructor Chaining**: Using `this()` to call other constructors
- **Factory Methods**: Creating objects through static factory methods
- **Builder Pattern**: Flexible object construction with method chaining
- **Object Initialization**: Various patterns for creating and initializing objects
- **Validation in Constructors**: Ensuring object integrity from creation
- **Static Members**: Class-level data and behavior
- **Advanced OOP Concepts**: Composition, encapsulation, and object lifecycle

## 📚 Theory

### Constructor Types

#### 1. Default Constructor
```csharp
public class Person
{
    public Person()
    {
        // Initialize with default values
    }
}
```

#### 2. Parameterized Constructor
```csharp
public Person(string firstName, string lastName)
{
    this.firstName = ValidateName(firstName);
    this.lastName = ValidateName(lastName);
}
```

#### 3. Constructor Chaining
```csharp
public Person(string firstName, string lastName) : this()
{
    // Calls default constructor first, then executes this code
}
```

#### 4. Copy Constructor
```csharp
public Person(Person other)
{
    // Create a new object based on existing object
    this.firstName = other.firstName;
    this.lastName = other.lastName;
}
```

#### 5. Static Constructor
```csharp
static Person()
{
    // Called once before first instance creation or static member access
    // Used for static field initialization
}
```

### Factory Methods

Factory methods provide semantic meaning to object creation:

```csharp
public static BankAccount CreateSavingsAccount(string holder, decimal balance)
{
    if (balance < 100m)
        throw new ArgumentException("Savings requires minimum $100");
    
    return new BankAccount(holder, balance, AccountType.Savings);
}
```

### Builder Pattern

For complex objects with many optional parameters:

```csharp
var account = BankAccount.Builder()
    .WithHolder("John Doe")
    .WithInitialBalance(5000m)
    .AsAccountType(AccountType.Premium)
    .WithCustomRate(0.045m)
    .Build();
```

### Constructor Best Practices

1. **Validate Early**: Check parameters in constructors
2. **Fail Fast**: Throw exceptions for invalid states
3. **Use Chaining**: Avoid code duplication with `this()`
4. **Keep Simple**: Don't perform heavy operations
5. **Provide Defaults**: Offer reasonable default values

## 🏗️ Project Structure

```
Lab3.1-Constructors-Advanced-OOP/
├── Models/
│   ├── Person.cs              # Demonstrates all constructor patterns
│   ├── Address.cs             # Supporting class with validation
│   ├── Vehicle.cs             # Abstract class with protected constructors
│   └── BankAccount.cs         # Factory methods and builder pattern
├── Services/
│   └── ConstructorDemos.cs    # Demonstration methods
├── Program.cs                 # Main application orchestrating demos
├── Lab3.1-Constructors-Advanced-OOP.csproj
└── README.md
```

## 🔧 Key Classes

### Person Class
- **Multiple Constructors**: Default, name-only, with birth date, full contact info
- **Constructor Chaining**: Each constructor builds on simpler ones
- **Copy Constructor**: Creates deep copies with address cloning
- **Factory Methods**: `CreateChild()`, `CreateEmployee()`
- **Validation**: Name length, email format, date ranges
- **Static Tracking**: Instance counting and statistics

### Vehicle Class (Abstract)
- **Protected Constructor**: Prevents direct instantiation
- **Static Constructor**: Initializes tracking systems
- **Derived Classes**: Car and Motorcycle with specific constructors
- **Factory Methods**: Type-specific creation methods
- **Polymorphism**: Abstract methods implemented by derived classes

### BankAccount Class
- **Constructor Overloading**: Multiple ways to create accounts
- **Factory Methods**: Semantic account creation
- **Builder Pattern**: Flexible account configuration
- **Copy Constructor**: Create accounts based on existing ones
- **Validation**: Account minimums, interest rate limits
- **Business Logic**: Account operations and management

## 🚀 Running the Lab

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022, VS Code, or any C# IDE

### Build and Run
```bash
# Navigate to the lab directory
cd "Day3/Lab3.1-Constructors-Advanced-OOP"

# Build the project
dotnet build

# Run the application
dotnet run
```

### Expected Output
The program will demonstrate:
1. Person constructor patterns and validation
2. Vehicle inheritance and polymorphic constructors
3. Bank account factory methods and builder pattern
4. Constructor chaining examples
5. Static constructor behavior
6. Object initializer patterns
7. Interactive examples with families, fleets, and banking

## 💡 Exercises

### Exercise 1: Custom Constructor Patterns
Create a `Product` class with:
- Default constructor (generates random ID)
- Constructor with name and price
- Constructor with full details (name, price, category, description)
- Copy constructor
- Factory methods for different product types

### Exercise 2: Builder Pattern Implementation
Implement a `Computer` class with builder pattern for:
- CPU type and speed
- RAM amount
- Storage type and capacity
- Graphics card
- Operating system
- Warranty period

### Exercise 3: Constructor Validation
Create a `Student` class with robust validation:
- Student ID format validation
- GPA range checking (0.0 - 4.0)
- Email format validation
- Enrollment date validation
- Course list validation

### Exercise 4: Static Constructor Usage
Create a `Configuration` class that:
- Uses static constructor to load settings
- Tracks application startup time
- Maintains global counters
- Provides static factory methods for different configurations

## 🏆 Challenges

### Challenge 1: Advanced Factory Pattern
Implement an abstract `ShapeFactory` with:
- Static factory methods for different shapes
- Parameter validation for each shape type
- Automatic shape registration system
- Shape creation statistics

### Challenge 2: Fluent Builder with Validation
Create a `DatabaseConnection` builder that:
- Validates connection parameters at each step
- Provides different connection types (SQL Server, MySQL, PostgreSQL)
- Includes connection pooling options
- Supports connection string generation

### Challenge 3: Constructor Dependency Injection
Implement a simple dependency injection system:
- Constructor parameter analysis
- Automatic dependency resolution
- Circular dependency detection
- Lifetime management (singleton, transient)

### Challenge 4: Object Pool with Constructors
Create an object pool system that:
- Uses factory methods for object creation
- Implements object recycling
- Tracks object usage statistics
- Provides different pool strategies

## 📋 Expected Output

```
🎯 Day 3 - Lab 3.1: Constructors and Advanced OOP
============================================================

=== Person Constructor Demonstrations ===

1. Default Constructor:
   Person created: Unknown Unknown (ID: P000001)
   Created: Unknown Unknown, Age: 0, Email: Not provided

2. Constructor with Name:
   Person created: John Doe (ID: P000002)
   Created: John Doe, Age: 0, Email: Not provided

3. Constructor with Name and Birth Date:
   Person created: Jane Smith (ID: P000003)
   Created: Jane Smith, Age: 33, Email: Not provided
   Age: 33, Age Group: Adult

[... additional output showing all constructor patterns ...]

=== Vehicle Constructor Demonstrations ===

Vehicle static constructor - initializing vehicle tracking system
1. Car Constructors:
   Vehicle created: 2022 Toyota Camry (Total: 1)
   Car created: 2022 Toyota Camry - 4 doors, Gasoline, Automatic
   Basic: Car: 2022 Toyota Camry, Price: $28,000, Status: Available

[... vehicle demonstrations ...]

=== Bank Account Constructor Demonstrations ===

BankAccount static constructor - initializing banking system
🏦 Account Type Information:
==================================================
Checking    : 1.00% annual interest rate
Savings     : 2.50% annual interest rate
Premium     : 3.50% annual interest rate
Business    : 2.00% annual interest rate

[... banking demonstrations ...]

👨‍👩‍👧‍👦 Creating a Family with Different Constructor Patterns:
--------------------------------------------------
Person created: John Smith (ID: P000008)
Person created: Jane Smith (ID: P000009)
Child created: Emily Smith (ID: P000010)
Child created: Michael Smith (ID: P000011)

Family Members:
  John Smith, Age: 43, Email: john.smith@email.com
    Age Group: Adult
  Jane Smith, Age: 41, Email: jane.smith@email.com
    Age Group: Adult
  Emily Smith, Age: 13, Email: emily.smith@email.com
    Age Group: Child
  Michael Smith, Age: 11, Email: michael.smith@email.com
    Age Group: Child

🎉 Lab 3.1 completed successfully!
```

## 🎓 Key Learning Points

1. **Constructor Chaining**: Use `this()` to avoid code duplication and ensure consistent initialization
2. **Validation**: Always validate constructor parameters to maintain object integrity
3. **Factory Methods**: Provide semantic meaning and encapsulate complex creation logic
4. **Builder Pattern**: Handle objects with many optional parameters elegantly
5. **Static Constructors**: Initialize static data and perform one-time setup
6. **Copy Constructors**: Create proper deep copies when needed
7. **Protected Constructors**: Control instantiation in inheritance hierarchies
8. **Object Lifecycle**: Understand when and how objects are created and initialized

## 🔗 Related Concepts

- **Inheritance**: Constructor behavior in derived classes
- **Polymorphism**: Virtual methods and constructor interaction
- **Encapsulation**: Private constructors and factory methods
- **SOLID Principles**: Single responsibility in constructor design
- **Design Patterns**: Factory, Builder, and Singleton patterns
- **Memory Management**: Object creation and garbage collection
- **Exception Handling**: Constructor failure and cleanup

## 📖 Additional Resources

- [Microsoft Docs: Constructors](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors)
- [C# Constructor Best Practices](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor)
- [Factory Method Pattern](https://refactoring.guru/design-patterns/factory-method)
- [Builder Pattern](https://refactoring.guru/design-patterns/builder)
- [Static Constructors](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors)

---

**Next Lab**: Lab 3.2 - Generics and Collections
**Previous Lab**: Lab 2.4 - Error Handling and Exceptions
