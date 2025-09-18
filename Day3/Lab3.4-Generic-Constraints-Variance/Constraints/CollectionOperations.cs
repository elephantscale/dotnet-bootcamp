// namespace Lab3._4_Generic_Constraints_Variance.Constraints;

// // Collection operations with various constraints
// public static class CollectionOperations
// {
//     // ICollection<T> constraint for collection operations
//     public static void AddRange<T, TCollection>(TCollection collection, IEnumerable<T> items) 
//         where TCollection : ICollection<T>
//     {
//         foreach (var item in items)
//         {
//             collection.Add(item);
//         }
//     }

//     public static void RemoveRange<T, TCollection>(TCollection collection, IEnumerable<T> items) 
//         where TCollection : ICollection<T>
//     {
//         foreach (var item in items)
//         {
//             collection.Remove(item);
//         }
//     }

//     public static bool ContainsAll<T, TCollection>(TCollection collection, IEnumerable<T> items) 
//         where TCollection : ICollection<T>
//     {
//         return items.All(collection.Contains);
//     }

//     public static bool ContainsAny<T, TCollection>(TCollection collection, IEnumerable<T> items) 
//         where TCollection : ICollection<T>
//     {
//         return items.Any(collection.Contains);
//     }

//     // IList<T> constraint for indexed operations
//     public static void Swap<T, TList>(TList list, int index1, int index2) 
//         where TList : IList<T>
//     {
//         if (index1 < 0 || index1 >= list.Count)
//             throw new ArgumentOutOfRangeException(nameof(index1));
//         if (index2 < 0 || index2 >= list.Count)
//             throw new ArgumentOutOfRangeException(nameof(index2));

//         (list[index1], list[index2]) = (list[index2], list[index1]);
//     }

//     public static void Reverse<T, TList>(TList list) 
//         where TList : IList<T>
//     {
//         int left = 0;
//         int right = list.Count - 1;

//         while (left < right)
//         {
//             Swap(list, left, right);
//             left++;
//             right--;
//         }
//     }

//     public static void Shuffle<T, TList>(TList list) 
//         where TList : IList<T>
//     {
//         var random = new Random();
//         for (int i = list.Count - 1; i > 0; i--)
//         {
//             int j = random.Next(i + 1);
//             Swap(list, i, j);
//         }
//     }

//     // IDictionary<TKey, TValue> constraint for dictionary operations
//     public static void AddRange<TKey, TValue, TDictionary>(TDictionary dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items) 
//         where TDictionary : IDictionary<TKey, TValue>
//     {
//         foreach (var item in items)
//         {
//             dictionary[item.Key] = item.Value;
//         }
//     }

//     public static TValue GetOrAdd<TKey, TValue, TDictionary>(TDictionary dictionary, TKey key, Func<TKey, TValue> valueFactory) 
//         where TDictionary : IDictionary<TKey, TValue>
//     {
//         if (dictionary.TryGetValue(key, out var existingValue))
//         {
//             return existingValue;
//         }

//         var newValue = valueFactory(key);
//         dictionary[key] = newValue;
//         return newValue;
//     }

//     public static bool TryRemove<TKey, TValue, TDictionary>(TDictionary dictionary, TKey key, out TValue? value) 
//         where TDictionary : IDictionary<TKey, TValue>
//     {
//         if (dictionary.TryGetValue(key, out value))
//         {
//             dictionary.Remove(key);
//             return true;
//         }

//         value = default(TValue);
//         return false;
//     }
// }

// // Generic collection wrapper with multiple constraints
// public class ConstrainedCollection<T> where T : class, IComparable<T>, ICloneable
// {
//     private readonly List<T> _items = new();

//     public int Count => _items.Count;
//     public bool IsEmpty => _items.Count == 0;

//     public void Add(T item)
//     {
//         _items.Add(item);
//     }

//     public void AddRange(IEnumerable<T> items)
//     {
//         _items.AddRange(items);
//     }

//     public bool Remove(T item)
//     {
//         return _items.Remove(item);
//     }

//     public void Clear()
//     {
//         _items.Clear();
//     }

//     public T? Find(Func<T, bool> predicate)
//     {
//         return _items.FirstOrDefault(predicate);
//     }

