using ECommerce.Core.Entities.Base;

namespace ECommerce.Core.Entities;

public class Order : AuditableEntity
{
    public DateTime OrderDate { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public decimal TotalPrice { get; set; }
}
