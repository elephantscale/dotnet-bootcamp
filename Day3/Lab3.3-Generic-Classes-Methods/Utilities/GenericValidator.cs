// namespace Lab3._3_Generic_Classes_Methods.Utilities;

// public static class GenericValidator
// {
//     public static ValidationResult<T> Validate<T>(T value, params IValidator<T>[] validators)
//     {
//         var errors = new List<string>();

//         foreach (var validator in validators)
//         {
//             if (!validator.IsValid(value))
//             {
//                 errors.Add(validator.GetErrorMessage(value));
//             }
//         }

//         return new ValidationResult<T>(value, errors);
//     }

//     public static bool IsValid<T>(T value, params IValidator<T>[] validators)
//     {
//         return validators.All(validator => validator.IsValid(value));
//     }

//     public static IValidator<T> NotNull<T>() where T : class
//     {
//         return new FuncValidator<T>(
//             value => value != null,
//             value => $"Value cannot be null"
//         );
//     }

//     public static IValidator<T> NotDefault<T>() where T : struct
//     {
//         return new FuncValidator<T>(
//             value => !EqualityComparer<T>.Default.Equals(value, default(T)),
//             value => $"Value cannot be default({typeof(T).Name})"
//         );
//     }

//     public static IValidator<string> NotEmpty()
//     {
//         return new FuncValidator<string>(
//             value => !string.IsNullOrEmpty(value),
//             value => "String cannot be null or empty"
//         );
//     }

//     public static IValidator<string> NotWhiteSpace()
//     {
//         return new FuncValidator<string>(
//             value => !string.IsNullOrWhiteSpace(value),
//             value => "String cannot be null, empty, or whitespace"
//         );
//     }

//     public static IValidator<string> MinLength(int minLength)
//     {
//         return new FuncValidator<string>(
//             value => value?.Length >= minLength,
//             value => $"String must be at least {minLength} characters long"
//         );
//     }

//     public static IValidator<string> MaxLength(int maxLength)
//     {
//         return new FuncValidator<string>(
//             value => value?.Length <= maxLength,
//             value => $"String cannot be longer than {maxLength} characters"
//         );
//     }

//     public static IValidator<T> Range<T>(T min, T max) where T : IComparable<T>
//     {
//         return new FuncValidator<T>(
//             value => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0,
//             value => $"Value must be between {min} and {max}"
//         );
//     }

//     public static IValidator<T> GreaterThan<T>(T threshold) where T : IComparable<T>
//     {
//         return new FuncValidator<T>(
//             value => value.CompareTo(threshold) > 0,
//             value => $"Value must be greater than {threshold}"
//         );
//     }

//     public static IValidator<T> LessThan<T>(T threshold) where T : IComparable<T>
//     {
//         return new FuncValidator<T>(
//             value => value.CompareTo(threshold) < 0,
//             value => $"Value must be less than {threshold}"
//         );
//     }

//     public static IValidator<IEnumerable<T>> NotEmpty<T>()
//     {
//         return new FuncValidator<IEnumerable<T>>(
//             value => value?.Any() == true,
//             value => "Collection cannot be null or empty"
//         );
//     }

//     public static IValidator<IEnumerable<T>> Count<T>(int expectedCount)
//     {
//         return new FuncValidator<IEnumerable<T>>(
//             value => value?.Count() == expectedCount,
//             value => $"Collection must contain exactly {expectedCount} items"
//         );
//     }

//     public static IValidator<IEnumerable<T>> MinCount<T>(int minCount)
//     {
//         return new FuncValidator<IEnumerable<T>>(
//             value => value?.Count() >= minCount,
//             value => $"Collection must contain at least {minCount} items"
//         );
//     }

//     public static IValidator<IEnumerable<T>> MaxCount<T>(int maxCount)
//     {
//         return new FuncValidator<IEnumerable<T>>(
//             value => value?.Count() <= maxCount,
//             value => $"Collection cannot contain more than {maxCount} items"
//         );
//     }
// }

// public interface IValidator<T>
// {
//     bool IsValid(T value);
//     string GetErrorMessage(T value);
// }

// public class FuncValidator<T> : IValidator<T>
// {
//     private readonly Func<T, bool> _validationFunc;
//     private readonly Func<T, string> _errorMessageFunc;

//     public FuncValidator(Func<T, bool> validationFunc, Func<T, string> errorMessageFunc)
//     {
//         _validationFunc = validationFunc ?? throw new ArgumentNullException(nameof(validationFunc));
//         _errorMessageFunc = errorMessageFunc ?? throw new ArgumentNullException(nameof(errorMessageFunc));
//     }

//     public bool IsValid(T value)
//     {
//         try
//         {
//             return _validationFunc(value);
//         }
//         catch
//         {
//             return false;
//         }
//     }

//     public string GetErrorMessage(T value)
//     {
//         return _errorMessageFunc(value);
//     }
// }

// public class ValidationResult<T>
// {
//     public T Value { get; }
//     public IReadOnlyList<string> Errors { get; }
//     public bool IsValid => !Errors.Any();

//     public ValidationResult(T value, IEnumerable<string> errors)
//     {
//         Value = value;
//         Errors = errors.ToList().AsReadOnly();
//     }

//     public void ThrowIfInvalid()
//     {
//         if (!IsValid)
//         {
//             throw new ValidationException($"Validation failed: {string.Join(", ", Errors)}");
//         }
//     }

//     public override string ToString()
//     {
//         return IsValid ? "Valid" : $"Invalid: {string.Join(", ", Errors)}";
//     }
// }

// public class ValidationException : Exception
// {
//     public ValidationException(string message) : base(message) { }
//     public ValidationException(string message, Exception innerException) : base(message, innerException) { }
// }

namespace Lab3._3_Generic_Classes_Methods.Utilities;

public static class GenericValidator
{
    public static bool IsDefault<T>(T value) => EqualityComparer<T>.Default.Equals(value, default!);
    public static bool NotNull<T>(T? value) where T : class => value is not null;
}