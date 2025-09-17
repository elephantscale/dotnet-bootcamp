using Lab3_1.Models;

namespace Lab3_1.Services
{
    public static class ConstructorDemos
    {
        public static void PersonConstructorDemos()
        {
            Console.WriteLine("=== Person Constructor Demonstrations ===\n");

            Console.WriteLine("1. Default Constructor:");
            var p1 = new Person();
            Console.WriteLine($"   {p1.Describe()}");

            Console.WriteLine("\n2. Constructor with Name:");
            var p2 = new Person("John", "Doe");
            Console.WriteLine($"   {p2.Describe()}");

            Console.WriteLine("\n3. Constructor with Name and Birth Date:");
            var p3 = new Person("Jane", "Smith", new DateTime(DateTime.Today.Year - 33, 5, 1));
            Console.WriteLine($"   {p3.Describe()}");
            Console.WriteLine($"   Age: {p3.Age}, Age Group: {p3.AgeGroup}");

            Console.WriteLine("\n4. Full Constructor with Contact:");
            var addr = new Address("10 Main St", "Springfield", "IL", "62704");
            var p4 = new Person("Alex", "Johnson", new DateTime(1995, 2, 20), "alex.j@company.com", addr);
            Console.WriteLine($"   {p4.Describe()}");
            Console.WriteLine($"   Address: {p4.Address}");

            Console.WriteLine("\n5. Copy Constructor (deep copy of address):");
            var p5 = new Person(p4);
            Console.WriteLine($"   Copy: {p5.Describe()}");
            Console.WriteLine();
        }

        public static void VehicleConstructorDemos()
        {
            Console.WriteLine("=== Vehicle Constructor Demonstrations ===\n");

            Console.WriteLine("1. Car Constructors:");
            var car1 = new Car("Toyota", "Camry", 2022, 28000m);
            Console.WriteLine($"   Basic: {car1.Summary()}");

            var car2 = Car.CreateEvHatch("Tesla", "Model 3", DateTime.Now.Year, 39999m);
            Console.WriteLine($"   Factory: {car2.Summary()}");

            Console.WriteLine("\n2. Motorcycle Constructors:");
            var m1 = new Motorcycle("Yamaha", "MT-07", 2023, 7899m, "Sport");
            Console.WriteLine($"   {m1.Summary()}");
            var m2 = new Motorcycle("Harley-Davidson", "Road King", 2021, 19999m, "Cruiser", hasSidecar: true);
            Console.WriteLine($"   {m2.Summary()}");

            Console.WriteLine();
        }

        public static void BankAccountConstructorDemos()
        {
            Console.WriteLine("=== Bank Account Constructor Demonstrations ===\n");
            BankAccount.PrintAccountTypeInfo();

            Console.WriteLine("1. Factory Methods:");
            var a1 = BankAccount.CreateChecking("Chris P. Bacon", 350m);
            var a2 = BankAccount.CreateSavings("Pat T. Cake", 1500m);
            var a3 = BankAccount.CreatePremium("Al B. Tross", 5000m);

            Console.WriteLine($"   {a1}");
            Console.WriteLine($"   {a2}");
            Console.WriteLine($"   {a3}");

            Console.WriteLine("\n2. Builder Pattern:");
            var built = BankAccount.Configure()
                .WithHolder("Taylor Swiftcode")
                .WithInitialBalance(7000m)
                .As(AccountType.Premium)
                .WithCustomRate(0.045m)
                .Build();

            Console.WriteLine($"   {built}");

            Console.WriteLine("\n3. Copy Constructor:");
            var copy = new BankAccount(built);
            Console.WriteLine($"   Copied: {copy}\n");
        }

        public static void FamilyDemo()
        {
            Console.WriteLine("👨‍👩‍👧‍👦 Creating a Family with Different Constructor Patterns:");
            Console.WriteLine("--------------------------------------------------");

            var dad = Person.CreateEmployee("John", "Smith", "john.smith@email.com",
                        new Address("12 Oak St", "Columbus", "OH", "43085"));
            var mom = Person.CreateEmployee("Jane", "Smith", "jane.smith@email.com",
                        new Address("12 Oak St", "Columbus", "OH", "43085"));
            var kid1 = Person.CreateChild("Emily", "Smith", 13);
            var kid2 = Person.CreateChild("Michael", "Smith", 11);

            var family = new[] { dad, mom, kid1, kid2 };

            Console.WriteLine("\nFamily Members:");
            foreach (var p in family)
            {
                Console.WriteLine($"  {p.FirstName} {p.LastName}, Age: {p.Age}, Email: {p.Email}");
                Console.WriteLine($"    Age Group: {p.AgeGroup}");
            }
        }
    }
}