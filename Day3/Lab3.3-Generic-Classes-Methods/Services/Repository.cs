

using Lab3._3_Generic_Classes_Methods.Interfaces;
using Lab3._3_Generic_Classes_Methods.Models;

namespace Lab3._3_Generic_Classes_Methods.Services;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

    public T Add(T entity)
    {
        if (entity.Id == 0) entity.Id = IdCounter<T>.Next();
        _items.Add(entity);
        return entity;
    }

    public T? GetById(int id) => _items.FirstOrDefault(e => e.Id == id);
    public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
    public IReadOnlyList<T> Find(Func<T, bool> predicate) => _items.Where(predicate).ToList();

    public bool Remove(int id)
    {
        var e = GetById(id);
        return e is not null && _items.Remove(e);
    }

    public bool Update(T entity)
    {
        var idx = _items.FindIndex(e => e.Id == entity.Id);
        if (idx < 0) return false;
        _items[idx] = entity;
        return true;
    }
}
