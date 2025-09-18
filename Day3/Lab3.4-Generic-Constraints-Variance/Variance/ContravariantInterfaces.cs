
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
