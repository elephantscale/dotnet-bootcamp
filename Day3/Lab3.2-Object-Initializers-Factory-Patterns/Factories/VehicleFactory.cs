// using Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

// namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

// // Simple Factory Pattern
// public static class VehicleFactory
// {
//     private static readonly Dictionary<VehicleType, Func<string, string, int, decimal, IVehicle>> _vehicleCreators = new()
//     {
//         { VehicleType.Car, (make, model, year, price) => new Car(make, model, year, price) },
//         { VehicleType.Truck, (make, model, year, price) => new Truck(make, model, year, price) },
//         { VehicleType.Motorcycle, (make, model, year, price) => new Motorcycle(make, model, year, price) },
//         { VehicleType.SUV, (make, model, year, price) => new SUV(make, model, year, price) },
//         { VehicleType.Van, (make, model, year, price) => new Van(make, model, year, price) }
//     };

//     public static IVehicle CreateVehicle(VehicleType type, string make, string model, int year = 2024, decimal price = 0)
//     {
//         if (!_vehicleCreators.ContainsKey(type))
//             throw new ArgumentException($"Unknown vehicle type: {type}");

//         if (string.IsNullOrWhiteSpace(make))
//             throw new ArgumentException("Make cannot be empty");

//         if (string.IsNullOrWhiteSpace(model))
//             throw new ArgumentException("Model cannot be empty");

//         if (year < 1900 || year > DateTime.Now.Year + 1)
//             throw new ArgumentException("Invalid year");

//         return _vehicleCreators[type](make, model, year, price);
//     }

//     // Factory methods with predefined configurations
//     public static IVehicle CreateEconomyCar(string make, string model)
//     {
//         return new Car(make, model, 2024, 25000)
//         {
//             Doors = 4,
//             FuelType = "Gasoline",
//             Transmission = "Manual"
//         };
//     }

//     public static IVehicle CreateLuxuryCar(string make, string model)
//     {
//         return new Car(make, model, 2024, 75000)
//         {
//             Doors = 4,
//             FuelType = "Hybrid",
//             Transmission = "Automatic"
//         };
//     }

//     public static IVehicle CreateWorkTruck(string make, string model)
//     {
//         return new Truck(make, model, 2024, 45000)
//         {
//             BedLength = "8 feet",
//             PayloadCapacity = 2000,
//             TowingCapacity = 8000
//         };
//     }
// }

// // Concrete Vehicle Implementations
// public class Car : IVehicle
// {
//     public string Make { get; }
//     public string Model { get; }
//     public int Year { get; }
//     public decimal Price { get; }
//     public VehicleType Type => VehicleType.Car;

//     public int Doors { get; set; } = 4;
//     public string FuelType { get; set; } = "Gasoline";
//     public string Transmission { get; set; } = "Automatic";

//     public Car(string make, string model, int year, decimal price)
//     {
//         Make = make;
//         Model = model;
//         Year = year;
//         Price = price;
//     }

//     public void Start() => Console.WriteLine($"{Make} {Model} engine started");
//     public void Stop() => Console.WriteLine($"{Make} {Model} engine stopped");

//     public string GetSpecifications()
//     {
//         return $"{Year} {Make} {Model} - {Doors} doors, {FuelType}, {Transmission}";
//     }

//     public decimal CalculateInsurance()
//     {
//         return Price * 0.08m; // 8% of vehicle value
//     }

//     public override string ToString()
//     {
//         return $"Car: {Year} {Make} {Model}, Price: ${Price:C}, Status: Available";
//     }
// }

// public class Truck : IVehicle
// {
//     public string Make { get; }
//     public string Model { get; }
//     public int Year { get; }
//     public decimal Price { get; }
//     public VehicleType Type => VehicleType.Truck;

//     public string BedLength { get; set; } = "6 feet";
//     public int PayloadCapacity { get; set; } = 1500;
//     public int TowingCapacity { get; set; } = 5000;

//     public Truck(string make, string model, int year, decimal price)
//     {
//         Make = make;
//         Model = model;
//         Year = year;
//         Price = price;
//     }

//     public void Start() => Console.WriteLine($"{Make} {Model} truck started");
//     public void Stop() => Console.WriteLine($"{Make} {Model} truck stopped");

//     public string GetSpecifications()
//     {
//         return $"{Year} {Make} {Model} - {BedLength} bed, {PayloadCapacity} lbs payload, {TowingCapacity} lbs towing";
//     }

//     public decimal CalculateInsurance()
//     {
//         return Price * 0.12m; // 12% of vehicle value (higher for commercial use)
//     }

//     public override string ToString()
//     {
//         return $"Truck: {Year} {Make} {Model}, Price: ${Price:C}, Payload: {PayloadCapacity} lbs";
//     }
// }

