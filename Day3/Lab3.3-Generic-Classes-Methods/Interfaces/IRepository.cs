
using Lab3._3_Generic_Classes_Methods.Models;

namespace Lab3._3_Generic_Classes_Methods.Interfaces;

public interface IRepository<T> where T : Entity
{
    T Add(T entity);
    T? GetById(int id);
    IReadOnlyList<T> GetAll();
    IReadOnlyList<T> Find(Func<T, bool> predicate);
    bool Remove(int id);
    bool Update(T entity);
    int Count { get; }
}
