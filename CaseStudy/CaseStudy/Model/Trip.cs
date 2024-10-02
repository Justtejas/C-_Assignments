namespace CaseStudy.Model
{
    public class Trip
    {
        public int TripID { get; set; }
        public int VehicleID { get; set; }
        public int RouteID { get; set; }
        public int DriverID { get; set; }
        public string DepartureDate { get; set; }
        public string ArrivalDate { get; set; }
    }
}
