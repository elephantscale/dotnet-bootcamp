using System;

namespace Lab1_5.Models
{
    public class Vehicle
    {
        // Fields (private data)
        private string _make = "";
        private string _model = "";
        private int _year;
        private decimal _price;

        // Properties (public interface)
        public string Make
        {
            get => _make;
            set => _make = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Model
        {
            get => _model;
            set => _model = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Year
        {
            get => _year;
            set => _year = value > 1885 ? value : throw new ArgumentException("Year must be after 1885");
        }

        public decimal Price
        {
            get => _price;
            set => _price = value >= 0 ? value : throw new ArgumentException("Price cannot be negative");
        }

        // Auto-implemented properties
        public string Color { get; set; } = "White";
        public bool IsRunning { get; private set; }

        // Constructor
        public Vehicle(string make, string model, int year, decimal price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
            IsRunning = false;
        }

        // Methods
        public void Start()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                Console.WriteLine($"{Make} {Model} is now running.");
            }
            else
            {
                Console.WriteLine($"{Make} {Model} is already running.");
            }
        }

        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
                Console.WriteLine($"{Make} {Model} has stopped.");
            }
            else
            {
                Console.WriteLine($"{Make} {Model} is already stopped.");
            }
        }

        public string GetVehicleInfo()
        {
            // Note: {Price:C} already includes the currency symbol for the current culture
            return $"{Year} {Make} {Model} - {Price:C} ({Color})";
        }

        public void Honk()
        {
            Console.WriteLine($"{Make} {Model}: Beep! Beep!");
        }

        // Override ToString for better object representation
        public override string ToString() => GetVehicleInfo();
    }
}