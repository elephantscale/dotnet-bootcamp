using Lab2_2.Models;

namespace Lab2_2
{
    public static class InheritanceConcepts
    {
        // Small types to illustrate overriding vs hiding and base constructor flow
        private class BaseDevice
        {
            public BaseDevice() => Console.WriteLine("BaseDevice ctor");
            public virtual void Describe() => Console.WriteLine("BaseDevice.Describe()");
            public void NonVirtual() => Console.WriteLine("BaseDevice.NonVirtual()");
        }

        private class FancyDevice : BaseDevice
        {
            public FancyDevice() : base() => Console.WriteLine("FancyDevice ctor");
            public override void Describe() => Console.WriteLine("FancyDevice.Describe() (override)");
            public new void NonVirtual() => Console.WriteLine("FancyDevice.NonVirtual() (hidden)");
        }

        public static void RunAll()
        {
            Console.WriteLine("=== Inheritance Concepts ===\n");

            Console.WriteLine("-- Base constructor call & overriding --");
            BaseDevice dev = new FancyDevice();
            dev.Describe();     // virtual -> overridden method
            dev.NonVirtual();   // non-virtual -> base version due to hiding

            Console.WriteLine("\n-- Polymorphism with existing hierarchy --");
            Animal[] animals =
            {
                new Dog("Polly", 3, 12),
                new Cat("Mochi", 2, 4.2),
                new Bird("Skye", 1, 0.2)
            };
            foreach (var a in animals)
            {
                Console.Write($"{a.Species} {a.Name}: ");
                Console.WriteLine(a.MakeSound()); // late-bound
            }

            Console.WriteLine("\n-- Type checking and safe casting --");
            object obj = animals[0]; // a Dog as object
            if (obj is Animal animal)
            {
                Console.WriteLine($"obj is an Animal -> {animal.Species}");
            }
            // safe cast using 'as'
            var maybeBird = obj as Bird;
            Console.WriteLine($"Casting Dog to Bird using 'as' yields null? {maybeBird is null}");
        }
    }
}