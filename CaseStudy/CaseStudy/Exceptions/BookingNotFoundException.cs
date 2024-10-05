namespace CaseStudy.Exceptions
{
    internal class BookingNotFoundException:ApplicationException
    {
        public int BookingID { get; }

        public BookingNotFoundException() { }

        public BookingNotFoundException(string message)
            : base(message) { }

        public BookingNotFoundException(string message, Exception inner)
            : base(message, inner) { }

        public BookingNotFoundException(string message, int bookingID)
            : this(message)
        {
            BookingID = bookingID;
        }
    }
}
