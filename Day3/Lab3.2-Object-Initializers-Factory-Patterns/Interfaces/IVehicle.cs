namespace Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

public enum VehicleType { Car, Truck, Motorcycle }

public interface IVehicle
{
    string Model { get; }
    string FuelType { get; }
    string Description();
}