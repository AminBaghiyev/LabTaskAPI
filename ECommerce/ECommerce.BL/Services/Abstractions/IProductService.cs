using ECommerce.BL.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.BL.Services.Abstractions;

public interface IProductService
{
    Task<List<ProductListItemDto>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task CreateAsync(ProductCreateDto entity);
    Task UpdateAsync(ProductUpdateDto entity, int id);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
