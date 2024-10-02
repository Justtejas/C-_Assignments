namespace CaseStudy.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int TripID { get; set; }
        public int PassengerID { get; set; }
        public string BookingDate { get; set; }
        public string Status { get; set; }
    }
}
