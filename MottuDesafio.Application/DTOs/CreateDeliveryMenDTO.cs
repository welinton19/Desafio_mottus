using MottuDesafio.Domain.Enum;

namespace MottuDesafio.Application.DTOs;

public class CreateDeliveryMenDTO
{
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? CnhNumber { get; set; }

    public CnhType CnhType { get; set; }

    public string? CnhImagePath { get; set; }
}
