using CaseStudy.Exceptions;
using CaseStudy.Model;
using CaseStudy.Util;
using System.Data.SqlClient;

namespace CaseStudy.DAO
{
    public class TransportManagementServiceImp: ITransportManagementService
    {
        readonly string _connectionString;
        public TransportManagementServiceImp()
        {
            _connectionString = DBConnUtil.GetConnString(); 
        }
        public bool CheckUser(string email, string password)
        {
            try
            {

                using SqlConnection sqlConnection = new(_connectionString);
                using SqlCommand cmd = new();
                cmd.CommandText = "select Email,Password from Passengers where Email = @email";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToString(reader["Email"]) == email && Convert.ToString(reader["Password"]) == password)
                    {
                        return true;
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            return false;
        }
        public Passenger GetPassenger(string email)
        {
            Passenger passenger = new();
            try
            {
                using SqlConnection sqlConnection = new(_connectionString);
                using SqlCommand cmd = new();
                cmd.CommandText = "select * from Passengers where Email = @email";
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    passenger.PassengerID = Convert.ToInt32(reader["PassengerID"]);
                    passenger.FirstName = Convert.IsDBNull(reader["FirstName"]) ? null : Convert.ToString(reader["FirstName"]);
                    passenger.Gender = Convert.IsDBNull(reader["Gender"]) ? null : Convert.ToString(reader["Gender"]);
                    passenger.Age = Convert.IsDBNull(reader["Age"]) ? null : Convert.ToInt32(reader["Age"]);
                    passenger.Email = Convert.IsDBNull(reader["Email"]) ? null : Convert.ToString(reader["Email"]);
                    passenger.PhoneNumber = Convert.IsDBNull(reader["PhoneNumber"]) ? null : Convert.ToString(reader["PhoneNumber"]);
                }
            }
            catch(SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            return passenger;
        }
        public bool AddPassenger(string name, string gender, int age, string email, string phoneNumber, string password)
        {
            try
            {
                using SqlConnection sqlConnection = new(_connectionString);
                using SqlCommand cmd = new();
                cmd.CommandText = "Insert into Passengers values (@name,@gender,@age,@email,@phoneNumber,@password)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int addStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return addStatus > 0;
            }
            catch(SqlException sqex)
            {
                Console.WriteLine(sqex.Message);
                return false;
            }
        }
        public bool BookTrip(int tripID, int passengerID, DateTime bookingDate)
        {
            if (tripID <= 0 || passengerID <= 0)
            {
                return false;
            }
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new(); 
            cmd.CommandText = "Insert into Bookings values (@tripID,@passengerID,@bookingDate,'Confirmed')";
            cmd.Parameters.AddWithValue("@tripID",tripID);
            cmd.Parameters.AddWithValue("@passengerID",passengerID);
            cmd.Parameters.AddWithValue("@bookingDate",bookingDate);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int bookTripStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return bookTripStatus > 0;
        }
        public bool AllocateDriver(int tripID, int driverID)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = "update Trips set DriverID = @driverID where TripID = @tripID";
            cmd.Parameters.AddWithValue("@driverID",driverID);
            cmd.Parameters.AddWithValue("@tripID",tripID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return updateStatus > 0;
        }
        public bool DeallocateDriver(int tripID)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = "update Trips set DriverID = 'null' where TripID = @tripID";
            cmd.Parameters.AddWithValue("@tripID",tripID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return updateStatus > 0;
        }
        public bool IsVehiclePresent(int vehicleID)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = "select * from Vehicles where VehicleID = @vehicleID";
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            bool isPresent = reader.HasRows;
            if (!isPresent)
            {
                throw new VehicleNotFoundException($"Could not find any vehicle for vehicle id {vehicleID}",vehicleID);
            }
            else
            {
                return isPresent;
            }
        }
        public bool UpdateVehicle(string fieldName, object? newValue, int vehicleID)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = $"Update Vehicles set {fieldName} = @newValue where VehicleID = @vehicleID";
            cmd.Parameters.AddWithValue("@vehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@newValue", newValue);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int updateStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return updateStatus > 0;
        }

