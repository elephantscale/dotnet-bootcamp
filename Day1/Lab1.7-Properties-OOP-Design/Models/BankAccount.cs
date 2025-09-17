namespace Lab1_7.Models
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly List<Transaction> _transactions;

        // Properties with different access levels
        public string AccountNumber { get; }
        public string AccountHolder { get; }
        public DateTime CreatedDate { get; }

        public decimal Balance
        {
            get => _balance;
            private set => _balance = value;
        }

        // Read-only collection
        public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

        // Computed properties
        public decimal TotalDeposits => _transactions
            .Where(t => t.Type == TransactionType.Deposit)
            .Sum(t => t.Amount);

        public decimal TotalWithdrawals => _transactions
            .Where(t => t.Type == TransactionType.Withdrawal)
            .Sum(t => t.Amount);

        public int TransactionCount => _transactions.Count;
        public Transaction? LastTransaction => _transactions.LastOrDefault();

        public bool IsActive { get; set; } = true;

        public string AccountStatus
        {
            get
            {
                if (!IsActive) return "Closed";
                if (Balance < 0) return "Overdrawn";
                if (Balance < 100) return "Low Balance";
                return "Active";
            }
        }

        public string AccountSummary => $"{AccountNumber} - {AccountHolder} - {Balance:C} ({AccountStatus})";

        // Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number is required");
            if (string.IsNullOrWhiteSpace(accountHolder))
                throw new ArgumentException("Account holder name is required");
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");

            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            CreatedDate = DateTime.Now;
            _transactions = new List<Transaction>();

            if (initialBalance > 0)
            {
                Balance = initialBalance;
                _transactions.Add(new Transaction(TransactionType.Deposit, initialBalance, "Initial deposit"));
            }
        }

        // Methods that modify properties
        public bool Deposit(decimal amount, string description = "Deposit")
        {
            if (amount <= 0) { Console.WriteLine("Deposit amount must be positive"); return false; }
            if (!IsActive) { Console.WriteLine("Cannot deposit to inactive account"); return false; }

            Balance += amount;
            _transactions.Add(new Transaction(TransactionType.Deposit, amount, description));
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public bool Withdraw(decimal amount, string description = "Withdrawal")
        {
            if (amount <= 0) { Console.WriteLine("Withdrawal amount must be positive"); return false; }
            if (!IsActive) { Console.WriteLine("Cannot withdraw from inactive account"); return false; }
            if (amount > Balance) { Console.WriteLine($"Insufficient funds. Available: {Balance:C}"); return false; }

            Balance -= amount;
            _transactions.Add(new Transaction(TransactionType.Withdrawal, amount, description));
            Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public void CloseAccount()
        {
            IsActive = false;
            Console.WriteLine($"Account {AccountNumber} has been closed");
        }
    }

    public enum TransactionType { Deposit, Withdrawal }

    public class Transaction
    {
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Timestamp { get; }

        public Transaction(TransactionType type, decimal amount, string description)
        {
            Type = type;
            Amount = amount;
            Description = description;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            var sign = Type == TransactionType.Deposit ? "+" : "-";
            return $"{Timestamp:yyyy-MM-dd HH:mm} | {Type} | {sign}{Amount:C} | {Description}";
        }
    }
}