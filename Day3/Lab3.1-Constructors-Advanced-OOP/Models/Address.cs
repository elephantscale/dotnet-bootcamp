namespace Lab3_1.Models
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string ZipCode { get; }
        public string Country { get; }

        public Address(string street, string city, string state, string zipCode, string country = "USA")
        {
            Street = string.IsNullOrWhiteSpace(street) ? throw new ArgumentException("Street required") : street.Trim();
            City = string.IsNullOrWhiteSpace(city) ? throw new ArgumentException("City required") : city.Trim();
            State = string.IsNullOrWhiteSpace(state) ? throw new ArgumentException("State required") : state.Trim();
            ZipCode = ValidateZip(zipCode);
            Country = string.IsNullOrWhiteSpace(country) ? "USA" : country.Trim();
        }

        // Copy constructor
        public Address(Address other)
            : this(other.Street, other.City, other.State, other.ZipCode, other.Country) { }

        private static string ValidateZip(string zip)
        {
            if (string.IsNullOrWhiteSpace(zip)) throw new ArgumentException("Zip required");
            var cleaned = new string(zip.Where(char.IsDigit).ToArray());
            if (cleaned.Length is not (5 or 9))
                throw new ArgumentException("Zip must be 5 or 9 digits");
            return cleaned;
        }

        public override string ToString() => $"{Street}, {City}, {State} {ZipCode}, {Country}";
    }
}