        public List<Trip> GetTrips() {
            List<Trip> trips = new();
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "SELECT * from Trips where TripType = 'Passenger'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Trip trip = new
                        (
                            Convert.ToInt32(reader["TripID"]),
                            Convert.IsDBNull(reader["VehicleID"]) ? null : Convert.ToInt32(reader["VehicleID"]),
                            Convert.IsDBNull(reader["RouteID"]) ? null : Convert.ToInt32(reader["RouteID"]),
                            Convert.ToDateTime(reader["DepartureDate"]),
                            Convert.ToDateTime(reader["ArrivalDate"]),
                            Convert.IsDBNull(reader["TripStatus"]) ? null : Convert.ToString(reader["TripStatus"]),
                            Convert.IsDBNull(reader["TripType"]) ? null : Convert.ToString(reader["TripType"]),
                            Convert.IsDBNull(reader["MaxPassenger"]) ? null : Convert.ToInt32(reader["MaxPassenger"]),
                            Convert.IsDBNull(reader["DriverID"]) ? null : Convert.ToInt32(reader["DriverID"])
                        );
                        trips.Add(trip);
                    }
                }
                sqlConnection.Close();
            }
            return trips;
        }
        public List<Vehicle> GetVehicles() {
            List<Vehicle> vehicles = new();
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "Select * from Vehicles";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehicle vehicle = new
                        (
                            Convert.ToInt32(reader["VehicleID"]),
                            Convert.IsDBNull(reader["Model"]) ? null : Convert.ToString(reader["Model"]),
                            Convert.IsDBNull(reader["Capacity"]) ? null : Convert.ToDouble(reader["Capacity"]),
                            Convert.IsDBNull(reader["Type"]) ? null : Convert.ToString(reader["Type"]),
                            Convert.IsDBNull(reader["VehicleStatus"]) ? null : Convert.ToString(reader["VehicleStatus"])
                        );
                        vehicles.Add(vehicle);
                    }
                }
                sqlConnection.Close();
            }
            return vehicles;
        }
        public void DisplayRoutes()
        {
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "Select * from Routes";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                         Console.WriteLine($"ID: {reader["RouteID"]}, Start: {reader["StartDestination"]}, End: {reader["EndDestination"]}, Distance: {reader["Distance"]}");
                    }
                }
                sqlConnection.Close();
            }
        }
        public List<Vehicle> GetAvailableVehicles() {
            List<Vehicle> vehicles = new();
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "Select * from Vehicles where VehicleStatus = 'Available'";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Vehicle vehicle = new
                        (
                            Convert.ToInt32(reader["VehicleID"]),
                            Convert.IsDBNull(reader["Model"]) ? null : Convert.ToString(reader["Model"]),
                            Convert.IsDBNull(reader["Capacity"]) ? null : Convert.ToDouble(reader["Capacity"]),
                            Convert.IsDBNull(reader["Type"]) ? null : Convert.ToString(reader["Type"]),
                            Convert.IsDBNull(reader["VehicleStatus"]) ? null : Convert.ToString(reader["VehicleStatus"])
                        );
                        vehicles.Add(vehicle);
                    }
                }
                sqlConnection.Close();
            }
            return vehicles;
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
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
        public bool DeleteVehicle(int VehicleID)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = "Delete from Vehicles where VehicleID =  @VehicleID";
            cmd.Parameters.AddWithValue("@VehicleID", VehicleID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int deleteVehicleStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return deleteVehicleStatus > 0;
        }
        public bool CancelTrip(int tripID)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = "Update Trips set TripStatus = 'Cancelled' where TripID = @tripID";
            cmd.Parameters.AddWithValue("@TripID", tripID);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int tripStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return tripStatus > 0;
        }
        public bool ScheduleTrip(int vehicleID, int routeID, DateTime departureDate, DateTime arrivalDate)
        {
            using SqlConnection sqlConnection = new(_connectionString);
            using SqlCommand cmd = new();
            cmd.CommandText = "Insert into Trips(VehicleID, RouteID, DepartureDate, ArrivalDate) values(@vehicleID, @routeID, @departureDate, @arrivalDate)";
            cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@RouteID", routeID);
            cmd.Parameters.AddWithValue("@DepartureDate", departureDate);
            cmd.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int tripStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return tripStatus > 0;
        }
        public bool CancelBooking(int bookingID)
        {
            try
            {
                using SqlConnection sqlConnection = new(_connectionString);
                using SqlCommand cmd = new();
                cmd.CommandText = "Update Bookings Set BookingStatus = 'Cancelled' Where BookingID = @bookingID";
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int bookingStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return bookingStatus > 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Booking> GetBookingsByTrip(int tripID)
        {
            List<Booking> bookings = new();
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "Select * from Bookings where TripID = @tripID";
                cmd.Parameters.AddWithValue("@tripID", tripID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Booking booking = new
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
            return bookings;
        }

        public List<Booking> GetBookingsByPassenger(int passengerID)
        {
            List<Booking> bookings = new();
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "Select * from Bookings where PassengerID = @passengerID";
                cmd.Parameters.AddWithValue("@passengerID", passengerID);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Booking bookingsByPassenger = new
                    (
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
            if (bookings.Count == 0 || bookings == null)
            {
                throw new BookingNotFoundException($"Could not find any bookings for {passengerID}", passengerID);
            }
            return bookings;
        }
        public List<Driver> GetAvailableDrivers()
        {
            List<Driver> drivers = new();
            using (SqlConnection sqlConnection = new(_connectionString))
            {
                using SqlCommand cmd = new();
                cmd.CommandText = "Select * from Drivers where TripID is null";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Driver driver = new
                    (
                         Convert.ToInt32(reader["DriverID"]),
                         Convert.IsDBNull(reader["TripID"]) ? null : Convert.ToInt32(reader["TripID"]),
                         Convert.ToString(reader["Name"])
                    );
                    drivers.Add(driver);
                }
                sqlConnection.Close();
            }
            return drivers;
        }
    }
}
