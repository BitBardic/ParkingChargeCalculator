using ParkingChargeCalculator;
using System;
using Xunit;

namespace UnitTests.ShortStayTests
{
    public class NonChargeablePeriod
    {
        private const decimal _noCharge = 0.00m;
        private readonly IStay shortStay;
        public NonChargeablePeriod()
        {
            shortStay = new ShortStay();
        }

        [Fact]
        public void ChargeShouldBeZeroOutSideOfChargingPeriod()
        {
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 19, 30, 0), new DateTime(2017, 09, 07, 20, 30, 0));

            Assert.Equal(_noCharge, result);
        }

        [Fact]
        public void ChargeShouldNotBeZeroWithInChargingPeriod()
        {
           
            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 07, 12, 30, 0), new DateTime(2017, 09, 07, 18, 0, 0));

            Assert.NotEqual(_noCharge, result);
        }

        [Fact]
        public void ChargeShouldBeZeroForWeekEnd()
        {

            var result = shortStay.CalculateCharges(new DateTime(2017, 09, 09, 0, 0, 0), new DateTime(2017, 09, 10, 23, 59, 0));

            Assert.Equal(_noCharge, result);
        }
    }
}
