using ParkingChargeCalculator;
using System;
using Xunit;

namespace UnitTests.LongStayTests
{
    public class ChargeablePeriod
    {
        private const decimal _perDayCharge = 7.50m;
        private const decimal _WholeWeekExcludingWeekEndCharge = 37.50m;
        private const decimal _WholeWeekIncludingWeekEndCharge = 52.50m;
        private readonly IStay longStay;

        public ChargeablePeriod()
        {
            this.longStay = new LongStay();  
        }

        [Fact]
        public void ChargeShouldBeAppliedForFullDay()
        {
            var result = longStay.CalculateCharges(new DateTime(2017, 09, 07, 0, 0, 0), new DateTime(2017, 09, 07, 0, 0, 0));

            Assert.Equal(_perDayCharge, result);
        }

        [Fact]
        public void ChargeShouldNotAppliedForOneDayWhenTimeSpanIsForTwoDays()
        {
            var result = longStay.CalculateCharges(new DateTime(2017, 09, 07, 0, 0, 0), new DateTime(2017, 09, 08, 0, 0, 0));

            Assert.NotEqual(_perDayCharge, result);
        }

        [Fact]
        public void ChargeShouldBeAppliedForWholeWeekIncludingWeekEnd()
        {
            var result = longStay.CalculateCharges(new DateTime(2017, 09, 04, 0, 0, 0), new DateTime(2017, 09, 10, 23, 59, 0));

            Assert.Equal(_WholeWeekIncludingWeekEndCharge, result);
        }

        [Fact]
        public void ChargeShouldBeAppliedForWholeWeekExcludingWeekEnd()
        {
            var result = longStay.CalculateCharges(new DateTime(2017, 09, 04, 0, 0, 0), new DateTime(2017, 09, 8, 23, 59, 0));

            Assert.Equal(_WholeWeekExcludingWeekEndCharge, result);
        }



    }
}
