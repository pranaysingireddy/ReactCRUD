using System.Web.Http;
using System.Web.Http.Cors;
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

        public IHttpActionResult Get()
        {
            return Ok(_repo.GetAllVehicles());
        }
    }
}
