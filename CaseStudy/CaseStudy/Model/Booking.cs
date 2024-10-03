namespace CaseStudy.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int? TripID { get; set; }
        public int? PassengerID { get; set; }
        public DateTime? BookingDate { get; set; }
        public string? BookingsStatus { get; set; }
        public Booking(int bookingID, int? tripID, int? passengerID, DateTime? bookingDate, string? bookingStatus)
        {
            BookingID = bookingID;
            TripID = tripID;
            PassengerID = passengerID;
            BookingDate = bookingDate;
            BookingsStatus = bookingStatus;
        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}\t TripID: {TripID}\t PassengerID: {PassengerID}\t Booking Date: {BookingDate}\t Booking Status: {BookingsStatus}";
        }
    }
}
