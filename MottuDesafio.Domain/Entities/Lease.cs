using MottuDesafio.Domain.Enum;

namespace MottuDesafio.Domain.Entities;

public class Lease
{
    public int Id { get; set; }

    public int MotorcycleId { get; set; }
    public Motorcycle Motorcycle { get; set; }

    public int DeliveryMenId { get; set; }
    public DeliveryMen DeliveryMen { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateOnly ExpectedEndDate { get; set; }
    public RentalPlans Plans { get; set; }
}
