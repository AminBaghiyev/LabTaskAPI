using AutoMapper;
using WorkshopManagement.BL.DTOs;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.BL.Profiles;

public class ParticipantProfile : Profile
{
    public ParticipantProfile()
    {
        CreateMap<ParticipantCreateDto, Participant>().ReverseMap();
        CreateMap<ParticipantUpdateDto, Participant>().ReverseMap();
    }
}
