

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
