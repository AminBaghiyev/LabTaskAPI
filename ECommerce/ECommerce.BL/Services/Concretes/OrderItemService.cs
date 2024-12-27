using AutoMapper;
using ECommerce.BL.DTOs;
using ECommerce.BL.Exceptions;
using ECommerce.BL.Services.Abstractions;
using ECommerce.Core.Entities;
using ECommerce.DAL.Repositories.Abstractions;

namespace ECommerce.BL.Services.Concretes;

public class OrderItemService : IOrderItemService
{
    readonly IRepository<OrderItem> _orderItemRepository;
    readonly IRepository<Product> _productRepository;
    readonly IRepository<Order> _orderRepository;
    readonly IMapper _mapper;

    public OrderItemService(IMapper mapper, IRepository<Product> productRepository, IRepository<OrderItem> orderItemRepository, IRepository<Order> orderRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _orderItemRepository = orderItemRepository;
        _orderRepository = orderRepository;
    }

    public async Task CreateAsync(OrderItemCreateDto entity)
    {
        Product product = await _productRepository.GetByIdAsNoTrackingAsync(entity.ProductId) ?? throw new EntityNotFoundException("Product not found!");
        Order order = await _orderRepository.GetByIdAsNoTrackingAsync(entity.OrderId) ?? throw new EntityNotFoundException("Order not found!");

        if (product.Stock < entity.Quantity) throw new OrderItemHighQuantityException();

        OrderItem orderItem = _mapper.Map<OrderItem>(entity);
        orderItem.Price = product.Price * orderItem.Quantity;
        product.Stock -= orderItem.Quantity;
        order.TotalPrice += orderItem.Price;

        await _orderItemRepository.CreateAsync(orderItem);
        _productRepository.Update(product);
        _orderRepository.Update(order);
    }

    public async Task DeleteAsync(int id)
    {
        OrderItem order = await GetByIdAsync(id);

        _orderItemRepository.Delete(order);
    }

    public async Task<List<OrderItemListItemDto>> GetAllAsync() => _mapper.Map<List<OrderItemListItemDto>>(await _orderItemRepository.GetAllAsync());

    public async Task<OrderItem> GetByIdAsync(int id)
    {
        return await _orderItemRepository.GetByIdAsNoTrackingAsync(id) ?? throw new EntityNotFoundException();
    }

    public async Task<int> SaveChangesAsync() => await _orderItemRepository.SaveChangesAsync();

    public async Task UpdateAsync(OrderItemUpdateDto entity, int id)
    {
        Product product = await _productRepository.GetByIdAsNoTrackingAsync(entity.ProductId) ?? throw new EntityNotFoundException("Product not found!");
        Order order = await _orderRepository.GetByIdAsNoTrackingAsync(entity.OrderId) ?? throw new EntityNotFoundException("Order not found!");

        if (product.Stock < entity.Quantity) throw new OrderItemHighQuantityException();

        OrderItem orderItem = await GetByIdAsync(id);
        OrderItem updatedOrderItem = _mapper.Map<OrderItem>(entity);
        updatedOrderItem.Id = id;
        updatedOrderItem.Price = product.Price * updatedOrderItem.Quantity;
        product.Stock -= updatedOrderItem.Quantity;
        order.TotalPrice = order.TotalPrice - orderItem.Price + updatedOrderItem.Price;
        updatedOrderItem.CreatedAt = orderItem.CreatedAt;
        updatedOrderItem.DeletedAt = orderItem.DeletedAt;

        _orderItemRepository.Update(updatedOrderItem);
        _productRepository.Update(product);
        _orderRepository.Update(order);
    }
}
