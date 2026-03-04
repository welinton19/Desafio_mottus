using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuDesafio.Domain.Services;

public class RentalCalculatorServices
{
    private static readonly Dictionary<int, decimal> Plans = new()
    {
        {7,30},
        {15,28},
        {30,22},
        {45,20},
        {50,18}
    };

    public decimal GetDailyPrices(int days) 
    {
        return Plans[days];
    }
}
