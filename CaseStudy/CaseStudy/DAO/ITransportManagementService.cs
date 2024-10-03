using CaseStudy.Model;
namespace CaseStudy.DAO
{
    internal interface ITransportManagementService
    {
        bool AddVehicle(Vehicle vehicle);
        //bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleID);

        bool ScheduleTrip(int vehicleID, int routeID, string departureDate, string arrivalDate);

        bool CancelTrip(int tripID);

        //bool BookTrip(int tripID, int passengerID, string bookingDate);

        bool CancelBooking(int bookingID);

        //bool AllocateDriver(int tripID, int driverID);

        //bool DeallocateDriver(int tripID);

        List<Booking> GetBookingsByPassenger(int passengerID);

        List<Booking> GetBookingsByTrip(int tripID);

        List<Driver> GetAvailableDrivers();
    }
}
