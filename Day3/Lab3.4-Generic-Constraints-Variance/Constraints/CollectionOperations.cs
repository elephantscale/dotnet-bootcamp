

namespace Lab3._4_Generic_Constraints_Variance.Constraints;

public static class CollectionOperations
{
    // Any collection that supports Add
    public static void AddRange<T>(ICollection<T> target, IEnumerable<T> items)
    {
        foreach (var item in items) target.Add(item);
    }

    // Read-only view copy
    public static T[] ToArray<T>(IReadOnlyCollection<T> items)
    {
        var arr = new T[items.Count];
        int i = 0;
        foreach (var item in items) arr[i++] = item!;
        return arr;
    }
}
