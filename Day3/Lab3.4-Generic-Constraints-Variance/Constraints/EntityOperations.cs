// using Lab3._4_Generic_Constraints_Variance.Models;

// namespace Lab3._4_Generic_Constraints_Variance.Constraints;

// // Operations with entity constraints
// public static class EntityOperations
// {
//     // Entity constraint - T must implement IEntity
//     public static void MarkAsUpdated<T>(T entity) where T : IEntity
//     {
//         entity.MarkAsUpdated();
//     }

//     public static void MarkAsDeleted<T>(T entity) where T : IEntity
//     {
//         entity.MarkAsDeleted();
//     }

//     public static bool IsDeleted<T>(T entity) where T : IEntity
//     {
//         return entity.IsDeleted;
//     }

//     public static TimeSpan GetAge<T>(T entity) where T : IEntity
//     {
//         return DateTime.UtcNow - entity.CreatedAt;
//     }

//     public static IEnumerable<T> FilterActive<T>(IEnumerable<T> entities) where T : IEntity
//     {
//         return entities.Where(e => !e.IsDeleted);
//     }

//     public static IEnumerable<T> FilterDeleted<T>(IEnumerable<T> entities) where T : IEntity
//     {
//         return entities.Where(e => e.IsDeleted);
//     }

//     public static IEnumerable<T> FilterByAge<T>(IEnumerable<T> entities, TimeSpan minAge, TimeSpan maxAge) where T : IEntity
//     {
//         var now = DateTime.UtcNow;
//         return entities.Where(e => 
//         {
//             var age = now - e.CreatedAt;
//             return age >= minAge && age <= maxAge;
//         });
//     }
// }

// // Repository with multiple constraints
// public class EntityRepository<T> where T : class, IEntity, IComparable<T>, new()
// {
//     private readonly List<T> _entities = new();

//     public int Count => _entities.Count(e => !e.IsDeleted);
//     public int TotalCount => _entities.Count;

//     public void Add(T entity)
//     {
//         _entities.Add(entity);
//     }

//     public void AddRange(IEnumerable<T> entities)
//     {
//         _entities.AddRange(entities);
//     }

//     public T Create()
//     {
//         // Constructor constraint allows us to create new instances
//         var entity = new T();
//         _entities.Add(entity);
//         return entity;
//     }

//     public IEnumerable<T> GetAll()
//     {
//         return _entities.Where(e => !e.IsDeleted);
//     }

//     public IEnumerable<T> GetAllIncludingDeleted()
//     {
//         return _entities.AsReadOnly();
//     }

//     public T? GetById(int id)
//     {
//         return _entities.FirstOrDefault(e => e.Id == id && !e.IsDeleted);
//     }

//     public void Delete(T entity)
//     {
//         entity.MarkAsDeleted();
//     }

//     public void HardDelete(T entity)
//     {
//         _entities.Remove(entity);
//     }

//     public IEnumerable<T> GetSorted()
//     {
//         // IComparable constraint allows sorting
//         return _entities.Where(e => !e.IsDeleted).OrderBy(e => e);
//     }

//     public IEnumerable<T> GetSortedDescending()
//     {
//         return _entities.Where(e => !e.IsDeleted).OrderByDescending(e => e);
//     }

//     public IEnumerable<T> GetRecentlyCreated(TimeSpan timeSpan)
//     {
//         var cutoff = DateTime.UtcNow - timeSpan;
//         return _entities.Where(e => !e.IsDeleted && e.CreatedAt >= cutoff);
//     }

//     public IEnumerable<T> GetRecentlyUpdated(TimeSpan timeSpan)
//     {
//         var cutoff = DateTime.UtcNow - timeSpan;
//         return _entities.Where(e => !e.IsDeleted && e.UpdatedAt >= cutoff);
//     }

