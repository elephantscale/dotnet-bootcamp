namespace Lab2_1
{
    public static class DateTimeOperations
    {
        public static void DemonstrateDateTimeBasics()
        {
            Console.WriteLine("=== DateTime Basics Demo ===\n");

            // Current date and time
            DateTime now = DateTime.Now;
            DateTime utcNow = DateTime.UtcNow;
            DateTime today = DateTime.Today;

            Console.WriteLine($"Current Local Time: {now}");
            Console.WriteLine($"Current UTC Time: {utcNow}");
            Console.WriteLine($"Today (Date only): {today}");

            // Creating specific dates
            DateTime specificDate = new DateTime(2024, 12, 25, 10, 30, 0);
            DateTime parsedDate = DateTime.Parse("2024-06-15 14:30:00");

            Console.WriteLine($"Christmas 2024: {specificDate}");
            Console.WriteLine($"Parsed Date: {parsedDate}");

            // Date arithmetic
            DateTime futureDate = now.AddDays(30);
            DateTime pastDate = now.AddMonths(-6);
            TimeSpan difference = futureDate - now;

            Console.WriteLine($"30 days from now: {futureDate}");
            Console.WriteLine($"6 months ago: {pastDate}");
            Console.WriteLine($"Difference: {difference.Days} days");
        }

        public static void DemonstrateDateTimeFormatting()
        {
            Console.WriteLine("\n=== DateTime Formatting Demo ===");

            DateTime date = new DateTime(2024, 3, 15, 14, 30, 45);

            // Standard format strings
            Console.WriteLine($"Short Date: {date:d}");
            Console.WriteLine($"Long Date: {date:D}");
            Console.WriteLine($"Short Time: {date:t}");
            Console.WriteLine($"Long Time: {date:T}");
            Console.WriteLine($"Full DateTime: {date:F}");
            Console.WriteLine($"ISO 8601: {date:yyyy-MM-ddTHH:mm:ss}");

            // Custom format strings
            Console.WriteLine($"Custom 1: {date:MMM dd, yyyy}");
            Console.WriteLine($"Custom 2: {date:dddd, MMMM dd}");
            Console.WriteLine($"Custom 3: {date:HH:mm:ss}");
            Console.WriteLine($"Custom 4: {date:yyyy/MM/dd hh:mm tt}");
        }

        public static void DemonstrateTimeSpan()
        {
            Console.WriteLine("\n=== TimeSpan Demo ===");

            // Creating TimeSpan objects
            TimeSpan span1 = new TimeSpan(2, 30, 45); // 2 hours, 30 minutes, 45 seconds
            TimeSpan span2 = TimeSpan.FromDays(7);
            TimeSpan span3 = TimeSpan.FromMinutes(90);

            Console.WriteLine($"Span 1: {span1}");
            Console.WriteLine($"Span 2: {span2}");
            Console.WriteLine($"Span 3: {span3}");

            // TimeSpan arithmetic
            TimeSpan total = span1 + span3;
            Console.WriteLine($"Span1 + Span3: {total}");

            // TimeSpan properties
            Console.WriteLine($"Total hours in span3: {span3.TotalHours}");
            Console.WriteLine($"Days in span2: {span2.Days}");
        }

        public static void DemonstrateAgeCalculation()
        {
            Console.WriteLine("\n=== Age Calculation Demo ===");

            DateTime[] birthDates = {
                new DateTime(1990, 5, 15),
                new DateTime(2000, 12, 3),
                new DateTime(1985, 8, 22),
                new DateTime(2010, 1, 10)
            };

            foreach (var birthDate in birthDates)
            {
                int age = CalculateAge(birthDate);
                Console.WriteLine($"Born: {birthDate:yyyy-MM-dd}, Age: {age} years");
            }
        }

        private static int CalculateAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;

            // Adjust if birthday hasn't occurred this year
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}