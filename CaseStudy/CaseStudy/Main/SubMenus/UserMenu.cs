//using CaseStudy.DAO;
//namespace CaseStudy.Main.SubMenus
//{
//    internal class UserMenu
//    {
//        public UserMenu() { 
//            Console.Title = "User Menu";
//        }

//        readonly ITransportManagementService _policyService = new TransportManagementServiceImp();
//        readonly PrettyConsole _prettyConsole = new();
//        public void Menu()
//        {
//            int choice = 0;
//            do
//            {
//                try
//                {
//                    Console.WriteLine("1. Register");
//                    Console.WriteLine("2. Login");
//                    Console.WriteLine("3. Exit");
//                    Console.Write("> ");
//                    choice = Convert.ToInt32(Console.ReadLine());
//                    switch (choice)
//                    {
//                        case 1:
//                            RegisterMenu();
//                            break;
//                        case 2:
//                            LoginMenu();
//                            break;
//                        case 3:
//                            Console.WriteLine("Exiting");
//                            break;
//                        default:
//                            Console.WriteLine("Invalid Option");
//                            break;
//                    }
//                } 
//                catch(Exception ex)
//                {
//                    Console.WriteLine(ex.Message);
//                }
//            } while (choice != 3);
//        }
//        public void RegisterMenu()
//        {
//            try
//            {
//                User user = new();
//                Console.WriteLine("Enter Email");
//                Console.Write("> ");
//                user.UserName = Console.ReadLine();
//                Console.WriteLine("\nEnter Password");
//                Console.Write("> ");
//                user.Password = Console.ReadLine();
//                Register(user);
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//        }

//        public void Register(User user)
//        {
//            bool status = _policyService.RegisterUser(user);
//            if (status)
//            {
//                _prettyConsole.Print("Registered Successfull", true);
//                policyMenu.Menu();
//            }
//            else
//            {
//                _prettyConsole.Print("Could not register user", false);
//            }
//        }
//        public void LoginMenu()
//        {
//            try
//            {
//                Console.WriteLine("Enter User Name");
//                Console.Write("> ");
//                string username = Console.ReadLine();
//                Console.WriteLine("\nEnter Password");
//                string password = Console.ReadLine();
//                Console.Write("> ");
//                LoginUser(username, password);
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//       }
//        public bool LoginUser(string user,string password)
//        {
//            bool status = _policyService.Login(user,password);
//            if (status)
//            {
//                _prettyConsole.Print("Logged Successfull", true);
//                policyMenu.Menu();
//            }
//            else
//            {
//                _prettyConsole.Print("Could not login", false);
//            }
//            return status;
//        }
//    }
//}
