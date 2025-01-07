using HospitalManagement.BL.DTOs;
using HospitalManagement.BL.Exceptions.BaseExceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class InsurancesController : ControllerBase
{
    readonly IInsuranceService _service;

    public InsurancesController(IInsuranceService service)
    {
        _service = service;
    }

    [HttpGet("{id}", Name = "GetInsuranceById")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [HttpGet(Name = "GetAllInsurances")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await _service.GetAllAsync());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [HttpPost("Create", Name = "CreateInsurance")]
    public async Task<IActionResult> CreateInsurance(InsuranceCreateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Insurance insurance = await _service.CreateAsync(dto);
            await _service.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, insurance);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [HttpPut("Update", Name = "UpdateInsurance")]
    public async Task<IActionResult> UpdateInsurance(InsuranceUpdateDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            Insurance insurance = await _service.UpdateAsync(dto);
            await _service.SaveChangesAsync();
            return Ok(insurance);
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [HttpPatch("Recover", Name = "RecoverInsurance")]
    public async Task<IActionResult> RecoverInsurance(int id)
    {
        try
        {
            await _service.RecoverAsync(id);
            await _service.SaveChangesAsync();
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [HttpPatch("SoftDelete", Name = "SoftDeleteInsurance")]
    public async Task<IActionResult> SoftDeleteInsurance(int id)
    {
        try
        {
            await _service.SoftDeleteAsync(id);
            await _service.SaveChangesAsync();
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }

    [HttpDelete("HardDelete", Name = "HardDeleteInsurance")]
    public async Task<IActionResult> HardDeleteInsurance(int id)
    {
        try
        {
            await _service.HardDeleteAsync(id);
            await _service.SaveChangesAsync();
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Something went wrong!" });
        }
    }
}
