namespace ECommerce.BL.DTOs;

public record ProductListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
