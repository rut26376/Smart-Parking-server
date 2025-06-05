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
    public List<BlCPManager> GetAll() => cpmanager.GetAll();

    [HttpGet("isManager/{userName}/{password}")]
    public bool IsManager(string userName , string password) => cpmanager.IsManager(new BlCPManager() { Password=password,UserName=userName});

    [HttpPost("addManagerPass")]
    public void AddManagerPass(string p) => cpmanager.Create(p);

}
