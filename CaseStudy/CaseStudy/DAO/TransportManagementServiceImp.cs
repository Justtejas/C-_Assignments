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
                    cmd.CommandText = "Update Trips set VehicleStatus = 'Cancelled' where TripID = @tripID";
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
    }
}
