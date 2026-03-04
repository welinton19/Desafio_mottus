using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MottuDesafio.Application.DTOs;

public class DeliveryMenGetDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    [Required(ErrorMessage = "the Name of DeliveryMen is Required!")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "the Cnpj of DeliveryMen is Required")]
    public string? Cnpj { get; set; }
    [Required(ErrorMessage = "the DateOfBirth of DeliveryMen is Required")]
    public DateOnly DateOfBirth { get; set; }
    [Required(ErrorMessage = "the CnhNumber of DeliveryMen is Required")]
    public string? CnhNumber { get; set; }

    [Required(ErrorMessage = "the CnhType of DeliveryMen is Required")]
    public CnhType CnhType { get; set; }

    public string? CnhImagePath { get; set; }
}
