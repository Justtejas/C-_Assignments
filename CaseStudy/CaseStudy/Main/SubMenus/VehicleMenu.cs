using CaseStudy.DAO;
using CaseStudy.Exceptions;
using CaseStudy.Model;

namespace CaseStudy.Main.SubMenus
{
    internal class VehicleMenu
    {
        readonly ITransportManagementService _transport = new TransportManagementServiceImp();
        readonly PrettyConsole _prettyConsole = new();
        public VehicleMenu()
        {
            Console.Title = "Vehicle";
        }

        public void Menu()
        {
            Console.Clear();
            int choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n------------------------------ Vehicles ------------------------\n");
                    Console.WriteLine("1. Add Vehicle");
                    Console.WriteLine("2. Display Vehicles");
                    Console.WriteLine("3. Update Vehicle");
                    Console.WriteLine("4. Delete Vehicle");
                    Console.WriteLine("5. Display Available Drivers");
                    Console.WriteLine("6. Exit");
                    Console.Write("> ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddVehicleMenu();
                            break;
                        case 2:
                            DisplayVehicles();
                            break;
                        case 3:
                            UpdateVehicleMenu();
                            break;
                        case 4:
                            DeleteVehicleMenu();
                            break;
                        case 5:
                            DisplayDrivers();
                            break;
                        case 6:
                            Console.WriteLine("Vehicle menu exited.");
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid Option! Try again");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (choice != 6);
        }

        private void DisplayDrivers()
        {
            _prettyConsole.Table(_transport.GetAvailableDrivers());
        }
        private void DisplayVehicles()
        {
            List<Vehicle> vehicles = _transport.GetVehicles();
            _prettyConsole.Table(vehicles);
        }
        private void AddVehicleMenu()
        {
            try
            {
                Console.WriteLine();
                Vehicle vehicle = new Vehicle();
                Console.WriteLine("\nAdd Model\n");
                Console.Write("> ");
                vehicle.Model = Console.ReadLine();
                Console.WriteLine("\nAdd Capacity\n");
                Console.Write("> ");
                vehicle.Capacity = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\nAdd Type\n");
                Console.Write("> ");
                vehicle.Type = Console.ReadLine();
                Console.WriteLine("\nAdd Vehicle Status\n");
                Console.Write("> ");
                vehicle.VehicleStatus = Console.ReadLine();
                AddVehicle(vehicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void AddVehicle(Vehicle vehicle)
        {
            bool addVehicleStatus = _transport.AddVehicle(vehicle);
            if (!addVehicleStatus)
            {
                _prettyConsole.Print("Error Adding Vehicle\n", "fail");
            }
            _prettyConsole.Print("Added Vehicle Successfully\n", "success");
        }

        private void UpdateVehicleMenu()
        {
            DisplayVehicles();
            int choice;
            string fieldToUpdate = string.Empty;
            object? newValue = null;
            Console.WriteLine("Enter the Vehicle ID of the Vehicle");
            Console.Write("> ");
            int vehicleID = Convert.ToInt32(Console.ReadLine());
            bool isPresent = _transport.IsVehiclePresent(vehicleID);
            try
            {
                if (isPresent)
                {
                    do
                    {
                        Console.WriteLine("Select the field to update");
                        Console.WriteLine("1. Model");
                        Console.WriteLine("2. Capacity");
                        Console.WriteLine("3. Type");
                        Console.WriteLine("4. Vehicle Status");
                        Console.WriteLine("5. Exit");
                        Console.Write("> ");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                fieldToUpdate = "Model";
                                Console.WriteLine("Enter new value of Model");
                                Console.Write("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 2:
                                fieldToUpdate = "Capacity";
                                Console.WriteLine("Enter new value of Capacity");
                                Console.Write("> ");
                                newValue = Convert.ToDouble(Console.ReadLine());
                                break;
                            case 3:
                                fieldToUpdate = "Type";
                                Console.WriteLine("Enter new value of Type");
                                Console.Write("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 4:
                                fieldToUpdate = "VehicleStatus";
                                Console.WriteLine("Enter new value of Vehicle Status");
                                Console.Write("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 5:
                                Console.WriteLine("Exiting Update Vehicle Menu");
                                break;
                        }
                        UpdateVehicle(fieldToUpdate, newValue, vehicleID);
                    } while (choice != 5);
                }
                else
                {
                    throw new VehicleNotFoundException($"The VehicleID {vehicleID} could not be found.\n", vehicleID);
                }
            }
            catch (VehicleNotFoundException vnfe)
            {
                Console.WriteLine(vnfe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdateVehicle(string fieldName, object? newValue, int vehicleID)
        {
            bool updateStatus = _transport.UpdateVehicle(fieldName, newValue, vehicleID);
            if (updateStatus)
            {
                _prettyConsole.Print($"Successfully updated {fieldName}\n", "success");
            }
            else
            {
                _prettyConsole.Print($"Error updating {fieldName}\n", "fail");
            }
        }
        private void DeleteVehicleMenu()
        {
            DisplayVehicles();
            Console.WriteLine("\nEnter the Vehicle Id:\n");
            Console.Write("> ");
            int vehicleID = Convert.ToInt32(Console.ReadLine());
            try
            {
                bool isPresent = _transport.IsVehiclePresent(vehicleID);
                if (isPresent)
                {
                    DeleteVehicle(vehicleID);
                }
                else
                {
                    throw new VehicleNotFoundException($"The VehicleID {vehicleID} could not be found.\n", vehicleID);
                }
            }
            catch (VehicleNotFoundException vnfe)
            {
                Console.WriteLine(vnfe.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteVehicle(int vehicleID)
        {
            bool deleteVehicleStatus = _transport.DeleteVehicle(vehicleID);
            if (!deleteVehicleStatus)
            {
                _prettyConsole.Print("Error Deleting Vehicle\n", "fail");
            }
            _prettyConsole.Print("Deleted Vehicle Successfully\n", "success");
        }
    }
}
