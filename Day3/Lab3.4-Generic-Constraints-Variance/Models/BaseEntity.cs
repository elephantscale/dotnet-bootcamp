// namespace Lab3._4_Generic_Constraints_Variance.Models;

// public abstract class BaseEntity<T> : IEntity<T>, IVersionedEntity, IAuditableEntity, ISoftDeletableEntity 
//     where T : IEquatable<T>
// {
//     public T Id { get; protected set; } = default!;
//     public DateTime CreatedAt { get; protected set; }
//     public DateTime? UpdatedAt { get; protected set; }
//     public bool IsDeleted { get; protected set; }
//     public int Version { get; protected set; }
//     public string? CreatedBy { get; set; }
//     public string? UpdatedBy { get; set; }
//     public DateTime? DeletedAt { get; protected set; }
//     public string? DeletedBy { get; set; }

//     // Explicit interface implementation for IEntity.Id
//     int IEntity.Id => Convert.ToInt32(Id);

//     protected BaseEntity()
//     {
//         CreatedAt = DateTime.UtcNow;
//         Version = 1;
//     }

//     protected BaseEntity(T id) : this()
//     {
//         Id = id;
//     }

//     public virtual void MarkAsUpdated()
//     {
//         UpdatedAt = DateTime.UtcNow;
//         IncrementVersion();
//     }

//     public virtual void MarkAsDeleted()
//     {
//         IsDeleted = true;
//         UpdatedAt = DateTime.UtcNow;
//         IncrementVersion();
//     }

//     public virtual void IncrementVersion()
//     {
//         Version++;
//     }

//     public virtual void SoftDelete(string? deletedBy = null)
//     {
//         IsDeleted = true;
//         DeletedAt = DateTime.UtcNow;
//         DeletedBy = deletedBy;
//         MarkAsUpdated();
//     }

//     public virtual void Restore()
//     {
//         IsDeleted = false;
//         DeletedAt = null;
//         DeletedBy = null;
//         MarkAsUpdated();
//     }

//     public override bool Equals(object? obj)
//     {
//         if (obj is not BaseEntity<T> other)
//             return false;

//         return Id.Equals(other.Id);
//     }

//     public override int GetHashCode()
//     {
//         return Id.GetHashCode();
//     }

//     public override string ToString()
//     {
//         return $"{GetType().Name}(Id: {Id}, Version: {Version})";
//     }
// }

namespace Lab3._4_Generic_Constraints_Variance.Models;

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
    public abstract string DisplayName { get; }
    public override string ToString() => $"{DisplayName} (ID: {Id})";
}