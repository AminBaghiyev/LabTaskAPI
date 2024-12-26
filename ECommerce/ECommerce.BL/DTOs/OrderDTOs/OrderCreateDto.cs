namespace ECommerce.BL.DTOs;

public record OrderCreateDto
{
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
    public bool IsDeleted { get; set; }
}
