using AutoMapper;
using WorkshopManagement.BL.DTOs;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.BL.Profiles;

public class WorkshopProfile : Profile
{
    public WorkshopProfile()
    {
        CreateMap<WorkshopCreateDto, Workshop>().ReverseMap();
        CreateMap<WorkshopUpdateDto, Workshop>().ReverseMap();
    }
}
