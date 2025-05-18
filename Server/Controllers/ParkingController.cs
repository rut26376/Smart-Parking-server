using BL.Api;
using BL.Models;
using BL.Services;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParkingController : ControllerBase
{
    IBLParking parking;
    public ParkingController(IBL manager) => parking = manager.Parking;

    [HttpGet("GetParking/{level}")]
    public IActionResult Get(string level)
    {
        var p = parking.Get(level);
        return p == null ? NotFound("Not found a available parking") : Ok(p);
    }

    [HttpPut("Update")]

    public void Update(BlParking p)
    {
        parking.Update(p);
    }

    [HttpGet("GetAllParkingPlaces/{level}")]
    public List<BlCarParkings> GetAll(string level) => parking.GetAll(level);
}
