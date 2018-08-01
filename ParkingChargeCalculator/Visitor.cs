using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingChargeCalculator
{
    public class Visitor
    {
        private readonly IStay Stay;
        private readonly DateTime StartTime;
        public Visitor(IStay Stay, DateTime StartTime)
        {
            this.Stay = Stay;
            this.StartTime = StartTime;
        }

        public decimal GetParkingCharges(DateTime EndTime)
        {
            return this.Stay.CalculateCharges(this.StartTime, EndTime);
        }
    }
}
