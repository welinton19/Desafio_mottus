using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;

namespace Desafio_Back_End.Net.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LeaseController : ControllerBase
{
    private readonly ILeaseService _leaseService;

    public LeaseController(ILeaseService leaseService)
    {
        _leaseService = leaseService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateLease([FromBody] CreateLeaseDTO createLeaseDTO)
    {
        var result = await _leaseService.CreateLeaseAsync(createLeaseDTO);
        return Ok(result);
    }
     [HttpGet("list")]
     public async Task<IActionResult> GetAllLeases()
     {
         var result = await _leaseService.GetAllAsync();
         return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetLeases(int id) 
    {
        var result = _leaseService.GetLeaseByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateLease(int id, [FromBody] UpdateLeaseDTO updateLeaseDTO)
    {
        var result = await _leaseService.UpdateLeaseAsync(updateLeaseDTO);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public void DeleteLease(int id) 
    {
        var result = _leaseService.DeleteLeaseAsync(id);
         if (result != result)
             return;
    }
}
