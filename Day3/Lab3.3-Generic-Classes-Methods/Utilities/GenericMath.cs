

namespace Lab3._3_Generic_Classes_Methods.Utilities;

public static class GenericMath
{
    public static T Max<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) >= 0 ? a : b;

    public static T Min<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) <= 0 ? a : b;

    // Generic math using static abstract operators (requires INumber<T>)
    public static T Add<T>(T a, T b) where T : INumber<T> => a + b;
}
