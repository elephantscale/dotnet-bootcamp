using Lab2_2.Models;

namespace Lab2_2.Services
{
    public class VehicleFleet
    {
        private readonly List<Vehicle> _vehicles = new();

        public void Add(Vehicle v)
        {
            _vehicles.Add(v);
            Console.WriteLine($"Added to fleet: {v.DescribeShort()}");
        }

        public void ListAll()
        {
            Console.WriteLine("\nFleet vehicles:");
            foreach (var v in _vehicles) v.PrintInfo();
        }

        public void OperateAll()
        {
            Console.WriteLine("\nOperating fleet:");
            foreach (var v in _vehicles)
            {
                v.Start();
                v.Accelerate();
                v.Stop();
            }
        }

        public void RefuelAll(double amount01 = 0.3)
        {
            Console.WriteLine("\nRefueling fleet:");
            foreach (var v in _vehicles) v.Refuel(amount01);
        }

        public void EfficiencyReport()
        {
            Console.WriteLine("\nEfficiency report:");
            var avgRange = _vehicles.Average(v => v.RangeEstimateKm());
            Console.WriteLine($"  Average estimated range: {avgRange:F0} km");
            foreach (var g in _vehicles.GroupBy(v => v.FuelKind))
            {
                Console.WriteLine($"  {g.Key}: {g.Count()} vehicles");
            }
        }
    }
}