using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriverController : ControllerBase
{
    IBLDriver driver;

    public DriverController(IBL manager) => driver = manager.Driver;

    [HttpGet("GetDriver/{name}/{password}/{licensePlate}")]
    public IActionResult GetDriver(string name, string password,string licensePlate)
    {
        var d = driver.Get(name, password,licensePlate);
        return d != null ? Ok(d) : NotFound("Not found a driver");
    }

    [HttpPost("AddDriver/{licensePlate}")]

    public string AddDriver(BlDriver d,string licensePlate) => driver.Create(d, licensePlate);

}
