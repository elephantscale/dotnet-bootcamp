using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3._4_Generic_Constraints_Variance.Constraints
{
    /// <summary>
    /// Operations that require T to be comparable.
    /// </summary>
    public static class ComparableOperations
    {
        /// <summary>
        /// Sorts a List<T> in place (fast path).
        /// </summary>
        public static void SortInPlace<T>(List<T> list) where T : IComparable<T>
            => list.Sort();

        /// <summary>
        /// Sorts any IList<T> in place by copying/sorting/writing back.
        /// </summary>
        public static void SortInPlace<T>(IList<T> list) where T : IComparable<T>
        {
            var tmp = list.ToList();
            tmp.Sort();
            for (int i = 0; i < list.Count; i++)
                list[i] = tmp[i];
        }

        /// <summary>
        /// Returns the smaller of two values.
        /// </summary>
        public static T Min<T>(T a, T b) where T : IComparable<T>
            => a.CompareTo(b) <= 0 ? a : b;

        /// <summary>
        /// Returns the larger of two values.
        /// </summary>
        public static T Max<T>(T a, T b) where T : IComparable<T>
            => a.CompareTo(b) >= 0 ? a : b;

        /// <summary>
        /// Returns a new ascending-sorted list from the source sequence.
        /// </summary>
        public static List<T> Sorted<T>(IEnumerable<T> source) where T : IComparable<T>
            => source.OrderBy(x => x).ToList();
    }
}