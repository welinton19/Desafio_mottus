using MottuDesafio.Domain.Enum;

namespace MottuDesafio.Domain.Entities;

public class DeliveryMen
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string? Name { get; set; }
    public string? Cnpj { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? CnhNumber { get; set; }

    public CnhType CnhType { get; set; }

    public string? CnhImagePath { get; set; }

    public DeliveryMen() { }

    public DeliveryMen(User user, string name, string cnpj, DateOnly dateOfBirth, string cnhNumber, CnhType cnhType)
    {
        User = user;
        Name = name;
        Cnpj = cnpj;
        DateOfBirth = dateOfBirth;
        CnhNumber = cnhNumber;
        CnhType = cnhType;
    }
}
