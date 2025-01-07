using AutoMapper;
using HospitalManagement.BL.DTOs;
using HospitalManagement.Core.Entities;

namespace HospitalManagement.BL.Profiles;

public class InsuranceProfile : Profile
{
    public InsuranceProfile()
    {
        CreateMap<InsuranceCreateDto, Insurance>().ReverseMap();
        CreateMap<InsuranceUpdateDto, Insurance>().ReverseMap();
        CreateMap<InsuranceListItemDto, Insurance>().ReverseMap();
    }
}
