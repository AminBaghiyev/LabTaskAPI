namespace WorkshopManagement.BL.DTOs;

public record WorkshopCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public bool IsDeleted { get; set; }
}
