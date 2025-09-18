// namespace Lab3._3_Generic_Classes_Methods.Collections;

// public class GenericDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TKey : notnull
// {
//     private struct Entry
//     {
//         public TKey Key;
//         public TValue Value;
//         public int HashCode;
//         public int Next;
//     }

//     private Entry[] _entries;
//     private int[] _buckets;
//     private int _count;
//     private int _freeList;
//     private int _freeCount;
//     private const int DefaultCapacity = 4;

//     public int Count => _count - _freeCount;
//     public bool IsEmpty => Count == 0;

//     public IEnumerable<TKey> Keys
//     {
//         get
//         {
//             for (int i = 0; i < _count; i++)
//             {
//                 if (_entries[i].HashCode >= 0)
//                     yield return _entries[i].Key;
//             }
//         }
//     }

//     public IEnumerable<TValue> Values
//     {
//         get
//         {
//             for (int i = 0; i < _count; i++)
//             {
//                 if (_entries[i].HashCode >= 0)
//                     yield return _entries[i].Value;
//             }
//         }
//     }

//     public GenericDictionary() : this(DefaultCapacity)
//     {
//     }

//     public GenericDictionary(int capacity)
//     {
//         if (capacity < 0)
//             throw new ArgumentOutOfRangeException(nameof(capacity));

//         Initialize(capacity);
//     }

//     public GenericDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : this()
//     {
//         foreach (var kvp in collection)
//         {
//             Add(kvp.Key, kvp.Value);
//         }
//     }

//     public TValue this[TKey key]
//     {
//         get
//         {
//             int index = FindEntry(key);
//             if (index >= 0)
//                 return _entries[index].Value;
//             throw new KeyNotFoundException($"Key '{key}' not found");
//         }
//         set
//         {
//             Insert(key, value, false);
//         }
//     }

//     public void Add(TKey key, TValue value)
//     {
//         Insert(key, value, true);
//     }

//     public bool TryAdd(TKey key, TValue value)
//     {
//         try
//         {
//             Add(key, value);
//             return true;
//         }
//         catch (ArgumentException)
//         {
//             return false;
//         }
//     }

//     public bool Remove(TKey key)
//     {
//         if (key == null)
//             throw new ArgumentNullException(nameof(key));

//         int hashCode = key.GetHashCode() & 0x7FFFFFFF;
//         int bucket = hashCode % _buckets.Length;
//         int last = -1;

//         for (int i = _buckets[bucket]; i >= 0; last = i, i = _entries[i].Next)
//         {
//             if (_entries[i].HashCode == hashCode && EqualityComparer<TKey>.Default.Equals(_entries[i].Key, key))
//             {
//                 if (last < 0)
//                     _buckets[bucket] = _entries[i].Next;
//                 else
//                     _entries[last].Next = _entries[i].Next;

//                 _entries[i].HashCode = -1;
//                 _entries[i].Next = _freeList;
//                 _entries[i].Key = default(TKey)!;
//                 _entries[i].Value = default(TValue)!;
//                 _freeList = i;
//                 _freeCount++;
//                 return true;
//             }
//         }
//         return false;
//     }

//     public bool ContainsKey(TKey key)
//     {
//         return FindEntry(key) >= 0;
//     }

//     public bool ContainsValue(TValue value)
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             if (_entries[i].HashCode >= 0 && EqualityComparer<TValue>.Default.Equals(_entries[i].Value, value))
//                 return true;
//         }
//         return false;
//     }

//     public bool TryGetValue(TKey key, out TValue? value)
//     {
//         int index = FindEntry(key);
//         if (index >= 0)
//         {
//             value = _entries[index].Value;
//             return true;
//         }
//         value = default(TValue);
//         return false;
//     }

//     public void Clear()
//     {
//         if (_count > 0)
//         {
//             Array.Clear(_buckets, 0, _buckets.Length);
//             Array.Clear(_entries, 0, _count);
//             _freeList = -1;
//             _count = 0;
//             _freeCount = 0;
//         }
//     }

//     private void Initialize(int capacity)
//     {
//         int size = GetPrime(capacity);
//         _buckets = new int[size];
//         for (int i = 0; i < _buckets.Length; i++)
//             _buckets[i] = -1;
//         _entries = new Entry[size];
//         _freeList = -1;
//     }

