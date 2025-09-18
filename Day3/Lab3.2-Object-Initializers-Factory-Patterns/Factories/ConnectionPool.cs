

namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

public sealed class PooledConnection
{
    public string Id { get; } = $"CONN-{Guid.NewGuid():N}".Substring(0, 8).ToUpperInvariant();
}

public sealed class ConnectionPool
{
    private readonly Queue<PooledConnection> _available = new();
    private readonly HashSet<PooledConnection> _leased = new();

    public int Capacity { get; }
    public int ActiveCount => _leased.Count;
    public int AvailableCount => _available.Count;
    public double UsagePercent => Capacity == 0 ? 0 : (double)ActiveCount / Capacity;

    public ConnectionPool(int size = 10)
    {
        Capacity = Math.Max(1, size);
        for (int i = 0; i < Capacity; i++) _available.Enqueue(new PooledConnection());
    }

    public PooledConnection Acquire()
    {
        if (_available.Count == 0) throw new InvalidOperationException("Pool exhausted");
        var c = _available.Dequeue();
        _leased.Add(c);
        return c;
    }

    public void Release(PooledConnection conn)
    {
        if (_leased.Remove(conn)) _available.Enqueue(conn);
    }
}
