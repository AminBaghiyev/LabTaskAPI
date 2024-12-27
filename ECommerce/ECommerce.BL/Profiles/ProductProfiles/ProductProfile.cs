using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
        CreateMap<ProductListItemDto, Product>().ReverseMap();
    }
}
