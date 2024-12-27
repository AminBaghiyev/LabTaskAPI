namespace ECommerce.BL.DTOs;

public record OrderItemUpdateDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public bool IsDeleted { get; set; }
}
