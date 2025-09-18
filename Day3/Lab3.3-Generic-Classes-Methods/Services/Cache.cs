
namespace Lab3._3_Generic_Classes_Methods.Services;

public sealed class Cache<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _cache = new();

    public void Set(TKey key, TValue value) => _cache[key] = value;
    public bool TryGet(TKey key, out TValue? value) => _cache.TryGetValue(key, out value!);
    public void Clear() => _cache.Clear();
}
