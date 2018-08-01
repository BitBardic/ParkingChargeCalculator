using System;

namespace ParkingChargeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start1 = DateTime.Parse("07/09/2017 19:30:00");
            DateTime end1 = DateTime.Parse("07/09/2017 20:30:00");

            var NotChargeableVisitor = new Visitor(new ShortStay(), start1);
            Console.WriteLine(NotChargeableVisitor.GetParkingCharges(end1));

            DateTime start2 = DateTime.Parse("07/09/2017 16:50:00");
            DateTime end2 = DateTime.Parse("09/09/2017 19:15:00");

            var ShortStayVisitor = new Visitor(new ShortStay(), start2);
            Console.WriteLine(ShortStayVisitor.GetParkingCharges(end2));


            DateTime start3 = DateTime.Parse("07/09/2017 07:50:00");
            DateTime end3 = DateTime.Parse("09/09/2017 05:20:00");

            var LongStayVisitor = new Visitor(new LongStay(), start3);
            Console.WriteLine(LongStayVisitor.GetParkingCharges(end3));

            Console.Read();
            
        }
    }
}
