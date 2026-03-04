using System.ComponentModel.DataAnnotations;

namespace MottuDesafio.Application.DTOs;

public class MotorCycleGetDTO
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "the Model of Motorcycle is Required!")]
    public string? Model { get; set; }
    [Required(ErrorMessage = "the Year of Motorcycle is Required!")]
    public DateOnly? Year { get; set; }
    [Required(ErrorMessage = "the Plate of Motorcycle is Required!")]
    public string? Plate { get; set; }
}
