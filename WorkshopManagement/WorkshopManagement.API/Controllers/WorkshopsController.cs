using Microsoft.AspNetCore.Mvc;
using WorkshopManagement.BL.DTOs;
using WorkshopManagement.BL.Services.Abstractions;

namespace WorkshopManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class WorkshopsController : ControllerBase
{
    private readonly IWorkshopService _workshopService;

    public WorkshopsController(IWorkshopService workshopService)
    {
        _workshopService = workshopService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _workshopService.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = e.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _workshopService.GetAllAsync());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(WorkshopCreateDto workshopDto)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _workshopService.CreateAsync(workshopDto));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(WorkshopUpdateDto workshopDto)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _workshopService.UpdateAsync(workshopDto));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = e.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _workshopService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = e.Message });
        }
    }
}
