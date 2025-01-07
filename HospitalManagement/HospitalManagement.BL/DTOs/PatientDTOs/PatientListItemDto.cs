namespace HospitalManagement.BL.DTOs;

public record PatientListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string SeriaNumber { get; set; }
}
