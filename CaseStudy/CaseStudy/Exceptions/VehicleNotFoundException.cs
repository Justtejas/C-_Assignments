namespace CaseStudy.Exceptions
{
    internal class VehicleNotFoundException:ApplicationException
    {
        public int VehicleID { get; }

        public VehicleNotFoundException() { }

        public VehicleNotFoundException(string message)
            : base(message) { }

        public VehicleNotFoundException(string message, Exception inner)
            : base(message, inner) { }

        public VehicleNotFoundException(string message, int vehicleID)
            : this(message)
        {
            VehicleID = vehicleID;
        }
    }
}
