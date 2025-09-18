// using System.Numerics;

// namespace Lab3._4_Generic_Constraints_Variance.Constraints;

// // Numeric operations with constraints
// public static class NumericOperations
// {
//     // Using INumber<T> constraint (available in .NET 7+)
//     public static T Add<T>(T left, T right) where T : INumber<T>
//     {
//         return left + right;
//     }

//     public static T Subtract<T>(T left, T right) where T : INumber<T>
//     {
//         return left - right;
//     }

//     public static T Multiply<T>(T left, T right) where T : INumber<T>
//     {
//         return left * right;
//     }

//     public static T Divide<T>(T left, T right) where T : INumber<T>
//     {
//         return left / right;
//     }

//     public static T Abs<T>(T value) where T : INumber<T>
//     {
//         return T.Abs(value);
//     }

//     public static T Max<T>(T left, T right) where T : INumber<T>
//     {
//         return T.Max(left, right);
//     }

//     public static T Min<T>(T left, T right) where T : INumber<T>
//     {
//         return T.Min(left, right);
//     }

//     // Sum operation for collections
//     public static T Sum<T>(IEnumerable<T> values) where T : INumber<T>
//     {
//         T sum = T.Zero;
//         foreach (var value in values)
//         {
//             sum += value;
//         }
//         return sum;
//     }

//     // Average operation
//     public static T Average<T>(IEnumerable<T> values) where T : INumber<T>
//     {
//         var list = values.ToList();
//         if (!list.Any())
//             throw new InvalidOperationException("Cannot calculate average of empty collection");

//         var sum = Sum(list);
//         var count = T.CreateChecked(list.Count);
//         return sum / count;
//     }

//     // Range check
//     public static bool IsInRange<T>(T value, T min, T max) where T : INumber<T>
//     {
//         return value >= min && value <= max;
//     }

//     // Clamp operation
//     public static T Clamp<T>(T value, T min, T max) where T : INumber<T>
//     {
//         if (min > max)
//             throw new ArgumentException("Min cannot be greater than max");

//         return T.Max(min, T.Min(max, value));
//     }
// }

// // Calculator class with struct constraint
// public class Calculator<T> where T : struct, INumber<T>
// {
//     public T Add(T a, T b) => a + b;
//     public T Subtract(T a, T b) => a - b;
//     public T Multiply(T a, T b) => a * b;
//     public T Divide(T a, T b) => a / b;

//     public T Power(T baseValue, int exponent)
//     {
//         if (exponent == 0) return T.One;
//         if (exponent == 1) return baseValue;

//         T result = T.One;
//         T currentBase = baseValue;
//         int currentExponent = Math.Abs(exponent);

//         while (currentExponent > 0)
//         {
//             if (currentExponent % 2 == 1)
//                 result *= currentBase;
//             currentBase *= currentBase;
//             currentExponent /= 2;
//         }

//         return exponent < 0 ? T.One / result : result;
//     }

//     public T Factorial(T n) where T : IBinaryInteger<T>
//     {
//         if (n < T.Zero)
//             throw new ArgumentException("Factorial is not defined for negative numbers");

//         T result = T.One;
//         for (T i = T.One; i <= n; i++)
//         {
//             result *= i;
//         }
//         return result;
//     }
// }

// // Statistics calculator with floating point constraint
// public class StatisticsCalculator<T> where T : struct, IFloatingPoint<T>
// {
//     public T Mean(IEnumerable<T> values)
//     {
//         var list = values.ToList();
//         if (!list.Any())
//             throw new InvalidOperationException("Cannot calculate mean of empty collection");

//         return NumericOperations.Sum(list) / T.CreateChecked(list.Count);
//     }

//     public T Variance(IEnumerable<T> values)
//     {
//         var list = values.ToList();
//         if (list.Count < 2)
//             throw new InvalidOperationException("Variance requires at least 2 values");

//         var mean = Mean(list);
//         var sumOfSquaredDifferences = list.Sum(x => (x - mean) * (x - mean));
//         return sumOfSquaredDifferences / T.CreateChecked(list.Count - 1);
//     }

//     public T StandardDeviation(IEnumerable<T> values)
//     {
//         return T.Sqrt(Variance(values));
//     }

//     public T Median(IEnumerable<T> values)
//     {
//         var sorted = values.OrderBy(x => x).ToList();
//         if (!sorted.Any())
//             throw new InvalidOperationException("Cannot calculate median of empty collection");

//         int count = sorted.Count;
//         if (count % 2 == 0)
//         {
//             var mid1 = sorted[count / 2 - 1];
//             var mid2 = sorted[count / 2];
//             return (mid1 + mid2) / T.CreateChecked(2);
//         }
//         else
//         {
//             return sorted[count / 2];
//         }
//     }
// }

using System.Numerics;

namespace Lab3._4_Generic_Constraints_Variance.Constraints;

public static class NumericOperations
{
    // Works for all numeric types thanks to INumber<T>
    public static T Add<T>(T a, T b) where T : INumber<T> => a + b;
    public static T Multiply<T>(T a, T b) where T : INumber<T> => a * b;

    public static T Sum<T>(IEnumerable<T> values) where T : INumber<T>
    {
        var total = T.Zero;
        foreach (var v in values) total += v;
        return total;
    }
}