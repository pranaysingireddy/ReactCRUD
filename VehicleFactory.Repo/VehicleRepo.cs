using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using VehicleFactory.Domain;

namespace VehicleFactory.Repo
{
    public class VehicleRepo
    {
        private readonly string _filePath = $"{HttpContext.Current.Server.MapPath("~")}/Vehicles.Json";
        public List<string> Errors = new List<string>();
		
		//Hello World

        public List<Vehicle> GetAllVehicles()
        {
            var fileData = File.ReadAllText(_filePath);

            var result = JsonConvert.DeserializeObject<List<Vehicle>>(fileData);

            return result;
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return GetAllVehicles().FirstOrDefault(a => a.VehicleId == vehicleId);
        }

        public bool SaveVehicle(Vehicle vehicle)
        {
            var jsonStr = JObject.FromObject(vehicle);
            try
            {
                var allvehicles = GetAllVehicles();
                if (!allvehicles.Where(a => a.VehicleId == vehicle.VehicleId).Any())
                {
                    allvehicles.Add(vehicle);
                    string newJsonResult = JsonConvert.SerializeObject(allvehicles, Formatting.Indented);
                    File.WriteAllText(_filePath, newJsonResult);
                    return true;
                }
                else
                {
                    Errors.Add("Another vehicle exists with the same Id");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Errors.Add("Error Occured");
                return false;
            }

        }


        public bool UpdateVehicle(Vehicle vehicle)
        {
            var jsonStr = JObject.FromObject(vehicle);

            try
            {
                var allvehicles = GetAllVehicles();
                var vehicleToUpdate = allvehicles.FirstOrDefault(a => a.VehicleId == vehicle.VehicleId);
                if (vehicleToUpdate != null)
                {
                    allvehicles[allvehicles.FindIndex(a => a.VehicleId == vehicle.VehicleId)] = vehicle;

                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(allvehicles, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(_filePath, newJsonResult);
                    return true;
                }
                else
                {
                    Errors.Add("Vehicle is not found to update");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Errors.Add("Error Occured");
                return false;
            }

        }


        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                var allvehicles = GetAllVehicles();
                var vehicleToDelete = allvehicles.FirstOrDefault(a => a.VehicleId == vehicleId);
                if (vehicleToDelete != null)
                {
                    allvehicles.Remove(vehicleToDelete);
                    string newJsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(allvehicles, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(_filePath, newJsonResult);
                    return true;
                }
                else
                {
                    Errors.Add("Vehicle is not found to delete");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Errors.Add("Error Occured");
                return false;
            }

        }
    }
}
