using System;

namespace Lab2_4.Exceptions
{
    // Validation errors with per-field messages
    public class ValidationException : Exception
    {
        public System.Collections.Generic.Dictionary<string, string[]> Errors { get; init; }
            = new System.Collections.Generic.Dictionary<string, string[]>();

        public ValidationException() : base("Validation failed.") { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, Exception inner) : base(message, inner) { }

        public ValidationException(System.Collections.Generic.Dictionary<string, string[]> errors)
            : base("Validation failed.")
        {
            Errors = errors ?? new();
        }

        public ValidationException(string message, System.Collections.Generic.Dictionary<string, string[]> errors)
            : base(message)
        {
            Errors = errors ?? new();
        }
    }

    // Domain/business layer exception with a code
    public class BusinessLogicException : Exception
    {
        public string ErrorCode { get; }
        public DateTime OccurredAtUtc { get; } = DateTime.UtcNow;

        public BusinessLogicException(string message, string errorCode)
            : base(message) => ErrorCode = errorCode;

        public BusinessLogicException(string message, string errorCode, Exception? inner)
            : base(message, inner) => ErrorCode = errorCode;
    }

    // Banking specific
    public class InsufficientFundsException : BusinessLogicException
    {
        public decimal CurrentBalance { get; }
        public decimal AttemptedAmount { get; }

        public InsufficientFundsException(string message, decimal current, decimal attempted)
            : base(message, "INSUFFICIENT_FUNDS")
        {
            CurrentBalance = current;
            AttemptedAmount = attempted;
        }

        public InsufficientFundsException(string message, decimal current, decimal attempted, Exception? inner)
            : base(message, "INSUFFICIENT_FUNDS", inner)
        {
            CurrentBalance = current;
            AttemptedAmount = attempted;
        }
    }

    // Network errors with endpoint/status
    public class NetworkException : Exception
    {
        public Uri Endpoint { get; }
        public int? StatusCode { get; }

        public NetworkException(string message, Uri endpoint, int? statusCode = null)
            : base(message)
        {
            Endpoint = endpoint;
            StatusCode = statusCode;
        }

        public NetworkException(string message, Uri endpoint, int? statusCode, Exception? inner)
            : base(message, inner)
        {
            Endpoint = endpoint;
            StatusCode = statusCode;
        }
    }

    // File processing errors with context
    public class FileProcessingException : Exception
    {
        public string FilePath { get; }
        public string Operation { get; }

        public FileProcessingException(string message, string filePath)
            : base(message)
        {
            FilePath = filePath;
            Operation = string.Empty;
        }

        public FileProcessingException(string message, string filePath, Exception inner)
            : base(message, inner)
        {
            FilePath = filePath;
            Operation = string.Empty;
        }

        public FileProcessingException(string message, string filePath, string operation, Exception? inner = null)
            : base(message, inner)
        {
            FilePath = filePath;
            Operation = operation;
        }
    }
}