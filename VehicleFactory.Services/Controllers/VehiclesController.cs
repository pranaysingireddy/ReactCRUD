using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using VehicleFactory.Domain;
using VehicleFactory.Repo;

namespace VehicleFactory.Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehiclesController : ApiController
    {
        private VehicleRepo _repo;

        public VehiclesController()
        {
            _repo = new VehicleRepo();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_repo.GetAllVehicles());
        }

        [HttpGet]
        [Route("api/vehicles/{vehicleId}")]
        public IHttpActionResult Get(int vehicleId)
        {
            return Ok(_repo.GetVehicleById(vehicleId));
        }

        [HttpPost]
        public IHttpActionResult Save([FromBody] Vehicle vehicle)
        {
            var result = _repo.SaveVehicle(vehicle);
            return result ? Ok(_repo.GetAllVehicles()) : SendBadRequest();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Vehicle vehicle)
        {
            var result = _repo.UpdateVehicle(vehicle);
            return result ? Ok(_repo.GetAllVehicles()) : SendBadRequest();
        }

        [HttpDelete]
        [Route("api/vehicles/{vehicleId}")]
        public IHttpActionResult Delete(int vehicleId)
        {
            var result = _repo.DeleteVehicle(vehicleId);
            return result ? Ok(_repo.GetAllVehicles()) : SendBadRequest();
        }

        private IHttpActionResult SendBadRequest()
        {
            foreach (var error in _repo.Errors.Distinct())
            {
                ModelState.AddModelError("Errors", error);
            }
            return BadRequest(ModelState);
        }
    }
}