using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutineController : ControllerBase
{
    IBLRoutine routine;

    public RoutineController(IBL manager) => routine = manager.Routine;

    [HttpGet("GetPrice/{licensePlate}")]
    public IActionResult Get(string licensePlate)
    {

        return Ok(routine.GetSum(licensePlate));
    }

    [HttpGet("FindMyCar/{licensePlate}")]
    public IActionResult Find(string licensePlate)
    {
        return Ok(routine.Find(licensePlate));
    }

    [HttpPost("AddRoutine/{driverCode}")]
    public void Create(BlRoutine r,string driverCode) => routine.Create(r, driverCode);

    [HttpGet("GetCarExists/{licensePlate}")]
    public bool carExists(string licensePlate) => routine.checkIfDoesntExist(licensePlate);

}
