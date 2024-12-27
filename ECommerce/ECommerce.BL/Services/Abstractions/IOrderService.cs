using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Services.Abstractions;

public interface IOrderService
{
    Task<List<OrderListItemDto>> GetAllAsync();
    Task<Order> GetByIdAsync(int id);
    Task CreateAsync(OrderCreateDto entity);
    Task UpdateAsync(OrderUpdateDto entity, int id);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
