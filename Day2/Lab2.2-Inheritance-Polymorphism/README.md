# Lab 2.2: Inheritance and Polymorphism

## Objectives
By the end of this lab, you will be able to:
- Understand inheritance concepts and class hierarchies
- Implement method overriding and virtual methods
- Apply polymorphism in real-world scenarios
- Use abstract classes and methods effectively
- Perform type checking and safe casting
- Design object-oriented solutions using inheritance

## Theory

### Inheritance
Inheritance is a fundamental OOP concept that allows a class (derived/child) to inherit properties and methods from another class (base/parent). This promotes code reuse and establishes "is-a" relationships.

```csharp
public class Animal  // Base class
{
    public virtual string MakeSound() => "Generic sound";
}

public class Dog : Animal  // Derived class
{
    public override string MakeSound() => "Woof!";
}
```

### Key Inheritance Concepts

#### Virtual and Override Keywords
- **virtual**: Allows a method to be overridden in derived classes
- **override**: Provides a new implementation of a virtual method
- **base**: Calls the base class implementation

#### Abstract Classes and Methods
- **abstract class**: Cannot be instantiated, designed to be inherited
- **abstract method**: Must be implemented by derived classes

#### Access Modifiers in Inheritance
- **public**: Accessible everywhere
- **protected**: Accessible in the class and derived classes
- **private**: Only accessible in the declaring class

### Polymorphism
Polymorphism allows objects of different types to be treated as instances of the same base type. The correct method is called at runtime based on the actual object type.

```csharp
Animal[] animals = { new Dog(), new Cat(), new Bird() };
foreach (Animal animal in animals)
{
    animal.MakeSound(); // Calls the correct overridden method
}
```

### Type Checking and Casting
- **is operator**: Checks if an object is of a specific type
- **as operator**: Safely casts to a type (returns null if fails)
- **Pattern matching**: Modern C# syntax for type checking and casting

## Exercises

### Exercise 1: Animal Hierarchy
Explore the `Animal` class hierarchy:
1. **Base Class (Animal)**: Common properties and virtual methods
2. **Derived Classes**: Dog, Cat, Bird with specific behaviors
3. **Method Overriding**: Each animal has unique sounds and movements
4. **Polymorphism**: Same method calls, different behaviors

**Key Concepts:**
- Virtual methods allow customization in derived classes
- Protected members are accessible to derived classes
- Constructor chaining with `base()` keyword

### Exercise 2: Vehicle Fleet Management
Work with the abstract `Vehicle` class:
1. **Abstract Base Class**: Defines contract for all vehicles
2. **Concrete Implementations**: Car, Motorcycle, Truck
3. **Abstract Methods**: Must be implemented by derived classes
4. **Polymorphic Operations**: Fleet management operations

**Key Concepts:**
- Abstract classes cannot be instantiated
- Abstract methods must be implemented
- Polymorphism enables uniform interface for different types

### Exercise 3: Service Classes with Polymorphism
Use service classes that demonstrate polymorphism:
1. **AnimalShelter**: Manages different animal types polymorphically
2. **VehicleFleet**: Handles various vehicle types uniformly
3. **Type-Specific Operations**: Using pattern matching and casting

**Key Concepts:**
- Collections of base type can hold derived objects
- Runtime type identification and casting
- Generic methods with type constraints

### Exercise 4: Advanced Inheritance Concepts
Explore advanced concepts through `InheritanceConcepts`:
1. **Base Constructor Calls**: How inheritance chain works
2. **Method Overriding vs Hiding**: Virtual vs new keywords
3. **Type Casting Safety**: Safe and unsafe casting examples
4. **Pattern Matching**: Modern C# type checking syntax

## Challenges

### Challenge 1: Shape Hierarchy
Create a shape inheritance hierarchy:
- Abstract `Shape` base class with area and perimeter methods
- Concrete shapes: `Circle`, `Rectangle`, `Triangle`
- `ShapeCalculator` service for polymorphic operations
- Implement `IComparable` for shape sorting

### Challenge 2: Employee Management System
Build an employee hierarchy:
- Base `Employee` class with common properties
- Derived classes: `Manager`, `Developer`, `Salesperson`
- Different salary calculation methods
- Polymorphic payroll processing

### Challenge 3: Game Character System
Design a game character system:
- Abstract `Character` base class
- Derived classes: `Warrior`, `Mage`, `Archer`
- Different attack and defense mechanisms
- Polymorphic battle system

### Challenge 4: Document Processing
Create a document processing system:
- Abstract `Document` base class
- Concrete types: `PDFDocument`, `WordDocument`, `TextDocument`
- Polymorphic processing pipeline
- Factory pattern for document creation

## Expected Output
When you run the program, you should see:

1. **Animal Shelter Demo**: 
   - Animals being admitted to shelter
   - Polymorphic feeding, exercise, and special actions
   - Type-specific behaviors for dogs, cats, and birds
   - Adoption process and statistics

2. **Vehicle Fleet Demo**:
   - Vehicles being added to fleet
   - Polymorphic starting, acceleration, and operations
   - Type-specific actions for cars, motorcycles, and trucks
   - Efficiency reports and fleet management

3. **Inheritance Concepts**:
   - Base constructor call demonstration
   - Method overriding examples
   - Polymorphism in action
   - Safe and unsafe type casting examples

## Key Takeaways

1. **Inheritance Benefits**: Code reuse, logical hierarchies, polymorphism
2. **Virtual vs Abstract**: Virtual methods can have implementation, abstract cannot
3. **Polymorphism Power**: Same interface, different behaviors at runtime
4. **Type Safety**: Use `is`, `as`, and pattern matching for safe casting
5. **Design Principles**: Favor composition over inheritance when appropriate
6. **Access Control**: Use `protected` for derived class access

## Best Practices

1. **Liskov Substitution Principle**: Derived classes should be substitutable for base classes
2. **Virtual Method Design**: Only make methods virtual if they need to be overridden
3. **Abstract Class Usage**: Use when you have common implementation to share
4. **Type Checking**: Prefer pattern matching over traditional casting
5. **Constructor Chaining**: Always call appropriate base constructors
6. **Method Overriding**: Use `override` keyword explicitly for clarity

## Next Steps
- Learn about interfaces and how they differ from abstract classes
- Explore composition vs inheritance trade-offs
- Study design patterns that use inheritance (Template Method, Strategy)
- Practice with more complex inheritance hierarchies

## Build and Run
```bash
# Navigate to the lab directory
cd "Day2/Lab2.2-Inheritance-Polymorphism"

# Build the project
dotnet build

# Run the application
dotnet run
```

## Files in this Lab
- `Models/Animal.cs` - Animal hierarchy with Dog, Cat, Bird classes
- `Models/Vehicle.cs` - Abstract Vehicle class with Car, Motorcycle, Truck implementations
- `Services/AnimalShelter.cs` - Polymorphic animal management
- `Services/VehicleFleet.cs` - Polymorphic vehicle fleet operations
- `InheritanceConcepts.cs` - Advanced inheritance demonstrations
- `Program.cs` - Main program orchestrating all demos
- `Lab2.2-Inheritance-Polymorphism.csproj` - Project configuration
