namespace HospitalManagement.BL.DTOs;

public record InsuranceListItemDto
{
    public int Id { get; set; }
    public string PersonInsurance { get; set; }
    public float Discount { get; set; }
}
