namespace Lab3._3_Generic_Classes_Methods.Collections;

public sealed class GenericList<T>
{
    private T[] _buffer;
    public int Count { get; private set; }
    public int Capacity => _buffer.Length;

    public GenericList(int capacity = 4) => _buffer = new T[Math.Max(capacity, 1)];

    public void Add(T item)
    {
        Ensure(Count + 1);
        _buffer[Count++] = item!;
    }

    public bool Contains(T item) => Array.IndexOf(_buffer, item, 0, Count) >= 0;

    public T this[int index]
    {
        get => index >= 0 && index < Count ? _buffer[index] : throw new IndexOutOfRangeException();
        set
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            _buffer[index] = value!;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
        Array.Copy(_buffer, index + 1, _buffer, index, Count - index - 1);
        Count--;
        _buffer[Count] = default!;
    }

    public IEnumerable<T> AsEnumerable()
    {
        for (int i = 0; i < Count; i++) yield return _buffer[i];
    }

    public override string ToString() => $"[{string.Join(", ", AsEnumerable())}]";

    private void Ensure(int needed)
    {
        if (needed <= _buffer.Length) return;
        Array.Resize(ref _buffer, Math.Max(needed, _buffer.Length * 2));
    }
}