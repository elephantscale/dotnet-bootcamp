
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
