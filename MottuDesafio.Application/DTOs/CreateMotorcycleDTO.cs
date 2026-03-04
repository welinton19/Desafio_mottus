using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuDesafio.Application.DTOs;

public class CreateMotorcycleDTO
{
    public string Model { get; set; }
    public string Plate { get; set; }
    public DateOnly Yaer {  get; set; }
}
