using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Profiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItemCreateDto, OrderItem>().ReverseMap();
        CreateMap<OrderItemUpdateDto, OrderItem>().ReverseMap();
        CreateMap<OrderItemListItemDto, OrderItem>().ReverseMap();
    }
}
