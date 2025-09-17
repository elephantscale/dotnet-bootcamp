# Lab 1.3: Creating Your First Project

## Objective
Learn the complete workflow of creating, structuring, and organizing a .NET project from scratch.

## Duration: 30 minutes

## Theory
A well-structured project follows conventions that make it maintainable and scalable. Understanding project templates, folder organization, and naming conventions is crucial for professional development.

## Exercise

### Part A: Project Creation (10 minutes)
Create a console application using both CLI and IDE methods.

### Part B: Project Structure (15 minutes)
Explore and customize the project structure, add multiple files and organize code.

### Part C: Build and Run (5 minutes)
Compile and execute your application using different methods.

## Hands-On Tasks

### Task 1: Create Project via CLI
```bash
# Create a new solution
dotnet new sln -n MyFirstApp

# Create a console project
dotnet new console -n MyFirstApp.Console

# Add project to solution
dotnet sln add MyFirstApp.Console/MyFirstApp.Console.csproj

# Navigate to project
cd MyFirstApp.Console
```

### Task 2: Examine Project Structure
```
MyFirstApp/
├── MyFirstApp.sln
└── MyFirstApp.Console/
    ├── MyFirstApp.Console.csproj
    ├── Program.cs
    └── bin/
    └── obj/
```

### Task 3: Create a Multi-File Application
Create `Models/Person.cs`:
```csharp
namespace MyFirstApp.Console.Models
{
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {GetFullName()}, Age: {Age}");
        }
    }
}
```

Create `Services/PersonService.cs`:
```csharp
using MyFirstApp.Console.Models;

namespace MyFirstApp.Console.Services
{
    public class PersonService
    {
        private List<Person> _people = new List<Person>();

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public void DisplayAllPeople()
        {
            Console.WriteLine("=== People List ===");
            foreach (var person in _people)
            {
                person.DisplayInfo();
            }
        }

        public Person? FindPersonByName(string firstName, string lastName)
        {
            return _people.FirstOrDefault(p => 
                p.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                p.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
```

Update `Program.cs`:
```csharp
using MyFirstApp.Console.Models;
using MyFirstApp.Console.Services;

Console.WriteLine("Welcome to My First .NET Application!");

var personService = new PersonService();

// Add some sample people
personService.AddPerson(new Person 
{ 
    FirstName = "John", 
    LastName = "Doe", 
    Age = 30 
});

personService.AddPerson(new Person 
{ 
    FirstName = "Jane", 
    LastName = "Smith", 
    Age = 25 
});

personService.AddPerson(new Person 
{ 
    FirstName = "Bob", 
    LastName = "Johnson", 
    Age = 35 
});

// Display all people
personService.DisplayAllPeople();

// Interactive search
Console.WriteLine("\n=== Search for a Person ===");
Console.Write("Enter first name: ");
string? firstName = Console.ReadLine();

Console.Write("Enter last name: ");
string? lastName = Console.ReadLine();

if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
{
    var foundPerson = personService.FindPersonByName(firstName, lastName);
    if (foundPerson != null)
    {
        Console.WriteLine("\nPerson found:");
        foundPerson.DisplayInfo();
    }
    else
    {
        Console.WriteLine("Person not found.");
    }
}

Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
```

### Task 4: Build and Run
```bash
# Build the project
dotnet build

# Run the project
dotnet run

# Or run with specific configuration
dotnet run --configuration Release
```

## Project Structure Best Practices

```
MyFirstApp.Console/
├── Models/           # Data models and entities
├── Services/         # Business logic and services
├── Utilities/        # Helper classes and extensions
├── Configuration/    # App settings and configuration
└── Program.cs        # Application entry point
```

## Expected Output
```
Welcome to My First .NET Application!
=== People List ===
Name: John Doe, Age: 30
Name: Jane Smith, Age: 25
Name: Bob Johnson, Age: 35

=== Search for a Person ===
Enter first name: Jane
Enter last name: Smith

Person found:
Name: Jane Smith, Age: 25

Press any key to exit...
```

## Key Takeaways
- Solutions can contain multiple projects
- Organize code into logical folders and namespaces
- Use meaningful names for classes and methods
- The `dotnet` CLI provides powerful project management
- Proper project structure improves maintainability

## Challenge Exercise
Add a `Utilities/InputValidator.cs` class that validates user input and modify the program to use it for safer input handling.

## Next Lab
Lab 1.4 will introduce source control with Git integration.
