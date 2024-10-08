namespace CaseStudy.Model
{
    public class Trip
    {
        public int TripID { get; set; }
        public int? VehicleID { get; set; }
        public int? RouteID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string? TripStatus { get; set; }
        public string? TripType { get; set; }
        public int? MaxPassengers { get; set; }
        public int? DriverID { get; set; }

        public Trip() { }
        public Trip(int tripID, int? vehicleID, int? routeID, DateTime departureDate, DateTime arrivalDate, string? tripStatus,string? tripType, int? maxPassengers, int? driverID)
        {
            TripID = tripID;
            VehicleID = vehicleID;
            RouteID = routeID;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            TripStatus = tripStatus;
            TripType = tripType;
            MaxPassengers = maxPassengers;
            DriverID = driverID;
        }

        public override string ToString()
        {
            return $"TripID: {TripID}\tVehicleID: {VehicleID}\tRouteID: {RouteID}\tDriverID: {DriverID}\tDeparture Date: {DepartureDate}\tArrival Date: {ArrivalDate}\tTrip Status: {TripStatus}\tMax Passengers: {MaxPassengers}";
        }
    }
}
