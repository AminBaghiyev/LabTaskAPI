using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<OrderCreateDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
        CreateMap<ProductListItemDto, Product>().ReverseMap();
    }
}
