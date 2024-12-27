namespace ECommerce.BL.DTOs;

public record OrderCreateDto
{
    public DateTime OrderDate { get; set; }
    public bool IsDeleted { get; set; }
}