//     public IEnumerable<T> FindAll(Func<T, bool> predicate)
//     {
//         return _items.Where(predicate);
//     }

//     // IComparable constraint enables sorting
//     public void Sort()
//     {
//         _items.Sort();
//     }

//     public void SortDescending()
//     {
//         _items.Sort((x, y) => y.CompareTo(x));
//     }

//     public IEnumerable<T> GetSorted()
//     {
//         return _items.OrderBy(x => x);
//     }

//     public T GetMin()
//     {
//         if (IsEmpty)
//             throw new InvalidOperationException("Collection is empty");
//         return _items.Min()!;
//     }

//     public T GetMax()
//     {
//         if (IsEmpty)
//             throw new InvalidOperationException("Collection is empty");
//         return _items.Max()!;
//     }

//     // ICloneable constraint enables cloning
//     public ConstrainedCollection<T> Clone()
//     {
//         var cloned = new ConstrainedCollection<T>();
//         foreach (var item in _items)
//         {
//             cloned.Add((T)item.Clone());
//         }
//         return cloned;
//     }

//     public T[] CloneToArray()
//     {
//         return _items.Select(item => (T)item.Clone()).ToArray();
//     }

//     public List<T> CloneToList()
//     {
//         return _items.Select(item => (T)item.Clone()).ToList();
//     }

//     // Class constraint enables null checks
//     public void RemoveNulls()
//     {
//         _items.RemoveAll(item => item == null);
//     }

//     public bool HasNulls()
//     {
//         return _items.Any(item => item == null);
//     }

//     public IEnumerable<T> GetNonNulls()
//     {
//         return _items.Where(item => item != null);
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         return _items.GetEnumerator();
//     }

//     public override string ToString()
//     {
//         return $"ConstrainedCollection<{typeof(T).Name}>[{Count} items]";
//     }
// }

// // Thread-safe collection with constraints
// public class ThreadSafeCollection<T> where T : class, IComparable<T>
// {
//     private readonly List<T> _items = new();
//     private readonly ReaderWriterLockSlim _lock = new();

//     public int Count
//     {
//         get
//         {
//             _lock.EnterReadLock();
//             try
//             {
//                 return _items.Count;
//             }
//             finally
//             {
//                 _lock.ExitReadLock();
//             }
//         }
//     }

//     public void Add(T item)
//     {
//         _lock.EnterWriteLock();
//         try
//         {
//             _items.Add(item);
//         }
//         finally
//         {
//             _lock.ExitWriteLock();
//         }
//     }

//     public void AddRange(IEnumerable<T> items)
//     {
//         _lock.EnterWriteLock();
//         try
//         {
//             _items.AddRange(items);
//         }
//         finally
//         {
//             _lock.ExitWriteLock();
//         }
//     }

//     public bool Remove(T item)
//     {
//         _lock.EnterWriteLock();
//         try
//         {
//             return _items.Remove(item);
//         }
//         finally
//         {
//             _lock.ExitWriteLock();
//         }
//     }

//     public T[] ToArray()
//     {
//         _lock.EnterReadLock();
//         try
//         {
//             return _items.ToArray();
//         }
//         finally
//         {
//             _lock.ExitReadLock();
//         }
//     }

//     public T[] ToSortedArray()
//     {
//         _lock.EnterReadLock();
//         try
//         {
//             var array = _items.ToArray();
//             Array.Sort(array);
//             return array;
//         }
//         finally
//         {
//             _lock.ExitReadLock();
//         }
//     }

//     public T? Find(Func<T, bool> predicate)
//     {
//         _lock.EnterReadLock();
//         try
//         {
//             return _items.FirstOrDefault(predicate);
//         }
//         finally
//         {
//             _lock.ExitReadLock();
//         }
//     }

//     public T[] FindAll(Func<T, bool> predicate)
//     {
//         _lock.EnterReadLock();
//         try
//         {
//             return _items.Where(predicate).ToArray();
//         }
//         finally
//         {
//             _lock.ExitReadLock();
//         }
//     }

//     public void Clear()
//     {
//         _lock.EnterWriteLock();
//         try
//         {
//             _items.Clear();
//         }
//         finally
//         {
//             _lock.ExitWriteLock();
//         }
//     }

//     public void Dispose()
//     {
//         _lock.Dispose();
//     }
// }

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