# Lab 2.4: Error Handling and Exceptions

## Objectives
By the end of this lab, you will be able to:
- Understand exception handling fundamentals in C#
- Create and use custom exceptions effectively
- Implement proper error handling patterns
- Handle exceptions in asynchronous operations
- Apply exception handling best practices
- Design robust applications with comprehensive error handling

## Theory

### Exception Handling Basics
Exceptions are runtime errors that disrupt the normal flow of program execution. C# provides a structured way to handle these errors using try-catch-finally blocks.

```csharp
try
{
    // Code that might throw an exception
}
catch (SpecificException ex)
{
    // Handle specific exception type
}
catch (Exception ex)
{
    // Handle any other exception
}
finally
{
    // Code that always executes
}
```

### Exception Hierarchy
All exceptions in .NET inherit from the `System.Exception` class:
- `SystemException`: Base for system-defined exceptions
- `ApplicationException`: Base for application-defined exceptions (less commonly used)
- Common exceptions: `ArgumentException`, `InvalidOperationException`, `NullReferenceException`

### Custom Exceptions
Create custom exceptions for specific business scenarios:

```csharp
public class BusinessLogicException : Exception
{
    public string ErrorCode { get; }
    
    public BusinessLogicException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}
```

### Exception Handling Patterns

#### Exception Filtering (C# 6+)
```csharp
catch (ArgumentException ex) when (ex.ParamName == "userId")
{
    // Handle only specific parameter exceptions
}
```

#### Exception Wrapping
```csharp
catch (SqlException ex)
{
    throw new DatabaseException("Database operation failed", ex);
}
```

#### Async Exception Handling
```csharp
try
{
    await SomeAsyncOperation();
}
catch (HttpRequestException ex)
{
    // Handle async operation exception
}
```

## Exercises

### Exercise 1: Basic Exception Handling
Explore fundamental exception handling concepts:
1. **Try-Catch-Finally**: Basic exception handling structure
2. **Multiple Catch Blocks**: Handling different exception types
3. **Exception Filtering**: Using when clauses for conditional handling
4. **Exception Propagation**: How exceptions bubble up the call stack

**Key Concepts:**
- Catch most specific exceptions first
- Use finally for cleanup code
- Exception filters provide more granular control
- Unhandled exceptions terminate the application

### Exercise 2: Custom Exception Design
Work with custom exceptions for business scenarios:
1. **ValidationException**: Input validation errors with detailed messages
2. **BusinessLogicException**: Business rule violations with error codes
3. **InsufficientFundsException**: Domain-specific banking exception
4. **NetworkException**: Network operation failures with context

**Key Concepts:**
- Custom exceptions provide domain-specific error information
- Include relevant properties for debugging and handling
- Inherit from appropriate base exception classes
- Provide multiple constructors for different scenarios

### Exercise 3: Real-World Exception Scenarios
Apply exception handling in practical applications:
1. **BankAccount Class**: Financial operations with validation and business rules
2. **FileProcessor Class**: File operations with comprehensive error handling
3. **Async Operations**: Network calls and async exception handling
4. **Resource Management**: Using statements and proper cleanup

**Key Concepts:**
- Validate inputs and throw appropriate exceptions
- Wrap lower-level exceptions with business context
- Handle resource cleanup in finally blocks or using statements
- Async operations require special exception handling considerations

### Exercise 4: Advanced Exception Patterns
Explore sophisticated exception handling techniques:
1. **Exception Logging**: Comprehensive error logging with context
2. **AggregateException**: Handling multiple exceptions from parallel operations
3. **Exception Recovery**: Retry patterns and graceful degradation
4. **Best Practices**: Guidelines for effective exception handling

**Key Concepts:**
- Log exceptions with sufficient context for debugging
- AggregateException contains multiple inner exceptions
- Implement retry logic for transient failures
- Follow established patterns for maintainable code

## Challenges

### Challenge 1: Retry Pattern Implementation
Create a robust retry mechanism:
- Generic retry wrapper for operations that might fail
- Exponential backoff strategy
- Different retry policies for different exception types
- Circuit breaker pattern for preventing cascade failures

