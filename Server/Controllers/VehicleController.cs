using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        IBLVehicle vehicle;
        public VehicleController(IBL manager)
        {
            vehicle = manager.Vehicle;
        }

        [HttpGet("Get/{lisencePlate}")]
        public string Get(string lisencePlate) => vehicle.GetDriverCode(lisencePlate);

        [HttpPost]
        public void Create(BlVehicle v) => vehicle.Create(v);
    }
}
