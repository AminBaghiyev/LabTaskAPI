using ECommerce.Core.Entities.Base;

namespace ECommerce.Core.Entities;

public class OrderItem : AuditableEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
