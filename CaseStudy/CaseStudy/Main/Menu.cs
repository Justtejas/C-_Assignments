using CaseStudy.Main.SubMenus;

namespace CaseStudy.Main
{
    internal class Menu
    {
        public Menu()
        {
            Console.Title = "Transport Management System";
        }

        public void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("------------------------------ Transport Management System ------------------------");
                Console.WriteLine("\n1. Vehicle");
                Console.WriteLine("2. Exit");
                Console.Write("> ");
                //Console.WriteLine("4. Schedule Trip");
                //Console.WriteLine("5. Cancel Trip");
                //Console.WriteLine("6. Book Trip");
                //Console.WriteLine("7. Cancel Booking");
                //Console.WriteLine("8. Allocate Driver");
                //Console.WriteLine("9. Deallocate Driver");
                //Console.WriteLine("10. Get Bookings");
                //Console.WriteLine("11. Get Available Drivers");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        VehicleMenu vMenu = new VehicleMenu();
                        Console.Clear();
                        vMenu.Menu();
                        break;
                    case 2:
                        Console.Beep();
                        Console.WriteLine("Exiting Transport Management System");
                        break;
                }
            }while(choice != 2);
        }
    }
}
