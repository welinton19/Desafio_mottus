namespace MottuDesafio.Domain.Entities;

public class Motorcycle
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public DateOnly? Year { get; set; }
    public string? Plate { get; set; }
}
