using System;
using System.Collections.Generic;

namespace Lab1_5.Models
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly string _accountNumber;
        private readonly List<string> _transactionHistory;

        public string AccountNumber => _accountNumber;
        public decimal Balance => _balance;
        public string AccountHolder { get; }
        public DateTime CreatedDate { get; }

        public BankAccount(string accountHolder, string accountNumber, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(accountHolder))
                throw new ArgumentException("Account holder name is required");
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number is required");
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");

            AccountHolder = accountHolder;
            _accountNumber = accountNumber;
            _balance = initialBalance;
            CreatedDate = DateTime.Now;
            _transactionHistory = new List<string>();

            if (initialBalance > 0)
                _transactionHistory.Add($"{DateTime.Now}: Initial deposit of {initialBalance:C}");
        }

        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                return false;
            }

            _balance += amount;
            _transactionHistory.Add($"{DateTime.Now}: Deposit of {amount:C}. New balance: {Balance:C}");
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive");
                return false;
            }

            if (amount > _balance)
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }

            _balance -= amount;
            _transactionHistory.Add($"{DateTime.Now}: Withdrawal of {amount:C}. New balance: {Balance:C}");
            Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
            return true;
        }

        public void PrintStatement()
        {
            Console.WriteLine($"\n=== Account Statement ===");
            Console.WriteLine($"Account Holder: {AccountHolder}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Current Balance: {Balance:C}");
            Console.WriteLine($"Account Created: {CreatedDate:yyyy-MM-dd}");
            Console.WriteLine("\nTransaction History:");
            foreach (var t in _transactionHistory)
                Console.WriteLine($"  {t}");
            Console.WriteLine("========================\n");
        }
    }
}