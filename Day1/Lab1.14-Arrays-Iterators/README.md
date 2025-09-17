# Lab 1.14: Arrays and Iterators

## Objectives
By the end of this lab, you will be able to:
- Understand different types of arrays in C# (single-dimensional, multidimensional, jagged)
- Work with array methods and properties
- Implement array searching and sorting algorithms
- Use various collection types (List, Dictionary, HashSet, Queue, Stack, LinkedList)
- Iterate through arrays and collections using different loop constructs
- Apply arrays and collections in practical scenarios

## Theory

### Arrays in C#
Arrays are reference types that store multiple elements of the same type in a contiguous memory location. C# supports several types of arrays:

#### Single-Dimensional Arrays
```csharp
int[] numbers = new int[5];           // Array of 5 integers
int[] values = { 1, 2, 3, 4, 5 };    // Array literal
int[] data = new int[] { 10, 20, 30 }; // Explicit initialization
```

#### Multidimensional Arrays
```csharp
int[,] matrix = new int[3, 4];        // 3x4 rectangular array
int[,] grid = { {1, 2}, {3, 4} };     // Initialized 2x2 array
```

#### Jagged Arrays
```csharp
int[][] jaggedArray = new int[3][];   // Array of arrays
jaggedArray[0] = new int[4];          // First row has 4 elements
jaggedArray[1] = new int[2];          // Second row has 2 elements
```

### Collections
.NET provides various collection types for different scenarios:

- **List<T>**: Dynamic array with type safety
- **Dictionary<TKey, TValue>**: Key-value pairs for fast lookups
- **HashSet<T>**: Unique elements with set operations
- **Queue<T>**: First-In-First-Out (FIFO) collection
- **Stack<T>**: Last-In-First-Out (LIFO) collection
- **LinkedList<T>**: Doubly-linked list for efficient insertion/deletion

### Array Methods and Properties
- **Length**: Number of elements in the array
- **Array.Sort()**: Sorts array elements
- **Array.Reverse()**: Reverses array order
- **Array.IndexOf()**: Finds first occurrence of element
- **Array.BinarySearch()**: Performs binary search (requires sorted array)
- **Array.Copy()**: Copies elements between arrays

## Exercises

### Exercise 1: Array Basics and Operations
Run the `ArrayOperations` class to explore:
1. Array declaration and initialization
2. Multidimensional and jagged arrays
3. Array methods (Sort, Reverse, IndexOf, etc.)
4. Array searching algorithms
5. Different iteration patterns

**Key Concepts:**
- Arrays are reference types
- Array bounds checking prevents index out of range errors
- Multidimensional arrays vs jagged arrays
- Linear vs binary search performance

### Exercise 2: Collection Types
Run the `CollectionOperations` class to explore:
1. List<T> operations (Add, Insert, Remove, etc.)
2. Dictionary<TKey, TValue> for key-value storage
3. HashSet<T> for unique elements and set operations
4. Queue<T> and Stack<T> for specialized ordering
5. LinkedList<T> for efficient insertion/deletion

**Key Concepts:**
- Type safety with generic collections
- Performance characteristics of different collections
- When to use each collection type
- FIFO vs LIFO behavior

### Exercise 3: Practical Applications
Run the `PracticalArrayExamples` class to see real-world usage:
1. **Student Grade Manager**: Parallel arrays and jagged arrays for student data
2. **Inventory System**: Dictionary-based inventory with stock management
3. **Matrix Operations**: 2D arrays for mathematical operations

**Key Concepts:**
- Parallel arrays for related data
- Dictionary lookups for efficient data retrieval
- Matrix operations using 2D arrays
- Business logic implementation with collections

## Challenges

### Challenge 1: Array Statistics Calculator
Create a class that calculates various statistics for an array of numbers:
- Mean, median, mode
- Standard deviation
- Min, max, range
- Quartiles and percentiles

### Challenge 2: Text Analysis Tool
Build a program that analyzes text using arrays and collections:
- Count word frequency using Dictionary
- Find most common words
- Identify unique words using HashSet
- Calculate reading statistics

### Challenge 3: Game Board Implementation
Create a tic-tac-toe or chess board using 2D arrays:
- Represent game state
- Implement move validation
- Check for win conditions
- Display board state

### Challenge 4: Data Structure Performance Comparison
Compare performance of different collections:
- Measure insertion time for List vs LinkedList
- Compare lookup time for List vs Dictionary
- Analyze memory usage patterns
- Create performance benchmarks

## Expected Output
When you run the program, you should see:

1. **Array Basics**: Demonstration of array creation, access, and bounds checking
2. **Multidimensional Arrays**: 2D arrays, jagged arrays, and 3D array examples
3. **Array Methods**: Sorting, searching, copying, and manipulation operations
4. **Collection Operations**: Examples of List, Dictionary, HashSet, Queue, Stack, and LinkedList
5. **Practical Examples**: 
   - Student grade management with averages and rankings
   - Inventory system with stock tracking and alerts
   - Matrix operations including addition, multiplication, and transpose

## Key Takeaways

1. **Array Types**: Understanding when to use single-dimensional, multidimensional, or jagged arrays
2. **Collection Selection**: Choosing the right collection type based on performance requirements
3. **Iteration Patterns**: Different ways to loop through arrays and collections
4. **Memory Efficiency**: Understanding reference vs value types in collections
5. **Algorithm Complexity**: Linear vs binary search, sorting algorithms
6. **Practical Applications**: Real-world usage patterns and best practices

## Next Steps
- Explore LINQ for advanced collection operations
- Learn about custom collection implementations
- Study algorithm complexity and performance optimization
- Practice with more complex data structures like trees and graphs

## Build and Run
```bash
# Navigate to the lab directory
cd "Day1/Lab1.14-Arrays-Iterators"

# Build the project
dotnet build

# Run the application
dotnet run
```

## Files in this Lab
- `ArrayOperations.cs` - Array basics, methods, and searching
- `CollectionOperations.cs` - Generic collections demonstration  
- `PracticalArrayExamples.cs` - Real-world applications
- `Program.cs` - Main program orchestrating all demos
- `Lab1.14-Arrays-Iterators.csproj` - Project configuration
