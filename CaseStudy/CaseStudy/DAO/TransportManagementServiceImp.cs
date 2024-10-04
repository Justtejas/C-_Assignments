using CaseStudy.Model;
using CaseStudy.Util;
using System.Data.SqlClient;

namespace CaseStudy.DAO
{
    public class TransportManagementServiceImp: ITransportManagementService
    {
        private string _connectionString;
        public TransportManagementServiceImp()
        {
            _connectionString = DBConnUtil.GetConnString(); 
        }

        public List<Vehicle> GetVehicles() {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from Vehicles";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle
                        (
                            Convert.ToInt32(reader["VehicleID"]),
                            Convert.IsDBNull(reader["Model"]) ? null : Convert.ToString(reader["Model"]),
                            Convert.IsDBNull(reader["Capacity"]) ? null : Convert.ToDouble(reader["Capacity"]),
                            Convert.IsDBNull(reader["Type"]) ? null : Convert.ToString(reader["Type"]),
                            Convert.IsDBNull(reader["VehicleStatus"]) ? null : Convert.ToString(reader["VehicleStatus"])
                        );
                        vehicles.Add(vehicle);
                    }
                    sqlConnection.Close();
                }
            }
            return vehicles;
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Insert Into Vehicles values(@Model,@Capacity,@Type,@VehicleStatus)";
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                    cmd.Parameters.AddWithValue("@Type", vehicle.Type);
                    cmd.Parameters.AddWithValue("@VehicleStatus", vehicle.VehicleStatus);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int addVehicleStatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return addVehicleStatus > 0;
                }
            }
        }
        public bool DeleteVehicle(int VehicleID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Delete from Vehicles where VehicleID =  @VehicleID";
                    cmd.Parameters.AddWithValue("@VehicleID",VehicleID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int deleteVehicleStatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return deleteVehicleStatus > 0;
                }
            }
        }
        public bool CancelTrip(int tripID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Update Trips set TripStatus = 'Cancelled' where TripID = @tripID";
                    cmd.Parameters.AddWithValue("@TripID",tripID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int tripStatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return tripStatus > 0;
                }
            }
        }
        public bool ScheduleTrip(int vehicleID, int routeID, string departureDate, string arrivalDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Insert into Trips(VehicleID, RouteID, DepartureDate, ArrivalDate) values(@vehicleID, @routeID, @departureDate, @arrivalDate)";
                    cmd.Parameters.AddWithValue("@VehicleID",vehicleID);
                    cmd.Parameters.AddWithValue("@RouteID",routeID);
                    cmd.Parameters.AddWithValue("@DepartureDate",DateTime.Parse(departureDate));
                    cmd.Parameters.AddWithValue("@ArrivalDate", DateTime.Parse(arrivalDate));
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int tripStatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return tripStatus > 0;
                }
            }
        }
        public bool CancelBooking(int bookingID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Update Bookings Set BookingStatus = 'Cancelled' Where BookingID = @bookingID";
                    cmd.Parameters.AddWithValue("@BookingID",bookingID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int bookingStatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return bookingStatus > 0;
                }
            }
        }

        public List<Booking> GetBookingsByTrip(int tripID)
        {
            List<Booking> bookings = new List<Booking>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from Bookings where TripID = @tripID";
                    cmd.Parameters.AddWithValue("@tripID",tripID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Booking booking = new Booking
                        (
                             Convert.ToInt32(reader["BookingID"]),
                             Convert.ToInt32(reader["TripID"]),
                             Convert.ToInt32(reader["PassengerID"]),
                             Convert.ToDateTime(reader["BookingDate"]),
                             Convert.ToString(reader["BookingsStatus"])
                        );
                        bookings.Add(booking);
                    }
                    sqlConnection.Close();
                }
            }
            return bookings;
        }

        public List<Booking> GetBookingsByPassenger(int passengerID)
        {
            List<Booking> bookings = new List<Booking>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from Bookings where PassengerID = @passengerID";
                    cmd.Parameters.AddWithValue("@passengerID",passengerID);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Booking bookingsByPassenger = new Booking(
                            Convert.ToInt32(reader["BookingID"]),
                             Convert.IsDBNull(reader["TripID"]) ? null : Convert.ToInt32(reader["TripID"]),
                             Convert.IsDBNull(reader["PassengerID"]) ? null : Convert.ToInt32(reader["PassengerID"]),
                             Convert.IsDBNull(reader["BookingDate"]) ? null : Convert.ToDateTime(reader["BookingDate"]),
                             Convert.IsDBNull(reader["BookingsStatus"]) ? null : Convert.ToString(reader["BookingsStatus"])
                        );
                        bookings.Add(bookingsByPassenger);
                    }
                    sqlConnection.Close();
                }
            }
            return bookings;
        }
        public List<Driver> GetAvailableDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select * from Drivers where TripID is null";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Driver driver = new Driver
                        (
                             Convert.ToInt32(reader["DriverID"]),
                             Convert.IsDBNull(reader["TripID"]) ? null : Convert.ToInt32(reader["TripID"]),
                             Convert.ToString(reader["Name"])
                        );
                        drivers.Add(driver);
                    }
                    sqlConnection.Close();
                }
            }
            return drivers;
        }
    }
}
