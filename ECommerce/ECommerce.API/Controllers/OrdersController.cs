using ECommerce.BL.DTOs;
using ECommerce.BL.Exceptions;
using ECommerce.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _orderService.GetByIdAsync(id));
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
            return Ok(await _orderService.GetAllAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Create(OrderCreateDto entity)
    {
        try
        {
            await _orderService.CreateAsync(entity);
            return StatusCode(StatusCodes.Status201Created, await _orderService.SaveChangesAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Update(OrderUpdateDto entity, int id)
    {
        try
        {
            await _orderService.UpdateAsync(entity, id);
            return StatusCode(StatusCodes.Status200OK, await _orderService.SaveChangesAsync());
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
            await _orderService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK, await _orderService.SaveChangesAsync());
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
