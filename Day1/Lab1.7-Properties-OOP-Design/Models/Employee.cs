namespace Lab1_7.Models
{
    public class Employee
    {
        // Private fields
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private decimal _salary;
        private DateTime _hireDate;

        // Full property with validation
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First name cannot be empty");
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last name cannot be empty");
                _lastName = value.Trim();
            }
        }

        // Property with business logic
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0) throw new ArgumentException("Salary cannot be negative");
                if (value > 1_000_000) throw new ArgumentException("Salary exceeds maximum allowed");
                _salary = value;
            }
        }

        // Read-only property
        public DateTime HireDate
        {
            get => _hireDate;
            private set => _hireDate = value;
        }

        // Auto-implemented properties
        public int EmployeeId { get; set; }
        public string Department { get; set; } = "General";
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Computed properties
        public string FullName => $"{FirstName} {LastName}";
        public int YearsOfService => DateTime.Now.Year - HireDate.Year;
        public decimal AnnualSalary => Salary * 12;
        public string DisplayName => $"{FullName} ({EmployeeId})";

        public string SalaryGrade => AnnualSalary switch
        {
            < 30_000 => "Entry Level",
            < 50_000 => "Junior",
            < 75_000 => "Mid Level",
            < 100_000 => "Senior",
            < 150_000 => "Lead",
            _ => "Executive"
        };

        // Constructor
        public Employee(int employeeId, string firstName, string lastName, decimal monthlySalary)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Salary = monthlySalary;
            HireDate = DateTime.Now;
        }

        // Methods using properties
        public void GiveRaise(decimal percentage)
        {
            if (percentage < 0) throw new ArgumentException("Raise percentage cannot be negative");

            var oldSalary = Salary;
            Salary += Salary * (percentage / 100m);

            Console.WriteLine($"{FullName} received a {percentage}% raise");
            Console.WriteLine($"Salary increased from {oldSalary:C} to {Salary:C} per month");
        }

        public void UpdateDepartment(string newDepartment)
        {
            if (string.IsNullOrWhiteSpace(newDepartment))
                throw new ArgumentException("Department cannot be empty");

            var oldDepartment = Department;
            Department = newDepartment;

            Console.WriteLine($"{FullName} transferred from {oldDepartment} to {Department}");
        }

        public void PrintEmployeeInfo()
        {
            Console.WriteLine($"\n=== Employee Information ===");
            Console.WriteLine($"ID: {EmployeeId}");
            Console.WriteLine($"Name: {FullName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Hire Date: {HireDate:yyyy-MM-dd}");
            Console.WriteLine($"Years of Service: {YearsOfService}");
            Console.WriteLine($"Monthly Salary: {Salary:C}");
            Console.WriteLine($"Annual Salary: {AnnualSalary:C}");
            Console.WriteLine($"Salary Grade: {SalaryGrade}");
            Console.WriteLine($"Status: {(IsActive ? "Active" : "Inactive")}");
            Console.WriteLine("============================\n");
        }
    }
}