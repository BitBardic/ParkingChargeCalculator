using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingChargeCalculator
{
    public interface IStay
    {
        decimal CalculateCharges(DateTime StartDate, DateTime EndDate);
    }
}
