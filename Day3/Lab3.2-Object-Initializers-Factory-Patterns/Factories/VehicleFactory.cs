

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
