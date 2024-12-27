using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderCreateDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>().ReverseMap();
        CreateMap<OrderListItemDto, Order>().ReverseMap();
    }
}
