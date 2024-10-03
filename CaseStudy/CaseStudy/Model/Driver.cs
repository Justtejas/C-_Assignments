namespace CaseStudy.Model
{
    public class Driver
    {
        public int DriverID { get; set; }
        public int? TripID { get; set; }
        public string Name { get; set; }

        public Driver( int driverID, int? tripID, string name)
        {
            DriverID = driverID;
            TripID = tripID;
            Name = name;
        }

        public override string ToString()
        {
            return $"DriverID: {DriverID}\tTripID: {TripID}\tName: {Name}";
        }
    }
}
