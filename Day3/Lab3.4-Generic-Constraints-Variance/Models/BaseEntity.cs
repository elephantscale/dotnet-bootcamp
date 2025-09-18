

namespace Lab3._4_Generic_Constraints_Variance.Models;

public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }
    public abstract string DisplayName { get; }
    public override string ToString() => $"{DisplayName} (ID: {Id})";
}
