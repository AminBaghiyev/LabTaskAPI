namespace ECommerce.BL.DTOs;

public record OrderItemCreateDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public bool IsDeleted { get; set; }
}
