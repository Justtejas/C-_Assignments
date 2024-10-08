using CaseStudy.DAO;
using CaseStudy.Exceptions;
using NUnit.Framework;

namespace CaseStudy.Tests
{
    [TestFixture]
    public class Test
    {

        [Test]
        public void Test_To_BookTrip()
        {
            ITransportManagementService testTMS = new TransportManagementServiceImp();
            int tripID = 0;
            int passengerID = 9;
            DateTime bookingDate = Convert.ToDateTime("2024-11-09");

            bool bookTripStatus = testTMS.BookTrip(tripID, passengerID,bookingDate);
            Assert.That(bookTripStatus, Is.True, "Trip Booked Successfully");
        }
        [Test]
        public void GetBookingsByPassenger_Throws_Exception()
        {
            ITransportManagementService testTMS = new TransportManagementServiceImp();
            int passengerID = 23;

            var ex = Assert.Throws<BookingNotFoundException>(() => testTMS.GetBookingsByPassenger(passengerID));
            Assert.That(ex.Message, Is.EqualTo($"Could not find any bookings for {passengerID}"));
        }
        [Test]
        public void GetVehicles_Throws_Exception()
        {
            ITransportManagementService testTMS = new TransportManagementServiceImp();
            int vehicleID = 4;

            var ex = Assert.Throws<VehicleNotFoundException>(() => testTMS.IsVehiclePresent(vehicleID));
            Assert.That(ex.Message, Is.EqualTo($"Could not find any vehicle for vehicle id {vehicleID}"));
        }
    }
}
