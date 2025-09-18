// namespace Lab3._3_Generic_Classes_Methods.Collections;

// public class GenericQueue<T> : IEnumerable<T>
// {
//     private T[] _items;
//     private int _head;
//     private int _tail;
//     private int _count;
//     private const int DefaultCapacity = 4;

//     public int Count => _count;
//     public bool IsEmpty => _count == 0;

//     public GenericQueue() : this(DefaultCapacity)
//     {
//     }

//     public GenericQueue(int capacity)
//     {
//         if (capacity < 0)
//             throw new ArgumentOutOfRangeException(nameof(capacity));

//         _items = new T[capacity];
//         _head = 0;
//         _tail = 0;
//         _count = 0;
//     }

//     public GenericQueue(IEnumerable<T> collection) : this()
//     {
//         foreach (var item in collection)
//         {
//             Enqueue(item);
//         }
//     }

//     public void Enqueue(T item)
//     {
//         if (_count == _items.Length)
//         {
//             Resize();
//         }

//         _items[_tail] = item;
//         _tail = (_tail + 1) % _items.Length;
//         _count++;
//     }

//     public T Dequeue()
//     {
//         if (_count == 0)
//             throw new InvalidOperationException("Queue is empty");

//         var item = _items[_head];
//         _items[_head] = default(T)!; // Clear reference
//         _head = (_head + 1) % _items.Length;
//         _count--;

//         return item;
//     }

//     public T Peek()
//     {
//         if (_count == 0)
//             throw new InvalidOperationException("Queue is empty");

//         return _items[_head];
//     }

//     public bool TryDequeue(out T? item)
//     {
//         if (_count > 0)
//         {
//             item = Dequeue();
//             return true;
//         }

//         item = default(T);
//         return false;
//     }

//     public bool TryPeek(out T? item)
//     {
//         if (_count > 0)
//         {
//             item = _items[_head];
//             return true;
//         }

//         item = default(T);
//         return false;
//     }

//     public bool Contains(T item)
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             int index = (_head + i) % _items.Length;
//             if (EqualityComparer<T>.Default.Equals(_items[index], item))
//                 return true;
//         }
//         return false;
//     }

//     public void Clear()
//     {
//         if (_count > 0)
//         {
//             Array.Clear(_items, 0, _items.Length);
//             _head = 0;
//             _tail = 0;
//             _count = 0;
//         }
//     }

//     public T[] ToArray()
//     {
//         var result = new T[_count];
//         for (int i = 0; i < _count; i++)
//         {
//             result[i] = _items[(_head + i) % _items.Length];
//         }
//         return result;
//     }

//     private void Resize()
//     {
//         int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
//         var newItems = new T[newCapacity];

//         for (int i = 0; i < _count; i++)
//         {
//             newItems[i] = _items[(_head + i) % _items.Length];
//         }

//         _items = newItems;
//         _head = 0;
//         _tail = _count;
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             yield return _items[(_head + i) % _items.Length];
//         }
//     }

//     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }

//     public override string ToString()
//     {
//         return $"GenericQueue<{typeof(T).Name}>[{_count} items]";
//     }
// }
namespace Lab3._3_Generic_Classes_Methods.Collections;

public sealed class GenericQueue<T>
{
    private readonly LinkedList<T> _list = new();
    public int Count => _list.Count;

    public void Enqueue(T item) => _list.AddLast(item);

    public T Dequeue()
    {
        var node = _list.First;
        if (node is null) throw new InvalidOperationException("Queue empty");
        var v = node.Value;
        _list.RemoveFirst();
        return v;
    }

    public T Peek()
    {
        var node = _list.First;
        if (node is null) throw new InvalidOperationException("Queue empty");
        return node.Value;
    }
}