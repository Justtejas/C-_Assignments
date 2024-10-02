using CaseStudy.DAO;
using CaseStudy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ITransportManagementService transport;
            transport = new TransportManagementServiceImp();
            Vehicle vehicle = new Vehicle(1,"Ford",10.00,"Van","On Trip");
            vehicle.ToString();
            Console.WriteLine(transport.AddVehicle(vehicle));
        }
    }
}
