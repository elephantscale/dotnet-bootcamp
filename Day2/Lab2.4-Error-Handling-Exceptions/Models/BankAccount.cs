using System;
using System.Collections.Generic;
using Lab2_4.Exceptions;

namespace Lab2_4.Models
{
    public class BankAccount
    {
        private readonly List<string> _transactions = new();

        public string AccountNumber { get; }
        public string AccountHolder { get; }
        public decimal Balance { get; private set; }

        public IReadOnlyList<string> TransactionHistory => _transactions.AsReadOnly();

        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0m)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ValidationException("Invalid account number")
                {
                    Errors = new Dictionary<string, string[]>
                    {
                        ["AccountNumber"] = new[] { "Account number is required." }
                    }
                };
            }

            if (string.IsNullOrWhiteSpace(accountHolder))
            {
                throw new ValidationException("Invalid account holder")
                {
                    Errors = new Dictionary<string, string[]>
                    {
                        ["AccountHolder"] = new[] { "Account holder is required." }
                    }
                };
            }

            if (initialBalance < 0)
            {
                throw new ValidationException("Initial balance cannot be negative.")
                {
                    Errors = new Dictionary<string, string[]>
                    {
                        ["InitialBalance"] = new[] { "Must be >= 0." }
                    }
                };
            }

            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;

            if (initialBalance > 0)
                _transactions.Add($"{DateTime.Now}: Opening deposit {initialBalance:C}");
        }

        public void Deposit(decimal amount, string note = "Deposit")
        {
            if (amount <= 0)
            {
                throw new ValidationException("Deposit amount must be positive.")
                {
                    Errors = new Dictionary<string, string[]>
                    {
                        ["Amount"] = new[] { "Must be > 0." }
                    }
                };
            }

            Balance += amount;
            _transactions.Add($"{DateTime.Now}: {note} {amount:C}, balance {Balance:C}");
        }

        public void Withdraw(decimal amount, string note = "Withdrawal")
        {
            if (amount <= 0)
            {
                throw new ValidationException("Withdrawal amount must be positive.")
                {
                    Errors = new Dictionary<string, string[]>
                    {
                        ["Amount"] = new[] { "Must be > 0." }
                    }
                };
            }

            if (amount > Balance)
                throw new InsufficientFundsException("Insufficient funds.", Balance, amount);

            Balance -= amount;
            _transactions.Add($"{DateTime.Now}: {note} {amount:C}, balance {Balance:C}");
        }

        public void TransferTo(BankAccount target, decimal amount)
        {
            try
            {
                Withdraw(amount, $"Transfer to {target.AccountNumber}");
                target.Deposit(amount, $"Transfer from {AccountNumber}");
            }
            catch (Exception ex)
            {
                // Order is (message, errorCode, inner)
                throw new BusinessLogicException("Transfer failed.", "TRANSFER_FAILED", ex);
            }
        }
    }
}