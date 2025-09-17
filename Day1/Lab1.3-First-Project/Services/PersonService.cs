using System;
using System.Collections.Generic;
using System.Linq;
using MyFirstApp.Console.Models;

namespace MyFirstApp.Console.Services
{
    public class PersonService
    {
        private readonly List<Person> _people = new();

        public void AddPerson(Person person) => _people.Add(person);

        public void DisplayAllPeople()
        {
            System.Console.WriteLine("=== People List ===");
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