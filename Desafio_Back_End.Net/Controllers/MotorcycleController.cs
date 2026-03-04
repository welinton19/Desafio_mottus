using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;

namespace Desafio_Back_End.Net.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MotorcycleController : ControllerBase
{
    private readonly IMotorcyclerService _motorcycleService;

    public MotorcycleController(IMotorcyclerService motorcycleService)
    {
        _motorcycleService = motorcycleService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateMotorcycle([FromBody] CreateMotorcycleDTO motorcycleDto)
    {
        var result = await _motorcycleService.CreateMotorcyclerAsync(motorcycleDto);
        return Ok(result);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAllMotorcycles()
    {
        var result = await _motorcycleService.GetAllMotorcyclersAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetMotorcycle(int id) {
        var result = _motorcycleService.GetMotorcyclerByIdAsync(id);
        if (result == null)
            return NotFound("Motorcycle not found.");
        return Ok(result);
    }
     [HttpPut("{id}")]
     [Authorize(Roles = "Admin")]
     public async Task<IActionResult> UpdateMotorcycle(int id, [FromBody] UpdateMotorcycleDTO motorcycleDto)
     {
         var result = await _motorcycleService.UpdateMotorcyclerAsyn( motorcycleDto);
         if (result == null)
             return NotFound("Motorcycle not found.");
         return Ok(result);
     }
     [HttpDelete("{id}")]
     [Authorize(Roles = "Admin")]
     public async Task<IActionResult> DeleteMotorcycle(int id)
     {
         var result = await _motorcycleService.DeletMotorcyclerAsync(id);
         if (result != result)
             return NotFound("Motorcycle not found.");
         return NoContent();
    }
}
