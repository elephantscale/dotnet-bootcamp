using System.Text.RegularExpressions;

namespace Lab3_1.Models
{
    public enum AgeGroup { Child, Teen, Adult, Senior }

    public class Person
    {
        // Static tracking
        private static int _counter = 0;
        public static int InstanceCount => _counter;

        private static string NextId() => $"P{Interlocked.Increment(ref _counter):D6}";

        // Fields
        private string _firstName = "Unknown";
        private string _lastName = "Unknown";

        // Core properties
        public string Id { get; }
        public string FirstName
        {
            get => _firstName;
            set => _firstName = ValidateName(value, nameof(FirstName));
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = ValidateName(value, nameof(LastName));
        }

        public DateTime? BirthDate { get; private set; }
        public string Email { get; private set; } = "Not provided";
        public Address? Address { get; private set; }

        // Computed
        public int Age
        {
            get
            {
                if (BirthDate is null) return 0;
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Value.Year;
                if (BirthDate.Value.Date > today.AddYears(-age)) age--;
                return Math.Max(age, 0);
            }
        }

        public AgeGroup AgeGroup => Age switch
        {
            < 13 => Models.AgeGroup.Child,
            < 18 => Models.AgeGroup.Teen,
            < 65 => Models.AgeGroup.Adult,
            _ => Models.AgeGroup.Senior
        };

        // // 1) Default constructor
        // public Person()
        // {
        //     Id = NextId();
        //     PrintCreated();
        // }

        // // 2) Constructor with name
        // public Person(string firstName, string lastName) : this()
        // {
        //     FirstName = firstName;
        //     LastName = lastName;
        // }

        // // 3) Constructor with name and birthdate (chaining)
        // public Person(string firstName, string lastName, DateTime birthDate) : this(firstName, lastName)
        // {
        //     BirthDate = ValidateBirthDate(birthDate);
        // }

        // // 4) Full constructor
        // public Person(string firstName, string lastName, DateTime birthDate, string email, Address address)
        //     : this(firstName, lastName, birthDate)
        // {
        //     SetEmail(email);
        //     Address = address ?? throw new ArgumentNullException(nameof(address));
        // }

        // // 5) Copy constructor (deep copy for Address)
        // public Person(Person other)
        //     : this(other.FirstName, other.LastName, other.BirthDate ?? DateTime.Today, other.Email,
        //           other.Address is null ? new Address("N/A", "N/A", "N/A", "00000") : new Address(other.Address))
        // { }
        // Person.cs – only the constructors changed

        public Person()
        {
            Id = NextId();
            // no logging here — names not set yet
        }

        public Person(string firstName, string lastName) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PrintCreated(); // log once with the real name
        }

        public Person(string firstName, string lastName, DateTime birthDate)
            : this(firstName, lastName)
        {
            BirthDate = ValidateBirthDate(birthDate);
            // already printed in the (first,last) ctor
        }

        public Person(string firstName, string lastName, DateTime birthDate, string email, Address address)
            : this(firstName, lastName, birthDate)
        {
            SetEmail(email);
            Address = address ?? throw new ArgumentNullException(nameof(address));
            // no extra print
        }

        // Copy ctor can optionally skip printing (it already prints in chained ctors if you want).
        public Person(Person other)
            : this(other.FirstName, other.LastName, other.BirthDate ?? DateTime.Today, other.Email,
                   other.Address is null ? new Address("N/A", "N/A", "N/A", "00000") : new Address(other.Address))
        { }

        // Static constructors (class-level init)
        static Person() { /* could load metadata here */ }

        // Factory methods
        public static Person CreateChild(string firstName, string lastName, int ageYears)
        {
            if (ageYears < 0 || ageYears > 17) throw new ArgumentException("Age must be 0-17 for child");
            var dob = DateTime.Today.AddYears(-ageYears);
            var child = new Person(firstName, lastName, dob);
            Console.WriteLine($"Child created: {child}");
            return child;
        }

        public static Person CreateEmployee(string firstName, string lastName, string email, Address address)
        {
            var emp = new Person(firstName, lastName)
            {
                Address = address
            };
            emp.SetEmail(email);
            Console.WriteLine($"Employee created: {emp}");
            return emp;
        }

        // Helpers
        private static string ValidateName(string name, string prop)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"{prop} required");
            if (name.Trim().Length < 2) throw new ArgumentException($"{prop} too short");
            return name.Trim();
        }

        private static DateTime ValidateBirthDate(DateTime dt)
        {
            var min = new DateTime(1900, 1, 1);
            if (dt < min || dt > DateTime.Today) throw new ArgumentException("Birth date out of range");
            return dt.Date;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email required");
            var ok = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!ok) throw new ArgumentException("Invalid email format");
            Email = email.Trim();
        }

        private void PrintCreated() =>
            Console.WriteLine($"Person created: {FirstName} {LastName} (ID: {Id})");

        public override string ToString() => $"{FirstName} {LastName} (ID: {Id})";

        public string Describe() =>
            $"Created: {FirstName} {LastName}, Age: {Age}, Email: {Email}";
    }
}