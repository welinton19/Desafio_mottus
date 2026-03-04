using MottuDesafio.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace MottusTeste;

public class MotorcycleTeste
{
    [Fact]
    public void Motorcycle_Creation_ShouldSetProperties()
    {
        // Arrange
        var model = "Honda CB500";
        var year = new DateOnly(2022, 1, 1);
        var plate = "ABC1234";

        // Act
        var motorcycle = new Motorcycle
        {
            Model = model,
            Year = year,
            Plate = plate
        };

        // Assert
        Assert.NotNull(motorcycle);
        Assert.Equal(model, motorcycle.Model);
        Assert.Equal(year, motorcycle.Year);
        Assert.Equal(plate, motorcycle.Plate);
        Assert.Equal(0, motorcycle.Id); 
    }

    [Fact]
    public void Motorcycle_DefaultConstructor_ShouldHaveDefaultValues()
    {
        // Act
        var motorcycle = new Motorcycle();
        // Assert
        Assert.NotNull(motorcycle);
        Assert.Null(motorcycle.Model);
        Assert.Null(motorcycle.Year);
        Assert.Null(motorcycle.Plate);
        Assert.Equal(0, motorcycle.Id);
    }

    [Fact]
    public void Motorcycle_SetProperties_ShouldUpdateValues()
    {
        // Arrange
        var motorcycle = new Motorcycle();
        var newModel = "Yamaha MT-07";
        var newYear = new DateOnly(2023, 1, 1);
        var newPlate = "XYZ5678";
        // Act
        motorcycle.Model = newModel;
        motorcycle.Year = newYear;
        motorcycle.Plate = newPlate;
        // Assert
        Assert.Equal(newModel, motorcycle.Model);
        Assert.Equal(newYear, motorcycle.Year);
        Assert.Equal(newPlate, motorcycle.Plate);
    }

    [Fact]
    public void Motorcycle_Id_ShouldBeSettable()
    {
        // Arrange
        var motorcycle = new Motorcycle();
        var newId = 10;
        // Act
        motorcycle.Id = newId;
        // Assert
        Assert.Equal(newId, motorcycle.Id);
    }
}
