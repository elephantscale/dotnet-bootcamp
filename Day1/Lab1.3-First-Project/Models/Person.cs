namespace MyFirstApp.Console.Models
{
    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }

        public string GetFullName() => $"{FirstName} {LastName}";

        public void DisplayInfo()
        {
            System.Console.WriteLine($"Name: {GetFullName()}, Age: {Age}");
        }

        public override string ToString() => $"{GetFullName()} ({Age})";
    }
}