// public class Motorcycle : IVehicle
// {
//     public string Make { get; }
//     public string Model { get; }
//     public int Year { get; }
//     public decimal Price { get; }
//     public VehicleType Type => VehicleType.Motorcycle;

//     public int EngineSize { get; set; } = 600;
//     public string Style { get; set; } = "Sport";

//     public Motorcycle(string make, string model, int year, decimal price)
//     {
//         Make = make;
//         Model = model;
//         Year = year;
//         Price = price;
//     }

//     public void Start() => Console.WriteLine($"{Make} {Model} motorcycle started");
//     public void Stop() => Console.WriteLine($"{Make} {Model} motorcycle stopped");

//     public string GetSpecifications()
//     {
//         return $"{Year} {Make} {Model} - {Style}, {EngineSize}cc engine";
//     }

//     public decimal CalculateInsurance()
//     {
//         return Price * 0.15m; // 15% of vehicle value (higher risk)
//     }

//     public override string ToString()
//     {
//         return $"Motorcycle: {Year} {Make} {Model}, Price: ${Price:C}, Engine: {EngineSize}cc";
//     }
// }

// public class SUV : IVehicle
// {
//     public string Make { get; }
//     public string Model { get; }
//     public int Year { get; }
//     public decimal Price { get; }
//     public VehicleType Type => VehicleType.SUV;

//     public int SeatingCapacity { get; set; } = 7;
//     public bool AllWheelDrive { get; set; } = true;

//     public SUV(string make, string model, int year, decimal price)
//     {
//         Make = make;
//         Model = model;
//         Year = year;
//         Price = price;
//     }

//     public void Start() => Console.WriteLine($"{Make} {Model} SUV started");
//     public void Stop() => Console.WriteLine($"{Make} {Model} SUV stopped");

//     public string GetSpecifications()
//     {
//         return $"{Year} {Make} {Model} - {SeatingCapacity} seats, {(AllWheelDrive ? "AWD" : "FWD")}";
//     }

//     public decimal CalculateInsurance()
//     {
//         return Price * 0.10m; // 10% of vehicle value
//     }

//     public override string ToString()
//     {
//         return $"SUV: {Year} {Make} {Model}, Price: ${Price:C}, Seats: {SeatingCapacity}";
//     }
// }

// public class Van : IVehicle
// {
//     public string Make { get; }
//     public string Model { get; }
//     public int Year { get; }
//     public decimal Price { get; }
//     public VehicleType Type => VehicleType.Van;

//     public int CargoCapacity { get; set; } = 150; // cubic feet
//     public bool IsPassenger { get; set; } = false;

//     public Van(string make, string model, int year, decimal price)
//     {
//         Make = make;
//         Model = model;
//         Year = year;
//         Price = price;
//     }

//     public void Start() => Console.WriteLine($"{Make} {Model} van started");
//     public void Stop() => Console.WriteLine($"{Make} {Model} van stopped");

//     public string GetSpecifications()
//     {
//         return $"{Year} {Make} {Model} - {CargoCapacity} cu ft, {(IsPassenger ? "Passenger" : "Cargo")} van";
//     }

//     public decimal CalculateInsurance()
//     {
//         return Price * 0.09m; // 9% of vehicle value
//     }

//     public override string ToString()
//     {
//         return $"Van: {Year} {Make} {Model}, Price: ${Price:C}, Capacity: {CargoCapacity} cu ft";
//     }
// }

using Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

public static class VehicleFactory
{
    public static IVehicle CreateVehicle(
        VehicleType type, string model, params (string key, string value)[] details) =>
        type switch
        {
            VehicleType.Car => new Car(model, "Gasoline", details),
            VehicleType.Truck => new Truck(model, "Diesel", details),
            VehicleType.Motorcycle => new Motorcycle(model, "Gasoline", details),
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
}

file sealed class Car(string model, string fuel, params (string key, string value)[] details) : IVehicle
{
    public string Model { get; } = model;
    public string FuelType { get; } = fuel;
    public string Description() =>
        $"Car: {Model} ({string.Join(", ", details.Select(d => $"{d.value} {d.key}"))})";
}
file sealed class Truck(string model, string fuel, params (string key, string value)[] details) : IVehicle
{
    public string Model { get; } = model;
    public string FuelType { get; } = fuel;
    public string Description() =>
        $"Truck: {Model} ({string.Join(", ", details.Select(d => $"{d.value} {d.key}"))})";
}
file sealed class Motorcycle(string model, string fuel, params (string key, string value)[] details) : IVehicle
{
    public string Model { get; } = model;
    public string FuelType { get; } = fuel;
    public string Description() =>
        $"Motorcycle: {Model} ({string.Join(", ", details.Select(d => $"{d.value} {d.key}"))})";
}