using CaseStudy.Model;
namespace CaseStudy.DAO
{
    internal interface ITransportManagementService
    {
        bool IsVehiclePresent(int vehicleId);
        bool UpdateVehicle(string fieldName, object? newValue, int vehicleID);
        List<Vehicle> GetVehicles();
        bool AddVehicle(Vehicle vehicle);
        bool AddPassenger(string name, string gender, int age, string email, string phoneNumber,string password);
        bool CheckUser(string email, string password);
        Passenger GetPassenger(string email);
        List<Vehicle> GetAvailableVehicles();
        List<Trip> GetTrips();
        void DisplayRoutes();
        
        bool DeleteVehicle(int vehicleID);

        bool ScheduleTrip(int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate);

        bool CancelTrip(int tripID);

        bool BookTrip(int tripID, int passengerID, DateTime bookingDate);

        bool CancelBooking(int bookingID);

        bool AllocateDriver(int tripID, int driverID);

        bool DeallocateDriver(int tripID); 
        List<Booking> GetBookingsByPassenger(int passengerID);

        List<Booking> GetBookingsByTrip(int tripID);

        List<Driver> GetAvailableDrivers();
    }
}
