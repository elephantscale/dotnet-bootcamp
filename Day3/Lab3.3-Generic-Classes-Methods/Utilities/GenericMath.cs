// namespace Lab3._3_Generic_Classes_Methods.Utilities;

// public static class GenericMath
// {
//     public static T Max<T>(T first, T second) where T : IComparable<T>
//     {
//         return first.CompareTo(second) >= 0 ? first : second;
//     }

//     public static T Min<T>(T first, T second) where T : IComparable<T>
//     {
//         return first.CompareTo(second) <= 0 ? first : second;
//     }

//     public static T Max<T>(params T[] values) where T : IComparable<T>
//     {
//         if (values == null || values.Length == 0)
//             throw new ArgumentException("Values cannot be null or empty");

//         T max = values[0];
//         for (int i = 1; i < values.Length; i++)
//         {
//             if (values[i].CompareTo(max) > 0)
//                 max = values[i];
//         }
//         return max;
//     }

//     public static T Min<T>(params T[] values) where T : IComparable<T>
//     {
//         if (values == null || values.Length == 0)
//             throw new ArgumentException("Values cannot be null or empty");

//         T min = values[0];
//         for (int i = 1; i < values.Length; i++)
//         {
//             if (values[i].CompareTo(min) < 0)
//                 min = values[i];
//         }
//         return min;
//     }

//     public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
//     {
//         if (min.CompareTo(max) > 0)
//             throw new ArgumentException("Min value cannot be greater than max value");

//         if (value.CompareTo(min) < 0)
//             return min;
//         if (value.CompareTo(max) > 0)
//             return max;
//         return value;
//     }

//     // Numeric operations using dynamic (for demonstration)
//     public static T Add<T>(T first, T second)
//     {
//         dynamic a = first!;
//         dynamic b = second!;
//         return (T)(a + b);
//     }

//     public static T Subtract<T>(T first, T second)
//     {
//         dynamic a = first!;
//         dynamic b = second!;
//         return (T)(a - b);
//     }

//     public static T Multiply<T>(T first, T second)
//     {
//         dynamic a = first!;
//         dynamic b = second!;
//         return (T)(a * b);
//     }

//     public static T Divide<T>(T first, T second)
//     {
//         dynamic a = first!;
//         dynamic b = second!;
//         return (T)(a / b);
//     }

//     public static double Average<T>(IEnumerable<T> values) where T : IConvertible
//     {
//         if (!values.Any())
//             throw new ArgumentException("Values cannot be empty");

//         double sum = 0;
//         int count = 0;

//         foreach (var value in values)
//         {
//             sum += Convert.ToDouble(value);
//             count++;
//         }

//         return sum / count;
//     }

//     public static T Sum<T>(IEnumerable<T> values)
//     {
//         if (!values.Any())
//             return default(T)!;

//         dynamic sum = values.First()!;
//         foreach (var value in values.Skip(1))
//         {
//             dynamic val = value!;
//             sum += val;
//         }

//         return (T)sum;
//     }

//     public static bool IsInRange<T>(T value, T min, T max) where T : IComparable<T>
//     {
//         return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
//     }

//     public static T Abs<T>(T value) where T : IComparable<T>
//     {
//         dynamic val = value!;
//         return val < 0 ? (T)(-val) : value;
//     }
// }

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