// using System.Collections.Concurrent;

// namespace Lab3._3_Generic_Classes_Methods.Services;

// public class Cache<TKey, TValue> where TKey : notnull
// {
//     private readonly ConcurrentDictionary<TKey, CacheItem<TValue>> _cache = new();
//     private readonly TimeSpan _defaultExpiration;
//     private readonly Timer _cleanupTimer;

//     public int Count => _cache.Count;
//     public TimeSpan DefaultExpiration => _defaultExpiration;

//     public Cache(TimeSpan? defaultExpiration = null)
//     {
//         _defaultExpiration = defaultExpiration ?? TimeSpan.FromMinutes(30);
//         _cleanupTimer = new Timer(CleanupExpiredItems, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
//     }

//     public void Set(TKey key, TValue value, TimeSpan? expiration = null)
//     {
//         var expirationTime = expiration ?? _defaultExpiration;
//         var item = new CacheItem<TValue>(value, DateTime.UtcNow.Add(expirationTime));
//         _cache.AddOrUpdate(key, item, (k, v) => item);
//     }

//     public TValue? Get(TKey key)
//     {
//         if (_cache.TryGetValue(key, out var item))
//         {
//             if (item.IsExpired)
//             {
//                 _cache.TryRemove(key, out _);
//                 return default(TValue);
//             }

//             item.UpdateLastAccessed();
//             return item.Value;
//         }

//         return default(TValue);
//     }

//     public bool TryGet(TKey key, out TValue? value)
//     {
//         value = Get(key);
//         return value != null || (_cache.ContainsKey(key) && !_cache[key].IsExpired);
//     }

//     public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory, TimeSpan? expiration = null)
//     {
//         if (TryGet(key, out var existingValue) && existingValue != null)
//         {
//             return existingValue;
//         }

//         var newValue = valueFactory(key);
//         Set(key, newValue, expiration);
//         return newValue;
//     }

//     public async Task<TValue> GetOrAddAsync(TKey key, Func<TKey, Task<TValue>> valueFactory, TimeSpan? expiration = null)
//     {
//         if (TryGet(key, out var existingValue) && existingValue != null)
//         {
//             return existingValue;
//         }

//         var newValue = await valueFactory(key);
//         Set(key, newValue, expiration);
//         return newValue;
//     }

//     public bool Remove(TKey key)
//     {
//         return _cache.TryRemove(key, out _);
//     }

//     public void Clear()
//     {
//         _cache.Clear();
//     }

//     public bool ContainsKey(TKey key)
//     {
//         if (_cache.TryGetValue(key, out var item))
//         {
//             if (item.IsExpired)
//             {
//                 _cache.TryRemove(key, out _);
//                 return false;
//             }
//             return true;
//         }
//         return false;
//     }

//     public IEnumerable<TKey> Keys
//     {
//         get
//         {
//             var validKeys = new List<TKey>();
//             foreach (var kvp in _cache)
//             {
//                 if (!kvp.Value.IsExpired)
//                 {
//                     validKeys.Add(kvp.Key);
//                 }
//                 else
//                 {
//                     _cache.TryRemove(kvp.Key, out _);
//                 }
//             }
//             return validKeys;
//         }
//     }

//     public IEnumerable<TValue> Values
//     {
//         get
//         {
//             var validValues = new List<TValue>();
//             foreach (var kvp in _cache.ToList())
//             {
//                 if (!kvp.Value.IsExpired)
//                 {
//                     validValues.Add(kvp.Value.Value);
//                 }
//                 else
//                 {
//                     _cache.TryRemove(kvp.Key, out _);
//                 }
//             }
//             return validValues;
//         }
//     }

//     public CacheStatistics GetStatistics()
//     {
//         var items = _cache.Values.ToList();
//         var validItems = items.Where(i => !i.IsExpired).ToList();

//         return new CacheStatistics
//         {
//             TotalItems = _cache.Count,
//             ValidItems = validItems.Count,
//             ExpiredItems = items.Count - validItems.Count,
//             OldestItem = validItems.Any() ? validItems.Min(i => i.CreatedAt) : (DateTime?)null,
//             NewestItem = validItems.Any() ? validItems.Max(i => i.CreatedAt) : (DateTime?)null,
//             LastAccessed = validItems.Any() ? validItems.Max(i => i.LastAccessed) : (DateTime?)null
//         };
//     }

//     private void CleanupExpiredItems(object? state)
//     {
//         var expiredKeys = _cache
//             .Where(kvp => kvp.Value.IsExpired)
//             .Select(kvp => kvp.Key)
//             .ToList();

//         foreach (var key in expiredKeys)
//         {
//             _cache.TryRemove(key, out _);
//         }
//     }

//     public void Dispose()
//     {
//         _cleanupTimer?.Dispose();
//         _cache.Clear();
//     }
// }

// public class CacheItem<T>
// {
//     public T Value { get; }
//     public DateTime CreatedAt { get; }
//     public DateTime ExpiresAt { get; }
//     public DateTime LastAccessed { get; private set; }

//     public bool IsExpired => DateTime.UtcNow > ExpiresAt;

//     public CacheItem(T value, DateTime expiresAt)
//     {
//         Value = value;
//         CreatedAt = DateTime.UtcNow;
//         ExpiresAt = expiresAt;
//         LastAccessed = CreatedAt;
//     }

//     public void UpdateLastAccessed()
//     {
//         LastAccessed = DateTime.UtcNow;
//     }
// }

// public class CacheStatistics
// {
//     public int TotalItems { get; set; }
//     public int ValidItems { get; set; }
//     public int ExpiredItems { get; set; }
//     public DateTime? OldestItem { get; set; }
//     public DateTime? NewestItem { get; set; }
//     public DateTime? LastAccessed { get; set; }

//     public double HitRatio => TotalItems > 0 ? (double)ValidItems / TotalItems : 0;

//     public override string ToString()
//     {
//         return $"Cache Stats: {ValidItems}/{TotalItems} valid items ({HitRatio:P1} hit ratio)";
//     }
// }
namespace Lab3._3_Generic_Classes_Methods.Services;

public sealed class Cache<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _cache = new();

    public void Set(TKey key, TValue value) => _cache[key] = value;
    public bool TryGet(TKey key, out TValue? value) => _cache.TryGetValue(key, out value!);
    public void Clear() => _cache.Clear();
}