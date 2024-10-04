using CaseStudy.DAO;
using CaseStudy.Model;

namespace CaseStudy.Main.SubMenus
{
    internal class VehicleMenu
    {
        readonly ITransportManagementService _transport = new TransportManagementServiceImp();
        PrettyConsole prettyConsole = new PrettyConsole();
        public VehicleMenu()
        {
            Console.Title = "Vehicle";
        }

        public void Menu()
        {
            int choice;
            do {
                Console.WriteLine("------------------------------ Vehicles ------------------------\n");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Display Vehicles");
                Console.WriteLine("3. Update Vehicle");
                Console.WriteLine("4. Delete Vehicle");
                Console.WriteLine("5. Exit");
                Console.Write("> ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        DisplayVehicles();
                        break;
                    case 4:
                        DeleteVehicle();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Vehicle menu");
                        Console.Clear();
                        break;
                }
            } while (choice != 5);
        }

        private void DisplayVehicles()
        {
            List<Vehicle> vehicles = _transport.GetVehicles();
            prettyConsole.Table(vehicles);
        }
        private Vehicle AddVehicleMenu()
        {
            Vehicle vehicle = new Vehicle();
            Console.WriteLine("Add Model\n");
            Console.Write("> ");
            vehicle.Model = Console.ReadLine();
            Console.WriteLine("Add Capacity\n");
            Console.Write("> ");
            vehicle.Capacity = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Add Type\n");
            Console.Write("> ");
            vehicle.Type = Console.ReadLine();
            Console.WriteLine("Add Vehicle Status\n");
            Console.Write("> ");
            vehicle.VehicleStatus = Console.ReadLine();
            return vehicle;
        }
        private void AddVehicle()
        {
            Vehicle vehicle = AddVehicleMenu();
            bool addVehicleStatus = _transport.AddVehicle(vehicle);
            if (!addVehicleStatus)
            {
                prettyConsole.Print("Error Adding Vehicle",false);
            }
            prettyConsole.Print("Added Vehicle Successfully",true);
        }
        private int DeleteVehicleMenu()
        {
            Console.WriteLine("Enter the Vehicle Id:\n");
            int vehicleID = Convert.ToInt32(Console.ReadLine());
            return vehicleID;
        }

        private void DeleteVehicle()
        {
            int vehicleID = DeleteVehicleMenu();
            bool deleteVehicleStatus = _transport.DeleteVehicle(vehicleID);
            if (!deleteVehicleStatus)
            {
                prettyConsole.Print("Error Deleting Vehicle",false);
            }
            prettyConsole.Print("Deleted Vehicle Successfully", false);
        }
    }
}
