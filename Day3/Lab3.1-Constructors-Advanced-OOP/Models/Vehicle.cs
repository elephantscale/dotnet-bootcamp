namespace Lab3_1.Models
{
    public abstract class Vehicle
    {
        // Static tracking
        public static int VehicleCount { get; private set; }

        public string Make { get; }
        public string Model { get; }
        public int Year { get; }
        public decimal Price { get; protected set; }
        public bool IsAvailable { get; protected set; } = true;

        // Static constructor
        static Vehicle()
        {
            Console.WriteLine("Vehicle static constructor - initializing vehicle tracking system");
        }

        protected Vehicle(string make, string model, int year, decimal price)
        {
            Make = string.IsNullOrWhiteSpace(make) ? throw new ArgumentException("Make required") : make.Trim();
            Model = string.IsNullOrWhiteSpace(model) ? throw new ArgumentException("Model required") : model.Trim();
            if (year < 1886 || year > DateTime.Now.Year + 1) throw new ArgumentException("Year out of range");
            if (price < 0) throw new ArgumentException("Price cannot be negative");

            Year = year;
            Price = price;
            VehicleCount++;
            Console.WriteLine($"Vehicle created: {Year} {Make} {Model} (Total: {VehicleCount})");
        }

        public abstract string Summary();
        public override string ToString() => $"{Year} {Make} {Model}";
    }

    public enum FuelType { Gasoline, Diesel, Hybrid, Electric }
    public enum Transmission { Manual, Automatic }

    public sealed class Car : Vehicle
    {
        public int Doors { get; }
        public FuelType Fuel { get; }
        public Transmission Transmission { get; }

        public Car(string make, string model, int year, decimal price,
                   int doors = 4, FuelType fuel = FuelType.Gasoline, Transmission transmission = Transmission.Automatic)
            : base(make, model, year, price)
        {
            Doors = doors switch
            {
                < 2 => throw new ArgumentException("Car must have at least 2 doors"),
                _ => doors
            };
            Fuel = fuel;
            Transmission = transmission;

            Console.WriteLine($"Car created: {this} - {Doors} doors, {Fuel}, {Transmission}");
        }

        public override string Summary() =>
            $"Car: {this}, Price: {Price:C0}, Status: {(IsAvailable ? "Available" : "Unavailable")}";

        // Factory helpers
        public static Car CreateSedan(string make, string model, int year, decimal price) =>
            new(make, model, year, price, doors: 4, fuel: FuelType.Gasoline, transmission: Transmission.Automatic);

        public static Car CreateEvHatch(string make, string model, int year, decimal price) =>
            new(make, model, year, price, doors: 4, fuel: FuelType.Electric, transmission: Transmission.Automatic);
    }

    public sealed class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; }
        public string Type { get; } // e.g., Cruiser, Sport, Touring

        public Motorcycle(string make, string model, int year, decimal price, string type = "Standard", bool hasSidecar = false)
            : base(make, model, year, price)
        {
            Type = string.IsNullOrWhiteSpace(type) ? "Standard" : type.Trim();
            HasSidecar = hasSidecar;
            Console.WriteLine($"Motorcycle created: {this} - {Type}, Sidecar: {(HasSidecar ? "Yes" : "No")}");
        }

        public override string Summary() =>
            $"Motorcycle: {this} ({Type}), Price: {Price:C0}, Sidecar: {(HasSidecar ? "Yes" : "No")}";
    }
}