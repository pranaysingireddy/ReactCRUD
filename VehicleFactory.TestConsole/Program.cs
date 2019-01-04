using System;
using VehicleFactory.Repo;

namespace VehicleFactory.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleRepo repo = new VehicleRepo();
            var allvehicles = repo.GetAllVehicles();

            foreach (var vehicle in allvehicles)
            {
                Console.WriteLine($"Name:{vehicle.Make}");

            }
            Console.ReadLine();
        }
    }
}



