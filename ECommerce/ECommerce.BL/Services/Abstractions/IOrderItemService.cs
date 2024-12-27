using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Services.Abstractions;

public interface IOrderItemService
{
    Task<List<OrderItemListItemDto>> GetAllAsync();
    Task<OrderItem> GetByIdAsync(int id);
    Task CreateAsync(OrderItemCreateDto entity);
    Task UpdateAsync(OrderItemUpdateDto entity, int id);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
