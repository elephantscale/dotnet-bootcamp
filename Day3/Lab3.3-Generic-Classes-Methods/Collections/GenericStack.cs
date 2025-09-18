

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