### Challenge 2: Exception Handling Middleware
Build a centralized exception handling system:
- Global exception handler that catches unhandled exceptions
- Exception categorization (user errors, system errors, etc.)
- Appropriate response generation based on exception type
- Logging and monitoring integration

### Challenge 3: Validation Framework
Design a comprehensive validation system:
- Fluent validation API with custom rules
- Validation result aggregation
- Custom validation exceptions with detailed error information
- Integration with business logic layers

### Challenge 4: Fault-Tolerant Service
Create a service that gracefully handles various failure scenarios:
- Network timeouts and connection failures
- Data corruption and format errors
- Resource exhaustion (memory, disk space)
- Graceful degradation when dependencies are unavailable

## Expected Output
When you run the program, you should see:

1. **Basic Exception Handling**:
   - Division by zero, array bounds, and null reference exceptions
   - Multiple catch blocks and finally block execution
   - Exception filtering with when clauses

2. **Custom Exception Demonstrations**:
   - ValidationException with property-specific errors
   - BusinessLogicException with error codes and timestamps
   - NetworkException with endpoint and status code information

3. **Bank Account Scenarios**:
   - Account creation validation
   - Insufficient funds handling during withdrawals and transfers
   - Transaction history and complex operation error handling

4. **File Processing Examples**:
   - File validation and security checks
   - I/O exception handling with proper error context
   - Batch processing with AggregateException

5. **Async Exception Handling**:
   - Network timeout simulation
   - Multiple async task failure handling
   - Proper async/await exception patterns

## Key Takeaways

1. **Exception Types**: Use specific exception types for better error handling
2. **Custom Exceptions**: Create domain-specific exceptions with relevant context
3. **Exception Safety**: Ensure resources are properly cleaned up
4. **Async Patterns**: Handle exceptions properly in async operations
5. **Logging**: Include sufficient context for debugging and monitoring
6. **User Experience**: Provide meaningful error messages to users

## Best Practices

1. **Catch Specific Exceptions**: Avoid catching `Exception` unless necessary
2. **Don't Swallow Exceptions**: Always handle or re-throw exceptions appropriately
3. **Use Finally or Using**: Ensure resource cleanup even when exceptions occur
4. **Provide Context**: Include relevant information in exception messages
5. **Log Appropriately**: Log exceptions with sufficient detail for debugging
6. **Fail Fast**: Validate inputs early and throw exceptions immediately
7. **Exception Neutrality**: Don't let exceptions escape from finalizers or dispose methods

## Common Anti-Patterns to Avoid

1. **Empty Catch Blocks**: Never ignore exceptions silently
2. **Generic Exception Catching**: Avoid `catch (Exception)` unless handling all errors
3. **Exception for Control Flow**: Don't use exceptions for normal program flow
4. **Losing Stack Trace**: Use `throw;` instead of `throw ex;` to preserve stack trace
5. **Resource Leaks**: Always clean up resources in finally blocks or using statements

## Exception Handling Guidelines

1. **When to Throw**: Throw exceptions for exceptional conditions, not expected scenarios
2. **When to Catch**: Catch exceptions when you can handle them meaningfully
3. **When to Wrap**: Wrap lower-level exceptions with business context
4. **When to Log**: Log exceptions at appropriate levels with sufficient context
5. **When to Retry**: Implement retry logic for transient failures only

## Build and Run
```bash
# Navigate to the lab directory
cd "Day2/Lab2.4-Error-Handling-Exceptions"

# Build the project
dotnet build

# Run the application
dotnet run
```

## Files in this Lab
- `Exceptions/CustomExceptions.cs` - Comprehensive custom exception definitions
- `Models/BankAccount.cs` - Banking operations with exception handling
- `Models/FileProcessor.cs` - File operations with comprehensive error handling
- `Services/ErrorHandlingDemos.cs` - Exception handling pattern demonstrations
- `Program.cs` - Main program showcasing all exception scenarios
- `Lab2.4-Error-Handling-Exceptions.csproj` - Project configuration
