namespace ECommerce.BL.DTOs;

public record OrderListItemDto
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}
