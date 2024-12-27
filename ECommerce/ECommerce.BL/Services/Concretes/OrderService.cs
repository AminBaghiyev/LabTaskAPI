using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.BL.Exceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.DAL.Repositories.Abstractions;

namespace ECommerce.BL.Services.Concretes;

public class OrderService : IOrderService
{
    readonly IRepository<Order> _repository;
    readonly IMapper _mapper;

    public OrderService(IRepository<Order> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateAsync(OrderCreateDto entity)
    {
        Order order = _mapper.Map<Order>(entity);
        await _repository.CreateAsync(order);
    }

    public async Task DeleteAsync(int id)
    {
        Order order = await GetByIdAsync(id);

        _repository.Delete(order);
    }

    public async Task<List<OrderListItemDto>> GetAllAsync() => _mapper.Map<List<OrderListItemDto>>(await _repository.GetAllAsync());

    public async Task<Order> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsNoTrackingAsync(id) ?? throw new EntityNotFoundException();
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();

    public async Task UpdateAsync(OrderUpdateDto entity, int id)
    {
        Order order = await GetByIdAsync(id);
        Order updatedOrder = _mapper.Map<Order>(entity);
        updatedOrder.Id = id;
        updatedOrder.CreatedAt = order.CreatedAt;
        updatedOrder.DeletedAt = order.DeletedAt;

        _repository.Update(updatedOrder);
    }
}
