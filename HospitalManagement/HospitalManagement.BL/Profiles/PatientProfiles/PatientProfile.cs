using AutoMapper;
using HospitalManagement.BL.DTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Profiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<PatientDto, Patient>().ReverseMap();
        CreateMap<PatientCreateDto, Patient>().ReverseMap();
        CreateMap<PatientUpdateDto, Patient>().ReverseMap();
        CreateMap<PatientListItemDto, Patient>().ReverseMap();
    }
}
