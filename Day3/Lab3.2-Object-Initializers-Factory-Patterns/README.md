# Lab 3.2: Object Initializers and Factory Patterns

## 🎯 Objectives

By the end of this lab, you will understand and be able to implement:

- **Object Initializers**: Simplified object creation and property setting
- **Collection Initializers**: Initialize collections with inline syntax
- **Anonymous Types**: Create types on-the-fly for temporary data
- **Factory Pattern**: Centralized object creation with business logic
- **Abstract Factory Pattern**: Create families of related objects
- **Factory Method Pattern**: Delegate object creation to derived classes
- **Singleton Pattern**: Ensure single instance creation
- **Object Pool Pattern**: Reuse expensive objects efficiently
- **Fluent Interfaces**: Method chaining for readable object configuration

## 📚 Theory

### Object Initializers

Object initializers provide a concise way to create and initialize objects:

```csharp
var person = new Person
{
    FirstName = "John",
    LastName = "Doe",
    Age = 30,
    Email = "john.doe@email.com"
};
```

### Collection Initializers

Initialize collections with values at creation:

```csharp
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var dictionary = new Dictionary<string, int>
{
    ["apple"] = 5,
    ["banana"] = 3,
    ["orange"] = 8
};
```

### Anonymous Types

Create types without explicit class definitions:

```csharp
var product = new { Name = "Laptop", Price = 999.99, InStock = true };
```

### Factory Pattern

Encapsulate object creation logic:

```csharp
public static class VehicleFactory
{
    public static IVehicle CreateVehicle(VehicleType type, string model)
    {
        return type switch
        {
            VehicleType.Car => new Car(model),
            VehicleType.Truck => new Truck(model),
            VehicleType.Motorcycle => new Motorcycle(model),
            _ => throw new ArgumentException("Unknown vehicle type")
        };
    }
}
```

### Abstract Factory Pattern

Create families of related objects:

```csharp
public abstract class UIFactory
{
    public abstract IButton CreateButton();
    public abstract ITextBox CreateTextBox();
}

public class WindowsUIFactory : UIFactory
{
    public override IButton CreateButton() => new WindowsButton();
    public override ITextBox CreateTextBox() => new WindowsTextBox();
}
```

## 🏗️ Project Structure

```
Lab3.2-Object-Initializers-Factory-Patterns/
├── Models/
│   ├── Product.cs              # Demonstrates object initializers
│   ├── Customer.cs             # Collection and object initializers
│   ├── Order.cs                # Complex initialization patterns
│   └── Inventory.cs            # Anonymous types and LINQ
├── Factories/
│   ├── VehicleFactory.cs       # Simple factory pattern
│   ├── DatabaseFactory.cs      # Abstract factory pattern
│   ├── LoggerFactory.cs        # Factory method pattern
│   └── ConnectionPool.cs       # Object pool pattern
├── Services/
│   ├── ConfigurationManager.cs # Singleton pattern
│   ├── ReportGenerator.cs      # Fluent interface pattern
│   └── DataProcessor.cs        # Combines multiple patterns
├── Interfaces/
│   ├── IVehicle.cs            # Vehicle abstraction
│   ├── IDatabase.cs           # Database abstraction
│   └── ILogger.cs             # Logger abstraction
├── Program.cs                  # Main application
├── Lab3.2-Object-Initializers-Factory-Patterns.csproj
└── README.md
```

## 🔧 Key Classes

### Product Class
- **Object Initializers**: Multiple initialization patterns
- **Validation**: Property setters with validation
- **Factory Methods**: Create products by category
- **Builder Pattern**: Fluent product configuration
- **Collection Support**: Initialize product lists and catalogs

### Vehicle Factory System
- **Simple Factory**: Create vehicles by type
- **Factory Method**: Abstract creation in base class
- **Registration**: Dynamic factory registration
- **Configuration**: Factory behavior customization
- **Validation**: Creation parameter validation

### Database Factory System
- **Abstract Factory**: Create database connection families
- **Provider Pattern**: Support multiple database types
- **Connection Pooling**: Efficient resource management
- **Configuration**: Connection string management
- **Error Handling**: Robust factory error handling

## 🚀 Running the Lab

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022, VS Code, or any C# IDE

### Build and Run
```bash
# Navigate to the lab directory
cd "Day3/Lab3.2-Object-Initializers-Factory-Patterns"

# Build the project
dotnet build

# Run the application
dotnet run
```

### Expected Output
The program will demonstrate:
1. Object initializer patterns and syntax variations
2. Collection initializers with different collection types
3. Anonymous type creation and usage
4. Factory pattern implementations
5. Abstract factory with multiple product families
6. Singleton pattern with thread safety
7. Object pool pattern with resource management
8. Fluent interface design and method chaining

## 💡 Exercises

### Exercise 1: Advanced Object Initializers
Create a `Restaurant` class with:
- Object initializers for basic info (name, address, cuisine)
- Collection initializers for menu items and staff
- Nested object initialization for address and contact info
- Validation in property setters
- Default value handling

### Exercise 2: Factory Method Implementation
Implement a `PaymentProcessorFactory` with:
- Factory methods for different payment types (Credit Card, PayPal, Bank Transfer)
- Parameter validation for each payment type
- Configuration-based factory selection
- Error handling and logging
- Factory registration system

### Exercise 3: Abstract Factory Pattern
Create a `ReportFactory` system with:
- Abstract factory for different report formats (PDF, Excel, HTML)
- Concrete factories for each format
- Common report interface
- Format-specific configuration
- Factory selection based on user preferences

