using System;

namespace ParkingChargeCalculator
{
    public class ShortStay : IStay
    {
        const decimal PerHourCharge = 1.10M;
        public decimal CalculateCharges(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate > EndDate)
                throw new ArgumentException("Start date must be before the End date.");

            var aSDateTime = DateTimeHelper.AdjustDateHourMinute(StartDate);
            var aEDateTime = DateTimeHelper.AdjustDateHourMinute(EndDate);

            var minutes = aEDateTime.Subtract(aSDateTime).Minutes;
            var PerMinuteCharge = 110M / 60M;

            var MinutelyCharges = decimal.Round((minutes * PerMinuteCharge) / 100, 2, MidpointRounding.AwayFromZero);

            aSDateTime = DateTimeHelper.RoundedHour(aSDateTime, minutes);
            aEDateTime = DateTimeHelper.RoundedHour(aEDateTime, minutes);

            var WeekDayHours = DateTimeHelper.CalculateWeekDayHours(aSDateTime, aEDateTime);

            var HourlyCharges = WeekDayHours * PerHourCharge;

            var TotalCharges = HourlyCharges + MinutelyCharges;

            return TotalCharges;
        }
    }
}
