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
                            VehicleMenu vMenu = new();
                            Console.Clear();
                            vMenu.Menu();
                            break;
                        case 2:
                            BookingsMenu bookingsMenu = new();
                            Console.Clear();
                            bookingsMenu.Menu();
                            break;
                        case 3:
                            Console.Beep();
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
    }
}
