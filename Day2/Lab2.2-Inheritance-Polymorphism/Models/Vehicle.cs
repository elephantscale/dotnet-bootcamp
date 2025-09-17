namespace Lab2_2.Models
{
    public enum FuelKind { Gasoline, Diesel, Electric, Hybrid }
    public enum Transmission { Manual, Automatic }

    // Abstract base
    public abstract class Vehicle
    {
        protected Vehicle(string make, string model, int year, FuelKind fuelKind, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelKind = fuelKind;
            Price = price;
        }

        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public FuelKind FuelKind { get; }
        public double Price { get; }
        public bool IsRunning { get; private set; }
        public double FuelLevel { get; private set; } = 0.5; // 0..1 for demo

        public virtual void Start()
        {
            IsRunning = true;
            Console.WriteLine($"{DescribeShort()} started.");
        }

        public virtual void Stop()
        {
            IsRunning = false;
            Console.WriteLine($"{DescribeShort()} stopped.");
        }

        public virtual void Refuel(double amount01)
        {
            FuelLevel = Math.Clamp(FuelLevel + amount01, 0, 1);
            Console.WriteLine($"{DescribeShort()} refueled to {(FuelLevel * 100):F0}%.");
        }

        public abstract void Accelerate();
        public abstract double RangeEstimateKm();

        public virtual string DescribeShort() => $"{Year} {Make} {Model}";
        public virtual void PrintInfo()
            => Console.WriteLine($"- {DescribeShort()} | {FuelKind} | ${Price:N0} | Range ~ {RangeEstimateKm():F0} km");
    }

    public class Car : Vehicle
    {
        public Car(string make, string model, int year, FuelKind fuelKind, double price, int doors = 4, Transmission transmission = Transmission.Automatic)
            : base(make, model, year, fuelKind, price)
        {
            Doors = doors;
            Transmission = transmission;
        }

        public int Doors { get; }
        public Transmission Transmission { get; }

        public override void Accelerate()
            => Console.WriteLine($"{DescribeShort()} (car) accelerates smoothly.");

        public override double RangeEstimateKm()
            => FuelKind switch
            {
                FuelKind.Electric => 420 * FuelLevel,
                FuelKind.Hybrid => 700 * FuelLevel,
                _ => 550 * FuelLevel
            };

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Doors: {Doors}, Transmission: {Transmission}");
        }
    }

    public class Motorcycle : Vehicle
    {
        public Motorcycle(string make, string model, int year, FuelKind fuelKind, double price, bool hasSidecar = false)
            : base(make, model, year, fuelKind, price)
        {
            HasSidecar = hasSidecar;
        }

        public bool HasSidecar { get; }

        public override void Accelerate()
            => Console.WriteLine($"{DescribeShort()} (motorcycle) zips ahead!");

        public override double RangeEstimateKm()
            => FuelKind == FuelKind.Electric ? 220 * FuelLevel : 350 * FuelLevel;

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Sidecar: {(HasSidecar ? "Yes" : "No")}");
        }
    }

    public class Truck : Vehicle
    {
        public Truck(string make, string model, int year, FuelKind fuelKind, double price, double capacityTons = 5)
            : base(make, model, year, fuelKind, price)
        {
            CapacityTons = Math.Max(0, capacityTons);
        }

        public double CapacityTons { get; }

        public override void Accelerate()
            => Console.WriteLine($"{DescribeShort()} (truck) builds momentum…");

        public override double RangeEstimateKm()
            => 400 * FuelLevel * (1 - Math.Min(0.5, CapacityTons / 20)); // crude load impact

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"  Capacity: {CapacityTons:F1} tons");
        }
    }
}