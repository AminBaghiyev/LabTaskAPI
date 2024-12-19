using WorkshopManagement.BL.DTOs;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.BL.Services.Abstractions;

public interface IWorkshopService
{
    Task<Workshop> GetByIdAsync(int id);
    Task<ICollection<Workshop>> GetAllAsync();
    Task<Workshop> CreateAsync(WorkshopCreateDto WorkshopDto);
    Task<Workshop> UpdateAsync(WorkshopUpdateDto WorkshopDto);
    Task DeleteAsync(int id);
}
