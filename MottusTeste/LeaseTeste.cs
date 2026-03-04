using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Enum;

namespace MottusTeste;

public class LeaseTeste
{
    [Fact]
    public void Lease_ShouldCreateInstance_WithCorrectProperties()
    {
        // Arrange
        var motorcycle = new Motorcycle
        {
            Id = 1,
            Model = "Honda CG 160",
            Year = new DateOnly(2023, 1, 1),
            Plate = "XYZ1234"
        };

        var user = new User
        {
            Id = 2,
            Name = "Test",
        };

        var deliveryMen = new DeliveryMen
        {
            Id = 3,
            User = user,
            Name = "Carlos Souza",
            Cnpj = "12345678000199",
            DateOfBirth = new DateOnly(1995, 6, 15),
            CnhNumber = "999888777",
            CnhType = CnhType.A
        };

        var startDate = new DateOnly(2026, 3, 1);
        var endDate = new DateOnly(2026, 3, 10);
        var expectedEndDate = new DateOnly(2026, 3, 10);

        // Act
        var lease = new Lease
        {
            MotorcycleId = motorcycle.Id,
            Motorcycle = motorcycle,
            DeliveryMenId = deliveryMen.Id,
            DeliveryMen = deliveryMen,
            StartDate = startDate,
            EndDate = endDate,
            ExpectedEndDate = expectedEndDate,
            Plans = RentalPlans.SevenDays
        };

        // Assert
        Assert.NotNull(lease);
        Assert.Equal(motorcycle.Id, lease.MotorcycleId);
        Assert.Equal(motorcycle, lease.Motorcycle);
        Assert.Equal(deliveryMen.Id, lease.DeliveryMenId);
        Assert.Equal(deliveryMen, lease.DeliveryMen);
        Assert.Equal(startDate, lease.StartDate);
        Assert.Equal(endDate, lease.EndDate);
        Assert.Equal(expectedEndDate, lease.ExpectedEndDate);
        Assert.Equal(RentalPlans.SevenDays, lease.Plans);
    }
}
