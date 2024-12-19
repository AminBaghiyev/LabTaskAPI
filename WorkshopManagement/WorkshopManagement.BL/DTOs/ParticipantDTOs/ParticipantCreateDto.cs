namespace WorkshopManagement.BL.DTOs;

public record ParticipantCreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int WorkshopId { get; set; }
    public bool IsDeleted { get; set; }
}
