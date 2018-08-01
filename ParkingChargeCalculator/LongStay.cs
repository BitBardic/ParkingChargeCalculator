using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingChargeCalculator
{
    public class LongStay : IStay
    {
        const decimal PerDayCharge = 7.50M;
        public decimal CalculateCharges(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate > EndDate)
                throw new ArgumentException("Start date must be before the End date.");

            var TotalCharges = DateTimeHelper.CalculateDays(StartDate, EndDate) * PerDayCharge;
            return TotalCharges;
        }
    }
}
