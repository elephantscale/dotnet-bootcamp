// namespace Lab3._3_Generic_Classes_Methods.Utilities;

// public static class GenericComparer
// {
//     public static IComparer<T> Create<T>(Func<T, T, int> compareFunc)
//     {
//         return new FuncComparer<T>(compareFunc);
//     }

//     public static IComparer<T> CreateDescending<T>() where T : IComparable<T>
//     {
//         return new DescendingComparer<T>();
//     }

//     public static IComparer<T> CreateByProperty<T, TProperty>(Func<T, TProperty> propertySelector) 
//         where TProperty : IComparable<TProperty>
//     {
//         return new PropertyComparer<T, TProperty>(propertySelector);
//     }

//     public static IComparer<T> CreateByPropertyDescending<T, TProperty>(Func<T, TProperty> propertySelector) 
//         where TProperty : IComparable<TProperty>
//     {
//         return new PropertyComparer<T, TProperty>(propertySelector, true);
//     }

//     public static IComparer<T> Chain<T>(params IComparer<T>[] comparers)
//     {
//         return new ChainedComparer<T>(comparers);
//     }

//     public static void Sort<T>(IList<T> list, IComparer<T>? comparer = null)
//     {
//         if (list is List<T> genericList)
//         {
//             genericList.Sort(comparer);
//         }
//         else
//         {
//             var items = list.ToArray();
//             Array.Sort(items, comparer);
//             list.Clear();
//             foreach (var item in items)
//             {
//                 list.Add(item);
//             }
//         }
//     }

//     public static T[] Sort<T>(T[] array, IComparer<T>? comparer = null)
//     {
//         var result = new T[array.Length];
//         Array.Copy(array, result, array.Length);
//         Array.Sort(result, comparer);
//         return result;
//     }

//     public static IEnumerable<T> Sort<T>(IEnumerable<T> source, IComparer<T>? comparer = null)
//     {
//         return source.OrderBy(x => x, comparer);
//     }
// }

// public class FuncComparer<T> : IComparer<T>
// {
//     private readonly Func<T, T, int> _compareFunc;

//     public FuncComparer(Func<T, T, int> compareFunc)
//     {
//         _compareFunc = compareFunc ?? throw new ArgumentNullException(nameof(compareFunc));
//     }

//     public int Compare(T? x, T? y)
//     {
//         if (x == null && y == null) return 0;
//         if (x == null) return -1;
//         if (y == null) return 1;

//         return _compareFunc(x, y);
//     }
// }

// public class DescendingComparer<T> : IComparer<T> where T : IComparable<T>
// {
//     public int Compare(T? x, T? y)
//     {
//         if (x == null && y == null) return 0;
//         if (x == null) return 1;
//         if (y == null) return -1;

//         return y.CompareTo(x); // Reversed comparison
//     }
// }

// public class PropertyComparer<T, TProperty> : IComparer<T> where TProperty : IComparable<TProperty>
// {
//     private readonly Func<T, TProperty> _propertySelector;
//     private readonly bool _descending;

//     public PropertyComparer(Func<T, TProperty> propertySelector, bool descending = false)
//     {
//         _propertySelector = propertySelector ?? throw new ArgumentNullException(nameof(propertySelector));
//         _descending = descending;
//     }

//     public int Compare(T? x, T? y)
//     {
//         if (x == null && y == null) return 0;
//         if (x == null) return -1;
//         if (y == null) return 1;

//         var propX = _propertySelector(x);
//         var propY = _propertySelector(y);

//         int result = propX.CompareTo(propY);
//         return _descending ? -result : result;
//     }
// }

// public class ChainedComparer<T> : IComparer<T>
// {
//     private readonly IComparer<T>[] _comparers;

//     public ChainedComparer(params IComparer<T>[] comparers)
//     {
//         _comparers = comparers ?? throw new ArgumentNullException(nameof(comparers));
//     }

//     public int Compare(T? x, T? y)
//     {
//         foreach (var comparer in _comparers)
//         {
//             int result = comparer.Compare(x, y);
//             if (result != 0)
//                 return result;
//         }
//         return 0;
//     }
// }

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