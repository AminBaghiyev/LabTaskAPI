using WorkshopManagement.BL.Services.Abstractions;
using WorkshopManagement.BL.DTOs;
using WorkshopManagement.Core.Entities;
using WorkshopManagement.DAL.Repositories.Abstractions;
using AutoMapper;

namespace WorkshopManagement.BL.Services.Implementations;

public class ParticipantService : IParticipantService
{
    private readonly IRepository<Participant> _participantRepository;
    private readonly IMapper _mapper;

    public ParticipantService(IRepository<Participant> participantRepository, IMapper mapper)
    {
        _participantRepository = participantRepository;
        _mapper = mapper;
    }

    public async Task<Participant> CreateAsync(ParticipantCreateDto ParticipantDto)
    {
        Participant participant = _mapper.Map<Participant>(ParticipantDto);
        participant.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _participantRepository.CreateAsync(participant);
        await _participantRepository.SaveChangesAsync();

        return participant;
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _participantRepository.IsExistsAsync(id)) throw new Exception("Participant not found!");

        Participant participant = await _participantRepository.GetByIdAsync(id);

        _participantRepository.Delete(participant);
        await _participantRepository.SaveChangesAsync();
    }

    public async Task<ICollection<Participant>> GetAllAsync()
    {
        return await _participantRepository.GetAllAsync();
    }

    public async Task<Participant> GetByIdAsync(int id)
    {
        if (!await _participantRepository.IsExistsAsync(id)) throw new Exception("Participant not found!");

        return await _participantRepository.GetByIdAsync(id, ["Workshop"]);
    }

    public async Task<Participant> UpdateAsync(ParticipantUpdateDto ParticipantDto)
    {
        if (!await _participantRepository.IsExistsAsync(ParticipantDto.Id)) throw new Exception("Participant not found!");

        Participant originalParticipant = await _participantRepository.GetByIdAsNoTrackingAsync(ParticipantDto.Id);

        Participant participant = _mapper.Map<Participant>(ParticipantDto);
        participant.CreatedAt = originalParticipant.CreatedAt;
        participant.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _participantRepository.Update(participant);
        await _participantRepository.SaveChangesAsync();
        return participant;
    }
}
