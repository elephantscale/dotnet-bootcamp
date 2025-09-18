// namespace Lab3._4_Generic_Constraints_Variance.Variance;

// // Contravariant interface - T only appears in input positions
// public interface IConsumer<in T>
// {
//     void Consume(T item);
//     void ConsumeMany(IEnumerable<T> items);
//     bool TryConsume(T item);
// }

// // Contravariant comparer interface
// public interface IComparer<in T>
// {
//     int Compare(T x, T y);
//     bool Equals(T x, T y);
// }

// // Contravariant validator interface
// public interface IValidator<in T>
// {
//     bool IsValid(T item);
//     IEnumerable<string> GetValidationErrors(T item);
// }

// // Contravariant event handler interface
// public interface IEventHandler<in T>
// {
//     void Handle(T eventData);
//     bool CanHandle(T eventData);
// }

// // Implementations of contravariant interfaces
// public class ObjectConsumer : IConsumer<object>
// {
//     public void Consume(object item)
//     {
//         Console.WriteLine($"Consuming object: {item} (Type: {item?.GetType().Name ?? "null"})");
//     }

//     public void ConsumeMany(IEnumerable<object> items)
//     {
//         foreach (var item in items)
//         {
//             Consume(item);
//         }
//     }

//     public bool TryConsume(object item)
//     {
//         try
//         {
//             Consume(item);
//             return true;
//         }
//         catch
//         {
//             return false;
//         }
//     }
// }

// public class StringConsumer : IConsumer<string>
// {
//     public void Consume(string item)
//     {
//         Console.WriteLine($"Consuming string: '{item}' (Length: {item?.Length ?? 0})");
//     }

//     public void ConsumeMany(IEnumerable<string> items)
//     {
//         foreach (var item in items)
//         {
//             Consume(item);
//         }
//     }

//     public bool TryConsume(string item)
//     {
//         if (item != null)
//         {
//             Consume(item);
//             return true;
//         }
//         return false;
//     }
// }

// public class ObjectComparer : IComparer<object>
// {
//     public int Compare(object x, object y)
//     {
//         if (x == null && y == null) return 0;
//         if (x == null) return -1;
//         if (y == null) return 1;

//         return string.Compare(x.ToString(), y.ToString(), StringComparison.OrdinalIgnoreCase);
//     }

//     public bool Equals(object x, object y)
//     {
//         return Compare(x, y) == 0;
//     }
// }

// public class StringComparer : IComparer<string>
// {
//     public int Compare(string x, string y)
//     {
//         return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
//     }

//     public bool Equals(string x, string y)
//     {
//         return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
//     }
// }

// public class ObjectValidator : IValidator<object>
// {
//     public bool IsValid(object item)
//     {
//         return item != null;
//     }

//     public IEnumerable<string> GetValidationErrors(object item)
//     {
//         if (item == null)
//         {
//             yield return "Object cannot be null";
//         }
//     }
// }

// public class StringValidator : IValidator<string>
// {
//     public bool IsValid(string item)
//     {
//         return !string.IsNullOrWhiteSpace(item);
//     }

//     public IEnumerable<string> GetValidationErrors(string item)
//     {
//         if (string.IsNullOrEmpty(item))
//         {
//             yield return "String cannot be null or empty";
//         }
//         else if (string.IsNullOrWhiteSpace(item))
//         {
//             yield return "String cannot be whitespace only";
//         }
//     }
// }

// public class ObjectEventHandler : IEventHandler<object>
// {
//     public void Handle(object eventData)
//     {
//         Console.WriteLine($"Handling object event: {eventData} (Type: {eventData?.GetType().Name ?? "null"})");
//     }

//     public bool CanHandle(object eventData)
//     {
//         return eventData != null;
//     }
// }

// public class StringEventHandler : IEventHandler<string>
// {
//     public void Handle(string eventData)
//     {
//         Console.WriteLine($"Handling string event: '{eventData}' (Length: {eventData?.Length ?? 0})");
//     }

//     public bool CanHandle(string eventData)
//     {
//         return !string.IsNullOrEmpty(eventData);
//     }
// }

// // Demonstration of contravariance usage
// public static class ContravarianceExamples
// {
//     public static void DemonstrateConsumerContravariance()
//     {
//         // Object consumer can be assigned to string consumer (contravariance)
//         IConsumer<object> objectConsumer = new ObjectConsumer();
//         IConsumer<string> stringConsumer = objectConsumer; // Contravariant assignment

