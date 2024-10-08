using CaseStudy.DAO;
using CaseStudy.Exceptions;
using CaseStudy.Model;

namespace CaseStudy.Main.SubMenus
{
    internal class BookingsMenu
    {
        readonly ITransportManagementService _transport = new TransportManagementServiceImp();
        readonly PrettyConsole _prettyConsole = new();
        public BookingsMenu()
        {
            Console.Title = "Booking Trip";
        }

        public void Menu(Passenger passenger)
        {
            int choice = 0;
            do
            {
                Console.WriteLine($"Your Passenger ID is {passenger.PassengerID}");
                try
                {
                    Console.WriteLine("\n------------------------------ Booking Trip ------------------------\n");
                    Console.WriteLine("1. Book Trip");
                    Console.WriteLine("2. Cancel Booking");
                    Console.WriteLine("3. Get your bookings");
                    Console.WriteLine("4. Schedule Trips");
                    Console.WriteLine("5. Exit");
                    Console.Write("> ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            BookTrip(passenger);
                            break;
                        case 2:
                            CancelTripMenu();
                            break;
                        case 3:
                            DisplayBookings(passenger);
                            break;
                        case 4:
                            ScheduleMenu();
                            break;
                        case 5:
                            Console.WriteLine("Booking Menu Exited.");
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid Option! Try again");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choice != 5);
        }

        private void ScheduleMenu()
        {
            _prettyConsole.Table(_transport.GetAvailableVehicles());
            Console.WriteLine("Enter the Vehicle id");
            Console.Write("> ");
            int vehicleID = Convert.ToInt32(Console.ReadLine());
            _transport.DisplayRoutes();
            Console.WriteLine("Enter the Route id");
            Console.Write("> ");
            int routeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Enter the Departure date (yyyy-mm-dd)\n");
            Console.Write("> ");
            DateTime departureDate = Convert.ToDateTime(Console.ReadLine());
            if (departureDate < DateTime.Now)
            {
                _prettyConsole.Print("The bookind date cannot be less than the current Date", "fail");
            }
            Console.WriteLine("\n Enter the Arrival date (yyyy-mm-dd)\n");
            Console.Write("> ");
            DateTime arrivalDate = Convert.ToDateTime(Console.ReadLine());
            if (arrivalDate < DateTime.Now)
            {
                _prettyConsole.Print("The bookind date cannot be less than the current Date", "fail");
            }
            bool status = _transport.ScheduleTrip(vehicleID,routeID,departureDate,arrivalDate);
            if (status)
            {
                _prettyConsole.Print("Trips scheduled successfully", "success");
            }
            else
            {
                _prettyConsole.Print("Could not schedule trip", "fail");
            }
        }
        private void DisplayBookings(Passenger passenger)
        {
            try
            {
                List<Booking> bookings = _transport.GetBookingsByPassenger(passenger.PassengerID);
                if (bookings == null || bookings.Count == 0)
                {
                    throw new BookingNotFoundException($"There are no bookings for passenger ID {passenger.PassengerID}",passenger.PassengerID);
                }
                else
                {
                    _prettyConsole.Table(bookings);
                }
            }
            catch(BookingNotFoundException bnfe)
            {
                _prettyConsole.Print(bnfe.Message,"exception");
            }
        }
        private void CancelTripMenu()
        {
            Console.WriteLine("Insert the Trip ID to cancel");
            Console.Write("> ");
            int tripID = Convert.ToInt32(Console.ReadLine());
            bool cancelStatus = _transport.CancelTrip(tripID);
            if (cancelStatus)
            {
                _prettyConsole.Print($"Cancelled Trip {tripID} Successfully","success");
            }
        }
        private void BookTrip(Passenger passenger)
        {
            Console.WriteLine($"Your Passenger ID is {passenger.PassengerID}");
            try
            {
                Console.Clear();
                Console.WriteLine();
                _prettyConsole.Table(_transport.GetTrips());
                Console.WriteLine("\nSelect Trip by entering the ID\n");
                Console.Write("> ");
                int tripID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter the booking date (yyyy-mm-dd)\n");
                Console.Write("> ");
                DateTime bookingDate = Convert.ToDateTime(Console.ReadLine());
                if (bookingDate < DateTime.Now)
                {
                    _prettyConsole.Print("The bookind date cannot be less than the current Date", "fail");
                }
                else
                {
                    bool status = _transport.BookTrip(tripID, passenger.PassengerID, bookingDate);
                    if (status)
                    {
                        _prettyConsole.Print("Trip Booked Successfully", "success");
                    }
                    else
                    {
                        _prettyConsole.Print("Unable to book the trip", "fail");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
