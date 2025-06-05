using BL;
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

    [HttpGet("getAll")]
    public async Task<List<BlDriver>> GetAll() =>await driver.GetAllDrivers();



    [HttpGet("GetDriverVehicles/{name}/{password}")]
    public IActionResult GetDriver(string name, string password)
    {
        
        var d = driver.Get(name, password);
        return d.Result != null ? Ok(d.Result) : NotFound("Not found a driver");
    }

    [HttpPost("AddDriver")]

    public string AddDriver(BlDriver d) => driver.Create(d);

}