//         stringConsumer.Consume("Hello, Contravariance!"); // Passes string to object consumer
//     }

//     public static void DemonstrateComparerContravariance()
//     {
//         // Object comparer can be assigned to string comparer (contravariance)
//         IComparer<object> objectComparer = new ObjectComparer();
//         IComparer<string> stringComparer = objectComparer; // Contravariant assignment

//         int result = stringComparer.Compare("Apple", "Banana");
//         Console.WriteLine($"String comparison result: {result}");
//     }

//     public static void DemonstrateValidatorContravariance()
//     {
//         // Object validator can be assigned to string validator (contravariance)
//         IValidator<object> objectValidator = new ObjectValidator();
//         IValidator<string> stringValidator = objectValidator; // Contravariant assignment

//         bool isValid = stringValidator.IsValid("Test String");
//         Console.WriteLine($"String validation result: {isValid}");
//     }

//     public static void DemonstrateEventHandlerContravariance()
//     {
//         // Object event handler can be assigned to string event handler (contravariance)
//         IEventHandler<object> objectHandler = new ObjectEventHandler();
//         IEventHandler<string> stringHandler = objectHandler; // Contravariant assignment

//         stringHandler.Handle("Event Data"); // Passes string to object handler
//     }

//     public static void DemonstrateActionContravariance()
//     {
//         // Action<object> can be assigned to Action<string> (contravariance in parameter)
//         Action<object> objectAction = obj => Console.WriteLine($"Action on object: {obj}");
//         Action<string> stringAction = objectAction; // Contravariant assignment

//         stringAction("Hello from Action!");
//     }

//     public static void DemonstratePredicateContravariance()
//     {
//         // Predicate<object> can be assigned to Predicate<string> (contravariance)
//         Predicate<object> objectPredicate = obj => obj != null;
//         Predicate<string> stringPredicate = objectPredicate; // Contravariant assignment

//         bool result = stringPredicate("Test");
//         Console.WriteLine($"Predicate result: {result}");
//     }
// }

// // Generic processor with contravariant input interface
// public interface IProcessor<in TInput, out TOutput>
// {
//     TOutput Process(TInput input);
//     IEnumerable<TOutput> ProcessMany(IEnumerable<TInput> inputs);
// }

// public class StringToLengthProcessor : IProcessor<string, int>
// {
//     public int Process(string input)
//     {
//         return input?.Length ?? 0;
//     }

//     public IEnumerable<int> ProcessMany(IEnumerable<string> inputs)
//     {
//         return inputs.Select(Process);
//     }
// }

// public class ObjectToStringProcessor : IProcessor<object, string>
// {
//     public string Process(object input)
//     {
//         return input?.ToString() ?? "null";
//     }

//     public IEnumerable<string> ProcessMany(IEnumerable<object> inputs)
//     {
//         return inputs.Select(Process);
//     }
// }

// // Demonstration of mixed variance
// public static class MixedVarianceExamples
// {
//     public static void DemonstrateProcessorVariance()
//     {
//         // Object-to-string processor can be used as string-to-string processor
//         IProcessor<object, string> objectProcessor = new ObjectToStringProcessor();
//         IProcessor<string, object> stringProcessor = objectProcessor; // Mixed variance

//         object result = stringProcessor.Process("Hello");
//         Console.WriteLine($"Processed result: {result}");
//     }

//     public static void DemonstrateFuncActionVariance()
//     {
//         // Func with contravariant parameter and covariant return
//         Func<object, string> objectToString = obj => obj?.ToString() ?? "null";
//         Func<string, object> stringToObject = objectToString; // Mixed variance

//         object result = stringToObject("Test");
//         Console.WriteLine($"Func result: {result}");
//     }
// }
namespace Lab3._4_Generic_Constraints_Variance.Variance;

// Contravariant: can be assigned to a variable expecting a more-derived argument
public interface IConsumer<in T>
{
    void Consume(T item);
}

public sealed class Consumer<T> : IConsumer<T>
{
    public List<string> Log { get; } = new();
    public void Consume(T item) => Log.Add($"Consumed: {item}");
}

public static class ContravariantDemo
{
    public static (int before, int after, List<string> log) Run()
    {
        IConsumer<object> objectConsumer = new Consumer<object>();
        // assign to consumer of string (contravariance)
        IConsumer<string> stringConsumer = objectConsumer;

        var c = (Consumer<object>)objectConsumer;
        int before = c.Log.Count;
        stringConsumer.Consume("Test String");
        int after = c.Log.Count;

        return (before, after, c.Log);
    }
}