namespace Lab3_1.Models
{
    public enum AccountType { Checking, Savings, Premium, Business }

    public class BankAccount
    {
        // Static data / initialization
        private static int _seq;
        public static IReadOnlyDictionary<AccountType, decimal> DefaultRates { get; }

        static BankAccount()
        {
            DefaultRates = new Dictionary<AccountType, decimal>
            {
                [AccountType.Checking] = 0.010m,
                [AccountType.Savings] = 0.025m,
                [AccountType.Premium] = 0.035m,
                [AccountType.Business] = 0.020m
            };
            Console.WriteLine("BankAccount static constructor - initializing banking system");
        }

        // Properties
        public string AccountNumber { get; }
        public string Holder { get; }
        public AccountType Type { get; }
        public decimal InterestRate { get; }
        public decimal Balance { get; private set; }
        public DateTime Created { get; } = DateTime.Now;

        // Constructors
        public BankAccount(string holder, AccountType type, decimal initialBalance = 0, decimal? rate = null)
        {
            if (string.IsNullOrWhiteSpace(holder)) throw new ArgumentException("Holder required");
            if (initialBalance < 0) throw new ArgumentException("Initial balance cannot be negative");

            Holder = holder.Trim();
            Type = type;
            InterestRate = rate ?? DefaultRates[type];
            Balance = initialBalance;
            AccountNumber = $"ACCT-{Interlocked.Increment(ref _seq):D6}";
        }

        // Copy constructor
        public BankAccount(BankAccount other)
            : this(other.Holder, other.Type, other.Balance, other.InterestRate) { }

        // Factory methods
        public static BankAccount CreateChecking(string holder, decimal balance) =>
            new(holder, AccountType.Checking, balance);

        public static BankAccount CreateSavings(string holder, decimal balance)
        {
            if (balance < 100m) throw new ArgumentException("Savings requires minimum $100");
            return new(holder, AccountType.Savings, balance);
        }

        public static BankAccount CreatePremium(string holder, decimal balance)
        {
            if (balance < 1000m) throw new ArgumentException("Premium requires minimum $1000");
            return new(holder, AccountType.Premium, balance);
        }

        public static BankAccount CreateBusiness(string holder, decimal balance) =>
            new(holder, AccountType.Business, balance);

        // Simple ops
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit must be positive");
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;
            if (amount > Balance) return false;
            Balance -= amount;
            return true;
        }

        // Builder pattern
        public static Builder Configure() => new();

        public class Builder
        {
            private string? _holder;
            private AccountType _type = AccountType.Checking;
            private decimal _initial;
            private decimal? _customRate;

            public Builder WithHolder(string name) { _holder = name; return this; }
            public Builder WithInitialBalance(decimal amount) { _initial = amount; return this; }
            public Builder As(AccountType type) { _type = type; return this; }
            public Builder WithCustomRate(decimal rate) { _customRate = rate; return this; }

            public BankAccount Build()
            {
                if (string.IsNullOrWhiteSpace(_holder)) throw new InvalidOperationException("Holder is required");
                // Validate by account type
                if (_type == AccountType.Savings && _initial < 100m)
                    throw new InvalidOperationException("Savings requires minimum $100");
                if (_type == AccountType.Premium && _initial < 1000m)
                    throw new InvalidOperationException("Premium requires minimum $1000");

                return new BankAccount(_holder!, _type, _initial, _customRate);
            }
        }

        public override string ToString() =>
            $"{AccountNumber} | {Holder} | {Type} | Balance: {Balance:C} | Rate: {InterestRate:P2}";

        // Utility
        public static void PrintAccountTypeInfo()
        {
            Console.WriteLine("🏦 Account Type Information:");
            Console.WriteLine("==================================================");
            foreach (var kv in DefaultRates)
            {
                Console.WriteLine($"{kv.Key,-11}: {kv.Value:P2} annual interest rate");
            }
            Console.WriteLine();
        }
    }
}