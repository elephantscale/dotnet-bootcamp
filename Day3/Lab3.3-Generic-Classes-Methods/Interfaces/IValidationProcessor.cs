namespace Lab3._3_Generic_Classes_Methods.Interfaces;

/// <summary>
/// A tiny, generic validation processor example placed here
/// to show that generics can live anywhere.
/// </summary>
public sealed class ValidationProcessor<T> : IProcessor<T, bool>
{
    private readonly Func<T, bool> _predicate;
    public ValidationProcessor(Func<T, bool> predicate) => _predicate = predicate;
    public bool Process(T input) => _predicate(input);
}