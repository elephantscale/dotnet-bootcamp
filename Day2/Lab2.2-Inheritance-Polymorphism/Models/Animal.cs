namespace Lab2_2.Models
{
    // Base (abstract) class
    public abstract class Animal
    {
        protected Animal(string name, int age, double weightKg)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
            Age = Math.Max(0, age);
            WeightKg = Math.Max(0, weightKg);
        }

        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public double WeightKg { get; protected set; }
        public virtual string Species => GetType().Name;

        public virtual void Feed(double foodKg)
        {
            // small weight increase for demo
            WeightKg += Math.Max(0, foodKg) * 0.25;
            Console.WriteLine($"{Species} {Name} was fed. New weight: {WeightKg:F1} kg");
        }

        public virtual void Exercise()
        {
            WeightKg = Math.Max(0, WeightKg - 0.1);
            Console.WriteLine($"{Species} {Name} did some exercise.");
        }

        public abstract string MakeSound();

        public virtual void Move() => Console.WriteLine($"{Species} {Name} moves around.");

        public virtual void PrintInfo()
        {
            Console.WriteLine($"- {Species} '{Name}', Age: {Age}, Weight: {WeightKg:F1} kg");
        }
    }

    public class Dog : Animal
    {
        public Dog(string name, int age, double weightKg, string breed = "Mixed", bool isTrained = true)
            : base(name, age, weightKg)
        {
            Breed = breed;
            IsTrained = isTrained;
        }

        public string Breed { get; }
        public bool IsTrained { get; }

        public override string MakeSound() => "Woof!";
        public override void Move() => Console.WriteLine($"Dog {Name} runs happily.");

        public void Fetch(string item = "stick")
            => Console.WriteLine($"Dog {Name} fetches the {item}!");

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Breed: {Breed}, Trained: {IsTrained}");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name, int age, double weightKg, int livesLeft = 9)
            : base(name, age, weightKg)
        {
            LivesLeft = Math.Clamp(livesLeft, 1, 9);
        }

        public int LivesLeft { get; private set; }

        public override string MakeSound() => "Meow!";
        public override void Move() => Console.WriteLine($"Cat {Name} sneaks gracefully.");

        public void Scratch() => Console.WriteLine($"Cat {Name} scratches the post.");

        public override void Exercise()
        {
            base.Exercise();
            Console.WriteLine($"Cat {Name} takes a nap after exercising.");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Lives left: {LivesLeft}");
        }
    }

    public class Bird : Animal
    {
        public Bird(string name, int age, double weightKg, double wingspanMeters = 0.3)
            : base(name, age, weightKg)
        {
            WingspanMeters = Math.Max(0.1, wingspanMeters);
        }

        public double WingspanMeters { get; }

        public override string MakeSound() => "Chirp!";
        public override void Move() => Console.WriteLine($"Bird {Name} flies through the air.");

        public void Sing() => Console.WriteLine($"Bird {Name} sings a melody.");

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Wingspan: {WingspanMeters:F2} m");
        }
    }
}