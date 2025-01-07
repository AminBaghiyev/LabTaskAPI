using HospitalManagement.BL.DTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Services.Abstractions;

public interface IInsuranceService
{
    Task<Insurance> GetByIdAsync(int id);
    Task<ICollection<InsuranceListItemDto>> GetAllAsync();
    Task<Insurance> CreateAsync(InsuranceCreateDto dto);
    Task<Insurance> UpdateAsync(InsuranceUpdateDto dto);
    Task HardDeleteAsync(int id);
    Task SoftDeleteAsync(int id);
    Task RecoverAsync(int id);
    Task<int> SaveChangesAsync();
}
