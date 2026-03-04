using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MottuDesafio.Application.DTOs;
using MottuDesafio.Application.Interfaces;

namespace Desafio_Back_End.Net.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeliveryMenController : ControllerBase
{
    private readonly IDeliveryMenService _deliveryMenService;

    public DeliveryMenController(IDeliveryMenService deliveryMenService)
    {
        _deliveryMenService = deliveryMenService;
    }

    [HttpPost("create")]
   public async Task<IActionResult> CreateDeliveryMen([FromBody] CreateDeliveryMenDTO deliveryMenDto)
    {
        var result = await _deliveryMenService.CreateDeliveryMenAsync(deliveryMenDto);
        return Ok(result);
    }
     [HttpGet("list")]
     public async Task<IActionResult> GetAllDeliveryMen()
     {
         var result = await _deliveryMenService.GetAllDeliveryMenAsync();
         return Ok(result);
     }
     [HttpGet("{id}")]
     public IActionResult GetDeliveryMen(int id) 
     {
         var result = _deliveryMenService.GetDeliveryMenByIdAsync(id);
         if (result == null)
             return NotFound();
         return Ok(result);
     }
     [HttpPut("{id}")]
     public async Task<IActionResult> UpdateDeliveryMen(int id, [FromBody] UpdateDeliveryMenDTO updateDeliveryMenDTO)
     {
         var result = await _deliveryMenService.UpdateDeliveryMenAsync(updateDeliveryMenDTO);
         if (result == null)
             return NotFound();
         return Ok(result);
     }
     [HttpDelete("{id}")]
     public void DeleteDeliveryMen(int id) 
     {
         var result = _deliveryMenService.DeleteDeliveryMenAsync(id);
          if (result != result)
              return;
          return;
    }   
}
