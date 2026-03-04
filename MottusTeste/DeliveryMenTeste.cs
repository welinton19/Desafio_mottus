using MottuDesafio.Domain.Entities;
using MottuDesafio.Domain.Enum;

namespace MottusTeste;

public class DeliveryMenTeste
{
    [Fact]
    public void DeliveryMen_DefaultConstructor_ShouldCreateInstance()
    {
        // Act
        var deliveryMen = new DeliveryMen();

        // Assert
        Assert.NotNull(deliveryMen);
        Assert.Equal(0, deliveryMen.Id);
    }

    [Fact]
    public void DeliveryMen_ParameterizedConstructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var user = new User
        {
            Id = 1,

        };

        var name = "João Silva";
        var cnpj = "12345678000199";
        var dateOfBirth = new DateOnly(1990, 5, 10);
        var cnhNumber = "987654321";
        var cnhType = CnhType.A;

        // Act
        var deliveryMen = new DeliveryMen(
            user,
            name,
            cnpj,
            dateOfBirth,
            cnhNumber,
            cnhType
        );

        // Assert
        Assert.NotNull(deliveryMen);
        Assert.Equal(user, deliveryMen.User);
        Assert.Equal(name, deliveryMen.Name);
        Assert.Equal(cnpj, deliveryMen.Cnpj);
        Assert.Equal(dateOfBirth, deliveryMen.DateOfBirth);
        Assert.Equal(cnhNumber, deliveryMen.CnhNumber);
        Assert.Equal(cnhType, deliveryMen.CnhType);
    }
}
