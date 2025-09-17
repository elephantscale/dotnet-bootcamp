using Lab2_2;               // <-- import the namespace that contains InheritanceConcepts
using Lab2_2.Models;
using Lab2_2.Services;

Console.WriteLine("=== Inheritance & Polymorphism Demo ===\n");

// ------------ Animal Shelter Demo ------------
Console.WriteLine(">>> Animal Shelter Demo");
var shelter = new AnimalShelter();

shelter.Admit(new Dog("Buddy", 4, 18.2, breed: "Labrador"));
shelter.Admit(new Cat("Luna", 3, 4.5));
shelter.Admit(new Bird("Kiwi", 1, 0.25, wingspanMeters: 0.35));

shelter.ListAll();
shelter.DailyCare();
shelter.Adopt("Luna");
shelter.Stats();

// ------------ Vehicle Fleet Demo ------------
Console.WriteLine("\n>>> Vehicle Fleet Demo");
var fleet = new VehicleFleet();
fleet.Add(new Car("Toyota", "Camry", 2022, FuelKind.Gasoline, 28000, 4, Transmission.Automatic));
fleet.Add(new Motorcycle("Yamaha", "MT-07", 2023, FuelKind.Gasoline, 7900));
fleet.Add(new Truck("Volvo", "FH16", 2021, FuelKind.Diesel, 120000, capacityTons: 12));
fleet.Add(new Car("Tesla", "Model 3", 2025, FuelKind.Electric, 39999, 4, Transmission.Automatic));

fleet.ListAll();
fleet.OperateAll();
fleet.RefuelAll(0.2);
fleet.EfficiencyReport();

// ------------ Inheritance Concepts ------------
Console.WriteLine();
InheritanceConcepts.RunAll();

Console.WriteLine("\nDone.\nPress any key to exit...");
Console.ReadKey();