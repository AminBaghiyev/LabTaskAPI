using HospitalManagement.BL.DTOs;

namespace HospitalManagement.BL.Services.Abstractions;

public interface IPatientService
{
    Task<PatientDto> GetByIdAsync(int id);
    Task<ICollection<PatientListItemDto>> GetAllAsync();
    Task<PatientDto> CreateAsync(PatientCreateDto dto);
    Task<PatientDto> UpdateAsync(PatientUpdateDto dto);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task<int> SaveChangesAsync();
}
