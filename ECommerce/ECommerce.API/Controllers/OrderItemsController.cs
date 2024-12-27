using ECommerce.BL.DTOs;
using ECommerce.BL.Exceptions;
using ECommerce.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    readonly IOrderItemService _orderItemService;

    public OrderItemsController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _orderItemService.GetByIdAsync(id));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _orderItemService.GetAllAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create(OrderItemCreateDto entity)
    {
        try
        {
            await _orderItemService.CreateAsync(entity);
            return StatusCode(StatusCodes.Status201Created, await _orderItemService.SaveChangesAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Update(OrderItemUpdateDto entity, int id)
    {
        try
        {
            await _orderItemService.UpdateAsync(entity, id);
            return StatusCode(StatusCodes.Status200OK, await _orderItemService.SaveChangesAsync());
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _orderItemService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK, await _orderItemService.SaveChangesAsync());
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }
}