//     private void Insert(TKey key, TValue value, bool add)
//     {
//         if (key == null)
//             throw new ArgumentNullException(nameof(key));

//         int hashCode = key.GetHashCode() & 0x7FFFFFFF;
//         int targetBucket = hashCode % _buckets.Length;

//         for (int i = _buckets[targetBucket]; i >= 0; i = _entries[i].Next)
//         {
//             if (_entries[i].HashCode == hashCode && EqualityComparer<TKey>.Default.Equals(_entries[i].Key, key))
//             {
//                 if (add)
//                     throw new ArgumentException($"Key '{key}' already exists");
//                 _entries[i].Value = value;
//                 return;
//             }
//         }

//         int index;
//         if (_freeCount > 0)
//         {
//             index = _freeList;
//             _freeList = _entries[index].Next;
//             _freeCount--;
//         }
//         else
//         {
//             if (_count == _entries.Length)
//             {
//                 Resize();
//                 targetBucket = hashCode % _buckets.Length;
//             }
//             index = _count;
//             _count++;
//         }

//         _entries[index].HashCode = hashCode;
//         _entries[index].Next = _buckets[targetBucket];
//         _entries[index].Key = key;
//         _entries[index].Value = value;
//         _buckets[targetBucket] = index;
//     }

//     private void Resize()
//     {
//         int newSize = GetPrime(_count * 2);
//         var newBuckets = new int[newSize];
//         for (int i = 0; i < newBuckets.Length; i++)
//             newBuckets[i] = -1;

//         var newEntries = new Entry[newSize];
//         Array.Copy(_entries, 0, newEntries, 0, _count);

//         for (int i = 0; i < _count; i++)
//         {
//             if (newEntries[i].HashCode >= 0)
//             {
//                 int bucket = newEntries[i].HashCode % newSize;
//                 newEntries[i].Next = newBuckets[bucket];
//                 newBuckets[bucket] = i;
//             }
//         }

//         _buckets = newBuckets;
//         _entries = newEntries;
//     }

//     private int FindEntry(TKey key)
//     {
//         if (key == null)
//             throw new ArgumentNullException(nameof(key));

//         int hashCode = key.GetHashCode() & 0x7FFFFFFF;
//         for (int i = _buckets[hashCode % _buckets.Length]; i >= 0; i = _entries[i].Next)
//         {
//             if (_entries[i].HashCode == hashCode && EqualityComparer<TKey>.Default.Equals(_entries[i].Key, key))
//                 return i;
//         }
//         return -1;
//     }

//     private static int GetPrime(int min)
//     {
//         int[] primes = { 3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437, 187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263, 1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369 };

//         for (int i = 0; i < primes.Length; i++)
//         {
//             if (primes[i] >= min)
//                 return primes[i];
//         }

//         // Fallback for very large sizes
//         for (int i = min | 1; i < int.MaxValue; i += 2)
//         {
//             if (IsPrime(i))
//                 return i;
//         }
//         return min;
//     }

//     private static bool IsPrime(int candidate)
//     {
//         if ((candidate & 1) != 0)
//         {
//             int limit = (int)Math.Sqrt(candidate);
//             for (int divisor = 3; divisor <= limit; divisor += 2)
//             {
//                 if ((candidate % divisor) == 0)
//                     return false;
//             }
//             return true;
//         }
//         return candidate == 2;
//     }

//     public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             if (_entries[i].HashCode >= 0)
//                 yield return new KeyValuePair<TKey, TValue>(_entries[i].Key, _entries[i].Value);
//         }
//     }

//     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }

//     public override string ToString()
//     {
//         return $"GenericDictionary<{typeof(TKey).Name}, {typeof(TValue).Name}>[{Count} items]";
//     }
// }

namespace Lab3._3_Generic_Classes_Methods.Collections;

public sealed class GenericDictionary<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _dict = new();

    public int Count => _dict.Count;

    public void Set(TKey key, TValue value) => _dict[key] = value;
    public bool TryGet(TKey key, out TValue? value) => _dict.TryGetValue(key, out value!);
    public IEnumerable<(TKey Key, TValue Value)> Items()
        => _dict.Select(kv => (kv.Key, kv.Value));
}