namespace Lab3._3_Generic_Classes_Methods.Utilities;

public sealed class KeyValueStore<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _store = new();
    public void Set(TKey key, TValue value) => _store[key] = value;
    public TValue? Get(TKey key) => _store.TryGetValue(key, out var val) ? val : default;
    public override string ToString() => string.Join(", ", _store.Select(kv => $"{kv.Key}={kv.Value}"));
}