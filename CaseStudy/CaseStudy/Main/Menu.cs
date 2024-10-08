using CaseStudy.DAO;
using CaseStudy.Main.SubMenus;
using CaseStudy.Model;

namespace CaseStudy.Main
{
    internal class Menu
    {
        public Menu()
        {
            Console.Title = "Transport Management System";
        }
        readonly ITransportManagementService _transport = new TransportManagementServiceImp();
        readonly PrettyConsole _prettyConsole = new();
        Passenger passenger = new Passenger();
        public static void MainMenu(Passenger passenger)
        {
            int choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("------------------------------ Transport Management System ------------------------");
                    Console.WriteLine("\n1. Vehicle");
                    Console.WriteLine("\n2. Booking Trips");
                    Console.WriteLine("\n3. Exit");
                    Console.Write("> ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            VehicleMenu vMenu = new();
                            Console.Clear();
                            vMenu.Menu();
                            break;
                        case 2:
                            BookingsMenu bookingsMenu = new();
                            Console.Clear();
                            bookingsMenu.Menu(passenger);
                            break;
                        case 3:
                            Console.WriteLine("Exiting Transport Management System");
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
            } while (choice != 3);
        }
        public void UserMenu()
        {
            try
            {
                Console.WriteLine("Enter Name");
                Console.Write("> ");
                string name = Console.ReadLine();
                if (name == null)
                {
                    Console.WriteLine("Name cannot be null");
                }
                Console.WriteLine("Enter Gender");
                string gender = Console.ReadLine();
                Console.Write("> ");
                if (gender == null)
                {
                    Console.WriteLine("Gender cannot be null");
                }
                Console.WriteLine("Enter Age");
                Console.Write("> ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Phone Number");
                Console.Write("> ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Email");
                Console.Write("> ");
                string email = Console.ReadLine();
                if (email == null)
                {
                    Console.WriteLine("Email cannot be null");
                }
                Console.WriteLine("Enter Password");
                string password = Console.ReadLine();
                if (password == null)
                {
                    Console.WriteLine("Password cannot be null");
                }
                bool status = _transport.AddPassenger(name, gender, age, email, phoneNumber, password);
                if (status)
                {
                    _prettyConsole.Print("Registered User Successfully", "success");
                    passenger = _transport.GetPassenger(email);
                    MainMenu(passenger);
                }
                else
                {
                    _prettyConsole.Print("Error adding", "fail");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Login()
        {
            Console.WriteLine("Enter Email");
            Console.Write("> ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            Console.Write("> ");
            string password = Console.ReadLine();
            bool status = _transport.CheckUser(email, password);
            if (status)
            {
                _prettyConsole.Print("Logged User Successfully", "success");
                passenger = _transport.GetPassenger(email);
                MainMenu(passenger);
            }
            else
            {
                _prettyConsole.Print("Invalid email or password , try again", "fail");
            }
        }

    }
}
