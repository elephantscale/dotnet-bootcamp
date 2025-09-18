// namespace Lab3._4_Generic_Constraints_Variance.Models;

// public interface IEntity
// {
//     int Id { get; }
//     DateTime CreatedAt { get; }
//     DateTime? UpdatedAt { get; }
//     bool IsDeleted { get; }

//     void MarkAsUpdated();
//     void MarkAsDeleted();
// }

// public interface IEntity<T> : IEntity where T : IEquatable<T>
// {
//     new T Id { get; }
// }

// public interface IVersionedEntity : IEntity
// {
//     int Version { get; }
//     void IncrementVersion();
// }

// public interface IAuditableEntity : IEntity
// {
//     string? CreatedBy { get; set; }
//     string? UpdatedBy { get; set; }
// }

// public interface ISoftDeletableEntity : IEntity
// {
//     DateTime? DeletedAt { get; }
//     string? DeletedBy { get; set; }
//     void SoftDelete(string? deletedBy = null);
//     void Restore();
// }

namespace Lab3._4_Generic_Constraints_Variance.Models;

public interface IEntity
{
    int Id { get; set; }
    string DisplayName { get; }
}