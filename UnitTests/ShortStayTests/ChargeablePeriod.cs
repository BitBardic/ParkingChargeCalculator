using ParkingChargeCalculator;
using System;
using Xunit;

namespace UnitTests.ShortStayTests
{
    public class ChargeablePeriod
    {
        private const decimal _hourlyCharge = 1.10m;
        private const decimal _halfAnHourCharge = 0.55m;
        private const int _fullDayHourlyCharge = 11;
        private readonly IStay shortStay;
        public ChargeablePeriod()
        {
            shortStay = new ShortStay();
        }

        [Fact]
        public void ChargeShouldBeAppliedForAnHour()
        {
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 14, 30, 0), new DateTime(2017, 09, 07, 15, 30, 0));

            Assert.Equal(_hourlyCharge, result);
        }

        [Fact]
        public void ChargeShouldNotBeAppliedForAnHour()
        {
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 14, 0, 0), new DateTime(2017, 09, 07, 16, 0, 0));

            Assert.NotEqual(_hourlyCharge, result);
        }

        [Fact]
        public void ChargeShouldBeAppliedForHalfAnHour()
        {
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 14, 30, 0), new DateTime(2017, 09, 07, 15, 0, 0));

            Assert.Equal(_halfAnHourCharge, result);
        }

        [Fact]
        public void ChargeShouldNotBeAppliedForHalfAnHour()
        {
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 14, 30, 0), new DateTime(2017, 09, 07, 15, 30, 0));

            Assert.NotEqual(_halfAnHourCharge, result);
        }

        [Fact]
        public void ChargeShouldBeAppliedForFullDay()
        {
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 8, 0, 0), new DateTime(2017, 09, 07, 18, 0, 0));

            Assert.Equal(_fullDayHourlyCharge, result);
        }
    }
}
