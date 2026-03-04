using MottuDesafio.Domain.Enum;

namespace MottuDesafio.Application.DTOs;

public class CreateLeaseDTO
{
    public int MotorcycleId { get; set; }
    public int DeliveryMenId { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly ExpectedEndDate { get; set; }
    public RentalPlans Plans { get; set; }
}
