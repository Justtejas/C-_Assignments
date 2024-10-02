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
        
        //public bool UpdateVehicle(Vehicle vehicle)
        //{
        //    cmd.CommandText = "Update Vehicle Set @"
        //}
    }
}
