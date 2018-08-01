using System;

namespace ParkingChargeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var start1 = DateTime.Parse("07/09/2017 19:30:00");
            var end1 = DateTime.Parse("07/09/2017 20:30:00");

            IStay shortStay = new ShortStay();

            var NotChargeableVisitor = new Visitor(shortStay, start1);
            Console.WriteLine(NotChargeableVisitor.GetParkingCharges(end1));

            var start2 = DateTime.Parse("07/09/2017 16:50:00");
            var end2 = DateTime.Parse("09/09/2017 19:15:00");

            var ShortStayVisitor = new Visitor(shortStay, start2);
            Console.WriteLine(ShortStayVisitor.GetParkingCharges(end2));


            var start3 = DateTime.Parse("07/09/2017 07:50:00");
            var end3 = DateTime.Parse("09/09/2017 05:20:00");

            IStay longStay = new LongStay();

            var LongStayVisitor = new Visitor(longStay, start3);
            Console.WriteLine(LongStayVisitor.GetParkingCharges(end3));

            Console.Read();
            
        }
    }
}