//     public void BulkDelete(Func<T, bool> predicate)
//     {
//         var entitiesToDelete = _entities.Where(e => !e.IsDeleted && predicate(e));
//         foreach (var entity in entitiesToDelete)
//         {
//             entity.MarkAsDeleted();
//         }
//     }

//     public void Cleanup()
//     {
//         // Remove entities that have been soft-deleted for more than 30 days
//         var cutoff = DateTime.UtcNow.AddDays(-30);
//         var expiredEntities = _entities
//             .Where(e => e.IsDeleted && e.UpdatedAt < cutoff)
//             .ToList();

//         foreach (var entity in expiredEntities)
//         {
//             _entities.Remove(entity);
//         }
//     }
// }

// // Factory with constructor constraint
// public class EntityFactory<T> where T : class, IEntity, new()
// {
//     public T Create()
//     {
//         return new T();
//     }

//     public T Create(Action<T> initializer)
//     {
//         var entity = new T();
//         initializer(entity);
//         return entity;
//     }

//     public IEnumerable<T> CreateBatch(int count)
//     {
//         for (int i = 0; i < count; i++)
//         {
//             yield return new T();
//         }
//     }

//     public IEnumerable<T> CreateBatch(int count, Action<T, int> initializer)
//     {
//         for (int i = 0; i < count; i++)
//         {
//             var entity = new T();
//             initializer(entity, i);
//             yield return entity;
//         }
//     }
// }

// // Cloneable operations with ICloneable constraint
// public static class CloneableOperations
// {
//     public static T Clone<T>(T original) where T : ICloneable
//     {
//         return (T)original.Clone();
//     }

//     public static IEnumerable<T> CloneAll<T>(IEnumerable<T> originals) where T : ICloneable
//     {
//         return originals.Select(original => (T)original.Clone());
//     }

//     public static T[] CloneArray<T>(T[] originals) where T : ICloneable
//     {
//         var clones = new T[originals.Length];
//         for (int i = 0; i < originals.Length; i++)
//         {
//             clones[i] = (T)originals[i].Clone();
//         }
//         return clones;
//     }

//     public static List<T> DeepCloneList<T>(List<T> originals) where T : ICloneable
//     {
//         return originals.Select(original => (T)original.Clone()).ToList();
//     }
// }

// // Versioned entity operations
// public static class VersionedEntityOperations
// {
//     public static void IncrementVersion<T>(T entity) where T : IVersionedEntity
//     {
//         entity.IncrementVersion();
//     }

//     public static IEnumerable<T> GetByVersion<T>(IEnumerable<T> entities, int version) where T : IVersionedEntity
//     {
//         return entities.Where(e => e.Version == version);
//     }

//     public static IEnumerable<T> GetLatestVersions<T>(IEnumerable<T> entities) where T : IVersionedEntity
//     {
//         return entities.GroupBy(e => e.Id)
//                       .Select(g => g.OrderByDescending(e => e.Version).First());
//     }

//     public static T? GetLatestVersion<T>(IEnumerable<T> entities, int id) where T : IVersionedEntity
//     {
//         return entities.Where(e => e.Id == id)
//                       .OrderByDescending(e => e.Version)
//                       .FirstOrDefault();
//     }
// }

using Lab3._4_Generic_Constraints_Variance.Models;

namespace Lab3._4_Generic_Constraints_Variance.Constraints;

public static class EntityOperations
{
    // Requires reference type implementing IEntity
    public static T AddWithAutoId<T>(ICollection<T> collection, T entity, ref int nextId)
        where T : class, IEntity
    {
        entity.Id = nextId++;
        collection.Add(entity);
        return entity;
    }

    // Requires parameterless constructor to create a new instance generically
    public static T CreateDefault<T>() where T : IEntity, new()
        => new T { Id = 0 };

    // Multiple constraints: ref type + interface + new()
    public static List<T> CloneDefaults<T>(int count)
        where T : class, IEntity, new()
    {
        var list = new List<T>(count);
        for (int i = 0; i < count; i++)
            list.Add(new T());
        return list;
    }
}