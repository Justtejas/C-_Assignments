namespace CaseStudy.Model
{
    public class Vehicle
    {
        public int VehicleID { get; set; } 
        public string? Model {  get; set; }
        public double? Capacity { get; set; }
        public string? Type { get; set; }
        public string? VehicleStatus { get; set; }

        public Vehicle()
        {
            
        }
        public Vehicle(int vehicleID, string? model, double? capacity, string? type, string? vehicleStatus)
        {
            VehicleID = vehicleID;
            Model = model;
            Capacity = capacity;
            Type = type;
            VehicleStatus = vehicleStatus;
        }

        public override string ToString()
        {
            return $"VehicleID: {VehicleID}\tModel: {Model}\tCapacity: {Capacity}\tType: {Type}\tStatus: {VehicleStatus}";
        }
    }
}
