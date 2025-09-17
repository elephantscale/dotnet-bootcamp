using MyFirstApp.Console.Models;
using MyFirstApp.Console.Services;

System.Console.WriteLine("Welcome to My First .NET Application!");

var personService = new PersonService();

// Add some sample people
personService.AddPerson(new Person { FirstName = "John", LastName = "Doe", Age = 30 });
personService.AddPerson(new Person { FirstName = "Jane", LastName = "Smith", Age = 25 });
personService.AddPerson(new Person { FirstName = "Bob", LastName = "Johnson", Age = 35 });

// Display all people
personService.DisplayAllPeople();

// Interactive search
System.Console.WriteLine("\n=== Search for a Person ===");
System.Console.Write("Enter first name: ");
string? firstName = System.Console.ReadLine();

System.Console.Write("Enter last name: ");
string? lastName = System.Console.ReadLine();

if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
{
    var foundPerson = personService.FindPersonByName(firstName, lastName);
    if (foundPerson is not null)
    {
        System.Console.WriteLine("\nPerson found:");
        foundPerson.DisplayInfo();
    }
    else
    {
        System.Console.WriteLine("Person not found.");
    }
}

System.Console.WriteLine("\nPress any key to exit...");
System.Console.ReadKey();