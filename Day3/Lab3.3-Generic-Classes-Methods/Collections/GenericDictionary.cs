

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
