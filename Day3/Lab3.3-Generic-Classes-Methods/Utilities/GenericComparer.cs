

namespace Lab3._3_Generic_Classes_Methods.Utilities;

public static class GenericComparer
{
    public static void SortInPlace<T>(List<T> list) where T : IComparable<T> => list.Sort();

    public static List<T> SortedCopy<T>(IEnumerable<T> items) where T : IComparable<T>
    {
        var copy = items.ToList();
        copy.Sort();
        return copy;
    }
}
