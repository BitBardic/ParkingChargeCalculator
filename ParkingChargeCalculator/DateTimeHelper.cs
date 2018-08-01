using System;

namespace ParkingChargeCalculator
{
    public class DateTimeHelper
    {
        public static int CalculateWeekDayHours(DateTime startDate, DateTime endDate)
        {
            int hourCount = 0;

            var totalHours = endDate.Subtract(startDate).TotalHours;
            if (totalHours < 1)
                return hourCount;

            for (var i = startDate; i < endDate; i = i.AddHours(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (i.TimeOfDay.Hours >= 8 && i.TimeOfDay.Hours < 18)
                    {
                        hourCount++;
                    }
                }
            }

            return hourCount;
        }

        public static DateTime AdjustDateHourMinute(DateTime dateTime)
        {
            if (dateTime.Hour >= 18 && dateTime.Minute >= 0)
            {
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 18, 0, 0);

            }

            if (dateTime.Hour <= 8 && dateTime.Minute <= 0)
            {
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 8, 0, 0);
            }

            return dateTime;
        }

        public static int CalculateDays(DateTime startDate, DateTime endDate)
        {
            return (endDate.Date - startDate.Date).Days + 1;
        }

        public static DateTime RoundedHour(DateTime dateTime, int minutes)
        {
            var i = 0;
            var dateTimeMinutes = dateTime.Minute;
            while (i < minutes)
            {
                dateTimeMinutes += 1;
                i++;
                if (dateTimeMinutes % 60 == 0)
                { 
                   dateTime = dateTime.AddMinutes(i);
                   return dateTime;
                }
            }

            return dateTime;
        }

    }
}
