
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
