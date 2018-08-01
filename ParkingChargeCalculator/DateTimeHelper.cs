using System;

namespace ParkingChargeCalculator
{
    public class DateTimeHelper
    {
        public static int CalculateWeekDayHours(DateTime StartDate, DateTime EndDate)
        {
            int hourCount = 0;
            var totalHours = EndDate.Subtract(StartDate).TotalHours;
            if (totalHours < 1)
                return hourCount;

            for (var i = StartDate; i < EndDate; i = i.AddHours(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (i.TimeOfDay.Hours >= 8 && i.TimeOfDay.Hours <= 18)
                    {
                        hourCount++;
                    }
                }
            }

            return hourCount;
        }

        public static DateTime AdjustDateHourMinute(DateTime Date)
        {
            if (Date.Hour >= 18 && Date.Minute >= 0)
            {
                return new DateTime(Date.Year, Date.Month, Date.Day, 18, 0, 0);

            }

            if (Date.Hour <= 8 && Date.Minute <= 0)
            {
                return new DateTime(Date.Year, Date.Month, Date.Day, 8, 0, 0);
            }

            return Date;
        }

        public static int CalculateDays(DateTime StartDate, DateTime EndDate)
        {
            return (EndDate.Date - StartDate.Date).Days + 1;
        }

    }
}
