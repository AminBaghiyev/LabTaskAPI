using WorkshopManagement.BL.DTOs;
using WorkshopManagement.Core.Entities;

namespace ParticipantManagement.BL.Services.Abstractions;

public interface IParticipantService
{
    Task<Participant> GetByIdAsync(int id);
    Task<ICollection<Participant>> GetAllAsync();
    Task<Participant> CreateAsync(ParticipantCreateDto ParticipantDto);
    Task<Participant> UpdateAsync(ParticipantUpdateDto ParticipantDto);
    Task DeleteAsync(int id);
}
