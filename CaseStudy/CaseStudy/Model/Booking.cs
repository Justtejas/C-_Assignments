namespace CaseStudy.Model
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int? TripID { get; set; }
        public int? PassengerID { get; set; }
        public string? BookingDate { get; set; }
        public string? VehicleStatus { get; set; }
        public Booking(int bookingID, int? tripID, int? passengerID, string? bookingDate, string? vehicleStatus)
        {
            BookingID = bookingID;
            TripID = tripID;
            PassengerID = passengerID;
            BookingDate = bookingDate;
            VehicleStatus = vehicleStatus;
        }

        public override string ToString()
        {
            return $"BookingID: {BookingID}\t TripID: {TripID}\t PassengerID: {PassengerID}\t BookingDate: {BookingDate}\t VehicleStatus: {VehicleStatus}";
        }
    }
}
