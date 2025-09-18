// namespace Lab3._3_Generic_Classes_Methods.Collections;

// public class GenericStack<T> : IEnumerable<T>
// {
//     private T[] _items;
//     private int _count;
//     private const int DefaultCapacity = 4;

//     public int Count => _count;
//     public bool IsEmpty => _count == 0;

//     public GenericStack() : this(DefaultCapacity)
//     {
//     }

//     public GenericStack(int capacity)
//     {
//         if (capacity < 0)
//             throw new ArgumentOutOfRangeException(nameof(capacity));

//         _items = new T[capacity];
//         _count = 0;
//     }

//     public GenericStack(IEnumerable<T> collection) : this()
//     {
//         foreach (var item in collection)
//         {
//             Push(item);
//         }
//     }

//     public void Push(T item)
//     {
//         EnsureCapacity(_count + 1);
//         _items[_count++] = item;
//     }

//     public T Pop()
//     {
//         if (_count == 0)
//             throw new InvalidOperationException("Stack is empty");

//         var item = _items[--_count];
//         _items[_count] = default(T)!; // Clear reference
//         return item;
//     }

//     public T Peek()
//     {
//         if (_count == 0)
//             throw new InvalidOperationException("Stack is empty");

//         return _items[_count - 1];
//     }

//     public bool TryPop(out T? item)
//     {
//         if (_count > 0)
//         {
//             item = Pop();
//             return true;
//         }

//         item = default(T);
//         return false;
//     }

//     public bool TryPeek(out T? item)
//     {
//         if (_count > 0)
//         {
//             item = _items[_count - 1];
//             return true;
//         }

//         item = default(T);
//         return false;
//     }

//     public bool Contains(T item)
//     {
//         for (int i = 0; i < _count; i++)
//         {
//             if (EqualityComparer<T>.Default.Equals(_items[i], item))
//                 return true;
//         }
//         return false;
//     }

//     public void Clear()
//     {
//         Array.Clear(_items, 0, _count);
//         _count = 0;
//     }

//     public T[] ToArray()
//     {
//         var result = new T[_count];
//         for (int i = 0; i < _count; i++)
//         {
//             result[i] = _items[_count - 1 - i]; // Reverse order (top to bottom)
//         }
//         return result;
//     }

//     private void EnsureCapacity(int minCapacity)
//     {
//         if (_items.Length < minCapacity)
//         {
//             int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
//             if (newCapacity < minCapacity)
//                 newCapacity = minCapacity;

//             Array.Resize(ref _items, newCapacity);
//         }
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         // Iterate from top to bottom
//         for (int i = _count - 1; i >= 0; i--)
//         {
//             yield return _items[i];
//         }
//     }

//     System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }

//     public override string ToString()
//     {
//         return $"GenericStack<{typeof(T).Name}>[{_count} items]";
//     }
// }

namespace Lab3._3_Generic_Classes_Methods.Collections;

public sealed class GenericStack<T>
{
    private readonly List<T> _list = new();

    public int Count => _list.Count;

    public void Push(T item) => _list.Add(item);

    public T Pop()
    {
        if (_list.Count == 0) throw new InvalidOperationException("Stack empty");
        var item = _list[^1];
        _list.RemoveAt(_list.Count - 1);
        return item;
    }

    public T Peek() => _list.Count == 0 ? throw new InvalidOperationException("Stack empty") : _list[^1];
}