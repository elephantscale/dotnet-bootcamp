# Lab 2.3: Interfaces and Abstract Classes

## Objectives
By the end of this lab, you will be able to:
- Understand the difference between interfaces and abstract classes
- Implement multiple interfaces in a single class
- Use explicit interface implementation to resolve naming conflicts
- Apply interface segregation principle in design
- Work with default interface methods (C# 8+)
- Design flexible and maintainable object-oriented solutions

## Theory

### Interfaces
An interface defines a contract that implementing classes must follow. It specifies what a class can do, but not how it does it.

```csharp
public interface IDrawable
{
    void Draw();
    void Move(int x, int y);
    string GetDescription();
}
```

### Key Interface Concepts

#### Multiple Interface Implementation
Unlike classes (single inheritance), a class can implement multiple interfaces:

```csharp
public class Circle : Shape, IDrawable, IResizable, IColorable
{
    // Must implement all interface methods
}
```

#### Explicit Interface Implementation
Resolves naming conflicts when implementing multiple interfaces:

```csharp
public class SmartDevice : IControllable, IAudioDevice
{
    // Implicit implementation
    public void SetVolume(int level) { }
    
    // Explicit implementation
    void IAudioDevice.SetVolume(int level) { }
}
```

#### Default Interface Methods (C# 8+)
Interfaces can provide default implementations:

```csharp
public interface ILogger
{
    void Log(string message, LogLevel level);
    
    // Default implementation
    void LogInfo(string message) => Log($"[INFO] {message}", LogLevel.Info);
}
```

### Abstract Classes vs Interfaces

| Feature | Abstract Class | Interface |
|---------|----------------|-----------|
| Inheritance | Single only | Multiple supported |
| Implementation | Can have concrete methods | Contract only (except default methods) |
| Fields | Can have fields | Properties only |
| Constructors | Can have constructors | No constructors |
| Access Modifiers | Any access level | Public only |
| Relationship | "is-a" | "can-do" |

### Interface Segregation Principle
Clients should not be forced to depend on interfaces they don't use. Create focused, specific interfaces rather than large, monolithic ones.

## Exercises

### Exercise 1: Shape Drawing System
Explore the comprehensive shape system:
1. **Abstract Shape Class**: Common functionality for all shapes
2. **Multiple Interfaces**: IDrawable, IResizable, IColorable, IGeometric, etc.
3. **Concrete Implementations**: Circle, Rectangle, Triangle
4. **DrawingCanvas Service**: Polymorphic shape management

**Key Concepts:**
- Abstract methods must be implemented by derived classes
- Multiple interface implementation provides flexibility
- Interface segregation creates focused contracts
- Polymorphism works with both abstract classes and interfaces

### Exercise 2: Media Player System
Work with the media player hierarchy:
1. **Abstract MediaPlayer Class**: Common media functionality
2. **Concrete Players**: AudioPlayer, VideoPlayer with specific features
3. **Interface Implementation**: INotifiable, ISaveable
4. **MediaLibrary Service**: Polymorphic media management

**Key Concepts:**
- Abstract classes provide shared implementation
- Interfaces define additional capabilities
- Event handling through interfaces
- Type-specific operations using pattern matching

### Exercise 3: Advanced Interface Concepts
Explore advanced interface features:
1. **Multiple Interface Implementation**: Single class, multiple contracts
2. **Explicit Implementation**: Resolving naming conflicts
3. **Default Methods**: Interface evolution without breaking changes
4. **Interface vs Abstract Class**: When to use each approach

**Key Concepts:**
- Explicit implementation requires interface casting
- Default methods enable interface evolution
- Choose interfaces for "can-do" relationships
- Choose abstract classes for "is-a" relationships with shared code

## Challenges

### Challenge 1: Plugin Architecture
Design a plugin system using interfaces:
- `IPlugin` base interface with Load/Unload methods
- Specific plugin interfaces: `IDataProcessor`, `IRenderer`, `IValidator`
- Plugin manager that loads and manages plugins dynamically
- Demonstrate loose coupling and extensibility

### Challenge 2: Repository Pattern
Implement the repository pattern with interfaces:
- `IRepository<T>` generic interface for CRUD operations
- Specific repositories: `IUserRepository`, `IProductRepository`
- Multiple implementations: `DatabaseRepository`, `FileRepository`, `MemoryRepository`
- Unit of Work pattern for transaction management

### Challenge 3: Command Pattern with Interfaces
Create a command system:
- `ICommand` interface with Execute/Undo methods
- Concrete commands: `CreateFileCommand`, `DeleteFileCommand`, `MoveFileCommand`
- `ICommandInvoker` for command execution
- Command history and macro recording

### Challenge 4: Observer Pattern Implementation
Build an event system using interfaces:
- `IObserver<T>` and `IObservable<T>` interfaces
- Event aggregator for decoupled communication
- Multiple event types and handlers
- Subscription management and cleanup

## Expected Output
When you run the program, you should see:

1. **Drawing Canvas Demo**:
   - Shapes implementing multiple interfaces
   - Polymorphic drawing, resizing, and color changes
   - Canvas statistics and validation
   - Interface usage demonstration
   - Shape cloning and manipulation

2. **Media Library Demo**:
   - Different media players with specific capabilities
   - Polymorphic media loading and playback
   - Type-specific operations (playlists, video settings)
   - Event handling and notifications
   - Library statistics and management

3. **Advanced Interface Concepts**:
   - Multiple interface implementation examples
   - Explicit interface implementation with naming conflicts
   - Default interface method usage
   - Comparison between interfaces and abstract classes

## Key Takeaways

1. **Interface Purpose**: Define contracts and capabilities, not implementation
2. **Multiple Inheritance**: Interfaces enable multiple inheritance of type
3. **Flexibility**: Interfaces provide loose coupling and high flexibility
4. **Segregation**: Keep interfaces focused and specific to their purpose
5. **Evolution**: Default methods allow interface evolution without breaking changes
6. **Design Choice**: Use interfaces for "can-do", abstract classes for "is-a" with shared code

## Best Practices

1. **Interface Naming**: Use descriptive names, often starting with 'I' (IDrawable, IComparable)
2. **Small Interfaces**: Follow Interface Segregation Principle - keep interfaces focused
3. **Explicit Implementation**: Use when implementing multiple interfaces with conflicting members
4. **Default Methods**: Use sparingly, mainly for interface evolution
5. **Documentation**: Clearly document interface contracts and expected behavior
6. **Composition**: Favor composition over inheritance when possible

## Design Patterns Demonstrated

1. **Strategy Pattern**: Different algorithms through interfaces
2. **Observer Pattern**: Event handling through INotifiable
3. **Template Method**: Abstract classes with virtual/abstract methods
4. **Factory Pattern**: Creating objects through interface contracts
5. **Repository Pattern**: Data access through interfaces
6. **Command Pattern**: Operations as objects implementing ICommand

## Next Steps
- Learn about generics and how they work with interfaces
- Explore dependency injection and inversion of control
- Study SOLID principles in depth
- Practice with more design patterns using interfaces
- Investigate async/await patterns with interfaces

## Build and Run
```bash
# Navigate to the lab directory
cd "Day2/Lab2.3-Interfaces-Abstract-Classes"

# Build the project
dotnet build

# Run the application
dotnet run
```

## Files in this Lab
- `Interfaces/IDrawable.cs` - Comprehensive interface definitions
- `Models/Shape.cs` - Abstract Shape class with Circle, Rectangle, Triangle implementations
- `Models/MediaPlayer.cs` - Abstract MediaPlayer with AudioPlayer, VideoPlayer implementations
- `Services/DrawingCanvas.cs` - Shape management service demonstrating polymorphism
- `Services/MediaLibrary.cs` - Media player management with interface usage
- `InterfaceConcepts.cs` - Advanced interface concept demonstrations
- `Program.cs` - Main program orchestrating all demos
- `Lab2.3-Interfaces-Abstract-Classes.csproj` - Project configuration
