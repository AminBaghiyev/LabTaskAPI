using WorkshopManagement.BL.DTOs;
using WorkshopManagement.BL.Services.Abstractions;
using WorkshopManagement.Core.Entities;
using WorkshopManagement.DAL.Repositories.Abstractions;

namespace WorkshopManagement.BL.Services.Implementations;

public class WorkshopService : IWorkshopService
{
    private readonly IRepository<Workshop> _workshopRepository;

    public WorkshopService(IRepository<Workshop> workshopRepository)
    {
        _workshopRepository = workshopRepository;
    }

    public Task<Workshop> CreateAsync(WorkshopCreateDto WorkshopDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _workshopRepository.IsExistsAsync(id)) throw new Exception("Workshop not found!");

        Workshop workshop = await _workshopRepository.GetByIdAsync(id);

        _workshopRepository.Delete(workshop);
    }

    public async Task<ICollection<Workshop>> GetAllAsync()
    {
        return await _workshopRepository.GetAllAsync();
    }

    public async Task<Workshop> GetByIdAsync(int id)
    {
        if (!await _workshopRepository.IsExistsAsync(id)) throw new Exception("Workshop not found!");

        return await _workshopRepository.GetByIdAsync(id);
    }

    public async Task<Workshop> UpdateAsync(WorkshopUpdateDto WorkshopDto)
    {
        if (!await _workshopRepository.IsExistsAsync(WorkshopDto.Id)) throw new Exception("Workshop not found!");

        Workshop workshop = await _workshopRepository.GetByIdAsync(WorkshopDto.Id); 

        workshop.Title = WorkshopDto.Title;
        workshop.Description = WorkshopDto.Description;
        workshop.Date = WorkshopDto.Date;
        workshop.Location = WorkshopDto.Location;
        workshop.UpdatedAt = DateTime.UtcNow.AddHours(4);
        workshop.IsDeleted = WorkshopDto.IsDeleted;

        return _workshopRepository.Update(workshop);
    }
}
