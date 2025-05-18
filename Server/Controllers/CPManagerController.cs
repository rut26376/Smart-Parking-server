using BL.Api;
using BL.Models;
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CPManagerController : ControllerBase
{
 
    IBLCPManager cpmanager;

    public CPManagerController(IBL manager) => cpmanager = manager.CPManager;

    [HttpGet("getAll")]
    public List<string> GetAll() => cpmanager.GetAll();
    [HttpPost("addManagerPass")]
    public void AddManagerPass(string p) => cpmanager.Create(p);

}