### Exercise 4: Fluent Interface Design
Design a `QueryBuilder` class with:
- Fluent method chaining for SQL query construction
- Method overloading for different parameter types
- Validation at each step
- Final build method that creates the query
- Support for complex query scenarios

## 🏆 Challenges

### Challenge 1: Dynamic Factory Registration
Implement a factory system that:
- Allows runtime registration of new factory types
- Uses reflection to discover factory implementations
- Supports factory priority and selection criteria
- Includes factory lifecycle management
- Provides factory usage statistics

### Challenge 2: Advanced Object Pool
Create an object pool that:
- Supports different pooling strategies (LIFO, FIFO, LRU)
- Implements automatic pool size adjustment
- Provides pool health monitoring
- Supports object validation before reuse
- Includes pool performance metrics

### Challenge 3: Configuration-Driven Factory
Build a factory system that:
- Reads factory configuration from JSON/XML
- Supports hot-reload of factory configurations
- Implements factory dependency injection
- Provides factory configuration validation
- Supports factory configuration versioning

### Challenge 4: Multi-Threaded Singleton
Implement a singleton that:
- Ensures thread safety without locks (where possible)
- Supports lazy initialization
- Provides singleton instance statistics
- Implements singleton cleanup and disposal
- Supports singleton testing and mocking

## 📋 Expected Output

```
🎯 Day 3 - Lab 3.2: Object Initializers and Factory Patterns
============================================================

=== Object Initializer Demonstrations ===

1. Basic Object Initializers:
   Product: Laptop - $999.99 (Electronics) - In Stock: True
   Created: 12/18/2024 3:45:23 PM

2. Collection Initializers:
   Customer: John Doe
   Orders: 3 orders
   - Order #1001: 2 items, Total: $1,299.98
   - Order #1002: 1 items, Total: $599.99
   - Order #1003: 3 items, Total: $2,199.97

3. Anonymous Types:
   Sales Summary: { Date = 12/18/2024, TotalSales = $3,999.94, OrderCount = 3 }
   Top Product: { Name = Gaming Laptop, Revenue = $1,599.99, Units = 1 }

=== Factory Pattern Demonstrations ===

4. Simple Factory Pattern:
   🚗 Vehicle Factory Creating Vehicles:
   - Car: Toyota Camry (4 doors, Automatic transmission)
   - Truck: Ford F-150 (Pickup, 1500 lbs capacity)
   - Motorcycle: Harley Davidson (Cruiser, 1200cc engine)

5. Abstract Factory Pattern:
   🗄️ Database Factory - SQL Server Provider:
   - Connection: SqlServerConnection to ProductionDB
   - Command: SqlServerCommand ready for execution
   - Transaction: SqlServerTransaction (Isolation: ReadCommitted)

6. Factory Method Pattern:
   📝 Logger Factory Creating Loggers:
   - FileLogger: Logging to application.log
   - ConsoleLogger: Logging to console output
   - DatabaseLogger: Logging to LoggingDB.Logs table

=== Advanced Pattern Demonstrations ===

7. Singleton Pattern:
   ⚙️ Configuration Manager (Singleton):
   - Instance ID: CFG-001
   - Configuration loaded from appsettings.json
   - Database: Server=localhost;Database=AppDB
   - API Key: ***-***-***-1234 (masked)

8. Object Pool Pattern:
   🏊 Database Connection Pool:
   - Pool Size: 10 connections
   - Active: 3, Available: 7
   - Connection acquired: CONN-007 (Pool usage: 30%)
   - Connection returned: CONN-007 (Pool usage: 20%)

9. Fluent Interface Pattern:
   📊 Report Builder:
   Report Configuration:
   - Title: Monthly Sales Report
   - Format: PDF
   - Date Range: 11/01/2024 to 11/30/2024
   - Filters: Region=North, Status=Completed
   - Sort: Date DESC, Amount DESC
   - Generated: MonthlySalesReport_202411.pdf

🎉 Lab 3.2 completed successfully!
```

## 🎓 Key Learning Points

1. **Object Initializers**: Simplify object creation and improve code readability
2. **Collection Initializers**: Initialize collections concisely at creation time
3. **Anonymous Types**: Create temporary types for data projection and grouping
4. **Factory Pattern**: Encapsulate object creation logic and improve maintainability
5. **Abstract Factory**: Create families of related objects with consistent interfaces
6. **Singleton Pattern**: Ensure single instance creation with proper thread safety
7. **Object Pool**: Reuse expensive objects to improve performance
8. **Fluent Interfaces**: Create readable and chainable APIs for complex configuration

## 🔗 Related Concepts

- **Dependency Injection**: Factory patterns as foundation for DI containers
- **Design Patterns**: GoF patterns and their modern implementations
- **SOLID Principles**: Factory patterns supporting Open/Closed principle
- **Performance**: Object pooling and creation optimization
- **Thread Safety**: Singleton and factory thread safety considerations
- **Configuration**: Factory configuration and runtime behavior
- **Testing**: Factory patterns and unit testing strategies

## 📖 Additional Resources

- [Microsoft Docs: Object Initializers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers)
- [Factory Pattern](https://refactoring.guru/design-patterns/factory-method)
- [Abstract Factory Pattern](https://refactoring.guru/design-patterns/abstract-factory)
- [Singleton Pattern](https://refactoring.guru/design-patterns/singleton)
- [Object Pool Pattern](https://sourcemaking.com/design_patterns/object_pool)

---

**Next Lab**: Lab 3.3 - Generic Classes and Methods
**Previous Lab**: Lab 3.1 - Constructors and Advanced OOP
