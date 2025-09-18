

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
