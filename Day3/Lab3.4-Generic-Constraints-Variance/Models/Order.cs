

namespace Lab3._4_Generic_Constraints_Variance.Models;

public sealed class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public DateTime Created { get; } = DateTime.Now;
    public override string DisplayName => $"Order #{Id}";
}
