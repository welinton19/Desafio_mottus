using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Enum;

namespace MottuDesafio.Application.DTOs;

public class UpdateLeaseDTO
{
    public MotorCycleGetDTO motorcycle { get; set; }
    public DeliveryMen deliveryMen { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public RentalPlans Plans { get; set; }
}
