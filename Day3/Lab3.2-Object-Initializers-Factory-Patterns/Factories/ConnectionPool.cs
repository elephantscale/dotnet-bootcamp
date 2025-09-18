// using System.Collections.Concurrent;

// namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

// // Object Pool Pattern
// public class ConnectionPool<T> where T : class, new()
// {
//     private readonly ConcurrentQueue<T> _pool = new();
//     private readonly Func<T> _objectFactory;
//     private readonly Action<T>? _resetAction;
//     private readonly int _maxSize;
//     private int _currentCount;

//     public int PoolSize => _pool.Count;
//     public int ActiveCount => _currentCount - _pool.Count;
//     public int MaxSize => _maxSize;

//     public ConnectionPool(int maxSize = 10, Func<T>? objectFactory = null, Action<T>? resetAction = null)
//     {
//         _maxSize = maxSize;
//         _objectFactory = objectFactory ?? (() => new T());
//         _resetAction = resetAction;

//         // Pre-populate the pool
//         for (int i = 0; i < maxSize / 2; i++)
//         {
//             _pool.Enqueue(CreateNewObject());
//         }
//     }

//     public T AcquireObject()
//     {
//         if (_pool.TryDequeue(out var obj))
//         {
//             return obj;
//         }

//         // Create new object if pool is empty and under max size
//         if (_currentCount < _maxSize)
//         {
//             return CreateNewObject();
//         }

//         // Wait for an object to be returned (simplified - in real implementation, use semaphore)
//         Thread.Sleep(10);
//         return AcquireObject();
//     }

//     public void ReturnObject(T obj)
//     {
//         if (obj == null) return;

//         _resetAction?.Invoke(obj);

//         if (_pool.Count < _maxSize)
//         {
//             _pool.Enqueue(obj);
//         }
//         else
//         {
//             // Pool is full, dispose the object if it implements IDisposable
//             if (obj is IDisposable disposable)
//             {
//                 disposable.Dispose();
//             }
//             Interlocked.Decrement(ref _currentCount);
//         }
//     }

//     private T CreateNewObject()
//     {
//         var obj = _objectFactory();
//         Interlocked.Increment(ref _currentCount);
//         return obj;
//     }

//     public void Clear()
//     {
//         while (_pool.TryDequeue(out var obj))
//         {
//             if (obj is IDisposable disposable)
//             {
//                 disposable.Dispose();
//             }
//         }
//         _currentCount = 0;
//     }
// }

// // Example pooled connection class
// public class DatabaseConnection : IDisposable
// {
//     private static int _nextId = 1;

//     public string ConnectionId { get; }
//     public DateTime CreatedAt { get; }
//     public DateTime LastUsed { get; private set; }
//     public bool IsInUse { get; private set; }

//     public DatabaseConnection()
//     {
//         ConnectionId = $"CONN-{_nextId++:D3}";
//         CreatedAt = DateTime.Now;
//         LastUsed = DateTime.Now;
//     }

//     public void Open()
//     {
//         IsInUse = true;
//         LastUsed = DateTime.Now;
//         Console.WriteLine($"Connection {ConnectionId} opened");
//     }

//     public void Close()
//     {
//         IsInUse = false;
//         Console.WriteLine($"Connection {ConnectionId} closed");
//     }

//     public void Reset()
//     {
//         IsInUse = false;
//         LastUsed = DateTime.Now;
//     }

//     public void Dispose()
//     {
//         Close();
//         Console.WriteLine($"Connection {ConnectionId} disposed");
//     }

//     public override string ToString()
//     {
//         return $"DatabaseConnection {ConnectionId} (Created: {CreatedAt:HH:mm:ss}, Last Used: {LastUsed:HH:mm:ss})";
//     }
// }

// // Connection Pool Manager
// public static class ConnectionPoolManager
// {
//     private static readonly Lazy<ConnectionPool<DatabaseConnection>> _connectionPool = 
//         new(() => new ConnectionPool<DatabaseConnection>(
//             maxSize: 10,
//             objectFactory: () => new DatabaseConnection(),
//             resetAction: conn => conn.Reset()
//         ));

//     public static ConnectionPool<DatabaseConnection> Instance => _connectionPool.Value;

//     public static DatabaseConnection GetConnection()
//     {
//         var connection = Instance.AcquireObject();
//         connection.Open();
//         return connection;
//     }

//     public static void ReturnConnection(DatabaseConnection connection)
//     {
//         connection.Close();
//         Instance.ReturnObject(connection);
//     }

//     public static object GetPoolStatistics()
//     {
//         var pool = Instance;
//         return new
//         {
//             PoolSize = pool.PoolSize,
//             ActiveConnections = pool.ActiveCount,
//             MaxSize = pool.MaxSize,
//             UtilizationPercentage = (double)pool.ActiveCount / pool.MaxSize * 100
//         };
//     }
// }

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