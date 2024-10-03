using CaseStudy.DAO;
using CaseStudy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ITransportManagementService transport = new TransportManagementServiceImp();;
            //Vehicle vehicle = new Vehicle(1,"Ford",10.00,"Van","On Trip");
            //vehicle.ToString();
            //Console.WriteLine(transport.AddVehicle(vehicle));
            //Console.WriteLine(transport.DeleteVehicle(5));
            //Console.WriteLine(transport.CancelTrip(1));
            //Console.WriteLine(transport.ScheduleTrip(4,2,"2024-10-03","2024-10-04"));
            //Console.WriteLine(transport.CancelBooking(2));
            List<Booking> bookingsByTripId = transport.GetBookingsByTrip(1);
            foreach(Booking booking in bookingsByTripId)
            {
                Console.WriteLine(booking.ToString());
            }
        }
    }
}
