using CaseStudy.DAO;
using CaseStudy.Main;
using CaseStudy.Model;


namespace CaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            int choice = 0;
            do
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("------------------------------ User Menu ------------------------");
                    Console.WriteLine("\n1. Login");
                    Console.WriteLine("\n2. Register");
                    Console.WriteLine("\n3. Exit");
                    Console.Write("> ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            menu.Login();
                            break;
                        case 2:
                            menu.UserMenu();
                            break;
                        case 3:
                            Console.Beep();
                            Console.WriteLine("Exiting Application");
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choice != 3) ;
        }
    }
}






































//ITransportManagementService transport = new TransportManagementServiceImp();;
//Vehicle vehicle = new Vehicle(1,"Ford",10.00,"Van","On Trip");
//vehicle.ToString();
//Console.WriteLine(transport.AddVehicle(vehicle));
//Console.WriteLine(transport.DeleteVehicle(5));
//Console.WriteLine(transport.CancelTrip(1));
//Console.WriteLine(transport.ScheduleTrip(4,2,"2024-10-03","2024-10-04"));
//Console.WriteLine(transport.CancelBooking(2));
//List<Booking> bookingsByTripId = transport.GetBookingsByTrip(1);
//List<Driver> drivers = transport.GetAvailableDrivers();
//List<Booking> bookingsByPassengers = transport.GetBookingsByPassenger(2);
//foreach(Booking booking in bookingsByPassengers)
//{
//    Console.WriteLine(booking.ToString());
//}
