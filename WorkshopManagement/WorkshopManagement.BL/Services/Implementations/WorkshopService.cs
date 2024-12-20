using AutoMapper;
using WorkshopManagement.BL.DTOs;
using WorkshopManagement.BL.Services.Abstractions;
using WorkshopManagement.Core.Entities;
using WorkshopManagement.DAL.Repositories.Abstractions;

namespace WorkshopManagement.BL.Services.Implementations;

public class WorkshopService : IWorkshopService
{
    private readonly IRepository<Workshop> _workshopRepository;
    private readonly IMapper _mapper;

    public WorkshopService(IRepository<Workshop> workshopRepository, IMapper mapper)
    {
        _workshopRepository = workshopRepository;
        _mapper = mapper;
    }

    public async Task<Workshop> CreateAsync(WorkshopCreateDto WorkshopDto)
    {
        Workshop workshop = _mapper.Map<Workshop>(WorkshopDto);
        workshop.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _workshopRepository.CreateAsync(workshop);
        await _workshopRepository.SaveChangesAsync();

        return workshop;
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _workshopRepository.IsExistsAsync(id)) throw new Exception("Workshop not found!");

        Workshop workshop = await _workshopRepository.GetByIdAsync(id);

        _workshopRepository.Delete(workshop);
        await _workshopRepository.SaveChangesAsync();
    }

    public async Task<ICollection<Workshop>> GetAllAsync()
    {
        return await _workshopRepository.GetAllAsync();
    }

    public async Task<Workshop> GetByIdAsync(int id)
    {
        if (!await _workshopRepository.IsExistsAsync(id)) throw new Exception("Workshop not found!");

        return await _workshopRepository.GetByIdAsync(id, ["Participants"]);
    }

    public async Task<Workshop> UpdateAsync(WorkshopUpdateDto WorkshopDto)
    {
        if (!await _workshopRepository.IsExistsAsync(WorkshopDto.Id)) throw new Exception("Workshop not found!");

        Workshop originalWorkshop = await _workshopRepository.GetByIdAsNoTrackingAsync(WorkshopDto.Id);

        Workshop workshop = _mapper.Map<Workshop>(WorkshopDto);
        workshop.CreatedAt = originalWorkshop.CreatedAt;
        workshop.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _workshopRepository.Update(workshop);
        await _workshopRepository.SaveChangesAsync();
        return workshop;
    }
}
