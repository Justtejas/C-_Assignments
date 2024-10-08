using CaseStudy.DAO;
using NUnit.Framework;
using NUnit.Framework.Internal.Builders;
namespace CaseStudy.Test
{
    public class Test
    {
        [Test]
        public void Test_To_Book_Trip()
        {
            ITransportManagementService testTM = new TransportManagementServiceImp();
                int tripID = 2;
                int passengerID = 5;
                DateTime bookingDate = Convert.ToDateTime("2024-12-23");

                bool bookTripStatus = testTM.BookTrip(tripID, passengerID,bookingDate);
                Assert.That(bookTripStatus, Is.True, "Trip Booked Successfully");

        }
        //    //public void getBookingsByPassenger_Throws_Exception()
        //    //{

        //    //     TMTest = new TransportManagementServiceImpl();
        //    //    int passengerID = 13;

        //    //    var ex = Assert.Throws<BookingNotFoundException>(() => TMTest.getBookingsByPassenger(passengerID));
        //    //    Assert.That(ex.Message, Is.EqualTo($"No bookings found for Passenger ID: {passengerID}"));
        //    //}
    }
}
