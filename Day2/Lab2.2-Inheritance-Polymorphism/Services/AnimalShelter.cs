using Lab2_2.Models;

namespace Lab2_2.Services
{
    public class AnimalShelter
    {
        private readonly List<Animal> _animals = new();

        public void Admit(Animal animal)
        {
            _animals.Add(animal);
            Console.WriteLine($"Admitted: {animal.Species} '{animal.Name}'");
        }

        public void ListAll()
        {
            Console.WriteLine("\nAnimals in shelter:");
            foreach (var a in _animals) a.PrintInfo();
        }

        public void DailyCare()
        {
            Console.WriteLine("\nDaily care:");
            foreach (var a in _animals)
            {
                a.Feed(0.2);
                a.Exercise();
                Console.WriteLine($"  {a.Species} {a.Name} says '{a.MakeSound()}'");
                // Type-specific behavior via polymorphism + pattern matching
                switch (a)
                {
                    case Dog d: d.Fetch(); break;
                    case Cat c: c.Scratch(); break;
                    case Bird b: b.Sing(); break;
                }
            }
        }

        public Animal? Adopt(string name)
        {
            var idx = _animals.FindIndex(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (idx >= 0)
            {
                var adopted = _animals[idx];
                _animals.RemoveAt(idx);
                Console.WriteLine($"\nAdopted: {adopted.Species} '{adopted.Name}'");
                return adopted;
            }
            Console.WriteLine($"\nNo animal named '{name}' found.");
            return null;
        }

        public void Stats()
        {
            Console.WriteLine("\nShelter stats:");
            Console.WriteLine($"  Total: {_animals.Count}");
            foreach (var group in _animals.GroupBy(a => a.Species))
                Console.WriteLine($"  {group.Key}: {group.Count()}");
        }
    }
}