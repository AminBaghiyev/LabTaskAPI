using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.BL.Exceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.DAL.Repositories.Abstractions;

namespace ECommerce.BL.Services.Concretes;

public class ProductService : IProductService
{
    readonly IRepository<Product> _repository;
    readonly IMapper _mapper;

    public ProductService(IRepository<Product> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(ProductCreateDto entity)
    {
        Product product = _mapper.Map<Product>(entity);
        await _repository.CreateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        Product product = await GetByIdAsync(id);

        _repository.Delete(product);
    }

    public async Task<List<ProductListItemDto>> GetAllAsync() => _mapper.Map<List<ProductListItemDto>>(await _repository.GetAllAsync());

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsNoTrackingAsync(id) ?? throw new EntityNotFoundException();
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();

    public async Task UpdateAsync(ProductUpdateDto entity, int id)
    {
        Product product = await GetByIdAsync(id);
        Product updatedProduct = _mapper.Map<Product>(entity);
        updatedProduct.Id = id;
        updatedProduct.CreatedAt = product.CreatedAt;
        updatedProduct.DeletedAt = product.DeletedAt;

        _repository.Update(updatedProduct);
    }
}
