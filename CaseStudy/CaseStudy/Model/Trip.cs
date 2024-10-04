namespace CaseStudy.Model
{
    public class Trip
    {
        public int TripID { get; set; }
        public int? VehicleID { get; set; }
        public int? RouteID { get; set; }
        public int? DriverID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string? TripStatus { get; set; }
        public int? MaxPassengers { get; set; }
               

        public Trip() { }
        public Trip(int tripID, int? vehicleID, int? routeID, int? driverID, DateTime departureDate, DateTime arrivalDate, string? tripStatus, int? maxPassengers)
        {
            TripID = tripID;
            VehicleID = vehicleID;
            RouteID = routeID;
            DriverID = driverID;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            TripStatus = tripStatus;
            MaxPassengers = maxPassengers;
        }

        public override string ToString()
        {
            return $"TripID: {TripID}\tVehicleID: {VehicleID}\tRouteID: {RouteID}\tDriverID: {DriverID}\tDeparture Date: {DepartureDate}\tArrival Date: {ArrivalDate}\tTrip Status: {TripStatus}\tMax Passengers: {MaxPassengers}";
        }
    }
}
