// namespace Lab3._3_Generic_Classes_Methods.Interfaces;

// public interface IRepository<T, TKey> where T : class where TKey : IEquatable<TKey>
// {
//     // Basic CRUD operations
//     void Add(T entity);
//     void AddRange(IEnumerable<T> entities);
//     T? GetById(TKey id);
//     IEnumerable<T> GetAll();
//     void Update(T entity);
//     void Delete(TKey id);
//     void Delete(T entity);

//     // Query operations
//     IEnumerable<T> Find(Func<T, bool> predicate);
//     T? FirstOrDefault(Func<T, bool> predicate);
//     bool Exists(Func<T, bool> predicate);
//     int Count();
//     int Count(Func<T, bool> predicate);

//     // Batch operations
//     void DeleteRange(IEnumerable<T> entities);
//     void DeleteRange(IEnumerable<TKey> ids);

//     // Events
//     event Action<T>? EntityAdded;
//     event Action<T>? EntityUpdated;
//     event Action<T>? EntityDeleted;
// }
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