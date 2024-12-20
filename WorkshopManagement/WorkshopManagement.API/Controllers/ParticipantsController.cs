using Microsoft.AspNetCore.Mvc;
using WorkshopManagement.BL.DTOs;
using WorkshopManagement.BL.Services.Abstractions;

namespace WorkshopManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ParticipantsController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantsController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _participantService.GetByIdAsync(id));
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
            return StatusCode(StatusCodes.Status200OK, await _participantService.GetAllAsync());
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ParticipantCreateDto participantDto)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _participantService.CreateAsync(participantDto));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = e.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(ParticipantUpdateDto participantDto)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _participantService.UpdateAsync(participantDto));
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
            await _participantService.DeleteAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = e.Message });
        }
    }
}
