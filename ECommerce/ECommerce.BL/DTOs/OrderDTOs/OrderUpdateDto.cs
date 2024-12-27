namespace ECommerce.BL.DTOs;

public record OrderUpdateDto
{
    public DateTime OrderDate { get; set; }
    public bool IsDeleted { get; set; }
}
