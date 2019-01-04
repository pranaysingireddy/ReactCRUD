using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using VehicleFactory.Domain;

namespace VehicleFactory.Repo
{
    public class VehicleRepo
    {
        //  private string jsonFile = @"C:\Users\prana\Source\repos\VehicleFactory\VehicleFactory.Domain\Vehicles.json";

        private readonly string _jsonstr = File.ReadAllText(@"C:\Users\prana\Source\repos\VehicleFactory\VehicleFactory.Domain\Vehicles.json");

        public List<Vehicle> GetAllVehicles()
        {
            var listtt = JsonConvert.DeserializeObject<List<Vehicle>>(_jsonstr);

            return listtt;


        }
    }
}
