// namespace Lab3._4_Generic_Constraints_Variance.Variance;

// // Covariant interface - T only appears in output positions
// public interface IProducer<out T>
// {
//     T Produce();
//     IEnumerable<T> ProduceMany(int count);
//     bool TryProduce(out T? item);
// }

// // Covariant read-only collection interface
// public interface IReadOnlyRepository<out T>
// {
//     T? GetById(int id);
//     IEnumerable<T> GetAll();
//     IEnumerable<T> Find(Func<T, bool> predicate);
//     int Count { get; }
// }

// // Covariant event source interface
// public interface IEventSource<out T>
// {
//     event Action<T>? EventOccurred;
//     T? LastEvent { get; }
//     IEnumerable<T> GetRecentEvents(int count);
// }

// // Implementations of covariant interfaces
// public class StringProducer : IProducer<string>
// {
//     private readonly Random _random = new();
//     private readonly string[] _words = { "Hello", "World", "Covariance", "Generic", "Interface" };

//     public string Produce()
//     {
//         return _words[_random.Next(_words.Length)];
//     }

//     public IEnumerable<string> ProduceMany(int count)
//     {
//         for (int i = 0; i < count; i++)
//         {
//             yield return Produce();
//         }
//     }

//     public bool TryProduce(out string? item)
//     {
//         item = Produce();
//         return true;
//     }
// }

// public class NumberProducer : IProducer<int>
// {
//     private readonly Random _random = new();

//     public int Produce()
//     {
//         return _random.Next(1, 101);
//     }

//     public IEnumerable<int> ProduceMany(int count)
//     {
//         for (int i = 0; i < count; i++)
//         {
//             yield return Produce();
//         }
//     }

//     public bool TryProduce(out int item)
//     {
//         item = Produce();
//         return true;
//     }
// }

// public class ReadOnlyProductRepository : IReadOnlyRepository<Product>
// {
//     private readonly List<Product> _products;

//     public int Count => _products.Count;

//     public ReadOnlyProductRepository(IEnumerable<Product> products)
//     {
//         _products = products.ToList();
//     }

//     public Product? GetById(int id)
//     {
//         return _products.FirstOrDefault(p => p.Id == id);
//     }

//     public IEnumerable<Product> GetAll()
//     {
//         return _products.AsReadOnly();
//     }

//     public IEnumerable<Product> Find(Func<Product, bool> predicate)
//     {
//         return _products.Where(predicate);
//     }
// }

// public class EventSource<T> : IEventSource<T>
// {
//     private readonly Queue<T> _recentEvents = new();
//     private const int MaxRecentEvents = 10;

//     public event Action<T>? EventOccurred;
//     public T? LastEvent { get; private set; }

//     public void RaiseEvent(T eventData)
//     {
//         LastEvent = eventData;

//         _recentEvents.Enqueue(eventData);
//         if (_recentEvents.Count > MaxRecentEvents)
//         {
//             _recentEvents.Dequeue();
//         }

//         EventOccurred?.Invoke(eventData);
//     }

//     public IEnumerable<T> GetRecentEvents(int count)
//     {
//         return _recentEvents.TakeLast(count);
//     }
// }

// // Demonstration of covariance usage
// public static class CovarianceExamples
// {
//     public static void DemonstrateProducerCovariance()
//     {
//         // String producer can be assigned to object producer (covariance)
//         IProducer<string> stringProducer = new StringProducer();
//         IProducer<object> objectProducer = stringProducer; // Covariant assignment

//         object result = objectProducer.Produce(); // Returns string as object
//         Console.WriteLine($"Produced object: {result} (Type: {result.GetType().Name})");
//     }

//     public static void DemonstrateRepositoryCovariance()
//     {
//         var products = new List<Product>
//         {
//             new Product("Laptop", 999.99m, "Electronics"),
//             new Product("Mouse", 29.99m, "Electronics")
//         };

//         // Product repository can be assigned to object repository (covariance)
//         IReadOnlyRepository<Product> productRepo = new ReadOnlyProductRepository(products);
//         IReadOnlyRepository<object> objectRepo = productRepo; // Covariant assignment

//         var allObjects = objectRepo.GetAll(); // Returns products as objects
//         Console.WriteLine($"Repository contains {allObjects.Count()} objects");
//     }

//     public static void DemonstrateEventSourceCovariance()
//     {
//         // String event source can be assigned to object event source (covariance)
//         var stringEventSource = new EventSource<string>();
//         IEventSource<object> objectEventSource = stringEventSource; // Covariant assignment

//         objectEventSource.EventOccurred += obj => 
//             Console.WriteLine($"Event received: {obj} (Type: {obj.GetType().Name})");

//         stringEventSource.RaiseEvent("Hello, Covariance!");
//     }

//     public static void DemonstrateCollectionCovariance()
//     {
//         // List<string> can be assigned to IEnumerable<object> (covariance)
//         List<string> strings = new() { "Hello", "World", "Covariance" };
//         IEnumerable<object> objects = strings; // Covariant assignment

//         foreach (var obj in objects)
//         {
//             Console.WriteLine($"Object: {obj} (Type: {obj.GetType().Name})");
//         }
//     }

//     public static void DemonstrateFuncCovariance()
//     {
//         // Func<string> can be assigned to Func<object> (covariance in return type)
//         Func<string> stringFunc = () => "Hello from Func";
//         Func<object> objectFunc = stringFunc; // Covariant assignment

//         object result = objectFunc();
//         Console.WriteLine($"Func result: {result} (Type: {result.GetType().Name})");
//     }
// }

// // Product class for demonstration (simplified version)
// public class Product
// {
//     public int Id { get; private set; }
//     public string Name { get; set; }
//     public decimal Price { get; set; }
//     public string Category { get; set; }

//     private static int _nextId = 1;

//     public Product(string name, decimal price, string category)
//     {
//         Id = _nextId++;
//         Name = name;
//         Price = price;
//         Category = category;
//     }

//     public override string ToString()
//     {
//         return $"{Name} (${Price:F2})";
//     }
// }

namespace Lab3._4_Generic_Constraints_Variance.Variance;

// Covariant: can be assigned to a variable expecting a less-derived generic argument
public interface IProducer<out T>
{
    T Produce();
}

public sealed class Producer<T> : IProducer<T>
{
    private readonly T _value;
    public Producer(T value) => _value = value;
    public T Produce() => _value;
}

public static class CovariantDemo
{
    public static (string asString, object asObject) Run()
    {
        IProducer<string> sp = new Producer<string>("Hello, World!");
        IProducer<object> op = sp; // covariance

        return (sp.Produce(), op.Produce());
    }
}